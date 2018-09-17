using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCorrectVarMenu : MonoBehaviour {
	public List<GameObject> MenuTypes;
	public int Index = 0;
	// Use this for initialization
	void Start () {
		
	}
	public void TurnOnCorrectMenu (int index) {
		for (int i = 0; i < MenuTypes.Count; i++)
			MenuTypes [i].SetActive (false);

		MenuTypes [index].SetActive (true);
		MenuTypes [index].GetComponent<SelectVarType> ().SetColor ();
		Index = index;

	}
	// Update is called once per frame
	void Update () {
		
	}
}
