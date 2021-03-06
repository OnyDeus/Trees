﻿using UnityEngine;
using System.Collections;

public class RootScript : MonoBehaviour {

	//Public Settings
	public float secondsToReachTarget = 1f;
	
	//Init for maths
	private float _moveTotalDistance; 

	private Vector3 _moveTarget;




	void Awake () {	}


	//Initialise from PlayerController
	public void Shoot(Vector3 targetPos)
	{
		_moveTarget = targetPos;

		transform.LookAt(new Vector3(targetPos.x,0,targetPos.z));

		_moveTotalDistance = Vector3.Distance(targetPos , transform.position);



		MoveRootAnimation();

	//	Vector3[] vectorGroup = new [] {babyTree.transform.position , transform.position};
	//	pathCenterPoint = CenterOfVectors(vectorGroup);
	}

	private void MoveRootAnimation()
	{
		float _myScale = 1; 

		//make smaller version should target be too close
		if (_moveTotalDistance < 10)
		{
			_myScale = _moveTotalDistance/10;
		}
		this.transform.localScale = new Vector3(_myScale,_myScale,_myScale);

		//Move to moveTarget (babyTree)
		iTween.MoveTo( this.gameObject,iTween.Hash(
			iT.MoveTo.position, _moveTarget,
			iT.MoveTo.easetype, iTween.EaseType.easeOutSine,
			iT.MoveTo.time, .8f,
			iT.MoveTo.oncomplete, "CompleteRootMove"
			));
	
		iTween.ScaleFrom(this.gameObject , iTween.Hash(
			iT.ScaleFrom.scale, Vector3.zero,
			iT.ScaleFrom.easetype, iTween.EaseType.linear,
			iT.ScaleFrom.time, .25f,
			iT.ScaleFrom.oncomplete, "ScaleDownRoot"
			));


	}

	private void ScaleDownRoot()
	{
			iTween.ScaleTo(this.gameObject , iTween.Hash(
			iT.ScaleTo.scale, Vector3.zero,
			iT.ScaleTo.easetype, iTween.EaseType.easeInQuad,
			iT.ScaleTo.time, .2f
			
			));
			 
	}

	private void CompleteRootMove()
	{

		Destroy(this.gameObject);
	}

}
