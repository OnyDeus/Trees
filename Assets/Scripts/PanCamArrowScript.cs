using UnityEngine;
using System.Collections;

public class PanCamArrowScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		this.transform.position = Input.mousePosition;

		if (Input.GetMouseButtonUp (1))
			Destroy(this.gameObject);

	}
}
