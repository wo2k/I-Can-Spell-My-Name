using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Level1A : MonoBehaviour {
	public GameObject NameData;
	public GameObject StartMenu;
	public GameObject EndMenu;
	public GameObject PauseMenu;
	public Text[] AnswersText;
	public List<string> Names;
	public GameObject[] Misses;
	public Text AnswerHint;
	public int answerButton = 0;
	public int answerIndex = 8;

	//int Multi = 1;
	public int Miss = 0;

	public GameObject Tutorial;
	public GameObject MainMenu;
	public bool gameStart = false;
    public string answer;

	// NEW STUFF IM WORKING WITH
	public string[] NamesChosen;


	void Start () {

        for (int i = 0; i < 4; i++)
        {
            if (LevelManager.instance.m_Difficulty == (LevelManager.Difficulty)i)
            {
                switch (i)
                {
                    case 0:
                        AnswersText[3].GetComponentInParent<Image>().sprite = AnswersText[0].GetComponentInParent<Image>().sprite;
                        AnswersText[1].GetComponentInParent<Image>().sprite = AnswersText[2].GetComponentInParent<Image>().sprite;
                        UIManager.instance.heartsAmount = 3;
                        break;
                    case 1:
                        UIManager.instance.heartsAmount = 3;
                        break;
                    case 2:
                        UIManager.instance.heartsAmount = 3;
                        break;
                    case 3:
                        UIManager.instance.heartsAmount = 3;
                        break;
                }
            }
        }

        NameData = FindObjectOfType<LevelManager>().gameObject;

        UIManager.instance.StartGame();
        UIManager.instance.mode = UIManager.subLevels1.Level1A;

    int LoginNumber = PlayerPrefs.GetInt("loginNumber");
		switch(LoginNumber){
		case 1:{
				AnswerHint.text =  PlayerPrefs.GetString ("firstName");
				NameData.GetComponentInParent<NameData> ().AddName (PlayerPrefs.GetString ("firstName"));
				break;
			}
		case 2:
			{
				AnswerHint.text =  PlayerPrefs.GetString ("secondName");
                    NameData.GetComponentInParent<NameData>().AddName (PlayerPrefs.GetString ("secondName"));
				break;
			}
		case 3:
			{
				AnswerHint.text =  PlayerPrefs.GetString ("thirdName");
                    NameData.GetComponentInParent<NameData>().AddName (PlayerPrefs.GetString ("thirdName"));
				break;
			}
		case 4:
			{
				AnswerHint.text =  PlayerPrefs.GetString ("fourthName");
                    NameData.GetComponentInParent<NameData>().AddName (PlayerPrefs.GetString ("fourthName"));
				break;
			}
		}

			
		
		Names = NameData.GetComponent<NameData> ().data;

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

    public void RemoveNamesFromList()
    {
        for(int i = 0; i < Names.Count; i++)
        {
            for(int j = 0; j < NamesChosen.Length; j++)
            {
                if (Names[i] == NamesChosen[j])
                    Names.Remove(Names[i]);
            }
        }
    }


	public void Choice1(){

        if (answerButton == 0)
        {
            NextLetter();
            ScorePoints();
        }
        else
        {
            switch (LevelManager.instance.m_Difficulty)
            {
                case LevelManager.Difficulty.Hard:
                    UIManager.instance.DeductTime(5);
                    break;
                case LevelManager.Difficulty.Genius:
                    UIManager.instance.DeductTime(5);
                    break;
            }
            
            Miss++;
            LevelManager.instance.CheckAnswer(false, UIManager.instance.heartsAmount, UIManager.instance.seahorseAnim);
            gameStart = false;
            if (LevelManager.instance.correctAnswerPoints < 3)
                NextLetter();
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
            switch (LevelManager.instance.m_Difficulty)
            {
                case LevelManager.Difficulty.Hard:
                    UIManager.instance.DeductTime(5);
                    break;
                case LevelManager.Difficulty.Genius:
                    UIManager.instance.DeductTime(5);
                    break;
            }
            Miss++;
            LevelManager.instance.CheckAnswer(false, UIManager.instance.heartsAmount, UIManager.instance.seahorseAnim);
            gameStart = false;
            if (LevelManager.instance.correctAnswerPoints < 3)
                NextLetter();
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
            switch (LevelManager.instance.m_Difficulty)
            {
                case LevelManager.Difficulty.Hard:
                    UIManager.instance.DeductTime(5);
                    break;
                case LevelManager.Difficulty.Genius:
                    UIManager.instance.DeductTime(5);
                    break;
            }
            Miss++;
            LevelManager.instance.CheckAnswer(false, UIManager.instance.heartsAmount, UIManager.instance.seahorseAnim);
            gameStart = false;
            if (LevelManager.instance.correctAnswerPoints < 3)
                NextLetter();
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
            switch (LevelManager.instance.m_Difficulty)
            {
                case LevelManager.Difficulty.Hard:
                    UIManager.instance.DeductTime(5);
                    break;
                case LevelManager.Difficulty.Genius:
                    UIManager.instance.DeductTime(5);
                    break;
            }
            Miss++;
            LevelManager.instance.CheckAnswer(false, UIManager.instance.heartsAmount, UIManager.instance.seahorseAnim);
            gameStart = false;
            if (LevelManager.instance.correctAnswerPoints < 3)
                NextLetter();
        }
	}

	public void NextLetter()
    {
		PlaceAnswer ();
	}

    void ScorePoints()
    {
        switch (LevelManager.instance.m_Difficulty)
        {
            case LevelManager.Difficulty.Easy:
                UIManager.instance.ScorePoints(true);
                break;

            case LevelManager.Difficulty.Normal:
                UIManager.instance.ScorePoints(true);
                break;

            case LevelManager.Difficulty.Hard:
                UIManager.instance.ScorePoints(5);
                break;

            case LevelManager.Difficulty.Genius:
                UIManager.instance.ScorePoints(5);
                break;
        }
    }

	public void Reset ()
    {
        for (int i = 0; i < Names.Count; i++)
        {
          //  Names[i] = Names[i].ToUpper();
            if (AnswerHint.text == Names[i])
                answerIndex = i;
        }

        //answerIndex = 8;
        AnswerHint.text = Names[answerIndex];
		answerButton = Random.Range (0, 4);
		AnswersText[answerButton].text = Names[answerIndex];

		Miss = 0;
		PlaceAnswer ();
	
	 //		Misses [0].SetActive (false);
		//	Misses [1].SetActive (false);
			//Misses [2].SetActive (false);
	}
		
	public void PlaceAnswer(){
		NamesChosen = new string[4];
		answerButton = Random.Range (0, 4);

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
				while(Used)
				{
					wrongName =	Random.Range (0, Names.Count);
                    //Checks to see if wrong names chosen equals to answer, if it does, choose again
                    while(Names[wrongName] == answer)
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
                            
                            switch(LevelManager.instance.m_Difficulty)
                        {
                            case LevelManager.Difficulty.Hard:
                                int activate = Random.Range(0, 2);
                                if (activate == 0)
                                    AnswersText[i].text = LevelManager.instance.ShuffleCharInName(answer);
                                break;
                            case LevelManager.Difficulty.Genius:
                                break;
                        }

						break;
					}
						
					
				
				 }

			}
		}
       
    }

	// Update is called once per frame
	void Update () {
					
	}
}
