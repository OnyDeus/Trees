using UnityEngine;
using System.Collections;

public class NutScript : MonoBehaviour {

	public GameObject target;

	// Use this for initialization
	void Start () {
	
		if (target)
		{
		this.transform.LookAt(target.transform.position);


		iTween.MoveTo( this.gameObject,iTween.Hash(
			iT.MoveTo.position, target.transform.position,
			iT.MoveTo.easetype, iTween.EaseType.linear,
			iT.MoveTo.time, .1f,
			iT.MoveTo.oncomplete, "DestroySelf"
			));
		}
	}

	private void OnCollisionEnter(Collision col)
	{
		if (col.gameObject == target)
		{

			target.GetComponent<AxeLoggerScript>().health -= 2f;
		}
	}


	private void DestroySelf()
	{
		Destroy( this.gameObject);
	}

}
