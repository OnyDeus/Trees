using UnityEngine;
using System.Collections;

public class GrassScript : MonoBehaviour {

	public float growSpeed = 1f;


	// Use this for initialization
	void Start () {
		iTween.ScaleFrom(this.gameObject, iTween.Hash(
			iT.ScaleFrom.z, .02f
			));
	}

}
