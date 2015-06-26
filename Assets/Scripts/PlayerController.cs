using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class PlayerController: MonoBehaviour{




	//private new Camera camera;
	public GameObject saplingTarget;
	public GameObject seedProjectile;
	public GameObject _motherTreeSeedShooter;

	public string buildMode;
	//NodeStatus has string for each type of content
/*	
 *  Sapling
 * 	BranchFist Tree
 * 	RootWhip Tree
 * 	NutPelter Tree
 *  RazorLeaf Tree
 *  ToxicPoison Tree
 *  BlindingPollen Tree
 *  Log
 *  Vine
 *  Rock
*/

	//text
	private Text _buildModeText;
	private Text _waterValue;


	public float seedFireRate = .5f;
	private float _seedNextFire = 0f;

	public float currentWater;


	// Use this for initialization
	void Start () {
		buildMode = "Sprout"; 
	
		//text
		_buildModeText = GameObject.Find("BuildModeText").GetComponent<Text>() as Text;
		_waterValue = GameObject.Find("WaterValue").GetComponent<Text>() as Text;
		
		//	camera = GameObject.Find("Main Camera").GetComponent<Camera>();
		_motherTreeSeedShooter = GameObject.Find("MotherTreeSeedShooter");
		
		//values
		currentWater = 3;

	}




	
	// Update is called once per frame
	void Update () {

		_waterValue.text = currentWater.ToString("f1");
		_buildModeText.text = buildMode.ToString();

	}//End Update


	public bool CanBuild(){
		if (Time.time > _seedNextFire)
			return true;
		else 
			return false; 
	}
	


}// End Class
