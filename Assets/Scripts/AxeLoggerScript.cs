using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AxeLoggerScript : MonoBehaviour {

	public float health = 10f;
	public float moveSpeed = 1f;
	public float visionRange = 5;
	public float attackRange = 1.2f;
	public float attackDamage = 1f;
	public float attackSpeed = 2f;
	public float waterValue = 1f;
	private float attackDelayTimer;
	
	private AIPath aI;
	private Transform navAnchor;
	public float navRepathRate = 1f;
	private float navRepathTimer = 0f;
	private Vector3 lastPos;

	private GameObject motherTree;
	public GameObject myTarget;
	
	
	private Animator anim;


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
		
		anim = GetComponentInChildren<Animator>();
		
		GameObject navAnchorObj = Instantiate(Resources.Load("Prefabs/NavAnchor"),this.transform.position,Quaternion.identity) as GameObject;
		navAnchor = navAnchorObj.transform;
		
		aI.target = navAnchor;
		
		motherTree = GameObject.Find("MotherTree");
		
		
		lastPos = this.transform.position;
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
			navAnchor.transform.LookAt(this.transform.position);
			navAnchor.transform.Translate(Vector3.forward * .5f);
			
		}
		

		
		// 
		if(myTarget)
		{
			if (Vector3.Distance(this.transform.position, myTarget.transform.position) <= attackRange
			   		&& attackDelayTimer > attackSpeed)
			{


				

				attackDelayTimer = 0;
				
				anim.ResetTrigger("IsAttacking");
				anim.SetTrigger("IsAttacking");
				
				//anim.Play(Attack, layer, 0.0f); //??????????????????
			} else
			{
			//	anim.Set("IsAttacking", false);
			}
		} 
		if (myTarget == null) 
		{
			Debug.LogError(this.gameObject.name + " has error, no Target"); 
		}
		
		
		//Test locations for move animation 
		if(lastPos == null || lastPos != this.transform.position )
		{
			anim.SetBool("IsMoving", true);
			lastPos = this.transform.position;
		} else
		{
			anim.SetBool("IsMoving", false);
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
	
	public void DoDamage(){
		Vector3 dirToTarget = myTarget.transform.position - this.transform.position;
		myTarget.GetComponent<Health>().TakeDamage(attackDamage); 
		Instantiate (Resources.Load("Particles/SplinterParticle"),myTarget.transform.position,Quaternion.LookRotation(new Vector3(dirToTarget.x ,0,dirToTarget.z)));
		
	}
	
	public void TakeDamage(float damage)
	{
		health -= damage;
		
		if (health < 0)
		{
			Destroy(this.gameObject);
			GameObject.Find("GameManager").GetComponent<PlayerController>().currentWater += 1;
		}
	}
	
	#region Find Closeset Untargeted Enemy 		//TODO: Check If queried Tree is closer to MoTree than this logger
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
