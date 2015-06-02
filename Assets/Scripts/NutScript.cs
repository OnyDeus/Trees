using UnityEngine;
using System.Collections;

public class NutScript : MonoBehaviour {

	private GameObject currentTarget;
	private Vector3 origin;
	private TrailRenderer trail;

	// Use this for initialization
	void Start () {
		trail = this.GetComponent<TrailRenderer>();
		origin = this.transform.position;
	}


	public void Shoot(GameObject target){
		currentTarget = target;
		trail.enabled = true;

		Vector3 targetPos = target.transform.position;
		this.transform.LookAt(targetPos);
		
		iTween.MoveTo( this.gameObject,iTween.Hash(
			iT.MoveTo.position, targetPos, 
			iT.MoveTo.easetype, iTween.EaseType.linear, 
			iT.MoveTo.time, .3f,
			iT.MoveTo.oncomplete, "SendDamage"
			)); 
	}


	private void SendDamage()
	{
		if (currentTarget)
		currentTarget.GetComponent<AxeLoggerScript>().TakeDamage(2f);
		
		Reset();

	}
	
	private void Reset()
	{
		currentTarget = null;
		trail.enabled = false;
		this.transform.position = origin;
	}

}
