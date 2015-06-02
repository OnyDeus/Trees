using UnityEngine;
using System.Collections;

public class AxeLoggerScript : MonoBehaviour {

	public float health = 10f;
	public float moveSpeed = 1f;
	
	private GameObject motherTreeTarget;

	// Use this for initialization
	void Start () {
		motherTreeTarget = GameObject.Find("MotherTree") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (motherTreeTarget.transform.position);
		
		transform.position += transform.forward * moveSpeed * Time.deltaTime;
	
	}
	
	public void TakeDamage(float damage)
	{
		health -= damage;
		
		if (health < 0)
		{
			Destroy(this.gameObject);
		}
	}
	
}
