using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class GroundGenerator : MonoBehaviour {

	int i;
	int j;

	Transform _ground;

	// Use this for initialization
	void Start () {

		_ground = GameObject.Find("Ground").transform;

		for (i = 0; i < 21; i++) {
			for (j = 0; j < 21; j++) {
				GameObject _node = Instantiate(Resources.Load("Prefabs/Node"),new Vector3(i, 0, j),Quaternion.LookRotation(Vector3.up)) as GameObject;
				_node.transform.parent = _ground;
				
			}
		}

	}
	
	// Update is called once per frame
	void Update () {

	}
}
