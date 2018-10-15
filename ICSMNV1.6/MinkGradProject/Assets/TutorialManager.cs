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
    public string[] LetterChosen;
    public string answer;

	// Use this for initialization
	void Start ()
    {
		AnswerHint.text = Letters[answerIndex];
		answerButton = Random.Range (0, 4);
		AnswersText[answerButton].text = Letters[answerIndex];
		SetOtherButtons (answerButton);

        UIManager.instance.HUD.SetActive(true);
        UIManager.instance.HUD.transform.GetChild(1).gameObject.SetActive(false);

    }

	public void PopSound(){
		SoundManagement.TriggerEvent ("PlayPop");
	}

	public void ScorePoints()
    {
        UIManager.instance.score += 1;
        UIManager.instance.scoreText.text = UIManager.instance.score.ToString ();
        UIManager.instance.total++;

        LevelManager.instance.CheckAnswer(true, true, UIManager.instance.heartsAmount, UIManager.instance.seahorseAnim);


    }
	
	public void Choice1(){
        if (answerButton == 0)
        {
            NextLetter();
            ScorePoints();
        }
        else
        {
            LevelManager.instance.CheckAnswer(false, true, UIManager.instance.heartsAmount, UIManager.instance.seahorseAnim);
            if (LevelManager.instance.correctAnswerPoints < 25)
                SetButtons();
        }
    }

	public void Choice2(){
        if (answerButton == 1)
        {
            NextLetter();
            ScorePoints();
        }
        else
        {
            LevelManager.instance.CheckAnswer(false, true, UIManager.instance.heartsAmount, UIManager.instance.seahorseAnim);
            if (LevelManager.instance.correctAnswerPoints < 25)
                SetButtons();
        }
    }

	public void Choice3(){
        if (answerButton == 2)
        {
            NextLetter();
            ScorePoints();
        }
        else
        {
            LevelManager.instance.CheckAnswer(false, true, UIManager.instance.heartsAmount, UIManager.instance.seahorseAnim);
            if (LevelManager.instance.correctAnswerPoints < 25)
                SetButtons();
        }
    }

	public void Choice4(){
        if (answerButton == 3)
        {
            NextLetter();
            ScorePoints();
        }
        else
        {
            LevelManager.instance.CheckAnswer(false, true, UIManager.instance.heartsAmount, UIManager.instance.seahorseAnim);
            if (LevelManager.instance.correctAnswerPoints < 25)
                SetButtons();
        }
    }

	public void Choice5(){
        if (answerButton == 4)
        {
            NextLetter();
            ScorePoints();
        }
        else
        {
            LevelManager.instance.CheckAnswer(false, true, UIManager.instance.heartsAmount, UIManager.instance.seahorseAnim);
            if(LevelManager.instance.correctAnswerPoints < 25)
            SetButtons();
        }
    }

	public void NextLetter(){

		if(answerIndex != 25)
		answerIndex++;
		AnswerHint.text = Letters[answerIndex];
        SetButtons();
	}

    public void SetButtons()
    {
        LetterChosen = new string[5];
        answerButton = Random.Range(0, 5);

        AnswersText[answerButton].text = Letters[answerIndex];
        answer = AnswersText[answerButton].text;

        int ChosenIndex = 0;
        for (int i = 0; i <= 4; i++)
        {

            if (answerButton == i)
            {
                LetterChosen[ChosenIndex] = Letters[answerIndex];
                ChosenIndex++;

            }
            else
            {

                bool Used = true;
                int wrongName = 0;
                while (Used)
                {
                    wrongName = Random.Range(0, Letters.Length);
                    //Checks to see if wrong names chosen equals to answer, if it does, choose again
                    while (Letters[wrongName] == answer)
                        wrongName = Random.Range(0, Letters.Length);

                    Used = false;
                    for (int j = 0; j < LetterChosen.Length; j++)
                    {
                        if (Letters[wrongName] == LetterChosen[j])
                        {
                            Used = true;
                            break;
                        }
                    }
                    if (Used != true)
                    {
                        LetterChosen[ChosenIndex] = Letters[wrongName];
                        AnswersText[i].text = Letters[wrongName];
                        ChosenIndex++;
                        break;
                    }



                }

            }
        }
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
		answerIndex = 0;
		AnswerHint.text = Letters[answerIndex];
		answerButton = Random.Range (0, 4);
		AnswersText[answerButton].text = Letters[answerIndex];
		SetOtherButtons (answerButton);

	}
}


