using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour {
	public Text[] AnswersText;
	public string[] Letters;
	public Text AnswerHint;
	public int answerButton;
	public int answerIndex = 0;
	int Score = 0;
	public Text ScoreText;
	int Multi = 1;
	int Miss = 0;
	int Total = 0;
	public GameObject Tutorial;
	public GameObject MainMenu;
	public List<GameObject> Misses;

	// Use this for initialization
	void Start () {
		AnswerHint.text = Letters[answerIndex];
		answerButton = Random.Range (0, 4);
		AnswersText[answerButton].text = Letters[answerIndex];
		SetOtherButtons (answerButton);
	}
	public void PopSound(){
		SoundManagement.TriggerEvent ("PlayPop");
	}
	public void ScorePoints(){
		Score += 1 * Multi;
		ScoreText.text = Score.ToString ();
		Total++;
		if (Total == 26) {
			int LoginNumber = PlayerPrefs.GetInt ("loginNumber");
			switch(LoginNumber){
			case 1:{
					PlayerPrefs.SetInt ("firstPlay1", 1);
					break;
				}
			case 2:
				{
					PlayerPrefs.SetInt ("firstPlay2", 1);
					break;
				}
			case 3:
				{
					PlayerPrefs.SetInt ("firstPlay3", 1);
					break;
				}
			case 4:
				{
					PlayerPrefs.SetInt ("firstPlay4", 1);
					break;
				}
			}
            Tutorial.SetActive(false);
            SceneManager.LoadScene("MainMenu");
			

		}
	}
	public void Choice1(){
		if (answerButton == 0) {
			NextLetter ();
			ScorePoints ();
			Multi++;
		} else {
			Multi = 1;
			Miss++;
			if (Miss > 0)
				Misses [0].SetActive (false);
			else
				Misses [0].SetActive (true);
			if (Miss > 1)
				Misses [1].SetActive (false);
			else
				Misses [1].SetActive (true);
			if (Miss > 2)
				Misses [2].SetActive (false);
			else
				Misses [2].SetActive (true);
			if (Miss == 3)
				Reset ();	
		}
	}
	public void Choice2(){
		if (answerButton == 1) {
			NextLetter ();
			ScorePoints ();
			Multi++;
		} else {
			Multi = 1;
			Miss++;
			if (Miss > 0)
				Misses [0].SetActive (false);
			else
				Misses [0].SetActive (true);
			if (Miss > 1)
				Misses [1].SetActive (false);
			else
				Misses [1].SetActive (true);
			if (Miss > 2)
				Misses [2].SetActive (false);
			else
				Misses [2].SetActive (true);
			if (Miss == 3)
				Reset ();	
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
			if (Miss > 0)
				Misses [0].SetActive (false);
			else
				Misses [0].SetActive (true);
			if (Miss > 1)
				Misses [1].SetActive (false);
			else
				Misses [1].SetActive (true);
			if (Miss > 2)
				Misses [2].SetActive (false);
			else
				Misses [2].SetActive (true);
			if (Miss == 3)
				Reset ();	
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
			if (Miss > 0)
				Misses [0].SetActive (false);
			else
				Misses [0].SetActive (true);
			if (Miss > 1)
				Misses [1].SetActive (false);
			else
				Misses [1].SetActive (true);
			if (Miss > 2)
				Misses [2].SetActive (false);
			else
				Misses [2].SetActive (true);
			if (Miss == 3)
				Reset ();	
		}
	}
	public void Choice5(){
		if (answerButton == 4) {
			NextLetter ();
			ScorePoints ();
			Multi++;
		} else {
			Multi = 1;
			Miss++;
			if (Miss > 0)
				Misses [0].SetActive (false);
			else
				Misses [0].SetActive (true);
			if (Miss > 1)
				Misses [1].SetActive (false);
			else
				Misses [1].SetActive (true);
			if (Miss > 2)
				Misses [2].SetActive (false);
			else
				Misses [2].SetActive (true);
			if (Miss == 3)
				Reset ();	
		}
	}
	public void NextLetter(){

		if(answerIndex != 25)
		answerIndex++;
		AnswerHint.text = Letters[answerIndex];
		answerButton = Random.Range (0, 4);
		AnswersText[answerButton].text = Letters[answerIndex];
		SetOtherButtons (answerButton);

	}
	public void SetOtherButtons(int rightanswer){
		if (rightanswer != 0) {
			int randomletter = Random.Range (0, 25);
				while(randomletter == answerIndex)
					randomletter = Random.Range(0,25);
				AnswersText[0].text = Letters[randomletter];
		}
		if (rightanswer != 1) {
			int randomletter = Random.Range (0, 25);
			while(randomletter == answerIndex)
				randomletter = Random.Range(0,25);
			AnswersText[1].text = Letters[randomletter];
		}
		if (rightanswer != 2) {
			int randomletter = Random.Range (0, 25);
			while(randomletter == answerIndex)
				randomletter = Random.Range(0,25);
			AnswersText[2].text = Letters[randomletter];
		}
		if (rightanswer != 3) {
			int randomletter = Random.Range (0, 25);
			while(randomletter == answerIndex)
				randomletter = Random.Range(0,25);
			AnswersText[3].text = Letters[randomletter];
		}
		if (rightanswer != 4) {
			int randomletter = Random.Range (0, 25);
			while(randomletter == answerIndex)
				randomletter = Random.Range(0,25);
			AnswersText[4].text = Letters[randomletter];
		}
	}
	void Reset (){
		ScoreText.text = "00000";
		Score = 0;
		Multi = 1;
		answerIndex = 0;
		AnswerHint.text = Letters[answerIndex];
		answerButton = Random.Range (0, 4);
		AnswersText[answerButton].text = Letters[answerIndex];
		SetOtherButtons (answerButton);
		Total = 0;
		Miss = 0;
		for (int i = 0; i < Misses.Count; i++)
			Misses [i].SetActive (true);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
