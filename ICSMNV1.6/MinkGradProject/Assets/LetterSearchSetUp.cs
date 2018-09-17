using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterSearchSetUp : MonoBehaviour {
	public Image image;
	public static int count = 0;
	public string upper;
	public string lower;
	public static bool UpperCaseFlag = true;
	public Button button;
	public int index = -1;
	// Use this for initialization
	public void SetImage(){
		if (index != -1) {
			this.GetComponentInParent<ChoiceBlock> ().AnswerBlocks [index].GetComponent<LetterPlacement> ().SetLetter (image);
			count++;
			this.GetComponentInParent<ChoiceBlock> ().Count = count;
		} else {
			this.GetComponentInParent<ChoiceBlock> ().Miss ();
		}
	}
	public void SetLetter (Image image_){
		image.sprite = image_.sprite;

	}
	public void RemoveLetter (){
		image.sprite = null;
	}
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
