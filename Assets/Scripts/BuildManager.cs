using UnityEngine;
using System.Collections;

public class BuildManager : MonoBehaviour {

	GameObject _motherTreeSeedShooter;
	Transform _playerObjects;
	Transform _grasses;

	private GameObject _node; 
	private Vector3 _nodePos;

	// Use this for initialization
	void Start () {
		_motherTreeSeedShooter = GameObject.Find("MotherTreeSeedShooter");
		_playerObjects = GameObject.Find("PlayerObjects").transform;
		_grasses = GameObject.Find("Grasses").transform;

	}

	public void NodeInfo(GameObject _nodeObject)
	{
		_node = _nodeObject;
		_nodePos = _node.transform.position;
	}


	public void SpawnSeedProjectile() 

	{	
		//MotherTree look to hit   HONESTLY TRY TO WEEN THIS AWAY TOO
		_motherTreeSeedShooter.transform.LookAt(_nodePos);

		//Instantiate Seed Projectile from mother tree 
		//seed will move itself to target
		GameObject seedProjectileClone = Instantiate (Resources.Load ("Prefabs/Seed Projectile"), 
		                                              _motherTreeSeedShooter.transform.position, _motherTreeSeedShooter.transform.rotation) as GameObject;
		seedProjectileClone.GetComponent<SeedProjectile>().Target(_nodePos);


	}
	public void SpawnGrass()
	{
		//Instantiate Seed Target at hit
		GameObject _grass = Instantiate (Resources.Load ("Prefabs/Grass"),
		             new Vector3(_nodePos.x,.14f,_nodePos.z),Quaternion.LookRotation(Vector3.up)) as GameObject;
		_grass.transform.parent = _grasses;
	}


	public void SpawnBabyTree()
	{
		GameObject _babyTree = Instantiate(Resources.Load("Prefabs/Baby Tree"),
		            new Vector3(_nodePos.x,.14f,_nodePos.z), Quaternion.Euler(0,Random.Range(0,360),0)) as GameObject;
		_babyTree.transform.parent = _playerObjects;
		_node.GetComponent<NodeScript>()._currentObject = _babyTree;
	}


	public void SpawnBranchFist()
	{
		GameObject _branchFist = 	Instantiate (Resources.Load("Prefabs/BranchFistTree"),
		             							new Vector3(_nodePos.x,.14f,_nodePos.z), Quaternion.Euler(0,Random.Range(0,360),0)) as GameObject;
		_branchFist.transform.parent = _playerObjects;
		_node.GetComponent<NodeScript>()._currentObject = _branchFist;
	}


	public void SpawnRootWhip()
	{
		GameObject _rootWhip = 		Instantiate (Resources.Load("Prefabs/RootWhipTree"),
		                                  		new Vector3(_nodePos.x,.14f,_nodePos.z), Quaternion.Euler(0,Random.Range(0,360),0)) as GameObject;
		_node.GetComponent<NodeScript>()._currentObject = _rootWhip;
	}


	public void SpawnNutPelter()
	{
		GameObject _nutPelter = Instantiate (Resources.Load("Prefabs/NutPelterTree"),
		                                    new Vector3(_nodePos.x,.14f,_nodePos.z), Quaternion.Euler(0,Random.Range(0,360),0)) as GameObject;
		_node.GetComponent<NodeScript>()._currentObject = _nutPelter;
	}

	
	public void SpawnRazorLeaf()
	{
		GameObject _razorLeaf = Instantiate (Resources.Load("Prefabs/RazorLeafTree"),
		                                     new Vector3(_nodePos.x,.14f,_nodePos.z), Quaternion.Euler(0,Random.Range(0,360),0)) as GameObject;
		_node.GetComponent<NodeScript>()._currentObject = _razorLeaf;
	}


	public void SpawnToxicPoison()
	{
		GameObject _toxicPoison = Instantiate (Resources.Load("Prefabs/Rock"),
		                                     new Vector3(_nodePos.x,.14f,_nodePos.z), Quaternion.Euler(0,Random.Range(0,360),0)) as GameObject;
		_node.GetComponent<NodeScript>()._currentObject = _toxicPoison;
	}

	public void SpawnBlindingPollen()
	{
		GameObject _blindingPollen = Instantiate (Resources.Load("Prefabs/Rock"),
		                                     new Vector3(_nodePos.x,.14f,_nodePos.z), Quaternion.Euler(0,Random.Range(0,360),0)) as GameObject;
		_node.GetComponent<NodeScript>()._currentObject = _blindingPollen;
	}

	public void SpawnVine()
	{
		GameObject _vine = Instantiate (Resources.Load("Prefabs/Vine"),
		                                          new Vector3(_nodePos.x,.14f,_nodePos.z), Quaternion.Euler(0,Random.Range(0,360),0)) as GameObject;
		_vine.transform.parent = _playerObjects;
		_node.GetComponent<NodeScript>()._currentObject = _vine;
	}

	public void SpawnLog()
	{
		GameObject _log = Instantiate (Resources.Load("Prefabs/Rock"),
		                                          new Vector3(_nodePos.x,.14f,_nodePos.z), Quaternion.Euler(0,Random.Range(0,360),0)) as GameObject;
		_log.transform.parent = _playerObjects;
		_node.GetComponent<NodeScript>()._currentObject = _log;
	}


	public void SpawnRock()
	{
		GameObject _rock = Instantiate (Resources.Load("Prefabs/Rock"),
		                               new Vector3(_nodePos.x,.14f,_nodePos.z), Quaternion.Euler(0,Random.Range(0,360),0)) as GameObject;
		_rock.transform.parent = _playerObjects;
		_node.GetComponent<NodeScript>()._currentObject = _rock;
	}


	public void DestroySelf(GameObject _object) //dont need this ... yet
	{
		Destroy(_object.gameObject);
	}

}
