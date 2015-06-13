using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	
	public float health = 10f;
	public float deathAnimTime = .33f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void TakeDamage(float attackDamage){
		health -= attackDamage;
		
		if (health < 0)
		{
			DeathAnimation();
			Invoke("InvokedDestroy", deathAnimTime );
			

			this.GetComponent<TileInfo>().myTile.GetComponent<TileScript>().UnBuild();
		}
	
	}
	
	public void DeathAnimation()
	{
		iTween.ScaleTo(this.gameObject, iTween.Hash(
			iT.ScaleTo.scale, Vector3.zero,
			iT.ScaleTo.time, deathAnimTime
			));
	}
	
	public void InvokedDestroy()
	{
		Destroy(this.gameObject);
	}
}
