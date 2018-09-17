using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterPlacement : MonoBehaviour {
	public Image Letter;


	// Use this for initialization
	void Start () {

	}
	public void SetLetter (Image image){
		Letter.sprite = image.sprite;

	}
	public void RemoveLetter (){
		Letter.sprite = null;
	}
	// Update is called once per frame
	void Update () {
		
	}
}
