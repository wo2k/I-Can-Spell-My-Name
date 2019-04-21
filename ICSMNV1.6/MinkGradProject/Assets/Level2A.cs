using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level2A : MonoBehaviour {
	public GameObject Keyboard;

	public string PlayersName;
	public string AnswerName;
	public bool gameStart = false;
	public Text timetext;
	int Score = 0;
	public Text ScoreText;
	int Multi = 1;
	//int Miss = 0;
	int Total = 0;
	public GameObject GameManager;
	public GameObject StartMenu;
	public GameObject EndMenu;

	// Use this for initialization
	public void StartGame(){
		StartMenu.SetActive (false);
		gameStart = true;
	}
	void Start () {

        UIManager.instance.heartsAmount = 3;
        UIManager.instance.StartGame();
        UIManager.instance.mode2 = UIManager.subLevels2.Level2A;
        Keyboard = FindObjectOfType<Keyboard>().gameObject;

        switch (FindObjectOfType<FirstPlayButtons>().LoginNumber){
		case 1:{
				PlayersName = PlayerPrefs.GetString ("firstName");
				break;
			}
		case 2:
			{
				PlayersName = PlayerPrefs.GetString ("secondName");
				break;
			}
		case 3:
			{
				
				PlayersName = PlayerPrefs.GetString ("thirdName");

				break;
			}
		case 4:
			{
				PlayersName = PlayerPrefs.GetString ("fourthName");
				break;
			}
		}
		Keyboard.GetComponent<Keyboard> ().PlayersName = PlayersName;
		Keyboard.GetComponent<Keyboard> ().SetUpName (0.4f, true);
	}
	
	// Update is called once per frame
	public void ScorePoints(){
		Score += 100 * Multi;
		ScoreText.text = Score.ToString ();
		Total++;
	}
	public void Reset(){
		int count =	Keyboard.GetComponent<Keyboard> ().LetterBlocks.Count;
		for (int i = 0; i < count; i++)
			Keyboard.GetComponent<Keyboard> ().LetterBlocks [i].GetComponent<LetterPlacement> ().RemoveLetter ();
		Keyboard.GetComponent<Keyboard> ().RaceCount = 0;
		Keyboard.GetComponent<Keyboard> ().answerString = "";
		Keyboard.GetComponent<Keyboard> ().Home = false;
		Keyboard.GetComponent<Keyboard> ().MoveFoward = false;
		Case_Control.index = 0;
		if (Keyboard.GetComponent<Keyboard> ().CapsLock != true)
			Keyboard.GetComponent<Keyboard> ().Shift ();
	//	StartMenu.SetActive (true);
	}

	public void ResetRace(){
		int count =	Keyboard.GetComponent<Keyboard> ().LetterBlocks.Count;
		for (int i = 0; i < count; i++)
			Keyboard.GetComponent<Keyboard> ().LetterBlocks [i].GetComponent<LetterPlacement> ().RemoveLetter ();
		Keyboard.GetComponent<Keyboard> ().answerString = "";
		Keyboard.GetComponent<Keyboard> ().Home = false;
		Keyboard.GetComponent<Keyboard> ().MoveFoward = false;
		Case_Control.index = 0;
		if (Keyboard.GetComponent<Keyboard> ().CapsLock != true)
			Keyboard.GetComponent<Keyboard> ().Shift ();
	}

	public void Restart(){
		int count =	Keyboard.GetComponent<Keyboard> ().LetterBlocks.Count;
		for (int i = 0; i < count; i++)
			Keyboard.GetComponent<Keyboard> ().LetterBlocks [i].GetComponent<LetterPlacement> ().RemoveLetter ();
		Keyboard.GetComponent<Keyboard> ().RaceCount = 0;
		Keyboard.GetComponent<Keyboard> ().Racer1count = 0;
		Keyboard.GetComponent<Keyboard> ().Racer2count = 0;
		Keyboard.GetComponent<Keyboard> ().PlayerCharcter.transform.localPosition = Keyboard.GetComponent<Keyboard> ().PlayerCharcterPosition;
		Keyboard.GetComponent<Keyboard> ().Racer1.transform.localPosition = Keyboard.GetComponent<Keyboard> ().Racer1Position;
		Keyboard.GetComponent<Keyboard> ().Racer2.transform.localPosition = Keyboard.GetComponent<Keyboard> ().Racer2Position;
		Keyboard.GetComponent<Keyboard> ().Home = false;
		Keyboard.GetComponent<Keyboard> ().MoveFoward = false;
		Keyboard.GetComponent<Keyboard> ().answerString = "";
		Keyboard.GetComponent<Keyboard> ().BossHealth.GetComponent<HealthScript> ().SetHealth (4);
		Keyboard.GetComponent<Keyboard> ().PlayerHealth.GetComponent<HealthScript> ().SetHealth (4);
		Case_Control.index = 0;
		if (Keyboard.GetComponent<Keyboard> ().CapsLock != true)
			Keyboard.GetComponent<Keyboard> ().Shift ();
		EndMenu.SetActive (false);
		Keyboard.GetComponent<Keyboard> ().chestwin = Random.Range (0, 6);
		Keyboard.GetComponent<Keyboard> ().wintreasue = false;
	}
	void Update () {
		Keyboard.GetComponent<Keyboard> ().KeyBoardInput ();
	}
}