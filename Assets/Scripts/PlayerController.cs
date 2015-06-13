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
	private Text _buildModeText;


	public float seedFireRate = .5f;
	private float _seedNextFire = 0f;



	// Use this for initialization
	void Start () {
		buildMode = "Sprout"; 
	
		_buildModeText = GameObject.Find("BuildModeText").GetComponent<Text>() as Text;

	//	camera = GameObject.Find("Main Camera").GetComponent<Camera>();
		_motherTreeSeedShooter = GameObject.Find("MotherTreeSeedShooter");

	}




	
	// Update is called once per frame
	void Update () {

		_buildModeText.text = buildMode.ToString();

	}//End Update


	public bool CanBuild(){
		if (Time.time > _seedNextFire)
			return true;
		else 
			return false; 
	}
	


}// End Class
