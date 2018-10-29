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
	//bool gameStart = false;
	// NEW STUFF IM WORKING WITH
	public string[] NamesChosen;
	public Animator ButtonAnim1;
    public List<string> Names;
    public string answer;
    public List<BoatHanlder> m_Boats = new List<BoatHanlder>();
    public int[] siblingIndex;
    public GameObject m_Waves;
    public List<int> rightBoat = new List<int>();
    public float time;
    public float animDuration;
    public float speedBoatTimer;
    public List<bool> hasSpawned = new List<bool>();
    public int spawnIndex;
    public Animation speedBoatAnim;
    public bool playedSpeedBoat = false;
    public Vector3 speedBoatPos;
    public GameObject[] speedBoatSpawner;
    public int speedBoatSection;
    public GameObject speedBoatText;

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
        //if(UIManager.instance.gameStart)
        InvokeRepeating("PlaySpeedBoat", 20.0f, 20.0f);
    }

    public void Choice1()
    {

        if (answerButton == 0)
        {
            NextLetter();
            UIManager.instance.ScorePoints(5);
            rightBoat.Clear();
            time = 0;
            for (int i = 0; i < m_Boats.Count; i++)
            {
                m_Boats[i].ReRouteBoat();
                m_Boats[i].RestartAnimation();
            }
            NewWave();
        }
        else
        {
          //  Miss++;
            LevelManager.instance.CheckAnswer(false, UIManager.instance.heartsAmount, UIManager.instance.seahorseAnim);
           // gameStart = false;
            if (LevelManager.instance.correctAnswerPoints < 5)
            {
                NextLetter();
                rightBoat.Clear();
                time = 0;
                for (int i = 0; i < m_Boats.Count; i++)
                {
                    m_Boats[i].ReRouteBoat();
                    m_Boats[i].RestartAnimation();
                }
                NewWave();
            }
        }
    }
    public void Choice2()
    {

        if (answerButton == 1)
        {
            NextLetter();
            UIManager.instance.ScorePoints(5);
            rightBoat.Clear();
            time = 0;
            for (int i = 0; i < m_Boats.Count; i++)
            {
                m_Boats[i].ReRouteBoat();
                m_Boats[i].RestartAnimation();
            }
            NewWave();
        }
        else
        {
            //Miss++;
            LevelManager.instance.CheckAnswer(false, UIManager.instance.heartsAmount, UIManager.instance.seahorseAnim);
         //   gameStart = false;
            if (LevelManager.instance.correctAnswerPoints < 5)
            {
                NextLetter();
                rightBoat.Clear();
                time = 0;
                for (int i = 0; i < m_Boats.Count; i++)
                {
                    m_Boats[i].ReRouteBoat();
                    m_Boats[i].RestartAnimation();
                }
                NewWave();
            }
        }
    }
    public void Choice3()
    {

        if (answerButton == 2)
        {
            NextLetter();
            UIManager.instance.ScorePoints(5);
            rightBoat.Clear();
            time = 0;
            for (int i = 0; i < m_Boats.Count; i++)
            {
                m_Boats[i].ReRouteBoat();
                m_Boats[i].RestartAnimation();
            }
            NewWave();
        }
        else
        {
           // Miss++;
            LevelManager.instance.CheckAnswer(false, UIManager.instance.heartsAmount, UIManager.instance.seahorseAnim);
           // gameStart = false;
            if (LevelManager.instance.correctAnswerPoints < 5)
            {
                NextLetter();
                rightBoat.Clear();
                time = 0;
                for (int i = 0; i < m_Boats.Count; i++)
                {
                    m_Boats[i].ReRouteBoat();
                    m_Boats[i].RestartAnimation();
                }
                NewWave();
            }
        }
    }
    public void Choice4()
    {

        if (answerButton == 3)
        {
            
            //speedBoatPos = speedBoatSpawner[Random.Range(0, 2)].transform.localPosition;
            speedBoatAnim.transform.parent.localPosition = speedBoatPos;
            speedBoatAnim.transform.localPosition = Vector3.zero;
            speedBoatAnim.Stop();

            NextLetter();
            UIManager.instance.ScorePoints(5);
            UIManager.instance.BonusPoints();
            rightBoat.Clear();
            time = 0;
            for (int i = 0; i < m_Boats.Count; i++)
            {
                m_Boats[i].ReRouteBoat();
                m_Boats[i].RestartAnimation();
            }

            NewWave();
        }
        else
        {
           
           // speedBoatPos = speedBoatSpawner[Random.Range(0, 2)].transform.localPosition;
            speedBoatAnim.transform.parent.localPosition = speedBoatPos;
            speedBoatAnim.transform.localPosition = Vector3.zero;
            speedBoatAnim.Stop();

            LevelManager.instance.CheckAnswer(false, UIManager.instance.heartsAmount, UIManager.instance.seahorseAnim);
           // gameStart = false;
            if (LevelManager.instance.correctAnswerPoints < 5)
            {
                NextLetter();
                rightBoat.Clear();
                time = 0;
                for (int i = 0; i < m_Boats.Count; i++)
                {
                    m_Boats[i].ReRouteBoat();
                    m_Boats[i].RestartAnimation();
                }
                NewWave();
            }
        }
    }

    #region SetWaves
    public void SetWaveLane(int boatDir, int boatNumber, string boatName)
    {
        for (int i = 0; i < m_Boats.Count; i++)
            m_Boats[i].transform.parent.SetParent(m_Waves.transform);

        switch (boatDir)
        {
            case 1:
                switch (boatNumber)
                {
                    case 0:
                            switch (boatName)
                            {
                                case "Boat1":
                                switch (m_Boats[0].boatNumber)
                                {
                                    case 1:
                                        siblingIndex[0] = 5;
                                        m_Boats[0].transform.parent.SetSiblingIndex(siblingIndex[0]);
                                        m_Boats[0].siblingIndex = siblingIndex[0];
                                        break;
                                    case 2:
                                        siblingIndex[0] = 5+1;
                                        m_Boats[0].transform.parent.SetSiblingIndex(siblingIndex[0]);
                                        m_Boats[0].siblingIndex = siblingIndex[0];
                                        break;
                                    case 3:
                                        siblingIndex[0] = 5+2;
                                        m_Boats[0].transform.parent.SetSiblingIndex(siblingIndex[0]);
                                        m_Boats[0].siblingIndex = siblingIndex[0];
                                        break;
                                }                              
                                break;

                                case "Boat2":
                                switch (m_Boats[1].boatNumber)
                                {
                                    case 1:
                                        siblingIndex[1] = 5;
                                        m_Boats[1].transform.parent.SetSiblingIndex(siblingIndex[1]);
                                        m_Boats[1].siblingIndex = siblingIndex[1];
                                        break;
                                    case 2:
                                        siblingIndex[1] = 5 + 1;
                                        m_Boats[1].transform.parent.SetSiblingIndex(siblingIndex[1]);
                                        m_Boats[1].siblingIndex = siblingIndex[1];
                                        break;
                                    case 3:
                                        siblingIndex[1] = 5 + 2;
                                        m_Boats[1].transform.parent.SetSiblingIndex(siblingIndex[1]);
                                        m_Boats[1].siblingIndex = siblingIndex[1];
                                        break;
                                }
                                break;

                                case "Boat3":
                                switch (m_Boats[2].boatNumber)
                                {
                                    case 1:
                                        siblingIndex[2] = 5;
                                        m_Boats[2].transform.parent.SetSiblingIndex(siblingIndex[2]);
                                        m_Boats[2].siblingIndex = siblingIndex[2];
                                        break;
                                    case 2:
                                        siblingIndex[2] = 5 + 1;
                                        m_Boats[2].transform.parent.SetSiblingIndex(siblingIndex[2]);
                                        m_Boats[2].siblingIndex = siblingIndex[2];
                                        break;
                                    case 3:
                                        siblingIndex[2] = 5 + 2;
                                        m_Boats[2].transform.parent.SetSiblingIndex(siblingIndex[2]);
                                        m_Boats[2].siblingIndex = siblingIndex[2];
                                        break;
                                }
                                break;
                            }                        
                        
                        break;
                    case 1:
                            switch (boatName)
                            {
                                case "Boat1":
                                switch (m_Boats[0].boatNumber)
                                {
                                    case 1:
                                        siblingIndex[0] = 3;
                                        m_Boats[0].transform.parent.SetSiblingIndex(siblingIndex[0]);
                                        m_Boats[0].siblingIndex = siblingIndex[0];
                                        break;
                                    case 2:
                                        siblingIndex[0] = 3 + 1;
                                        m_Boats[0].transform.parent.SetSiblingIndex(siblingIndex[0]);
                                        m_Boats[0].siblingIndex = siblingIndex[0];
                                        break;
                                    case 3:
                                        siblingIndex[0] = 3 + 2;
                                        m_Boats[0].transform.parent.SetSiblingIndex(siblingIndex[0]);
                                        m_Boats[0].siblingIndex = siblingIndex[0];
                                        break;
                                }                               
                                break;

                                case "Boat2":
                                switch (m_Boats[1].boatNumber)
                                {
                                    case 1:
                                        siblingIndex[1] = 3;
                                        m_Boats[1].transform.parent.SetSiblingIndex(siblingIndex[1]);
                                        m_Boats[1].siblingIndex = siblingIndex[1];
                                        break;
                                    case 2:
                                        siblingIndex[1] = 3 + 1;
                                        m_Boats[1].transform.parent.SetSiblingIndex(siblingIndex[1]);
                                        m_Boats[1].siblingIndex = siblingIndex[1];
                                        break;
                                    case 3:
                                        siblingIndex[1] = 3 + 2;
                                        m_Boats[1].transform.parent.SetSiblingIndex(siblingIndex[1]);
                                        m_Boats[1].siblingIndex = siblingIndex[1];
                                        break;
                                }
                                break;

                                case "Boat3":
                                switch (m_Boats[2].boatNumber)
                                {
                                    case 1:
                                        siblingIndex[2] = 3;
                                        m_Boats[2].transform.parent.SetSiblingIndex(siblingIndex[2]);
                                        m_Boats[2].siblingIndex = siblingIndex[2];
                                        break;
                                    case 2:
                                        siblingIndex[2] = 3 + 1;
                                        m_Boats[2].transform.parent.SetSiblingIndex(siblingIndex[2]);
                                        m_Boats[2].siblingIndex = siblingIndex[2];
                                        break;
                                    case 3:
                                        siblingIndex[2] = 3 + 2;
                                        m_Boats[2].transform.parent.SetSiblingIndex(siblingIndex[2]);
                                        m_Boats[2].siblingIndex = siblingIndex[2];
                                        break;
                                }
                                break;
                            }
                        
                        break;
                    case 2:
                            switch (boatName)
                            {
                                case "Boat1":
                                switch (m_Boats[0].boatNumber)
                                {
                                    case 1:
                                        siblingIndex[0] = 1;
                                        m_Boats[0].transform.parent.SetSiblingIndex(siblingIndex[0]);
                                        m_Boats[0].siblingIndex = siblingIndex[0];
                                        break;
                                    case 2:
                                        siblingIndex[0] = 1 + 1;
                                        m_Boats[0].transform.parent.SetSiblingIndex(siblingIndex[0]);
                                        m_Boats[0].siblingIndex = siblingIndex[0];
                                        break;
                                    case 3:
                                        siblingIndex[0] = 1 + 2;
                                        m_Boats[0].transform.parent.SetSiblingIndex(siblingIndex[0]);
                                        m_Boats[0].siblingIndex = siblingIndex[0];
                                        break;
                                }                             
                                break;

                                case "Boat2":
                                switch (m_Boats[1].boatNumber)
                                {
                                    case 1:
                                        siblingIndex[1] = 1;
                                        m_Boats[1].transform.parent.SetSiblingIndex(siblingIndex[1]);
                                        m_Boats[1].siblingIndex = siblingIndex[1];
                                        break;
                                    case 2:
                                        siblingIndex[1] = 1 + 1;
                                        m_Boats[1].transform.parent.SetSiblingIndex(siblingIndex[1]);
                                        m_Boats[1].siblingIndex = siblingIndex[1];
                                        break;
                                    case 3:
                                        siblingIndex[1] = 1 + 2;
                                        m_Boats[1].transform.parent.SetSiblingIndex(siblingIndex[1]);
                                        m_Boats[1].siblingIndex = siblingIndex[1];
                                        break;
                                }
                                break;

                                case "Boat3":
                                switch (m_Boats[2].boatNumber)
                                {
                                    case 1:
                                        siblingIndex[2] = 1;
                                        m_Boats[2].transform.parent.SetSiblingIndex(siblingIndex[2]);
                                        m_Boats[2].siblingIndex = siblingIndex[2];
                                        break;
                                    case 2:
                                        siblingIndex[2] = 1 + 1;
                                        m_Boats[2].transform.parent.SetSiblingIndex(siblingIndex[2]);
                                        m_Boats[2].siblingIndex = siblingIndex[2];
                                        break;
                                    case 3:
                                        siblingIndex[2] = 1 + 2;
                                        m_Boats[2].transform.parent.SetSiblingIndex(siblingIndex[2]);
                                        m_Boats[2].siblingIndex = siblingIndex[2];
                                        break;
                                }
                                break;
                            }                        
                        break;
                }
                break;
            case 0:
                switch (boatNumber)
                {
                    case 0:
                            switch (boatName)
                            {
                                case "Boat1":
                                switch (m_Boats[0].boatNumber)
                                {
                                    case 1:
                                        siblingIndex[0] = 1;
                                        m_Boats[0].transform.parent.SetSiblingIndex(siblingIndex[0]);
                                        m_Boats[0].siblingIndex = siblingIndex[0];
                                        break;
                                    case 2:
                                        siblingIndex[0] = 1 + 1;
                                        m_Boats[0].transform.parent.SetSiblingIndex(siblingIndex[0]);
                                        m_Boats[0].siblingIndex = siblingIndex[0];
                                        break;
                                    case 3:
                                        siblingIndex[0] = 1 + 2;
                                        m_Boats[0].transform.parent.SetSiblingIndex(siblingIndex[0]);
                                        m_Boats[0].siblingIndex = siblingIndex[0];
                                        break;
                                }
                                break;

                                case "Boat2":
                                switch (m_Boats[1].boatNumber)
                                {
                                    case 1:
                                        siblingIndex[1] = 1;
                                        m_Boats[1].transform.parent.SetSiblingIndex(siblingIndex[1]);
                                        m_Boats[1].siblingIndex = siblingIndex[1];
                                        break;
                                    case 2:
                                        siblingIndex[1] = 1 + 1;
                                        m_Boats[1].transform.parent.SetSiblingIndex(siblingIndex[1]);
                                        m_Boats[1].siblingIndex = siblingIndex[1];
                                        break;
                                    case 3:
                                        siblingIndex[1] = 1 + 2;
                                        m_Boats[1].transform.parent.SetSiblingIndex(siblingIndex[1]);
                                        m_Boats[1].siblingIndex = siblingIndex[1];
                                        break;
                                }
                                break;

                                case "Boat3":
                                switch (m_Boats[2].boatNumber)
                                {
                                    case 1:
                                        siblingIndex[2] = 1;
                                        m_Boats[2].transform.parent.SetSiblingIndex(siblingIndex[2]);
                                        m_Boats[2].siblingIndex = siblingIndex[2];
                                        break;
                                    case 2:
                                        siblingIndex[2] = 1 + 1;
                                        m_Boats[2].transform.parent.SetSiblingIndex(siblingIndex[2]);
                                        m_Boats[2].siblingIndex = siblingIndex[2];
                                        break;
                                    case 3:
                                        siblingIndex[2] = 1 + 2;
                                        m_Boats[2].transform.parent.SetSiblingIndex(siblingIndex[2]);
                                        m_Boats[2].siblingIndex = siblingIndex[2];
                                        break;
                                }
                                break;
                            }                       
                        break;
                    case 1:
                            switch (boatName)
                            {
                                case "Boat1":
                                switch (m_Boats[0].boatNumber)
                                {
                                    case 1:
                                        siblingIndex[0] = 3;
                                        m_Boats[0].transform.parent.SetSiblingIndex(siblingIndex[0]);
                                        m_Boats[0].siblingIndex = siblingIndex[0];
                                        break;
                                    case 2:
                                        siblingIndex[0] = 3 + 1;
                                        m_Boats[0].transform.parent.SetSiblingIndex(siblingIndex[0]);
                                        m_Boats[0].siblingIndex = siblingIndex[0];
                                        break;
                                    case 3:
                                        siblingIndex[0] = 3  +2;
                                        m_Boats[0].transform.parent.SetSiblingIndex(siblingIndex[0]);
                                        m_Boats[0].siblingIndex = siblingIndex[0];
                                        break;
                                }                           
                                break;

                                case "Boat2":
                                switch (m_Boats[1].boatNumber)
                                {
                                    case 1:
                                        siblingIndex[1] = 3;
                                        m_Boats[1].transform.parent.SetSiblingIndex(siblingIndex[1]);
                                        m_Boats[1].siblingIndex = siblingIndex[1];
                                        break;
                                    case 2:
                                        siblingIndex[1] = 3 + 1;
                                        m_Boats[1].transform.parent.SetSiblingIndex(siblingIndex[1]);
                                        m_Boats[1].siblingIndex = siblingIndex[1];
                                        break;
                                    case 3:
                                        siblingIndex[1] = 3 + 2;
                                        m_Boats[1].transform.parent.SetSiblingIndex(siblingIndex[1]);
                                        m_Boats[1].siblingIndex = siblingIndex[1];
                                        break;
                                }
                                break;

                                case "Boat3":
                                switch (m_Boats[2].boatNumber)
                                {
                                    case 1:
                                        siblingIndex[2] = 3;
                                        m_Boats[2].transform.parent.SetSiblingIndex(siblingIndex[2]);
                                        m_Boats[2].siblingIndex = siblingIndex[2];
                                        break;
                                    case 2:
                                        siblingIndex[2] = 3 + 1;
                                        m_Boats[2].transform.parent.SetSiblingIndex(siblingIndex[2]);
                                        m_Boats[2].siblingIndex = siblingIndex[2];
                                        break;
                                    case 3:
                                        siblingIndex[2] = 3 + 2;
                                        m_Boats[2].transform.parent.SetSiblingIndex(siblingIndex[2]);
                                        m_Boats[2].siblingIndex = siblingIndex[2];
                                        break;
                                }
                                break;
                            }                       
                        break;
                    case 2:
                            switch (boatName)
                            {
                                case "Boat1":
                                switch (m_Boats[0].boatNumber)
                                {
                                    case 1:
                                        siblingIndex[0] = 6;
                                        m_Boats[0].transform.parent.SetSiblingIndex(siblingIndex[0]);
                                        m_Boats[0].siblingIndex = siblingIndex[0];
                                        break;
                                    case 2:
                                        siblingIndex[0] = 6 + 1;
                                        m_Boats[0].transform.parent.SetSiblingIndex(siblingIndex[0]);
                                        m_Boats[0].siblingIndex = siblingIndex[0];
                                        break;
                                    case 3:
                                        siblingIndex[0] = 6 + 1;
                                        m_Boats[0].transform.parent.SetSiblingIndex(siblingIndex[0]);
                                        m_Boats[0].siblingIndex = siblingIndex[0];
                                        break;
                                }
                                
                                break;

                                case "Boat2":
                                switch (m_Boats[1].boatNumber)
                                {                       
                                    case 1:
                                        siblingIndex[1] = 5;
                                        m_Boats[1].transform.parent.SetSiblingIndex(siblingIndex[1]);
                                        m_Boats[1].siblingIndex = siblingIndex[1];
                                        break;
                                    case 2:
                                        siblingIndex[1] = 5+1;
                                        m_Boats[1].transform.parent.SetSiblingIndex(siblingIndex[1]);
                                        m_Boats[1].siblingIndex = siblingIndex[1];
                                        break;
                                    case 3:
                                        siblingIndex[1] = 5+2;
                                        m_Boats[1].transform.parent.SetSiblingIndex(siblingIndex[1]);
                                        m_Boats[1].siblingIndex = siblingIndex[1];
                                        break;
                                }                              
                                break;

                                case "Boat3":
                                switch (m_Boats[2].boatNumber)
                                {
                                    case 1:
                                        siblingIndex[2] = 6;
                                        m_Boats[2].transform.parent.SetSiblingIndex(siblingIndex[2]);
                                        m_Boats[2].siblingIndex = siblingIndex[2];
                                        break;
                                    case 2:
                                        siblingIndex[2] = 6 + 1;
                                        m_Boats[2].transform.parent.SetSiblingIndex(siblingIndex[2]);
                                        m_Boats[2].siblingIndex = siblingIndex[2];
                                        break;
                                    case 3:
                                        siblingIndex[2] = 6 + 1;
                                        m_Boats[2].transform.parent.SetSiblingIndex(siblingIndex[2]);
                                        m_Boats[2].siblingIndex = siblingIndex[2];
                                        break;
                                }
                                break;
                            }
                        
                        break;
                }
                break;
        }

    }


    public void SetBoatNumber(string boatName)
    {
        switch (boatName)
        {
            case "Boat1":
                if (m_Boats[0].transform.parent.GetSiblingIndex() < m_Boats[1].transform.parent.GetSiblingIndex() && m_Boats[0].transform.parent.GetSiblingIndex() < m_Boats[2].transform.parent.GetSiblingIndex())
                    m_Boats[0].boatNumber = 1;

                if (m_Boats[0].transform.parent.GetSiblingIndex() > m_Boats[1].transform.parent.GetSiblingIndex() && m_Boats[0].transform.parent.GetSiblingIndex() < m_Boats[2].transform.parent.GetSiblingIndex())
                    m_Boats[0].boatNumber = 2;

                if (m_Boats[0].transform.parent.GetSiblingIndex() < m_Boats[1].transform.parent.GetSiblingIndex() && m_Boats[0].transform.parent.GetSiblingIndex() > m_Boats[2].transform.parent.GetSiblingIndex())
                    m_Boats[0].boatNumber = 2;

                if (m_Boats[0].transform.parent.GetSiblingIndex() > m_Boats[1].transform.parent.GetSiblingIndex() && m_Boats[0].transform.parent.GetSiblingIndex() > m_Boats[2].transform.parent.GetSiblingIndex())
                    m_Boats[0].boatNumber = 3;
                break;

            case "Boat2":
                if (m_Boats[1].transform.parent.GetSiblingIndex() < m_Boats[0].transform.parent.GetSiblingIndex() && m_Boats[1].transform.parent.GetSiblingIndex() < m_Boats[2].transform.parent.GetSiblingIndex())
                    m_Boats[1].boatNumber = 1;

                if (m_Boats[1].transform.parent.GetSiblingIndex() > m_Boats[0].transform.parent.GetSiblingIndex() && m_Boats[1].transform.parent.GetSiblingIndex() < m_Boats[2].transform.parent.GetSiblingIndex())
                    m_Boats[1].boatNumber = 2;

                if (m_Boats[1].transform.parent.GetSiblingIndex() < m_Boats[0].transform.parent.GetSiblingIndex() && m_Boats[1].transform.parent.GetSiblingIndex() > m_Boats[2].transform.parent.GetSiblingIndex())
                    m_Boats[1].boatNumber = 2;

                if (m_Boats[1].transform.parent.GetSiblingIndex() > m_Boats[0].transform.parent.GetSiblingIndex() && m_Boats[1].transform.parent.GetSiblingIndex() > m_Boats[2].transform.parent.GetSiblingIndex())
                    m_Boats[1].boatNumber = 3;
                break;

            case "Boat3":
                if (m_Boats[2].transform.parent.GetSiblingIndex() < m_Boats[0].transform.parent.GetSiblingIndex() && m_Boats[2].transform.parent.GetSiblingIndex() < m_Boats[1].transform.parent.GetSiblingIndex())
                    m_Boats[2].boatNumber = 1;

                if (m_Boats[2].transform.parent.GetSiblingIndex() < m_Boats[0].transform.parent.GetSiblingIndex() && m_Boats[2].transform.parent.GetSiblingIndex() > m_Boats[1].transform.parent.GetSiblingIndex())
                    m_Boats[2].boatNumber = 2;

                if (m_Boats[2].transform.parent.GetSiblingIndex() > m_Boats[0].transform.parent.GetSiblingIndex() && m_Boats[2].transform.parent.GetSiblingIndex() < m_Boats[1].transform.parent.GetSiblingIndex())
                    m_Boats[2].boatNumber = 2;

                if (m_Boats[2].transform.parent.GetSiblingIndex() > m_Boats[0].transform.parent.GetSiblingIndex() && m_Boats[2].transform.parent.GetSiblingIndex() > m_Boats[1].transform.parent.GetSiblingIndex())
                    m_Boats[2].boatNumber = 3;
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
        rightBoat.Clear();
        time = 0;
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

    private bool IsAllSpawningComplete()
    {
        for (int i = 0; i < hasSpawned.Count; ++i)
        {
            if (hasSpawned[i] == false)
            {
                return false;
            }
        }

        return true;
    }

    public void NewWave()
    {
        if (IsAllSpawningComplete())
        {
            for (int i = 0; i < m_Boats.Count; i++)
                SetWaveLane(m_Boats[i].levelSection, m_Boats[i].rightBoat, m_Boats[i].transform.parent.name);

            for (int i = 0; i < m_Boats.Count; i++)
            {
                SetBoatNumber(m_Boats[i].transform.parent.name);
            }

            for (int i = 0; i < m_Boats.Count; i++)
                SetWaveLane(m_Boats[i].levelSection, m_Boats[i].rightBoat, m_Boats[i].transform.parent.name);

            for (int i = 0; i < m_Boats.Count; i++)
            {
                SetBoatNumber(m_Boats[i].transform.parent.name);
            }

            for (int i = 0; i < m_Boats.Count; i++)
                SetWaveLane(m_Boats[i].levelSection, m_Boats[i].rightBoat, m_Boats[i].transform.parent.name);

            for (int i = 0; i < hasSpawned.Count; i++)
            {
                hasSpawned[i] = false;
            }

            spawnIndex = 0;
        }
    }

    public void PlaySpeedBoat()
    {
        speedBoatSection = Random.Range(0, 2);

        if(speedBoatSection == 0)//Right
        {
            speedBoatPos = speedBoatSpawner[0].transform.localPosition;
            speedBoatAnim.transform.parent.localPosition = speedBoatPos;
            speedBoatAnim.transform.parent.rotation = new Quaternion(0, 0, 0, 0);
            speedBoatText.transform.localEulerAngles = new Vector3(0, 0, 0);
            speedBoatAnim.Play();
        }

        if (speedBoatSection == 1)//Left
        {
            speedBoatPos = speedBoatSpawner[1].transform.localPosition;
            speedBoatAnim.transform.parent.localPosition = speedBoatPos;
            speedBoatAnim.transform.parent.rotation = new Quaternion(0, -180, 0, 0);
            speedBoatText.transform.localEulerAngles = new Vector3(0, -180, 0);
            speedBoatAnim.Play();
        }

    }

    void Update()
    {
        time += Time.deltaTime;
        animDuration = m_Boats[1].GetComponent<Animation>().clip.length;
        animDuration -= time;

        if (animDuration <= 0.0f)
        {
            NextLetter();
            rightBoat.Clear();
            time = 0;

        }

        NewWave();


            

    }

}
