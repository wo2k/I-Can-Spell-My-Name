using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginButtons : MonoBehaviour {
	public Text firstPlayer;
	public Text secondPlayer;
	public Text thirdPlayer;
	public Text fourthPlayer;
	public Button one;
	public Button two;
	public Button three;
	public Button four;
	public Text EditText;
	string firstName = "";
	string secondName = "";
	string thirdName = "";
	string fourthName = "";
	bool EditToggle = false;
	int LoginNumber = 0;
	public Image Jelly;
	public Image Fish;
	public Image Star;
	public Image Shark;
	public Image Whale;
	public Image Angel;
	public Image Urchin;
	public Image Blank;
	public GameObject Character;


	// Use this for initialization
	public void SetImages(){
		firstName = PlayerPrefs.GetString ("firstName");
		int color = PlayerPrefs.GetInt ("firstColor");
		int Character = PlayerPrefs.GetInt ("firstCharacter");
		if (color == 1)
			one.image.color = Color.red;
		if (color == 2)
			one.image.color = Color.green;
		if (color == 3)
			one.image.color = new Color (1.0F, (206.0F / 255.0F), 0, 1);
		if (color == 4)
			one.image.color = Color.cyan;
		if (Character == 1)
			one.image.sprite = Blank.sprite;
		if (color == 0)
			one.image.color = Color.white;

		if (Character == 0)
			one.image.sprite = Blank.sprite;
		if (Character == 1)
			one.image.sprite = Jelly.sprite;
		if (Character == 2)
			one.image.sprite = Fish.sprite;
		if (Character == 3)
			one.image.sprite = Star.sprite;
		if (Character == 4)
			one.image.sprite = Urchin.sprite;

		if (Character == 5)
			one.image.sprite = Shark.sprite;

		if (Character == 6)
			one.image.sprite = Angel.sprite;

		if (Character == 7)
			one.image.sprite = Whale.sprite;




		secondName = PlayerPrefs.GetString ("secondName");
		color = PlayerPrefs.GetInt ("secondColor");
		Character = PlayerPrefs.GetInt ("secondCharacter");
		if (Character == 0)
			two.image.sprite = Blank.sprite;
		if (color == 0)
			two.image.color = Color.white;
		if (color == 1)
			two.image.color = Color.red;
		if (color == 2)
			two.image.color = Color.green;
		if (color == 3)
			two.image.color = new Color (1.0F, (206.0F / 255.0F), 0, 1);
		if (color == 4)
			two.image.color = Color.cyan;

		if (Character == 1)
			two.image.sprite = Jelly.sprite;
		if (Character == 2)
			two.image.sprite = Fish.sprite;
		if (Character == 3)
			two.image.sprite = Star.sprite;
		if (Character == 4)
			one.image.sprite = Urchin.sprite;

		if (Character == 5)
			two.image.sprite = Shark.sprite;

		if (Character == 6)
			two.image.sprite = Angel.sprite;

		if (Character == 7)
			two.image.sprite = Whale.sprite;

		thirdName = PlayerPrefs.GetString ("thirdName");
		color = PlayerPrefs.GetInt ("thirdColor");
		Character = PlayerPrefs.GetInt ("thirdCharacter");
		if (Character == 0)
			three.image.sprite = Blank.sprite;
		if (color == 0)
			three.image.color = Color.white;
		if (color == 1)
			three.image.color = Color.red;
		if (color == 2)
			three.image.color = Color.green;
		if (color == 3)
			three.image.color = new Color (1.0F, (206.0F / 255.0F), 0, 1);
		if (color == 4)
			three.image.color = Color.cyan;

		if (Character == 1)
			three.image.sprite = Jelly.sprite;
		if (Character == 2)
			three.image.sprite = Fish.sprite;
		if (Character == 3)
			three.image.sprite = Star.sprite;
		if (Character == 4)
			three.image.sprite = Urchin.sprite;

		if (Character == 5)
			three.image.sprite = Shark.sprite;

		if (Character == 6)
			three.image.sprite = Angel.sprite;

		if (Character == 7)
			three.image.sprite = Whale.sprite;


		fourthName = PlayerPrefs.GetString ("fourthName");
		color = PlayerPrefs.GetInt ("fourthColor");
		Character = PlayerPrefs.GetInt ("fourthCharacter");
		if (Character == 0)
			four.image.sprite = Blank.sprite;
		if (color == 0)
			four.image.color = Color.white;
		if (color == 1)
			four.image.color = Color.red;
		if (color == 2)
			four.image.color = Color.green;
		if (color == 3)
			four.image.color = new Color (1.0F, (206.0F / 255.0F), 0, 1);
		if (color == 4)
			four.image.color = Color.cyan;

		if (Character == 1)
			four.image.sprite = Jelly.sprite;
		if (Character == 2)
			four.image.sprite = Fish.sprite;
		if (Character == 3)
			four.image.sprite = Star.sprite;
		if (Character == 4)
			four.image.sprite = Urchin.sprite;

		if (Character == 5)
			four.image.sprite = Shark.sprite;

		if (Character == 6)
			four.image.sprite = Angel.sprite;

		if (Character == 7)
			four.image.sprite = Whale.sprite;


		firstPlayer.text = firstName;
		secondPlayer.text = secondName;
		thirdPlayer.text = thirdName;
		fourthPlayer.text = fourthName;
	}
	void fullreset(){

		PlayerPrefs.SetString ("firstName", "Add Player");
		PlayerPrefs.SetString ("secondName", "Add Player");
		PlayerPrefs.SetString ("thirdName", "Add Player");
		PlayerPrefs.SetString ("fourthName", "Add Player");
		PlayerPrefs.SetInt ("firstPlay1", 0);
		PlayerPrefs.SetInt ("firstPlay2", 0);
		PlayerPrefs.SetInt ("firstPlay3", 0);
		PlayerPrefs.SetInt ("firstPlay4", 0);
		PlayerPrefs.SetInt ("firstColor", 0);
		PlayerPrefs.SetInt ("secondColor", 0);
		PlayerPrefs.SetInt ("thirdColor", 0);
		PlayerPrefs.SetInt ("fourthColor", 0);
		PlayerPrefs.SetInt ("firstCharacter", 0);
		PlayerPrefs.SetInt ("secondCharacter", 0);
		PlayerPrefs.SetInt ("thirdCharacter", 0);
		PlayerPrefs.SetInt ("fourthCharacter", 0);

	}
	void Start () {

	//fullreset();

		/*
		firstName = PlayerPrefs.GetString ("firstName");
		int color = PlayerPrefs.GetInt ("firstColor");
		int Character = PlayerPrefs.GetInt ("firstCharacter");
	

		if (color == 1)
			one.image.color = Color.red;
		if (color == 2)
			one.image.color = Color.green;
		if (color == 3)
			one.image.color = new Color (1.0F, (206.0F / 255.0F), 0, 1);
		if (color == 4)
			one.image.color = Color.cyan;
		if (Character == 1)
			one.image.sprite = Blank.sprite;
		if (color == 0)
			one.image.color = Color.white;
		
		if (Character == 0)
			one.image.sprite = Blank.sprite;
		if (Character == 1)
			one.image.sprite = Jelly.sprite;
		if (Character == 2)
			one.image.sprite = Fish.sprite;
		if (Character == 3)
			one.image.sprite = Star.sprite;
		if (Character == 4)
			one.image.sprite = Urchin.sprite;

		if (Character == 5)
			one.image.sprite = Shark.sprite;

		if (Character == 6)
			one.image.sprite = Angel.sprite;

		if (Character == 7)
			one.image.sprite = Whale.sprite;
		
	
	

		secondName = PlayerPrefs.GetString ("secondName");
		 color = PlayerPrefs.GetInt ("secondColor");
		Character = PlayerPrefs.GetInt ("secondCharacter");
		if (Character == 0)
			two.image.sprite = Blank.sprite;
		if (color == 0)
			two.image.color = Color.white;
		if (color == 1)
			two.image.color = Color.red;
		if (color == 2)
			two.image.color = Color.green;
		if (color == 3)
			two.image.color = new Color (1.0F, (206.0F / 255.0F), 0, 1);
		if (color == 4)
			two.image.color = Color.cyan;

		if (Character == 1)
			two.image.sprite = Jelly.sprite;
		if (Character == 2)
			two.image.sprite = Fish.sprite;
		if (Character == 3)
			two.image.sprite = Star.sprite;
		if (Character == 4)
			one.image.sprite = Urchin.sprite;

		if (Character == 5)
			two.image.sprite = Shark.sprite;

		if (Character == 6)
			two.image.sprite = Angel.sprite;

		if (Character == 7)
			two.image.sprite = Whale.sprite;
		
		thirdName = PlayerPrefs.GetString ("thirdName");
		color = PlayerPrefs.GetInt ("thirdColor");
		Character = PlayerPrefs.GetInt ("thirdCharacter");
		if (Character == 0)
			three.image.sprite = Blank.sprite;
		if (color == 0)
			three.image.color = Color.white;
		if (color == 1)
			three.image.color = Color.red;
		if (color == 2)
			three.image.color = Color.green;
		if (color == 3)
			three.image.color = new Color (1.0F, (206.0F / 255.0F), 0, 1);
		if (color == 4)
			three.image.color = Color.cyan;

		if (Character == 1)
			three.image.sprite = Jelly.sprite;
		if (Character == 2)
			three.image.sprite = Fish.sprite;
		if (Character == 3)
			three.image.sprite = Star.sprite;
		if (Character == 4)
			three.image.sprite = Urchin.sprite;

		if (Character == 5)
			three.image.sprite = Shark.sprite;

		if (Character == 6)
			three.image.sprite = Angel.sprite;

		if (Character == 7)
			three.image.sprite = Whale.sprite;
		
		
		fourthName = PlayerPrefs.GetString ("fourthName");
		color = PlayerPrefs.GetInt ("fourthColor");
		Character = PlayerPrefs.GetInt ("fourthCharacter");
		if (Character == 0)
			four.image.sprite = Blank.sprite;
		if (color == 0)
			four.image.color = Color.white;
		if (color == 1)
			four.image.color = Color.red;
		if (color == 2)
			four.image.color = Color.green;
		if (color == 3)
			four.image.color = new Color (1.0F, (206.0F / 255.0F), 0, 1);
		if (color == 4)
			four.image.color = Color.cyan;

		if (Character == 1)
			four.image.sprite = Jelly.sprite;
		if (Character == 2)
			four.image.sprite = Fish.sprite;
		if (Character == 3)
			four.image.sprite = Star.sprite;
		if (Character == 4)
			four.image.sprite = Urchin.sprite;

		if (Character == 5)
			four.image.sprite = Shark.sprite;

		if (Character == 6)
			four.image.sprite = Angel.sprite;

		if (Character == 7)
			four.image.sprite = Whale.sprite;
		*/

		firstPlayer.text = PlayerPrefs.GetString ("firstName");
		if (firstPlayer.text != "Add Player") {
			Character.GetComponent<SetCharacter> ().SetUpLogin (1);
			one.image.sprite = Character.GetComponent<Image> ().sprite;
			one.image.color = Character.GetComponent<Image> ().color;
		}

		secondPlayer.text = PlayerPrefs.GetString ("secondName");
		if (secondPlayer.text != "Add Player") {
			Character.GetComponent<SetCharacter> ().SetUpLogin (2);
			one.image.sprite = Character.GetComponent<Image> ().sprite;
			one.image.color = Character.GetComponent<Image> ().color;
		}
		thirdPlayer.text = PlayerPrefs.GetString ("thirdName");
		if (thirdPlayer.text != "Add Player") {
			Character.GetComponent<SetCharacter> ().SetUpLogin (3);
			one.image.sprite = Character.GetComponent<Image> ().sprite;
			one.image.color = Character.GetComponent<Image> ().color;
		}
		fourthPlayer.text = PlayerPrefs.GetString ("fourthName");
		if (fourthPlayer.text != "Add Player") {
			Character.GetComponent<SetCharacter> ().SetUpLogin (4);
			one.image.sprite = Character.GetComponent<Image> ().sprite;
			one.image.color = Character.GetComponent<Image> ().color;
		}
	}
	public void Edit(){
		if (!EditToggle) {
			EditText.text = "Back";
			EditToggle = true;
			if (firstPlayer.text == "Add Player") {
				one.enabled = false;
			} else {
				firstPlayer.text = "Remove?";
			}
			if (secondPlayer.text == "Add Player") {
				two.enabled = false;
			} else {
				
				secondPlayer.text = "Remove?";
			}
			if (thirdPlayer.text == "Add Player") {
				three.enabled = false;
			} else {
				thirdPlayer.text = "Remove?";
			}
			if (fourthPlayer.text == "Add Player") {
				four.enabled = false;
			} else {
				fourthPlayer.text = "Remove?";
			}
		} else {
			one.enabled = true;
			two.enabled = true;
			three.enabled = true;
			four.enabled = true;
			EditText.text = "Edit";
			EditToggle = false;

			firstName = PlayerPrefs.GetString ("firstName");
			secondName = PlayerPrefs.GetString ("secondName");
			thirdName = PlayerPrefs.GetString ("thirdName");
			fourthName = PlayerPrefs.GetString ("fourthName");

			firstPlayer.text = firstName;
			secondPlayer.text = secondName;
			thirdPlayer.text = thirdName;
			fourthPlayer.text = fourthName;
		}
	
	}
	public void Confermation(){;
		LoginNumber = PlayerPrefs.GetInt ("loginNumber");
		switch(LoginNumber){
		case 1:{
				one.enabled = false;
				firstPlayer.text = "Add Player";
				break;
			}
		case 2:
			{
				two.enabled = false;
				secondPlayer.text = "Add Player";
				break;
			}
		case 3:
			{
				three.enabled = false;
				thirdPlayer.text = "Add Player";
				break;
			}
		case 4:
			{
				four.enabled = false;
				fourthPlayer.text = "Add Player";
				break;
			}

	
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
