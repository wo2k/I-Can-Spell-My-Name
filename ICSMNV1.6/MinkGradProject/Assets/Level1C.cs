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
    public List<BoatHanlder> m_Boats = new List<BoatHanlder>();
    public int[] siblingIndex;
    public GameObject m_Waves;
    public bool[] waveLaneTaken;
    public int[] leftBoat;
    public List<int> rightBoat = new List<int>();


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

        NextLetter();
    }

    public void Choice1()
    {

        if (answerButton == 0)
        {
            NextLetter();
            UIManager.instance.ScorePoints();
            rightBoat.Clear();
            for (int i = 0; i < m_Boats.Count; i++)
            {
                m_Boats[i].ReRouteBoat();
                m_Boats[i].RestartAnimation();
            }
        }
        else
        {
          //  Miss++;
            LevelManager.instance.CheckAnswer(false, UIManager.instance.heartsAmount, UIManager.instance.seahorseAnim);
            gameStart = false;
            if (LevelManager.instance.correctAnswerPoints < 3)
            {
                NextLetter();
                rightBoat.Clear();
                for (int i = 0; i < m_Boats.Count; i++)
                {
                    m_Boats[i].ReRouteBoat();
                    m_Boats[i].RestartAnimation();
                }
            }
        }
    }
    public void Choice2()
    {

        if (answerButton == 1)
        {
            NextLetter();
            UIManager.instance.ScorePoints();
            rightBoat.Clear();
            for (int i = 0; i < m_Boats.Count; i++)
            {
                m_Boats[i].ReRouteBoat();
                m_Boats[i].RestartAnimation();
            }
        }
        else
        {
            //Miss++;
            LevelManager.instance.CheckAnswer(false, UIManager.instance.heartsAmount, UIManager.instance.seahorseAnim);
            gameStart = false;
            if (LevelManager.instance.correctAnswerPoints < 3)
            {
                NextLetter();
                rightBoat.Clear();
                for (int i = 0; i < m_Boats.Count; i++)
                {
                    m_Boats[i].ReRouteBoat();
                    m_Boats[i].RestartAnimation();
                }
            }
        }
    }
    public void Choice3()
    {

        if (answerButton == 2)
        {
            NextLetter();
            UIManager.instance.ScorePoints();
            rightBoat.Clear();
            for (int i = 0; i < m_Boats.Count; i++)
            {
                m_Boats[i].ReRouteBoat();
                m_Boats[i].RestartAnimation();
            }
        }
        else
        {
           // Miss++;
            LevelManager.instance.CheckAnswer(false, UIManager.instance.heartsAmount, UIManager.instance.seahorseAnim);
            gameStart = false;
            if (LevelManager.instance.correctAnswerPoints < 3)
            {
                NextLetter();
                rightBoat.Clear();
                for (int i = 0; i < m_Boats.Count; i++)
                {
                    m_Boats[i].ReRouteBoat();
                    m_Boats[i].RestartAnimation();
                }
            }
        }
    }
    public void Choice4()
    {

        if (answerButton == 3)
        {
            NextLetter();
            UIManager.instance.ScorePoints();
            rightBoat.Clear();
            for (int i = 0; i < m_Boats.Count; i++)
            {
                m_Boats[i].ReRouteBoat();
                m_Boats[i].RestartAnimation();
            }
        }
        else
        {
            //Miss++;
            LevelManager.instance.CheckAnswer(false, UIManager.instance.heartsAmount, UIManager.instance.seahorseAnim);
            gameStart = false;
            if (LevelManager.instance.correctAnswerPoints < 3)
            {
                NextLetter();
                rightBoat.Clear();
                for (int i = 0; i < m_Boats.Count; i++)
                {
                    m_Boats[i].ReRouteBoat();
                    m_Boats[i].RestartAnimation();
                }
            }
        }
    }

    #region SetWaves
    public void SetWaveLane(string boatDir, int boatNumber, string boatName)
    {
      //  for (int i = 0; i < m_Boats.Count; i++)
            //m_Boats[i].transform.parent.SetParent(m_Waves.transform);

        switch (boatDir)
        {
            case "Left":
                switch (boatNumber)
                {
                    case 0:
                        if (waveLaneTaken[0] == false)
                        {
                            switch (boatName)
                            {
                                case "Boat1":
                                    siblingIndex[0] = 1;
                                    //m_Boats[0].transform.parent.SetSiblingIndex(siblingIndex[0]);
                                    leftBoat[0] = boatNumber;
                                    waveLaneTaken[0] = true;
                                    break;
                                case "Boat2":
                                    siblingIndex[1] = 1;
                                    //m_Boats[1].transform.parent.SetSiblingIndex(siblingIndex[1]);
                                    leftBoat[1] = boatNumber;
                                    waveLaneTaken[0] = true;
                                    break;
                                case "Boat3":
                                    siblingIndex[2] = 1;
                                    //m_Boats[2].transform.parent.SetSiblingIndex(siblingIndex[2]);
                                    leftBoat[2] = boatNumber;
                                    waveLaneTaken[0] = true;
                                    break;
                            }
                        }
                        else
                        {
                            switch (boatName)
                            {
                                case "Boat1":
                                    while (boatNumber == leftBoat[0])
                                        boatNumber = RandomWithExclusion(0, m_Boats.Count, boatNumber);
                                    break;
                                case "Boat2":
                                    while (boatNumber == leftBoat[1])
                                        boatNumber = RandomWithExclusion(0, m_Boats.Count, boatNumber);
                                    break;
                                case "Boat3":
                                    while (boatNumber == leftBoat[2])
                                        boatNumber = RandomWithExclusion(0, m_Boats.Count, boatNumber);
                                    break;
                            }
                        }
                        break;
                    case 1:
                        if (waveLaneTaken[1] == false)
                        {
                            switch (boatName)
                            {
                                case "Boat1":
                                    siblingIndex[0] = 5;
                                   // m_Boats[0].transform.parent.SetSiblingIndex(siblingIndex[0]);
                                    leftBoat[0] = boatNumber;
                                    waveLaneTaken[1] = true;
                                    break;
                                case "Boat2":
                                    siblingIndex[1] = 5;
                                    //m_Boats[1].transform.parent.SetSiblingIndex(siblingIndex[1]);
                                    leftBoat[1] = boatNumber;
                                    waveLaneTaken[1] = true;
                                    break;
                                case "Boat3":
                                    siblingIndex[2] = 5;
                                  //  m_Boats[2].transform.parent.SetSiblingIndex(siblingIndex[2]);
                                    leftBoat[2] = boatNumber;
                                    waveLaneTaken[1] = true;
                                    break;
                            }
                        }
                        else
                        {
                            switch (boatName)
                            {
                                case "Boat1":
                                    while (boatNumber == leftBoat[0])
                                        boatNumber = RandomWithExclusion(0, m_Boats.Count, boatNumber);
                                    break;
                                case "Boat2":
                                    while (boatNumber == leftBoat[1])
                                        boatNumber = RandomWithExclusion(0, m_Boats.Count, boatNumber);
                                    break;
                                case "Boat3":
                                    while (boatNumber == leftBoat[2])
                                        boatNumber = RandomWithExclusion(0, m_Boats.Count, boatNumber);
                                    break;
                            }
                        }
                        break;
                    case 2:
                        if (waveLaneTaken[2] == false)
                        {
                            switch (boatName)
                            {
                                case "Boat1":
                                    siblingIndex[0] = 7;
                                   // m_Boats[0].transform.parent.SetSiblingIndex(siblingIndex[0]);
                                    leftBoat[0] = boatNumber;
                                    waveLaneTaken[2] = true;
                                    break;
                                case "Boat2":
                                    siblingIndex[1] = 7;
                                   // m_Boats[1].transform.parent.SetSiblingIndex(siblingIndex[1]);
                                    leftBoat[1] = boatNumber;
                                    waveLaneTaken[2] = true;
                                    break;
                                case "Boat3":
                                    siblingIndex[2] = 7;
                                  //  m_Boats[2].transform.parent.SetSiblingIndex(siblingIndex[2]);
                                    leftBoat[2] = boatNumber;
                                    waveLaneTaken[2] = true;
                                    break;
                            }
                        }
                        else
                        {
                            switch (boatName)
                            {
                                case "Boat1":
                                    while (boatNumber == leftBoat[0])
                                        boatNumber = RandomWithExclusion(0, m_Boats.Count, boatNumber);
                                    break;
                                case "Boat2":
                                    while (boatNumber == leftBoat[1])
                                        boatNumber = RandomWithExclusion(0, m_Boats.Count, boatNumber);
                                    break;
                                case "Boat3":
                                    while (boatNumber == leftBoat[2])
                                        boatNumber = RandomWithExclusion(0, m_Boats.Count, boatNumber);
                                    break;
                            }
                        }
                        break;
                }
                break;
            case "Right":
                switch (boatNumber)
                {
                    case 0:
                        if (waveLaneTaken[3] == false)
                        {
                            switch (boatName)
                            {
                                case "Boat1":
                                    siblingIndex[0] = 1;
                                  //  m_Boats[0].transform.parent.SetSiblingIndex(siblingIndex[0]);
                                    rightBoat[0] = boatNumber;
                                    waveLaneTaken[3] = true;
                                    break;
                                case "Boat2":
                                    siblingIndex[1] = 1;
                                    rightBoat[1] = boatNumber;
                                  //  m_Boats[1].transform.parent.SetSiblingIndex(siblingIndex[1]);
                                    waveLaneTaken[3] = true;
                                    break;
                                case "Boat3":
                                    siblingIndex[2] = 1;
                                  //  m_Boats[2].transform.parent.SetSiblingIndex(siblingIndex[2]);
                                    rightBoat[2] = boatNumber;
                                    waveLaneTaken[3] = true;
                                    break;
                            }
                        }
                        else
                        {
                            switch (boatName)
                            {
                                case "Boat1":
                                    while (boatNumber == leftBoat[0])
                                        boatNumber = RandomWithExclusion(0, m_Boats.Count, boatNumber);
                                    break;
                                case "Boat2":
                                    while (boatNumber == leftBoat[1])
                                        boatNumber = RandomWithExclusion(0, m_Boats.Count, boatNumber);
                                    break;
                                case "Boat3":
                                    while (boatNumber == leftBoat[2])
                                        boatNumber = RandomWithExclusion(0, m_Boats.Count, boatNumber);
                                    break;
                            }
                        }
                        break;
                    case 1:
                        if (waveLaneTaken[4] == false)
                        {
                            switch (boatName)
                            {
                                case "Boat1":
                                    siblingIndex[0] = 5;
                                    rightBoat[0] = boatNumber;
                                   // m_Boats[0].transform.parent.SetSiblingIndex(siblingIndex[0]);
                                    waveLaneTaken[4] = true;
                                    break;
                                case "Boat2":
                                    siblingIndex[1] = 5;
                                  //  m_Boats[1].transform.parent.SetSiblingIndex(siblingIndex[1]);
                                    rightBoat[1] = boatNumber;
                                    waveLaneTaken[4] = true;
                                    break;
                                case "Boat3":
                                    siblingIndex[2] = 5;
                                  //  m_Boats[2].transform.parent.SetSiblingIndex(siblingIndex[2]);
                                    rightBoat[2] = boatNumber;
                                    waveLaneTaken[4] = true;
                                    break;
                            }
                        }
                        else
                        {
                            switch (boatName)
                            {
                                case "Boat1":
                                    while (boatNumber == leftBoat[0])
                                        boatNumber = RandomWithExclusion(0, m_Boats.Count, boatNumber);
                                    break;
                                case "Boat2":
                                    while (boatNumber == leftBoat[1])
                                        boatNumber = RandomWithExclusion(0, m_Boats.Count, boatNumber);
                                    break;
                                case "Boat3":
                                    while (boatNumber == leftBoat[2])
                                        boatNumber = RandomWithExclusion(0, m_Boats.Count, boatNumber);
                                    break;
                            }
                        }
                        break;
                    case 2:
                        if (waveLaneTaken[5] == false)
                        {
                            switch (boatName)
                            {
                                case "Boat1":
                                    siblingIndex[0] = 7;
                                 //   m_Boats[0].transform.parent.SetSiblingIndex(siblingIndex[0]);
                                    rightBoat[0] = boatNumber;
                                    waveLaneTaken[5] = true;
                                    break;
                                case "Boat2":
                                    siblingIndex[1] = 7;
                                   // m_Boats[1].transform.parent.SetSiblingIndex(siblingIndex[1]);
                                    rightBoat[1] = boatNumber;
                                    waveLaneTaken[5] = true;
                                    break;
                                case "Boat3":
                                    siblingIndex[2] = 7;
                                   // m_Boats[2].transform.parent.SetSiblingIndex(siblingIndex[2]);
                                    rightBoat[2] = boatNumber;
                                    waveLaneTaken[5] = true;
                                    break;
                            }
                        }
                        else
                        {
                            switch (boatName)
                            {
                                case "Boat1":
                                    while (boatNumber == leftBoat[0])
                                        boatNumber = RandomWithExclusion(0, m_Boats.Count, boatNumber);
                                    break;
                                case "Boat2":
                                    while (boatNumber == leftBoat[1])
                                        boatNumber = RandomWithExclusion(0, m_Boats.Count, boatNumber);
                                    break;
                                case "Boat3":
                                    while (boatNumber == leftBoat[2])
                                        boatNumber = RandomWithExclusion(0, m_Boats.Count, boatNumber);
                                    break;
                            }
                        }
                        break;
                }
                break;
        }

    }
    #endregion

    int RandomWithExclusion(int min, int max, int exclusion)
    {
        var result = Random.Range(min, max - 1);
        return (result < exclusion) ? result : result + 1;
    }

    public void NextLetter(){
		PlaceAnswer ();
    }

	public void Reset (){

        AnswerHint.text = Names[answerIndex];
		answerButton = Random.Range (0, 4);
		AnswersText[answerButton].text = Names[answerIndex];

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

    void Update()
    {

    }

}
