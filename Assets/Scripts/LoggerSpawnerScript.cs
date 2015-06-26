using UnityEngine;
using System.Collections;

public class LoggerSpawnerScript : MonoBehaviour {

	public int totalLoggers = 3;
	public float spawnSpeed = 8;
	public float timeToBuild = 10;

	// Use this for initialization
	void Start () {
		Invoke("SpawnLogger" , timeToBuild);
		
		
	}
	
	void Update ()
	{
		if (timeToBuild >= 0)
		{
			Debug.Log("Incoming enemies");
		}
	
	}
	
	
	// Update is called once per frame
	void SpawnLogger() {
		
		if (totalLoggers >= 0){
	
			Instantiate(Resources.Load("Prefabs/AxeLogger"), transform.position, Quaternion.identity);
			
			Invoke("SpawnLogger" , spawnSpeed);
			totalLoggers --;
		}
	}
}
