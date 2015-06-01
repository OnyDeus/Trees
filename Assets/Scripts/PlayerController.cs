using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class PlayerController: MonoBehaviour{




	private new Camera camera;
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
		buildMode = "Sapling";
	
		_buildModeText = GameObject.Find("BuildModeText").GetComponent<Text>() as Text;

		camera = GameObject.Find("Main Camera").GetComponent<Camera>();
		_motherTreeSeedShooter = GameObject.Find("MotherTreeSeedShooter");

	}




	
	// Update is called once per frame
	void Update () {

		_buildModeText.text = buildMode.ToString();

		Ray ray = camera.ScreenPointToRay(Input.mousePosition);
		RaycastHit mouseHit = new RaycastHit();


	/*	if(Physics.Raycast(ray.origin, ray.direction, out mouseHit, 100f))
		 {
			if(mouseHit.collider.tag == "Node")
			{

				GameObject _targetNode = mouseHit.transform.gameObject as GameObject;
				Vector3 _targetNodePos = _targetNode.transform.position;



				_targetNode.gameObject.GetComponent<NodeScript>().HighlightNode();
				Debug.Log ("Bang"); 

			}

		}
*/
	
		// Left Mouse functions
		if(Physics.Raycast(ray.origin, ray.direction, out mouseHit, 100f) && Input.GetMouseButton(0) && Time.time > _seedNextFire)
		{
	/*		if (mouseHit.collider.tag == "Node")
			{
				GameObject _targetNode = mouseHit.collider.gameObject;

				if (_targetNode.GetComponent<NodeScript>().nodeOccupied == false)
				{
					//Spawn/shoot seed
					this.GetComponent<SpawnManager>().SpawnBabyTree(_targetNode);

					_seedNextFire = Time.time + seedFireRate;
				}
			}
	*/


//---------->			HAY YOU, MOVE MELEE TREE TO BuildManager as BranchFist Tree!


			// Improve Baby Tree to Melee Tree when clicked
	/*		if (mouseHit.collider.tag == "Baby Tree")
			{
				//Make reference to the hit Baby Tree 
				GameObject babyTree = mouseHit.collider.gameObject;



				//Instantiate (Resources.Load("Prefabs/Melee Tree"),babyTree.transform.position, Quaternion.Euler(0,Random.Range(0,360),0));

				// Create root to baby tree and pass root target
				GameObject rootClone = Instantiate (Resources.Load("Prefabs/Root"),
				                                    new Vector3(_motherTreeSeedShooter.transform.position.x,0,_motherTreeSeedShooter.transform.position.z) ,Quaternion.identity) as GameObject;

				rootClone.GetComponent<RootScript>().getVariables(babyTree.gameObject);

				
				//Destroy(babyTree.gameObject); 
				_seedNextFire = Time.time + seedFireRate;

			}
			*/
		
		}// End left mouse functions
	
	}//End Update


	public bool CanBuild(){
		if (Time.time > _seedNextFire)
			return true;
		else 
			return false; 
	}
	

	public void ImproveBabyTree(GameObject babyTree) //really dont think I need this
	{
		Instantiate (Resources.Load("Prefabs/Melee Tree"),babyTree.transform.position, Quaternion.Euler(0,Random.Range(0,360),0));

	}

}// End Class
