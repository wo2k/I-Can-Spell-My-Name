using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level2B : MonoBehaviour {
	public GameObject Keyboard;

	public string PlayersName;
	public string AnswerName;
	public bool gameStart = false;
	public Text timetext;
	float timer = 45.0f;
	float minutes = 0;
	float seconds = 0;
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
        UIManager.instance.mode2 = UIManager.subLevels2.Level2B;
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
		Keyboard.GetComponent<Keyboard> ().SetUpName (0.6f, false);
	}

	// Update is called once per frame
	public void ScorePoints(){
		Score += 100 * Multi;
		ScoreText.text = Score.ToString ();
		Total++;
	}
	public void Win () {
		EndMenu.SetActive (true);
	}
	void Update () {
		/*if (gameStart) {
			if (timer > 0) {
				timer -= Time.deltaTime;
				if (timer <= 0)
					timer = 0;
			} else if (timer <= 0) {
				this.GetComponent<Win> ().LoseState ();

			}
			minutes = Mathf.Floor (timer / 60);
			seconds = timer % 60;

			if (Mathf.RoundToInt (seconds) < 10)
				timetext.text = Mathf.RoundToInt (minutes).ToString () + ":0" + Mathf.RoundToInt (seconds).ToString ();
			else
				timetext.text = Mathf.RoundToInt (minutes).ToString () + ":" + Mathf.RoundToInt (seconds).ToString ();

		}*/
		Keyboard.GetComponent<Keyboard> ().KeyBoardInput ();

	}

	public void Reset(){
		int count =	Keyboard.GetComponent<Keyboard> ().LetterBlocks.Count;
		for (int i = 0; i < count; i++)
			Keyboard.GetComponent<Keyboard> ().LetterBlocks [i].GetComponent<LetterPlacement> ().RemoveLetter ();

		Keyboard.GetComponent<Keyboard> ().answerString = "";
		Case_Control.index = 0;
		if (Keyboard.GetComponent<Keyboard> ().CapsLock != true)
			Keyboard.GetComponent<Keyboard> ().Shift ();
		 timer = 45.0f;
		 minutes = 0;
		seconds = 0;
		 Score = 0;

		Multi = 1;
		 //Miss = 0;
		 Total = 0;
		StartMenu.SetActive (true);
	}
	public void Restart(){
		int count =	Keyboard.GetComponent<Keyboard> ().LetterBlocks.Count;
		for (int i = 0; i < count; i++)
			Keyboard.GetComponent<Keyboard> ().LetterBlocks [i].GetComponent<LetterPlacement> ().RemoveLetter ();

		Keyboard.GetComponent<Keyboard> ().answerString = "";
		Case_Control.index = 0;
		timer = 45.0f;
		minutes = 0;
		seconds = 0;
		Score = 0;

		Multi = 1;
		//Miss = 0;
		Total = 0;
		if (Keyboard.GetComponent<Keyboard> ().CapsLock != true)
			Keyboard.GetComponent<Keyboard> ().Shift ();
		EndMenu.SetActive (false);
	}
}