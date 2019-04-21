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
            int item = this.GetComponentInParent<ChoiceBlock>().LetterBlocks.IndexOf(this.gameObject);

            this.GetComponentInParent<ChoiceBlock> ().LetterBlocks [item].GetComponent<Case_Control> ().SetImage ();
			count++;
			this.GetComponentInParent<ChoiceBlock> ().Count = count;
            //this.GetComponentInParent<ChoiceBlock>().SetUpName();
           

        } else {
           // GetComponentInChildren<Button>().interactable = false;
           // GetComponentInChildren<Image>().color = new Color(1, 1, 1, 0.5f);
            LevelManager.instance.CheckAnswer(false, UIManager.instance.heartsAmount, UIManager.instance.seahorseAnim, FindObjectOfType<Keyboard>().PlayersName.Length, System.Enum.GetValues(typeof(UIManager.subLevels2)).Length);
        }
	}
	public Image SetLetter (Image image_){
		image.sprite = image_.sprite;

        return image;

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
