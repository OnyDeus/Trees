using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class TileScript : MonoBehaviour, IPointerClickHandler,IPointerEnterHandler,IPointerExitHandler{

	private PlayerController PlayerController;
	private BuildManager BuildManager;

	private GameObject myGrass;
	private GameObject myNavObstacle;

	public string currentStatus = "Open" ;
	public GameObject currentObject = null;
	
	


	void Start () {	
		GameObject GM = GameObject.Find("GameManager");
		PlayerController = GM.GetComponent<PlayerController>();
		BuildManager = GM.GetComponent<BuildManager>();
	}

	void Update () {	}
	
	public void OnPointerClick (PointerEventData eventData)
	{
		if (PlayerController.CanBuild() )
		{	
			if (currentStatus == "Open")
			{
				ClickAnimation();
			}
			BuildManager.BuildOn(this.gameObject);
			
		}
	}
	
	public void SetOwnerships(GameObject grass, GameObject NavObstacle)
	{
		myGrass = grass;
		myNavObstacle = NavObstacle;
	
	}

	
	public void UnBuild()
	{
		Destroy(myGrass.gameObject);
		Destroy(myNavObstacle.gameObject);
		this.transform.position = new Vector3 (this.transform.position.x, 0 , this.transform.position.z);
		currentStatus = "Open";
	
	}
	
	
	#region Tile Highlight on hover over
	public void OnPointerEnter (PointerEventData eventData)
	{
		if(currentStatus == "Open")
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
	
	public void OnPointerExit (PointerEventData eventData){
		if(currentStatus == "Open")
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
