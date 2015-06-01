using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour {

	public bool moveByArrowKeys = true;
	public bool moveByMouse = false;

	public bool moveByTween = false;
	public float mouseSensitivity = .5f;
	public float slowActivationDistance = 4f;

	private Vector3 lastPosition;


	//-----------------------------------------
	void Start () {	}


	void Update () {
	
		if (moveByArrowKeys){
			ArrowControl();
		}

		if (moveByMouse){
			MouseControl ();

		}

		/*
		Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
		RaycastHit mouseHit = new RaycastHit();

		if(Physics.Raycast(ray.origin, ray.direction, out mouseHit, 100f))
		{

		}
		*/
	}//End Update
	//-----------------------------------------


	private void ArrowControl ()
	{
		this.transform.position = this.transform.position + (Vector3.forward * Input.GetAxisRaw("Vertical") * Time.deltaTime * 4f);
		this.transform.position = this.transform.position + (Vector3.right * Input.GetAxisRaw("Horizontal") * Time.deltaTime * 4f);

	}

	private void MouseControl ()
	{
		//Spawn arrows, start moving
		if (Input.GetMouseButtonDown(1))
		{
			lastPosition = Input.mousePosition;
			
			GameObject panCamIcon = Instantiate(Resources.Load("GUI/PanCamArrows"),Input.mousePosition,Quaternion.identity) as GameObject;
			panCamIcon.transform.SetParent(GameObject.Find("Canvas").transform,false);
		}

		//MoveTween switch
		if (moveByTween){

			//Continue moving
			if (Input.GetMouseButton(1))
			{


				Vector3 delta = Input.mousePosition - lastPosition;
				float moveSpeed = mouseSensitivity;

				//Debug.Log(Vector3.Distance(Input.mousePosition, lastPosition));

			//	if (Vector3.Distance(Input.mousePosition, lastPosition) < slowActivationDistance)
			//	{
					moveSpeed = mouseSensitivity * (Vector3.Distance(Input.mousePosition,lastPosition) / slowActivationDistance);
					transform.position = transform.position + (new Vector3(delta.x * moveSpeed, 0,delta.y * moveSpeed) * Time.deltaTime); 

			//	}
			//	else 
			//	{

			//		transform.position = transform.position + (new Vector3(delta.x * mouseSensitivity, 0,delta.y * mouseSensitivity) * Time.deltaTime);   

			//	}
				Debug.Log(moveSpeed); 
				lastPosition = Input.mousePosition; 



			}
		}//End moveByTween

		if (!moveByTween){

			//Continue moving
			if (Input.GetMouseButton(1))
			{
				Vector3 delta = Input.mousePosition - lastPosition;
				transform.position = transform.position + new Vector3(delta.x * mouseSensitivity, 0,delta.y * mouseSensitivity );
				lastPosition = Input.mousePosition;
			}
		}//End linear movement

	}


}
