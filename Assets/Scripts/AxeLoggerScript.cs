using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AxeLoggerScript : MonoBehaviour {

	public float health = 10f;
	public float moveSpeed = 1f;
	public float visionRange = 5;
	public float attackRange = 1.2f;
	public float attackDamage = 1f;
	public float attackSpeed = .5f;
	private float attackDelayTimer;
	
	private AIPath aI;
	private Transform navAnchor;
	public float navRepathRate = 1f;
	private float navRepathTimer = 0f;

	private GameObject motherTree;
	public GameObject myTarget;


	/*public enum FSMState
	{
		None,
		Patrol,
		Chase,
		Attack,
		Dead,
	}
	public FSMState curState;*/


	// Use this for initialization
	void Start () {
		aI = GetComponent<AIPath>();
		
	
		
		GameObject navAnchorObj = Instantiate(Resources.Load("Prefabs/NavAnchor"),this.transform.position,Quaternion.identity) as GameObject;
		navAnchor = navAnchorObj.transform;
		
		aI.target = navAnchor;
		
		motherTree = GameObject.Find("MotherTree");
		Logic(); //gets myTarget
	}
	
	// Update is called once per frame
	void Update () {
	
		attackDelayTimer += Time.deltaTime;
		navRepathTimer += Time.deltaTime;
		

		if (navRepathTimer > navRepathRate)
		{			
			Logic(); //gets myTarget
	
			
			navAnchor.position = myTarget.transform.position; 
			
		}
		

		
		
		if(myTarget)
		{
			if (Vector3.Distance(this.transform.position, myTarget.transform.position) <= attackRange
			   		&& attackDelayTimer > attackSpeed)
			{
				Vector3 dirToTarget = myTarget.transform.position - this.transform.position;

				
				myTarget.GetComponent<Health>().TakeDamage(attackDamage); 
				attackDelayTimer = 0;
				
				
				Instantiate (Resources.Load("Particles/SplinterParticle"),myTarget.transform.position,Quaternion.LookRotation(new Vector3(dirToTarget.x,0,dirToTarget.z)));
			}
		} 
		if (myTarget == null) 
		{
			Debug.Log(this.gameObject.name + " has error, no Target"); 
		}
		
	} //end Update
	
	void Logic()
	{
		GameObject closestTree = FindClosestUntargeted();

		if (closestTree) 
		{	
			closestTree.GetComponent<TargetedBy>().logger = this.gameObject;
			myTarget = closestTree;
		}

		if (!closestTree)
		{
			myTarget = motherTree.gameObject;
		}
		

	}
	
	public void TakeDamage(float damage)
	{
		health -= damage;
		
		if (health < 0)
		{
			Destroy(this.gameObject);
		}
	}
	
	#region Find Closeset Untargeted Enemy 
	GameObject FindClosestUntargeted()
	{
		GameObject [] plrTrees;
		plrTrees = GameObject.FindGameObjectsWithTag("Tree");
		
		List<GameObject> untargetedTrees = new List<GameObject>();
		foreach (GameObject plrTree in plrTrees)
		{
			//Make list of untargeted trees, leave currently targeted tree in for testing
			if (plrTree.GetComponent<TargetedBy>().logger == null || plrTree.GetComponent<TargetedBy>().logger == this.gameObject)
				untargetedTrees.Add(plrTree);
		}
		
		GameObject closest = null;
		float distance = visionRange;
		Vector3 position = this.transform.position;
		//find closest tree from untargetedTrees list
		foreach (GameObject go in untargetedTrees)
		{
			Vector3 diff = go.transform.position - position;
			float curDistance = diff.sqrMagnitude;
			if (curDistance < distance){
				closest = go;
				distance = curDistance; 
			}
		}
		return closest;
	}
	#endregion 
	
/*	#region FindClosesetEnemy 
	GameObject FindClosestTree()
	{
		GameObject [] gos;
		gos = GameObject.FindGameObjectsWithTag("Tree");
		GameObject closest = null;
		float distance = visionRange;
		Vector3 position = this.transform.position;
		foreach (GameObject go in gos){
			Vector3 diff = go.transform.position - position;
			float curDistance = diff.sqrMagnitude;
			if (curDistance < distance){
				closest = go;
				distance = curDistance;
			}
		}
		return closest;
	}
	#endregion */
	
}
