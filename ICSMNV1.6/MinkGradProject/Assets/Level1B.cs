using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level1B : MonoBehaviour {
	
	public GameObject StartMenu;
	public GameObject EndMenu;
	public Text[] AnswersText;
	public string[] Names;
	public Text AnswerHint;
	public int answerButton = 0;
	int answerIndex = 8;
	public Text timetext;
	float timer = 60.0f;
	float minutes = 1;
	float seconds = 0;
	int Score = 0;
	public Text ScoreText;
	int Multi = 1;
	int Miss = 0;
	int Total = 0;
	public GameObject Tutorial;
	public GameObject MainMenu;
    public GameObject PauseMenu;
    bool gameStart = false;
	// NEW STUFF IM WORKING WITH
	public string[] NamesChosen;
    public Animator ButtonAnim1;
	// Use this for initialization
	public void RestartGame(){
		EndMenu.SetActive (false);
		Reset ();
		gameStart = true;
	}

	void Start () {
		int LoginNumber = PlayerPrefs.GetInt("loginNumber");
		switch(LoginNumber){
		case 1:{
				AnswerHint.text =  PlayerPrefs.GetString ("firstName");
				break;
			}
		case 2:
			{
				AnswerHint.text =  PlayerPrefs.GetString ("secondName");
				break;
			}
		case 3:
			{
				AnswerHint.text =  PlayerPrefs.GetString ("thirdName");
				break;
			}
		case 4:
			{
				AnswerHint.text =  PlayerPrefs.GetString ("fourthName");
				break;
			}
		}

	}
	public void ScorePoints(){
		Score += 100 * Multi;
		ScoreText.text = Score.ToString ();
		Total++;
	}

	public void Choice1(){
		if (answerButton == 0) {
			NextLetter ();
			ScorePoints ();
			Multi++;
		} else {
			Multi = 1;
			Miss++;
            SoundManagement.TriggerEvent("PlayWrongAnswer");
            LevelManager.instance.VibrateOnHandHeld();

            if (Miss == 3){
                UIManager.instance.GameOver();
                gameStart = false;
			}
		}
	}
	public void Choice2(){
		ButtonAnim1.SetBool ("Clicked", true);
		if (answerButton == 1) {
			NextLetter ();
			ScorePoints ();
			Multi++;
		} else {
			Multi = 1;
			Miss++;
            SoundManagement.TriggerEvent("PlayWrongAnswer");
            LevelManager.instance.VibrateOnHandHeld();

            if (Miss == 3){
                UIManager.instance.GameOver();
                gameStart = false;
			}

		}
	}
	public void Choice3(){
		if (answerButton == 2) {
			NextLetter ();
			ScorePoints ();
			Multi++;
		} else {
			Multi = 1;
			Miss++;
            SoundManagement.TriggerEvent("PlayWrongAnswer");
            LevelManager.instance.VibrateOnHandHeld();

            if (Miss == 3){
                UIManager.instance.GameOver();
                gameStart = false;
			}
		}
	}
	public void Choice4(){
		if (answerButton == 3) {
			NextLetter ();
			ScorePoints ();
			Multi++;
		} else {
			Multi = 1;
			Miss++;
            SoundManagement.TriggerEvent("PlayWrongAnswer");
            LevelManager.instance.VibrateOnHandHeld();

            if (Miss == 3) {
                UIManager.instance.GameOver();
                gameStart = false;
			}
		}
	}

	public void NextLetter(){
		PlaceAnswer ();
		//	RemoveFirst ();
		//	SetOtherButtons ();

	}

	/* public void SetOtherButtons(){
		if (answerButton != 0) {
			int randomletter = Random.Range (0,Names.Length - 1);
			while(randomletter == answerIndex)
				randomletter = Random.Range(0,Names.Length - 1);
			AnswersText[0].text = Names[randomletter];
		}
		if (answerButton != 1) {
			int randomletter = Random.Range (0, Names.Length - 1);
			while(randomletter == answerIndex)
				randomletter = Random.Range(0,Names.Length - 1);
			AnswersText[1].text = Names[randomletter];
		}
		if (answerButton != 2) {
			int randomletter = Random.Range (0, Names.Length - 1);
			while(randomletter == answerIndex)
				randomletter = Random.Range(0,Names.Length - 1);
			AnswersText[2].text = Names[randomletter];
		}
		if (answerButton != 3) {
			int randomletter = Random.Range (0, Names.Length - 1);
			while(randomletter == answerIndex)
				randomletter = Random.Range(0,Names.Length - 1);
			AnswersText[3].text = Names[randomletter];
		}
	}
	*/

	public void Reset (){
		ScoreText.text = "00000";
		Score = 0;
		Multi = 1;
		answerIndex = 8;
        timetext.text = "1:00";
        AnswerHint.text = Names[answerIndex];
		answerButton = Random.Range (0, 4);
		AnswersText[answerButton].text = Names[answerIndex];
		//	SetOtherButtons ();
		Total = 0;
		timer = 60.0f;
		minutes = 1;
		seconds = 0;
		Miss = 0;
		PlaceAnswer ();
	}
	public void StartGame(){
		StartMenu.SetActive (false);
		PlaceAnswer();
		gameStart = true;
	}

    public void PauseGame()
    {
        PauseMenu.SetActive(true);
        gameStart = false;
    }
    public void UnPauseGame()
    {
        PauseMenu.SetActive(false);
        gameStart = true;
    }

    public void PlaceAnswer(){
		NamesChosen = new string[4];
		answerButton = Random.Range (0, 4);
		AnswersText[answerButton].text = Names[answerIndex];
		int ChosenIndex = 0;
		for (int i = 0; i <= 3; i++) 
		{

			if (answerButton == i) 
			{
				NamesChosen[ChosenIndex] = Names[answerIndex];
				ChosenIndex++;

			} 
			else 
			{

				bool Used = true;
				int wrongName = 0;
				while(Used)
				{
					wrongName =	Random.Range (0, 8);
					Used = false;
					for (int j = 0; j < NamesChosen.Length - 1; j++) 
					{
						if (Names [wrongName] == NamesChosen [j]) {
							Used = true;
							break;
						}
					}
					if (Used != true) {
						NamesChosen[ChosenIndex] = Names[wrongName];
						AnswersText[i].text = Names[wrongName];
						ChosenIndex++;
						break;
					}



				}

			}
		}
	}

	// Update is called once per frame
	void Update () {
		if (UIManager.instance.gameStart) {

			if (timer > 0) {
				timer -= Time.deltaTime;
				if (timer <= 0)
					timer = 0;
			} else if (timer <= 0) {
                UIManager.instance.GameOver();

            }
			minutes = Mathf.Floor (timer / 60);
			seconds = timer % 60;

			if(Mathf.RoundToInt (seconds) < 10 )
				timetext.text =  Mathf.RoundToInt (minutes).ToString() + ":0" +  Mathf.RoundToInt (seconds).ToString() ;
			else
				timetext.text =  Mathf.RoundToInt (minutes).ToString() + ":" + Mathf.RoundToInt (seconds).ToString();
		}
	}
}
