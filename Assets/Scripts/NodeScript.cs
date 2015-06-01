using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;


public class NodeScript : MonoBehaviour, IPointerClickHandler,IPointerEnterHandler,IPointerExitHandler {
	
	public int NodeStatus = 0;
	public GameObject _currentObject;
	//NodeStatus has int for each type of content
/*	0: Unnocupied / buildable
 * 	1: Sapling
 * 	21: BranchFist Tree
 * 	22: RootWhip Tree
 * 	31: NutPelter Tree
 *  32: RazorLeaf Tree
 *  41: ToxicPoison Tree
 *  42: BlindingPollen Tree
 *  51: Log
 *  52: Vine
 *  53: Rock
*/

	private GameObject _GameManager;
	private BuildManager _BuildManager;
	private PlayerController _PlayerController;

	public void Start ()
	{
		_GameManager = GameObject.Find("GameManager") as GameObject;

		_BuildManager = _GameManager.GetComponent<BuildManager>();
		_PlayerController = _GameManager.GetComponent<PlayerController>();
	}


	#region IPointerClickHandler implementation
	
	public void OnPointerClick (PointerEventData eventData)
	{
		if (_PlayerController.CanBuild())
		{	
			//pass node info to BuildManagerS
			_BuildManager.NodeInfo(this.gameObject);

			//Check buildmode string
			switch(_PlayerController.buildMode)
			{	
			//Spawn Sapling mode
			case "Sapling":  
				switch (NodeStatus)
				{	
				case 0: //Node open
					ClickAnimation();
					_BuildManager.SpawnSeedProjectile();
					_BuildManager.Invoke("SpawnGrass", .2f);
					_BuildManager.Invoke("SpawnBabyTree", 1.5f);


					//Switch node status to sapling
					NodeStatus= 1;
					break;
				default:
					Debug.Log("Not applicable action");
					break;
				}
				break; //end sapling

			case "BranchFist":
				switch (NodeStatus)
				{
				case 1: 

					_currentObject.GetComponent<GrowAtStart>().StopGrowAnim();
					Destroy(_currentObject.gameObject);
					
					_BuildManager.SpawnBranchFist();
					
					//Switch node status to BranchFist
					NodeStatus= 21;
					break;
				}
				break; //end Branchfist

			case "RootWhip":
				switch (NodeStatus)
				{
				case 1: 
					_currentObject.GetComponent<GrowAtStart>().StopGrowAnim();
					Destroy(_currentObject.gameObject);
					
					_BuildManager.SpawnRootWhip();
					
					//Switch node status to BranchFist
					NodeStatus= 22;
					break;
				}
				break; //end RootWhip

			case "NutPelter":
				switch (NodeStatus)
				{
				case 1: 
					_currentObject.GetComponent<GrowAtStart>().StopGrowAnim();
					Destroy(_currentObject.gameObject);
					
					_BuildManager.SpawnNutPelter();
					
					//Switch node status to BranchFist
					NodeStatus= 31;
					break;
				}
				break; //end NutPelter

			case "Vine":
				switch (NodeStatus)
				{
				case 0: 
					ClickAnimation();
					_BuildManager.Invoke("SpawnGrass", .2f);
					_BuildManager.Invoke("SpawnVine", .3f);
					
					//Switch node status to BranchFist
					NodeStatus= 51;
					break;
				}
				break; //end Branchfist

			case "Rock":
				switch (NodeStatus)
				{
				case 0: 
					ClickAnimation();
					_BuildManager.Invoke("SpawnGrass", .2f);
					_BuildManager.Invoke ("SpawnRock", .3f);
					
					//Switch node status to BranchFist
					NodeStatus= 53;
					break;
				}
				break; //end Branchfist



			}//end buildmode switch
		}
	}
	#endregion

	#region IPointerEnterHandler implementation

	public void OnPointerEnter (PointerEventData eventData)
	{
		if(NodeStatus == 0)
		{
			//transform.position =  new Vector3(this.transform.position.x , .15f , this.transform.position.z);
			iTween.MoveTo(this.gameObject, iTween.Hash(
				"name", "nodeHighlight",
				"time",.4f ,
				"easetype",iTween.EaseType.easeOutQuart ,
				"position",new Vector3(this.transform.position.x , .15f , this.transform.position.z)
				));
		}
	}

	#endregion
	
	
	#region IPointerExitHandler implementation

	public void OnPointerExit (PointerEventData eventData)
	{
		if(NodeStatus == 0)
		{
			iTween.StopByName("nodeHighlight");
			
			iTween.MoveTo(this.gameObject, iTween.Hash(
				"time",.2f ,
				"easetype",iTween.EaseType.easeOutQuart ,
				"position",new Vector3(this.transform.position.x , 0 , this.transform.position.z)
				));
			
			//this.transform.localPosition =  new Vector3(this.transform.localPosition.x , 0 , this.transform.localPosition.z);
		}
	}

	#endregion


	//InvokeSpawnSeed, ClickAnimation, ClickAnimationUp together for spawning Seed
	private void InvokeSpawnSeed()
	{
		_BuildManager.SpawnSeedProjectile();
	//	_myObject = _BuildManager.GetBabyTreeObject();
	}
	
	private void ClickAnimation()
	{
		iTween.StopByName("nodeHighlight");

		iTween.MoveTo(this.gameObject, iTween.Hash(
			"time",.1f ,
			"EaseType",iTween.EaseType.easeOutQuart ,
			"position",new Vector3(this.transform.position.x , -.1f , this.transform.position.z),
			iT.MoveTo.oncomplete, "ClickAnimationUp"
			));
	}
	private void ClickAnimationUp()
	{
		iTween.MoveTo(this.gameObject, iTween.Hash(
			"name" ,"occupyUp",
			"time",.2f ,
			"EaseType",iTween.EaseType.easeOutQuart ,
			"position",new Vector3(this.transform.position.x , .15f , this.transform.position.z)
			));
	}
	


}
