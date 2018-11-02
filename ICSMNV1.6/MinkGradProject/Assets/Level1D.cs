using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Level1D: MonoBehaviour {

    public GameObject NameData;
    public List<Text> AnswersText = new List<Text>();
    public List<string> Names = new List<string>();
	public Text AnswerHint;
	public int answerButton = 0;
	int answerIndex, wrongIndex;

	public GameObject Tutorial;

	//bool gameStart = false;
	// NEW STUFF IM WORKING WITH
	public List<string> NamesChosen = new List<string>();
	public Animator ButtonAnim1;
    public string answer;
    //public Slider healthMeter;
    public GameObject fishRef, badFishRef;
    public GameObject bubbleRef;
    public GameObject killZone;

    public GameObject m_Waves;

    public int fishIndex = -1 , badFishIndex = -1;

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

            if (AnswerHint.text == Names[i])
            {
                answerIndex = i;

            }
        }

        answer = NameData.GetComponentInParent<NameData>().GetName(PlayerPrefs.GetString("firstName"));

        InvokeRepeating("SpawnFish", Random.Range(0.5f, 5.0f), Random.Range(2.5f, 5.0f));
        InvokeRepeating("SpawnBadFish", Random.Range(0.5f, 5.0f), Random.Range(2.5f, 5.0f));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
       // Gizmos.DrawLine(startLine, endLine);
    }

    void SpawnFish()
    {
        GameObject fish = Instantiate(fishRef, new Vector3(0, 0, 0), Quaternion.identity, gameObject.transform);
       // AnswersText[fishIndex] = fish.GetComponentInChildren<Text>();
        AnswersText.Add(fish.GetComponentInChildren<Text>());
        fish.GetComponent<Fish>().mood = Fish.FishMood.Good;
        fishIndex++;
        PlaceAnswer();
        fish.name = "Fish " + (fishIndex + 1);
    }

    void SpawnBadFish()
    {
        GameObject badFish = Instantiate(fishRef, new Vector3(0, 0, 0), Quaternion.identity, gameObject.transform);
        AnswersText.Add(badFish.GetComponentInChildren<Text>());
        badFish.GetComponent<Fish>().mood = Fish.FishMood.Bad;
        fishIndex++;
        PlaceWrongAnswer();       
        badFish.name = "Bad Fish " + fishIndex;
    }

    public void Choice1(GameObject fish)
    {
        
        if (fish.GetComponentInChildren<Text>().text == answer)
        {
            GameObject bubbleParticle = Instantiate(bubbleRef, new Vector3(0, 0, 0), Quaternion.identity, gameObject.transform);     
            bubbleParticle.transform.position = fish.transform.position;

            Destroy(fish);

            UIManager.instance.ScorePoints(5);
          //  healthMeter.value += .10f;
        }
        else
        {
            LevelManager.instance.CheckAnswer(false, UIManager.instance.heartsAmount, UIManager.instance.seahorseAnim);
            GameObject bubbleParticle = Instantiate(bubbleRef, new Vector3(0, 0, 0), Quaternion.identity, gameObject.transform);
            bubbleParticle.transform.position = fish.transform.position;
            Destroy(fish);

            if (LevelManager.instance.correctAnswerPoints < 5)
            {
         
                // healthMeter.value -= .10f;
            }
        }
    }

	public void Reset (){
  
        AnswerHint.text = Names[answerIndex];
		answerButton = Random.Range (0, 4);
		AnswersText[answerButton].text = Names[answerIndex];

		PlaceAnswer ();
	}

    public void PlaceWrongAnswer()
    {
         int ChosenIndex = 0;
      
                bool Used = true;
                int wrongName = 0;
                while (Used)
                {
                    wrongName = Random.Range(0, Names.Count);

                    //Checks to see if wrong names chosen equals to answer, if it does, choose again
                    while (Names[wrongName] == answer)
                        wrongName = Random.Range(0, Names.Count);

                    Used = false;
                    for (int j = 0; j < NamesChosen.Count; j++)
                    {
                        if (Names[wrongName] == NamesChosen[j])
                        {
                            Used = true;
                            break;
                        }
                    }
                    if (Used != true)
                    {
                        NamesChosen.Add(Names[wrongName]);
                        AnswersText[fishIndex].text = Names[wrongName];
                        ChosenIndex++;

                break;
                    }



                }
    }

    public void PlaceAnswer()
    {
        answerButton = 0;

        AnswersText[fishIndex].text = NameData.GetComponentInParent<NameData>().GetName(PlayerPrefs.GetString("firstName"));

        if (AnswersText[fishIndex].text.Length >= 5)
                AnswersText[fishIndex].transform.localScale = new Vector3(.80f, .80f, 1.0f);
            else
                AnswersText[fishIndex].transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        NamesChosen.Add(NameData.GetComponentInParent<NameData>().GetName(PlayerPrefs.GetString("firstName")));
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
