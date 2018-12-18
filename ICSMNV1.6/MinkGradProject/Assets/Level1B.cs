using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level1B : MonoBehaviour {

    public GameObject NameData;

    public Text[] AnswersText;
	public List<string> Names;
	public Text AnswerHint;
	public int answerButton = 0;
	int answerIndex = 8;
    AnimatorStateInfo animState;
    AnimatorClipInfo[] animClip;
    public float animTime;
    public GameObject Tutorial;

   // bool gameStart;// = false;
	// NEW STUFF IM WORKING WITH
	public string[] NamesChosen;
    public List<Animator> anim = new List<Animator>();
    public GameObject[] waterSprout;
    public GameObject[] m_Dolphins;
    public bool isSprouting;
    public List<Animation> dolphinAnim = new List<Animation>();
    public float dolpAnimTime;
    public string answer;
    public Button[] choiceNames;

    public enum DolphinState {Up, Idle, Down};
    public DolphinState m_Dolphin;

    public Vector3[] dolphinPos;
    public Vector3[] dolphinIdlePos;

	void Start () {

        switch (LevelManager.instance.m_Difficulty)
        {
            case LevelManager.Difficulty.Easy:
                UIManager.instance.heartsAmount = 5;
                break;

            case LevelManager.Difficulty.Normal:
                UIManager.instance.heartsAmount = 5;
                break;

            case LevelManager.Difficulty.Hard:
                UIManager.instance.heartsAmount = 3;
                break;

            case LevelManager.Difficulty.Genius:
                UIManager.instance.heartsAmount = 3;
                break;
        }

        m_Dolphin = DolphinState.Up;
        NameData = FindObjectOfType<LevelManager>().gameObject;
        UIManager.instance.StartGame();
        for(int i = 0; i < m_Dolphins.Length; i++)
        dolphinPos[i] = m_Dolphins[i].transform.localPosition;

        StartCoroutine(DolphinUp()); 

        int LoginNumber = PlayerPrefs.GetInt("loginNumber");

        UIManager.instance.mode = UIManager.subLevels1.Level1B;

        switch (LoginNumber){
		case 1:{
				AnswerHint.text =  PlayerPrefs.GetString ("firstName");
                    NameData.GetComponentInParent<NameData>().AddName(PlayerPrefs.GetString("firstName"));
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


    IEnumerator DolphinStates()
    {
        switch (m_Dolphin)
        {
            case DolphinState.Up:
                DolphinUp();
                break;
            case DolphinState.Idle:
                DolphinIdle();
                break;
            case DolphinState.Down:
                DolphinDown();
                break;
        }
        yield return null;
    }

    IEnumerator DolphinUp()
    {
        m_Dolphin = DolphinState.Up;

        for (int i = 0; i < dolphinAnim.Count; i++)
        dolphinAnim[i].Play("Dolphin-Idle");
        
        StartCoroutine(DolphinIdle());

        for (int i = 0; i < waterSprout.Length; i++)
        {
            waterSprout[i].GetComponent<Image>().enabled = false;
            waterSprout[i].GetComponent<Animator>().enabled = false;
        }
        isSprouting = false;

       // for(int i = 0; i < choiceNames.Length; i++)
        //choiceNames[i].interactable = true;

        yield return null;
    }

    IEnumerator DolphinIdle()
    {
        m_Dolphin = DolphinState.Idle;

        yield return new WaitForSeconds(1);
        for (int i = 0; i < dolphinAnim.Count; i++)
            dolphinAnim[i].Play("Dolphin-Up");
        
        yield return new WaitForSeconds(1);
        for (int i = 0; i < waterSprout.Length; i++)
        {
            waterSprout[i].GetComponent<Image>().enabled = true;
            waterSprout[i].GetComponent<Animator>().enabled = true;
            waterSprout[i].GetComponent<Animator>().Play("WaterSrpout");
        }
        //  for (int i = 0; i < waterSprout.Length; i++)
        //    waterSprout[i].SetActive(true);
        NextLetter();
        for (int i = 0; i < m_Dolphins.Length; i++)
        dolphinIdlePos[i] = m_Dolphins[i].transform.position;

        isSprouting = true;

        yield return new WaitForSeconds(0.2f);
        for(int i = 0; i < anim.Count; i++)
        anim[i].SetTrigger("Idle");

        for (int i = 0; i < choiceNames.Length; i++)
        {
            choiceNames[i].interactable = true;
            choiceNames[i].GetComponentInChildren<Text>().enabled = true;
        }
           // choiceNames[i].gameObject.SetActive(true);
    
    }

    IEnumerator DolphinDown()
    {
        m_Dolphin = DolphinState.Down;

        for (int i = 0; i < anim.Count; i++)
            anim[i].SetTrigger("End");

        for (int i = 0; i < anim.Count; i++)
            yield return new WaitForSeconds(.30f);

        isSprouting = false;

        for (int i = 0; i < waterSprout.Length; i++)
        {
            waterSprout[i].GetComponent<Image>().enabled = false;
            waterSprout[i].GetComponent<Animator>().enabled = false;
        }
        // for (int i = 0; i < waterSprout.Length; i++)
        // waterSprout[i].SetActive(false);

        yield return new WaitForSeconds(.20f);      

        for (int i = 0; i < dolphinAnim.Count; i ++)
            dolphinAnim[i].Play("Dolphin-Down");

      //  for (int i = 0; i < m_Dolphins.Length; i++)
            //m_Dolphins[i].transform.localPosition = Vector3.zero;//dolphinIdlePos[i];

        yield return new WaitForSeconds(1);

        for (int i = 0; i < m_Dolphins.Length; i++)
            m_Dolphins[i].transform.localPosition = dolphinPos[i];

        StartCoroutine(DolphinUp());

    }

    public void Choice1()
    {
        StartCoroutine(DolphinDown());
        for (int i = 0; i < choiceNames.Length; i++)
        {
            choiceNames[i].GetComponent<Button>().interactable = false;
            choiceNames[i].GetComponentInChildren<Text>().enabled = false;
        }
        if (answerButton == 0)
        {
            switch (LevelManager.instance.m_Difficulty)
            {
                case LevelManager.Difficulty.Genius:
                    UIManager.instance.AddTime(2);
                    break;
            }
            ScorePoints();
        }
        else
        {
            switch (LevelManager.instance.m_Difficulty)
            {
                case LevelManager.Difficulty.Normal:
                    UIManager.instance.DeductTime(5);
                    break;
                case LevelManager.Difficulty.Hard:
                    UIManager.instance.DeductTime(5);
                    break;
                case LevelManager.Difficulty.Genius:
                    UIManager.instance.DeductTime(5);
                    break;
            }
            LevelManager.instance.CheckAnswer(false, UIManager.instance.heartsAmount, UIManager.instance.seahorseAnim);

        }
    }

    public void Choice2()
    {
    
        StartCoroutine(DolphinDown());
        for (int i = 0; i < choiceNames.Length; i++)
        {
            choiceNames[i].GetComponent<Button>().interactable = false;
            choiceNames[i].GetComponentInChildren<Text>().enabled = false;
        }
        if (answerButton == 1)
        {
            switch (LevelManager.instance.m_Difficulty)
            {
                case LevelManager.Difficulty.Genius:
                    UIManager.instance.AddTime(2);
                    break;
            }
            ScorePoints();
        }
            
        else
        {
            switch (LevelManager.instance.m_Difficulty)
            {
                case LevelManager.Difficulty.Normal:
                    UIManager.instance.DeductTime(5);
                    break;
                case LevelManager.Difficulty.Hard:
                    UIManager.instance.DeductTime(5);
                    break;
                case LevelManager.Difficulty.Genius:
                    UIManager.instance.DeductTime(5);
                    break;
            }
            LevelManager.instance.CheckAnswer(false, UIManager.instance.heartsAmount, UIManager.instance.seahorseAnim);
     
        }
    }

	public void Choice3()
    {
        StartCoroutine(DolphinDown());
        for (int i = 0; i < choiceNames.Length; i++)
        {
            choiceNames[i].GetComponent<Button>().interactable = false;
            choiceNames[i].GetComponentInChildren<Text>().enabled = false;
        }
        if (answerButton == 2)
        {
            switch (LevelManager.instance.m_Difficulty)
            {
                case LevelManager.Difficulty.Genius:
                    UIManager.instance.AddTime(2);
                    break;
            }
            ScorePoints();
        }
        else
        {
            switch (LevelManager.instance.m_Difficulty)
            {
                case LevelManager.Difficulty.Normal:
                    UIManager.instance.DeductTime(5);
                    break;
                case LevelManager.Difficulty.Hard:
                    UIManager.instance.DeductTime(5);
                    break;
                case LevelManager.Difficulty.Genius:
                    UIManager.instance.DeductTime(5);
                    break;
            }
            LevelManager.instance.CheckAnswer(false, UIManager.instance.heartsAmount, UIManager.instance.seahorseAnim);
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
                UIManager.instance.ScorePoints();
                break;

            case LevelManager.Difficulty.Normal:
                UIManager.instance.ScorePoints();
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
		//answerIndex = 8;      
        AnswerHint.text = Names[answerIndex];
		answerButton = Random.Range (0, 3);
		AnswersText[answerButton].text = Names[answerIndex];
		//	SetOtherButtons ();		
		PlaceAnswer ();
	}


    public void PlaceAnswer()
    {
        NamesChosen = new string[4];
        answerButton = Random.Range(0, 3);

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
        for (int i = 0; i <= 2; i++)
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

                        switch (LevelManager.instance.m_Difficulty)
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


    private void Update()
    {
        if (isSprouting)
        {
            for (int i = 0; i < anim.Count; i++)
            {
                animClip = anim[i].GetCurrentAnimatorClipInfo(0);
                animState = anim[i].GetCurrentAnimatorStateInfo(0);
                animTime = animClip[0].clip.length * animState.normalizedTime;
            }
        }

        

    }

}
