using UnityEngine;
using System.Collections;

public class BranchFistScript : MonoBehaviour {

	public float attackPower = 4f;
	public float attackRange = 1.5f;
	public float attackDelay = 1f;

	private float _delayTimer;

	// Use this for initialization
	void Start () {
	//	DoCheck();


	}
	
	// Update is called once per frame
	void Update () {
	


		if (FindClosestEnemy() !=null)
		{
			if (Vector3.Distance(this.transform.position, FindClosestEnemy().transform.position) <= attackRange 
			    && _delayTimer > attackDelay)
			{
				FindClosestEnemy().GetComponent<AxeLoggerScript>().health -= attackPower;
				Instantiate(Resources.Load("Particles/HitParticle"),FindClosestEnemy().transform.position, Quaternion.identity);
				_delayTimer = 0f;
			}

		}

		_delayTimer += Time.deltaTime;
	}//end update



	//IEnumerator DoCheck(){
	//	for (;;){
	//		FindClosestEnemy();
	//		yield return new WaitForSeconds(.1f);
	//	}





	GameObject FindClosestEnemy()
	{
		GameObject [] gos;
		gos = GameObject.FindGameObjectsWithTag("Enemy");
		GameObject closest = null;
		float distance = Mathf.Infinity;
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
	}//end FindClosestEnemy

}//end class
