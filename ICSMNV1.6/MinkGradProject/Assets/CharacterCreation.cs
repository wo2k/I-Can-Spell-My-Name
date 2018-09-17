using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCreation : MonoBehaviour {
	public GameObject CharacterType;
	public GameObject CharacterVar;
	public GameObject CharacterColor;
	// Use this for initialization
	void Start () {
		
	}
	public void GotoVaration () {
		CharacterVar.SetActive (true);
		CharacterVar.GetComponent<ShowCorrectVarMenu> ().TurnOnCorrectMenu (CharacterType.GetComponent<SelectFishType> ().Index);
		CharacterType.SetActive (false);
	}
	public void BacktoType () {
		CharacterType.SetActive (true);
		CharacterVar.SetActive (false);
	}
	public void BacktoColor () {
		CharacterColor.SetActive (true);
		CharacterType.SetActive (false);
	}
	public void GotoType () {
		CharacterColor.SetActive (false);
		CharacterType.SetActive (true);
		CharacterType.GetComponent<SelectFishType> ().SetColor ();
	}
	// Update is called once per frame
	void Update () {
		
	}
}
