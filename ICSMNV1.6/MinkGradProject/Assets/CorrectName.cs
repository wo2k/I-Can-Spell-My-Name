using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CorrectName : MonoBehaviour {
	public Text playername;
	public  GameObject ConfermationScreen;

	// Use this for initialization
	void Start () {
		playername.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		int loginnumber = PlayerPrefs.GetInt ("loginNumber");

		switch (loginnumber) {
		case 0:{
				playername.text = "fixthis";
				break;
			}
		case 1:{
				playername.text = PlayerPrefs.GetString ("firstName");
				break;
			}
		case 2:{
				playername.text = PlayerPrefs.GetString ("secondName");
				break;
			}
		case 3:{
				playername.text = PlayerPrefs.GetString ("thirdName");
				break;
			}
		case 4:{
				playername.text = PlayerPrefs.GetString ("fourthName");
				break;
			}
		}
	}
	public void CloseConfermation() {
		ConfermationScreen.SetActive (false);
	}
	public void OpenConfermation() {
		if(playername.text != "Add Player")
			ConfermationScreen.SetActive (true);
	}
}
