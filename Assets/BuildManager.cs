using UnityEngine;
using System.Collections;

public class BuildManager : MonoBehaviour {

	private PlayerController _PlayerController;
	
	GameObject _motherTreeSeedShooter;
	Transform _playerObjects;
	Transform _grasses;
	
	
	void Start () {	
		_PlayerController = this.GetComponent<PlayerController>();
	
		_motherTreeSeedShooter = GameObject.Find("MotherTreeSeedShooter");
		_playerObjects = GameObject.Find("PlayerObjects").transform;
		_grasses = GameObject.Find("Grasses").transform;
	}

	void Update () {	}
	
	public void BuildOn (GameObject tile){
		TileScript tileScript = tile.GetComponent<TileScript>();
		Vector3 tilePos = tile.transform.position;
	
		switch(_PlayerController.buildMode)
		{	
			//Spawn Sapling mode
		case "Sprout":  

			if (tileScript.currentStatus == "Open")
			{

				SpawnSeedProjectile(tilePos);
				StartCoroutine(SpawnGrass(tile, tilePos, .3f));
				StartCoroutine(SpawnBabyTree(tile ,tilePos, .75f));
			
				tileScript.currentStatus = _PlayerController.buildMode;
			}
		break; //end sapling
			
		case "BranchFist":
			if (tileScript.currentStatus == "Sprout")
			{
				SpawnGrowRoot(tilePos);
				StartCoroutine(DestroyExistingSprout(tile, .7f));
				StartCoroutine( SpawnNutPelter(tile, tilePos, .7f));
				
				tileScript.currentStatus = _PlayerController.buildMode;
			}
		break;
			
			
		case "NutPelter":
			if (tileScript.currentStatus == "Sprout")
			{
				SpawnGrowRoot(tilePos);
				StartCoroutine(DestroyExistingSprout(tile, .7f));
				StartCoroutine(SpawnNutPelter( tile, tilePos,.7f));
				
				tileScript.currentStatus = _PlayerController.buildMode;
			}
		break;
			
		case "Rock":
			if (tileScript.currentStatus == "Open")
			{
				StartCoroutine(SpawnGrass(tile, tilePos, .3f));
				StartCoroutine(SpawnRock(tile, tilePos, .3f));
				
				tileScript.currentStatus = _PlayerController.buildMode;
			}
		break;
		}//end buildmode switch
			
	} // end Build Function
	
	IEnumerator DestroyExistingSprout(GameObject tile, float delay)
	{
		yield return new WaitForSeconds(delay);	
		Destroy(tile.GetComponent<TileScript>().currentObject.gameObject);
	}
	
	public void SpawnSeedProjectile(Vector3 tilePos) 
		
	{	
		//MotherTree look to hit   HONESTLY TRY TO WEEN THIS AWAY TOO
		_motherTreeSeedShooter.transform.LookAt(tilePos);
		
		//Instantiate Seed Projectile from mother tree 
		//seed will move itself to target
		GameObject seedProjectileClone = Instantiate (Resources.Load ("Prefabs/Seed Projectile"), 
		                                              _motherTreeSeedShooter.transform.position, _motherTreeSeedShooter.transform.rotation) as GameObject;
		seedProjectileClone.GetComponent<SeedProjectile>().Target(tilePos);
	}
	

	IEnumerator SpawnGrass(GameObject tile, Vector3 tilePos, float delay) //Also spawns NavObstacle!
	{
		yield return new WaitForSeconds(delay);	
		//Instantiate Seed Target at hit
		GameObject _grass = Instantiate (Resources.Load ("Prefabs/Grass"),
		                                 new Vector3(tilePos.x,.14f,tilePos.z),Quaternion.LookRotation(Vector3.up)) as GameObject;
		_grass.transform.parent = _grasses;
		GameObject NavObstacle = Instantiate (Resources.Load ("Prefabs/NavObstacle") , new Vector3(tilePos.x,0,tilePos.z) , Quaternion.identity) as GameObject;
		tile.GetComponent<TileScript>().SetOwnerships(_grass, NavObstacle);
		
	}
	
	private void SpawnGrowRoot(Vector3 tilePos)
	{
		GameObject _root = Instantiate ( Resources.Load ("Prefabs/GrowRoot"),
		                                _motherTreeSeedShooter.transform.position, Quaternion.identity) as GameObject;
		_root.GetComponent<RootScript>().Shoot(tilePos);
	}
	
	IEnumerator SpawnBabyTree(GameObject tile, Vector3 tilePos, float delay)
	{
		yield return new WaitForSeconds(delay);	
		GameObject _babyTree = Instantiate(Resources.Load("Prefabs/Baby Tree"),
		                                   new Vector3(tilePos.x,.14f,tilePos.z), Quaternion.Euler(0,Random.Range(0,360),0)) as GameObject;
		_babyTree.transform.parent = _playerObjects;
		_babyTree.GetComponent<TileInfo>().myTile = tile;
		tile.GetComponent<TileScript>().currentObject = _babyTree;
	}
	
	IEnumerator SpawnBranchFist(GameObject tile, Vector3 tilePos, float delay)
	{
		yield return new WaitForSeconds(delay);
		GameObject _branchFist = 	Instantiate (Resources.Load("Prefabs/BranchFistTree"),
		                                       new Vector3(tilePos.x,.14f,tilePos.z), Quaternion.Euler(0,Random.Range(0,360),0)) as GameObject;
		_branchFist.transform.parent = _playerObjects;
		_branchFist.GetComponent<TileInfo>().myTile = tile;
		tile.GetComponent<TileScript>().currentObject = _branchFist;
	}
	
	IEnumerator SpawnNutPelter(GameObject tile, Vector3 tilePos, float delay)
	{
		yield return new WaitForSeconds(delay);
		GameObject _nutPelter = 	Instantiate (Resources.Load("Prefabs/NutPelterTree"),
		                                       new Vector3(tilePos.x,.14f,tilePos.z), Quaternion.Euler(0,Random.Range(0,360),0)) as GameObject;
		_nutPelter.transform.parent = _playerObjects;
		_nutPelter.GetComponent<TileInfo>().myTile = tile;
		tile.GetComponent<TileScript>().currentObject = _nutPelter;
	}
	
	IEnumerator SpawnRock(GameObject tile, Vector3 tilePos, float delay)
	{
		yield return new WaitForSeconds(delay);
	
		GameObject _rock =	Instantiate (Resources.Load("Prefabs/Rock"),
		                               new Vector3(tilePos.x,.14f,tilePos.z), Quaternion.Euler(0,Random.Range(0,360),0)) as GameObject;
		_rock.transform.parent = _playerObjects;

		tile.GetComponent<TileScript>().currentObject = _rock;
	}
	
	
}
