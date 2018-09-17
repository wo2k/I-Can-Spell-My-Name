using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Case_Control : MonoBehaviour {
	public GameObject Upper;
	public GameObject Lower;
	public static int index = 0;
	public string upper;
	public string lower;
	public static bool UpperCaseFlag = true;
	public Button button;
	public static int HMindex = 0;
	public static int HMmisses = 0;
	public static bool miss = false;
	// Use this for initialization
	void Start () {


			

	}
	public void SetImage(){
		SoundManagement.TriggerEvent ("PlayPop");
		switch (upper) {
		case "A":
			{ SoundManagement.TriggerEvent ("PlayA");
				break;
			}
		case "B":
			{ SoundManagement.TriggerEvent ("PlayB");
				break;
			}
		case "C":
			{ SoundManagement.TriggerEvent ("PlayC");
				break;
			}
		case "D":
			{ SoundManagement.TriggerEvent ("PlayD");
				break;
			}
		case "E":
			{ SoundManagement.TriggerEvent ("PlayE");
				break;
			}
		case "F":
			{ SoundManagement.TriggerEvent ("PlayF");
				break;
			}
		case "G":
			{ SoundManagement.TriggerEvent ("PlayG");
				break;
			}
		case "H":
			{ SoundManagement.TriggerEvent ("PlayH");
				break;
			}
		case "I":
			{ SoundManagement.TriggerEvent ("PlayI");
				break;
			}
		case "J":
			{ SoundManagement.TriggerEvent ("PlayJ");
				break;
			}
		case "K":
			{ SoundManagement.TriggerEvent ("PlayK");
				break;
			}
		case "L":
			{ SoundManagement.TriggerEvent ("PlayL");
				break;
			}
		case "M":
			{ SoundManagement.TriggerEvent ("PlayM");
				break;
			}
		case "N":
			{ SoundManagement.TriggerEvent ("PlayN");
				break;
			}
		case "O":
			{ SoundManagement.TriggerEvent ("PlayO");
				break;
			}
		case "P":
			{ SoundManagement.TriggerEvent ("PlayP");
				break;
			}
		case "Q":
			{ SoundManagement.TriggerEvent ("PlayQ");
				break;
			}
		case "R":
			{ SoundManagement.TriggerEvent ("PlayR");
				break;
			}
		case "S":
			{ SoundManagement.TriggerEvent ("PlayS");
				break;
			}
		case "T":
			{ SoundManagement.TriggerEvent ("PlayT");
				break;
			}
		case "U":
			{ SoundManagement.TriggerEvent ("PlayU");
				break;
			}
		case "V":
			{ SoundManagement.TriggerEvent ("PlayV");
				break;
			}
		case "W":
			{ SoundManagement.TriggerEvent ("PlayW");
				break;
			}
		case "X":
			{ SoundManagement.TriggerEvent ("PlayX");
				break;
			}
		case "Y":
			{ SoundManagement.TriggerEvent ("PlayY");
				break;
			}
		case "Z":
			{ SoundManagement.TriggerEvent ("PlayZ");
				break;
			}

		}
		if (this.GetComponentInParent<Keyboard> ().LevelNum == 3) {

			if (UpperCaseFlag) {
				this.GetComponentInParent<Keyboard> ().LettersBlockHM.GetComponent<TypedLetter> ().TypedStuff [HMindex].sprite = Upper.GetComponent<Image> ().sprite;
				HMindex = HMindex + 1;
				int lenght = this.GetComponentInParent<Keyboard> ().PlayersName.Length;
				for (int i = 0; i < lenght; i++) { 
					char[] name = this.GetComponentInParent<Keyboard> ().PlayersName.ToCharArray ();
					char[] thisletter = upper.ToCharArray ();
					if (name [i] == thisletter [0] && GetComponentInParent<Keyboard> ().Used [i] != true) {
						GetComponentInParent<Keyboard> ().Used [i] = true;
						this.GetComponentInParent<Keyboard> ().LetterBlocks [i].GetComponent<LetterPlacement> ().SetLetter (Upper.GetComponent<Image> ());
						this.GetComponentInParent<Keyboard> ().answerString = this.GetComponentInParent<Keyboard> ().answerString + upper;
						break;
					} else {
						miss = true;
					}
				}
				if (miss == true) {
					miss = false;
					HMmisses++;
					this.GetComponentInParent<Keyboard> ().Miss ();
				}

			} else {
				this.GetComponentInParent<Keyboard> ().LettersBlockHM.GetComponent<TypedLetter> ().TypedStuff [HMindex].sprite = Lower.GetComponent<Image> ().sprite;
				HMindex = HMindex + 1;
				int lenght = this.GetComponentInParent<Keyboard> ().PlayersName.Length;
				for (int i = 0; i < lenght; i++) {
					char[] name = this.GetComponentInParent<Keyboard> ().PlayersName.ToCharArray ();
					char[] thisletter = lower.ToCharArray ();
					if (name [i] == thisletter [0] && GetComponentInParent<Keyboard> ().Used [i] != true) {
						GetComponentInParent<Keyboard> ().Used [i] = true;
						this.GetComponentInParent<Keyboard> ().LetterBlocks [i].GetComponent<LetterPlacement> ().SetLetter (Lower.GetComponent<Image> ());
						this.GetComponentInParent<Keyboard> ().answerString = this.GetComponentInParent<Keyboard> ().answerString + lower;
						break;
					} else {
						miss = true;
					}
				}
				if (miss == true) {
					miss = false;
					HMmisses++;
					this.GetComponentInParent<Keyboard> ().Miss ();
				}

			}
		} else {
			if (UpperCaseFlag) {
				this.GetComponentInParent<Keyboard> ().LetterBlocks [index].GetComponent<LetterPlacement> ().SetLetter (Upper.GetComponent<Image> ());
				this.GetComponentInParent<Keyboard> ().answerString = this.GetComponentInParent<Keyboard> ().answerString + upper;
			} else {
				this.GetComponentInParent<Keyboard> ().LetterBlocks [index].GetComponent<LetterPlacement> ().SetLetter (Lower.GetComponent<Image> ());
				this.GetComponentInParent<Keyboard> ().answerString = this.GetComponentInParent<Keyboard> ().answerString + lower;
			}
			index++;
		}

	}
	public void Change_Case(bool flag){
		UpperCaseFlag = flag;
		if (flag) {
			Upper.SetActive (true);
			Lower.SetActive (false);
		}else{
			Upper.SetActive (false);
			Lower.SetActive (true);
		}
	}
	public void Delete(){
		if (index != 0)
			index--;
	}
	public  int GetIndex(){
		return index;
	}
	// Update is called once per frame
	void Update () {
		
	}
}
