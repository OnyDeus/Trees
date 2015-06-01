using UnityEngine;
using System.Collections;

public class GrowAtStart : MonoBehaviour {

	public Vector3 growFromValue = new Vector3(.3f,.3f,.3f);

	// Use this for initialization
	void Start () {
	
		iTween.ScaleFrom(this.gameObject, iTween.Hash(
			"name" ,"GrowStart",
			iT.ScaleFrom.scale, growFromValue
			));


	}

	public void StopGrowAnim()
	{
		iTween.StopByName("GrowStart");
	}
}
