using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	public Text Playername;
	public Text Playername2;
	// Use this for initialization
	void Start () {
        UIManager.instance.mode = UIManager.subLevels1.None;
        UIManager.instance.mode2 = UIManager.subLevels2.None;

        int LoginNumber = PlayerPrefs.GetInt("loginNumber");
		string temp = "fixthis"; 
		switch(LoginNumber){
		case 1:{
				temp = PlayerPrefs.GetString ("firstName");
				break;
			}
		case 2:
			{
				temp = PlayerPrefs.GetString ("secondName");
				break;
			}
		case 3:
			{
				temp = PlayerPrefs.GetString ("thirdName");
				break;
			}
		case 4:
			{
				temp = PlayerPrefs.GetString ("fourthName");
				break;
			}
		}

		Playername.text = temp;
		Playername2.text = temp;
		//
	}
	
	// Update is called once per frame
	void Update () {

	}
}
