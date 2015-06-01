using UnityEngine;
using System.Collections;

public class BuildModeController : MonoBehaviour {

	private PlayerController _PlayerController;
	private void Start()
	{
		_PlayerController = this.GetComponentInParent<PlayerController>();
	}

	public void SetSapling(){
		_PlayerController.buildMode = "Sapling";}
	
	public void SetBranchFistTree(){
		_PlayerController.buildMode = "BranchFist";}

	public void SetRootWhipTree(){
		_PlayerController.buildMode = "RootWhip";}

	public void SetNutPelterTree(){
		_PlayerController.buildMode = "NutPelter";}

	public void SetRazorLeafTree(){
		_PlayerController.buildMode = "RazorLeaf";}

	public void SetBlindingPollenTree(){
		_PlayerController.buildMode = "BlindingPollen";}

	public void SetToxicPoisonTree(){
		_PlayerController.buildMode = "ToxicPoison";}

	public void SetVine(){
		_PlayerController.buildMode = "Vine";}

	public void SetLog(){
		_PlayerController.buildMode = "Log";}

	public void SetRock(){
		_PlayerController.buildMode = "Rock";}
}
