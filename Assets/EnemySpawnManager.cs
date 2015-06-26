using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class EnemySpawnManager : MonoBehaviour {

	public int gracePeriod;
	private bool isGrace = true;

	private GameObject spawner; 	

	private Text _timeNtillAxe;
	private Text _timeNtillChainsaw;

	public float timeNtillAxeBuild;
	public float axeBuildShorter;
	private float axeBuildTimer;
	
	


	void Start () {
		spawner = GameObject.Find("LoggerSpawner") as GameObject;
	
		//textboxes
		_timeNtillAxe = GameObject.Find("TimeNtillAxeValue").GetComponent<Text>() as Text;
		_timeNtillChainsaw = GameObject.Find("TimeNtillChainsawValue").GetComponent<Text>() as Text;
		
		
		axeBuildTimer = gracePeriod;
	}
	
	// Update is called once per frame
	void Update () {
	
		_timeNtillAxe.text = axeBuildTimer.ToString("F2");
		//_timeNtillChainsaw.text = buildMode.ToString("F2");
	

			
		if (axeBuildTimer <= 0)
		{
			SpawnLogger();
		}	
			
		axeBuildTimer -= Time.deltaTime;
	}
		
		
		// Update is called once per frame
	void SpawnLogger() {
			
			
		Instantiate(Resources.Load("Prefabs/AxeLogger"), spawner.transform.position, Quaternion.identity);
		
		if (isGrace)
		{
			axeBuildTimer = timeNtillAxeBuild;
			isGrace = false;
		} 
		else
		{		
			axeBuildTimer = timeNtillAxeBuild;
			timeNtillAxeBuild = timeNtillAxeBuild - axeBuildShorter;
		}
	}
}
