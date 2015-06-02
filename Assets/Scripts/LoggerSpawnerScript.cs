using UnityEngine;
using System.Collections;

public class LoggerSpawnerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		SpawnLogger();
		
		
	}
	
	// Update is called once per frame
	void SpawnLogger() {
	
		Instantiate(Resources.Load("Prefabs/AxeLogger"), transform.position, Quaternion.identity);
		
		Invoke("SpawnLogger" , 3f);
	
	}
}
