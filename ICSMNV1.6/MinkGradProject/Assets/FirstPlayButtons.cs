using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstPlayButtons : MonoBehaviour {
	public GameObject Tutorial;
	public GameObject MainhMenu;
	public GameObject ConfirmSubMenu;
    public GameObject Level1A;
	public int LoginNumber = 0;
	bool firstplay;
	public InputField input;
	bool EditToggle = false;

    // Use this for initialization
    void Start() {
        PlayerPrefs.SetInt("loginNumber", LoginNumber);

     /*   switch (LoginNumber)
        {
            case 1:
                PlayerPrefs.GetInt("firstCharacter");
                PlayerPrefs.GetInt("firstColor");
                PlayerPrefs.GetInt("firstVar");
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
        }*/
    }

	public void SavePlayer (){
		input.text = input.text.ToUpper ();
		switch(LoginNumber){
		case 1:{
				PlayerPrefs.SetString ("firstName", input.text.ToUpper());
				break;
			}
		case 2:
			{
				PlayerPrefs.SetString ("secondName", input.text.ToUpper());
				break;
			}
		case 3:
			{
				PlayerPrefs.SetString ("thirdName", input.text.ToUpper());
				break;
			}
		case 4:
			{
				PlayerPrefs.SetString ("fourthName", input.text.ToUpper());
				break;
			}
		}
	}
	public void SetLogin1(){
		LoginNumber = 1;
		PlayerPrefs.SetInt ("loginNumber", LoginNumber );
		if (EditToggle) {
			ConfirmSubMenu.SetActive (true);
		} else {
			
			int temp = 5;
			temp = PlayerPrefs.GetInt ("firstPlay1");

			if (temp == 0) {
				Tutorial.SetActive (true);

			} else {
				MainhMenu.SetActive (true);
			}
		}
	}
	public void SetLogin2(){
		LoginNumber = 2;
		PlayerPrefs.SetInt ("loginNumber", LoginNumber );
		if (EditToggle) {
			ConfirmSubMenu.SetActive (true);
		} else {
			
			int temp = 5;
			temp = PlayerPrefs.GetInt ("firstPlay2");

			if (temp == 0) {
				Tutorial.SetActive (true);

			} else {
				MainhMenu.SetActive (true);
			}
		}
	}

	public void SetLogin3(){
		LoginNumber = 3;
		PlayerPrefs.SetInt ("loginNumber", LoginNumber );
		if (EditToggle) {
			ConfirmSubMenu.SetActive (true);
		} else {
			
			int temp = 5;
			temp = PlayerPrefs.GetInt ("firstPlay3");

			if (temp == 0) {
				Tutorial.SetActive (true);

			} else {
				MainhMenu.SetActive (true);
			}
		}
	}

	public void SetLogin4(){
		LoginNumber = 4;
		PlayerPrefs.SetInt ("loginNumber", LoginNumber );

		if (EditToggle) {
			ConfirmSubMenu.SetActive (true);
		} else {
			
			int temp = 5;
			temp = PlayerPrefs.GetInt ("firstPlay4");

			if (temp == 0) {
				Tutorial.SetActive (true);

			} else {
				MainhMenu.SetActive (true);
			}
		}
	}
	public void Confermation(){
		
		switch(LoginNumber){
		case 1:{
				PlayerPrefs.SetString ("firstName", "Add Player");
				PlayerPrefs.SetInt ("firstPlay1", 0);
				PlayerPrefs.SetInt ("firstColor", 0);
				PlayerPrefs.SetInt ("firstCharacter", 0);
				break;
			}
		case 2:
			{
				PlayerPrefs.SetString ("secondName", "Add Player");
				PlayerPrefs.SetInt ("firstPlay2", 0);
				PlayerPrefs.SetInt ("secondColor", 0);
				PlayerPrefs.SetInt ("secondCharacter", 0);
				break;
			}
		case 3:
			{
				PlayerPrefs.SetString ("thirdName", "Add Player");
				PlayerPrefs.SetInt ("firstPlay3", 0);
				PlayerPrefs.SetInt ("thirdColor", 0);
				PlayerPrefs.SetInt ("thirdCharacter", 0);
				break;
			}
		case 4:
			{
				PlayerPrefs.SetString ("fourthName", "Add Player");
				PlayerPrefs.SetInt ("firstPlay4", 0);
				PlayerPrefs.SetInt ("fourthColor", 0);
				PlayerPrefs.SetInt ("fourthCharacter", 0);
				break;
			}
		}
		ConfirmSubMenu.SetActive (false);
	}

	public void Decline(){
        Level1A.GetComponent<Level1A>().Reset();
        Level1A.SetActive(false);
        ConfirmSubMenu.SetActive (false);
        MainhMenu.SetActive(true);
        Level1A.GetComponent<Level1A>().StartMenu.SetActive(true);
    }

	public void Edit(){
		if (!EditToggle){ EditToggle = true;
		} else {
			EditToggle = false;}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
