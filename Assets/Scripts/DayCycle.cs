using UnityEngine;
using System.Collections;

public class DayCycle : MonoBehaviour {

	public int secondsInADay = 2; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		iTween.RotateAdd(this.gameObject, iTween.Hash(
			"amount", new Vector3(180,0,0),
			"EaseType",iTween.EaseType.linear, 
			"time",secondsInADay));
	}
}
