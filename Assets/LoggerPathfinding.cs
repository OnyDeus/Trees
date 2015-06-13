using UnityEngine;
using System.Collections;
using Pathfinding;

public class LoggerPathfinding : MonoBehaviour {
	public Vector3 targetPosition;
	public GameObject targetObject;
	
	private Seeker seeker;
	private CharacterController controller;
	
	public Path path;
	
	public float speed = 200;
	public float rotateSpeed = 6;
	
	public float nextWaypoitDistance = 3;
	
	private int currentWaypoint = 0;
	
	public float newPathRate = 1f;
	private float newPathTimer = 0;
	
	
	void Start () {
		seeker = GetComponent<Seeker>();
		controller = GetComponent<CharacterController>();
		targetObject = GameObject.Find("TargetObject");  
	
		GetNewPath();
	}
	
	
	public void GetNewPath()
	{
		if (targetObject)
		{
			seeker.StartPath (transform.position, targetObject.transform.position, OnPathComplete);
		}
	}
	
	
	
	public void FixedUpdate () {
	//	seeker.StartPath (transform.position, targetObject.position, OnPathComplete);
		
	
		//no path
		if(path == null) {
			return;
		}
		
		//end of path function
		if(currentWaypoint >= path.vectorPath.Count) {
			GetNewPath();
		}
		
		//Direction to the next waypoint
		Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
		dir *= speed * Time.fixedDeltaTime;
		
		//Move this
		controller.SimpleMove (dir);
		
		
		
		//Look rotation
		/*Linear speed rotation*/
		transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(new Vector3(dir.x, 0, dir.z)), rotateSpeed * Time.fixedDeltaTime);
		
		/*Absolute rotation*/
	//	this.transform.LookAt(new Vector3(path.vectorPath[currentWaypoint].x, this.transform.position.y ,path.vectorPath[currentWaypoint].z )); 
			
		//Check if we are close enough to the next waypoint
		// If so, proceed to follow the next waypoint
		if (Vector3.Distance (transform.position,path.vectorPath[currentWaypoint]) < nextWaypoitDistance) {
			currentWaypoint++;
			return;
		}
		
		newPathTimer += Time.fixedDeltaTime;
		if (newPathTimer > newPathRate)
		{
			GetNewPath();
			newPathTimer = 0;
		}
		
	
	
	}//end Update
	
	
	public void OnPathComplete(Path newPath){
		Debug.Log ("Path Completed. Errors made= " + newPath.error);
		if (!newPath.error)
		{
			path = newPath;
			currentWaypoint = 0;
		}
	
	}
}
