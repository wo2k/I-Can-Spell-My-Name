using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Level1D: MonoBehaviour {

    public GameObject NameData;
    public Text[] AnswersText;
    public List<string> Names = new List<string>();
	public Text AnswerHint;
	public int answerButton = 0;
	int answerIndex = 8;

	public GameObject Tutorial;

	//bool gameStart = false;
	// NEW STUFF IM WORKING WITH
	public string[] NamesChosen;
	public Animator ButtonAnim1;
    public string answer;
    //public Slider healthMeter;
    public GameObject fishRef;

    public GameObject killZone;

   // public UnityAction RightAnswer;

   // public List<GameObject> fishQueue = new List<GameObject>();
    public int fishIndex;

    void Start()
    {

#if UNITY_EDITOR
        killZone.SetActive(true);
#else
        killZone.SetActive(false);
#endif

        //RightAnswer = new UnityAction(Choice1);

        NameData = FindObjectOfType<LevelManager>().gameObject;

        UIManager.instance.StartGame();
        UIManager.instance.mode = UIManager.subLevels1.Level1D;

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

        InvokeRepeating("SpawnFish", 0.5f , 6);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
       // Gizmos.DrawLine(startLine, endLine);
    }

    void SpawnFish()
    {
        GameObject fish = Instantiate(fishRef, new Vector3(0, 0, 0), Quaternion.identity, gameObject.transform);
        fishIndex++;
        fish.name = "Fish " + fishIndex;
        AnswersText[0] = fish.GetComponentInChildren<Text>();
        PlaceAnswer();
    }

    public void Choice1(GameObject fish)
    {
        
        if (answerButton == 0)
        {
            GameObject bubbleParticle = Resources.Load("Misc/Bubble") as GameObject;
          //  bubbleParticle.transform.position = fish.transform.position;
            Destroy(fish);
            //NextLetter();
            UIManager.instance.ScorePoints(5);
          //  healthMeter.value += .10f;
        }
        else
        {
            LevelManager.instance.CheckAnswer(false, UIManager.instance.heartsAmount, UIManager.instance.seahorseAnim);
          //  gameStart = false;
            if (LevelManager.instance.correctAnswerPoints < 5)
            {
                NextLetter();
               // healthMeter.value -= .10f;
            }
        }
    }
    public void Choice2()
    {

        if (answerButton == 1)
        {
            NextLetter();
            UIManager.instance.ScorePoints(5);
            //healthMeter.value += .10f;
        }
        else
        {
            
            LevelManager.instance.CheckAnswer(false, UIManager.instance.heartsAmount, UIManager.instance.seahorseAnim);
           // gameStart = false;
            if (LevelManager.instance.correctAnswerPoints < 5)
            {
                NextLetter();
               // healthMeter.value -= .10f;
            }
        }
    }
    public void Choice3()
    {

        if (answerButton == 2)
        {
            NextLetter();
            UIManager.instance.ScorePoints(5);
           // healthMeter.value += .10f;
        }
        else
        {
            
            LevelManager.instance.CheckAnswer(false, UIManager.instance.heartsAmount, UIManager.instance.seahorseAnim);
           // gameStart = false;
            if (LevelManager.instance.correctAnswerPoints < 5)
            {
                NextLetter();
             //   healthMeter.value -= .10f;
            }
        }
    }
    public void Choice4()
    {

        if (answerButton == 3)
        {
            NextLetter();
            UIManager.instance.ScorePoints(5);
           // healthMeter.value += .10f;
        }
        else
        {
            
            LevelManager.instance.CheckAnswer(false, UIManager.instance.heartsAmount, UIManager.instance.seahorseAnim);
           // gameStart = false;
            if (LevelManager.instance.correctAnswerPoints < 5)
            {
                NextLetter();
//healthMeter.value -= .10f;
            }
        }
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

    public void PlaceAnswer()
    {
        NamesChosen = new string[1];
        answerButton = 0;

        AnswersText[answerButton].text = Names[answerIndex];
        answer = AnswersText[answerButton].text;

        for (int i = 0; i < AnswersText.Length; i++)
        {
            if (AnswersText[i].text.Length >= 5)
                AnswersText[i].transform.localScale = new Vector3(.80f, .80f, 1.0f);
            else
                AnswersText[i].transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        NamesChosen[0] = Names[answerIndex];
       // int ChosenIndex = 0;

        /*for (int i = 0; i <= 3; i++)
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
        }*/
    }

   /* public void HungerMeter()
    {
        int currLife = (int)healthMeter.value;
        int maxLife = (int)healthMeter.maxValue;
        float lifeRatio = healthMeter.value / healthMeter.maxValue;
        healthMeter.value = lifeRatio;
    }*/

    // Update is called once per frame
    void Update () {
  
    }
}
