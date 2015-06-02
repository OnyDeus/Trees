using UnityEngine;
using System.Collections;

public class NutPelterScript : MonoBehaviour {

	#region Object settings
		public float attackPower = 4f;
		public float attackRange = 1.5f;
		public float attackDelay = 1f;
	#endregion
	
	#region functional variables
		private float timeSinceLastShot;
		private int currentNut = 1;
		private GameObject nut1;
		private GameObject nut2;
	#endregion
	
	
	void Start () {
		nut1 = Instantiate(Resources.Load("Prefabs/NutBullet"),this.transform.position, Quaternion.identity) as GameObject;
		nut2 = Instantiate(Resources.Load("Prefabs/NutBullet"),this.transform.position, Quaternion.identity) as GameObject;
	}
	
	#region Update
	void Update () {
		
		if (timeSinceLastShot > attackDelay)
		{
		    GameObject enemy = FindClosestEnemy();
			
			if (enemy !=null && Vector3.Distance(this.transform.position, enemy.transform.position) <= attackRange)
			{	
				ShootAtEnemy(enemy);
			}
		}
		timeSinceLastShot += Time.deltaTime;
	}
	#endregion
	
	

	public void ShootAtEnemy(GameObject _enemy)
	{
		if( currentNut == 1)
			nut1.GetComponent<NutScript>().Shoot(_enemy);
		else if ( currentNut == 2)
			nut2.GetComponent<NutScript>().Shoot(_enemy);	
			
			
			
		timeSinceLastShot = 0f;	
	}



	#region FindClosesetEnemy 
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
	}
	#endregion 


}//end class
