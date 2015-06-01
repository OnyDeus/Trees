using UnityEngine;
using System.Collections;

public class SeedProjectile : MonoBehaviour {



	private Vector3 goalTarget;



	public float secondsToReachTarget = 1f;


	private GameObject seedChild;
	public float maxSeedRollSpeed;

	
	private Vector3 rotateCenterPoint;
	private float randomRollSpeed;

	void Start () {
		//Initialise random roll speed and child to perform roll
		randomRollSpeed = Random.Range(-maxSeedRollSpeed, maxSeedRollSpeed);
		seedChild = this.transform.GetChild(0).gameObject;

		Invoke("DestroySelf", 1.5f); 

	}
	

	void Update ()
	{ 
		//Eileron roll child object(mesh) at predetermined speed (hack 'cause I cant roll and rotate around same object)
		seedChild.transform.Rotate(new Vector3(0,0, randomRollSpeed * Time.deltaTime ));

		//Arc around centerpoint
		transform.RotateAround(rotateCenterPoint, transform.right, secondsToReachTarget * 120 * Time.deltaTime); 
	}


	//Function called from PlayerManager to pass target variable when initialised
	public void Target(Vector3 mouseHit)
	{
		goalTarget = mouseHit;

		//find center vector between Mama and target
		Vector3[] vectorGroup = new [] {goalTarget , transform.position};
		rotateCenterPoint = CenterOfVectors(vectorGroup);

	}

	public void DestroySelf()
	{
		Destroy(gameObject);
	}

/*	//Collide with intended target creates baby tree and destroys seed & target 
	void OnCollisionEnter (Collision col)
	{
		if(col.gameObject.tag == "Seed Target")
		{
			Instantiate(Resources.Load("Prefabs/Baby Tree"), col.transform.position, Quaternion.Euler(0,Random.Range(0,360),0));
			Destroy(gameObject);
		//	Destroy(col.gameObject);
		}
	}*/

	//Helpful function to find center between Mama tree and seed target (for rotate around arc shot) 
	public Vector3 CenterOfVectors( Vector3[] vectors )
	{
		Vector3 sum = Vector3.zero;
		if( vectors == null || vectors.Length == 0 )
		{
			return sum;
		}
		
		foreach( Vector3 vec in vectors )
		{
			sum += vec;
		}
		return sum/vectors.Length;
	}
}
