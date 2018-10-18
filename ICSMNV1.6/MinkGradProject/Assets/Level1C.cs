using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level1C: MonoBehaviour {

    public GameObject NameData;
	public Text[] AnswersText;
	public Text AnswerHint;
	public int answerButton = 0;
	int answerIndex = 8;
	public GameObject Tutorial;
	bool gameStart = false;
	// NEW STUFF IM WORKING WITH
	public string[] NamesChosen;
	public Animator ButtonAnim1;
    public List<string> Names;
    public string answer;

    void Start()
    {
        NameData = FindObjectOfType<LevelManager>().gameObject;

        UIManager.instance.StartGame();
        UIManager.instance.mode = UIManager.subLevels1.Level1C;

        int LoginNumber = PlayerPrefs.GetInt("loginNumber");
        switch (LoginNumber)
        {
            case 1:
                {
                    AnswerHint.text = PlayerPrefs.GetString("firstName");
                    NameData.GetComponentInParent<NameData>().AddName(PlayerPrefs.GetString("firstName"));
                    break;
                }
            case 2:
                {
                    AnswerHint.text = PlayerPrefs.GetString("secondName");
                    NameData.GetComponentInParent<NameData>().AddName(PlayerPrefs.GetString("secondName"));
                    break;
                }
            case 3:
                {
                    AnswerHint.text = PlayerPrefs.GetString("thirdName");
                    NameData.GetComponentInParent<NameData>().AddName(PlayerPrefs.GetString("thirdName"));
                    break;
                }
            case 4:
                {
                    AnswerHint.text = PlayerPrefs.GetString("fourthName");
                    NameData.GetComponentInParent<NameData>().AddName(PlayerPrefs.GetString("fourthName"));
                    break;
                }
        }



        Names = NameData.GetComponent<NameData>().data;

        for (int i = 0; i < Names.Count; i++)
        {
            //Names [i] =	Names [i].ToUpper ();
            if (AnswerHint.text == Names[i])
            {
                answerIndex = i;
                AnswersText[answerButton].text = Names[answerIndex];
                answer = AnswersText[answerButton].text;
            }
        }

        for (int i = 0; i < AnswersText.Length; i++)
        {
            if (AnswersText[i].text.Length >= 5)
                AnswersText[i].transform.localScale = new Vector3(.80f, .80f, 1.0f);
            else
                AnswersText[i].transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
    }

    public void Choice1()
    {

        if (answerButton == 0)
        {
            NextLetter();
            UIManager.instance.ScorePoints();
            for (int i = 0; i < FindObjectsOfType<BoatHanlder>().Length; i++)
                FindObjectsOfType<BoatHanlder>()[i].ReRouteBoat();
        }
        else
        {
          //  Miss++;
            LevelManager.instance.CheckAnswer(false, UIManager.instance.heartsAmount, UIManager.instance.seahorseAnim);
            gameStart = false;
            if (LevelManager.instance.correctAnswerPoints < 3)
            {
                NextLetter();
                for (int i = 0; i < FindObjectsOfType<BoatHanlder>().Length; i++)
                    FindObjectsOfType<BoatHanlder>()[i].ReRouteBoat();
            }
        }
    }
    public void Choice2()
    {

        if (answerButton == 1)
        {
            NextLetter();
            UIManager.instance.ScorePoints();
            for (int i = 0; i < FindObjectsOfType<BoatHanlder>().Length; i++)
                FindObjectsOfType<BoatHanlder>()[i].ReRouteBoat();
        }
        else
        {
            //Miss++;
            LevelManager.instance.CheckAnswer(false, UIManager.instance.heartsAmount, UIManager.instance.seahorseAnim);
            gameStart = false;
            if (LevelManager.instance.correctAnswerPoints < 3)
            {
                NextLetter();
                for (int i = 0; i < FindObjectsOfType<BoatHanlder>().Length; i++)
                    FindObjectsOfType<BoatHanlder>()[i].ReRouteBoat();
            }
        }
    }
    public void Choice3()
    {

        if (answerButton == 2)
        {
            NextLetter();
            UIManager.instance.ScorePoints();
            for (int i = 0; i < FindObjectsOfType<BoatHanlder>().Length; i++)
                FindObjectsOfType<BoatHanlder>()[i].ReRouteBoat();
        }
        else
        {
           // Miss++;
            LevelManager.instance.CheckAnswer(false, UIManager.instance.heartsAmount, UIManager.instance.seahorseAnim);
            gameStart = false;
            if (LevelManager.instance.correctAnswerPoints < 3)
            {
                NextLetter();
                for (int i = 0; i < FindObjectsOfType<BoatHanlder>().Length; i++)
                    FindObjectsOfType<BoatHanlder>()[i].ReRouteBoat();
            }
        }
    }
    public void Choice4()
    {

        if (answerButton == 3)
        {
            NextLetter();
            UIManager.instance.ScorePoints();
            for (int i = 0; i < FindObjectsOfType<BoatHanlder>().Length; i++)
                FindObjectsOfType<BoatHanlder>()[i].ReRouteBoat();
        }
        else
        {
            //Miss++;
            LevelManager.instance.CheckAnswer(false, UIManager.instance.heartsAmount, UIManager.instance.seahorseAnim);
            gameStart = false;
            if (LevelManager.instance.correctAnswerPoints < 3)
            {
                NextLetter();
                for (int i = 0; i < FindObjectsOfType<BoatHanlder>().Length; i++)
                    FindObjectsOfType<BoatHanlder>()[i].ReRouteBoat();
            }
        }
    }

    public void NextLetter(){
		PlaceAnswer ();

	}

	public void Reset (){
	//	ScoreText.text = "00000";
	//	Score = 0;
		//Multi = 1;
		//answerIndex = 8;
      //  timetext.text = "1:00";
        AnswerHint.text = Names[answerIndex];
		answerButton = Random.Range (0, 4);
		AnswersText[answerButton].text = Names[answerIndex];
		//	SetOtherButtons ();
		//Total = 0;
		//timer = 60.0f;
		//minutes = 1;
		//seconds = 0;
		//Miss = 0;
		PlaceAnswer ();
	}

	public void PlaceAnswer(){
        NamesChosen = new string[4];
        answerButton = Random.Range(0, 4);

        AnswersText[answerButton].text = Names[answerIndex];
        answer = AnswersText[answerButton].text;

        for (int i = 0; i < AnswersText.Length; i++)
        {
            if (AnswersText[i].text.Length >= 5)
                AnswersText[i].transform.localScale = new Vector3(.80f, .80f, 1.0f);
            else
                AnswersText[i].transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
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
                while (Used)
                {
                    wrongName = Random.Range(0, Names.Count);
                    //Checks to see if wrong names chosen equals to answer, if it does, choose again
                    while (Names[wrongName] == answer)
                        wrongName = Random.Range(0, Names.Count);

                    Used = false;
                    for (int j = 0; j < NamesChosen.Length; j++)
                    {
                        if (Names[wrongName] == NamesChosen[j])
                        {
                            Used = true;
                            break;
                        }
                    }
                    if (Used != true)
                    {
                        NamesChosen[ChosenIndex] = Names[wrongName];
                        AnswersText[i].text = Names[wrongName];
                        ChosenIndex++;
                        break;
                    }



                }

            }
        }
    }

}
