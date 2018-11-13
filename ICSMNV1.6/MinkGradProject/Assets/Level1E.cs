using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level1E: MonoBehaviour {

    public GameObject NameData;
    public List<string> Names;
    public Text[] AnswersText;
	public Text AnswerHint;
	public int answerButton = 0;
	int answerIndex = 8;
    public string answer;


    public string[] NamesChosen;

    public GameObject enemyRef;
    public int enemyIndex = 0;
    public GameObject m_Waves;
    public List<GameObject> m_Lanes = new List<GameObject>();

    public Transform muzzlePos;
    public GameObject cannonBallRef;
    public GameObject pathParent;
    public GameObject m_Cannon;
    private int numOfTrajectoryPoints = 30;
    private List<GameObject> trajectoryPoints = new List<GameObject>();
    public Vector3 velocity;

    void Start()
    {
        NameData = FindObjectOfType<LevelManager>().gameObject;

        UIManager.instance.StartGame();
        UIManager.instance.mode = UIManager.subLevels1.Level1A;

        int LoginNumber = PlayerPrefs.GetInt("loginNumber");
        switch (LoginNumber)
        {
            case 1:
                {
                 //   AnswerHint.text = PlayerPrefs.GetString("firstName");
                    NameData.GetComponentInParent<NameData>().AddName(PlayerPrefs.GetString("firstName"));
                    break;
                }
            case 2:
                {
                  //  AnswerHint.text = PlayerPrefs.GetString("secondName");
                    NameData.GetComponentInParent<NameData>().AddName(PlayerPrefs.GetString("secondName"));
                    break;
                }
            case 3:
                {
                   // AnswerHint.text = PlayerPrefs.GetString("thirdName");
                    NameData.GetComponentInParent<NameData>().AddName(PlayerPrefs.GetString("thirdName"));
                    break;
                }
            case 4:
                {
                  //  AnswerHint.text = PlayerPrefs.GetString("fourthName");
                    NameData.GetComponentInParent<NameData>().AddName(PlayerPrefs.GetString("fourthName"));
                    break;
                }
        }

        Names = NameData.GetComponent<NameData>().data; 

        for (int i = 0; i < AnswersText.Length; i++)
        {
            if (AnswersText[i].text.Length >= 5)
                AnswersText[i].transform.localScale = new Vector3(.80f, .80f, 1.0f);
            else
                AnswersText[i].transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }

        SpawnEnemyBoat();


        for (int i = 0; i < numOfTrajectoryPoints; i++)
        {
            GameObject dot = Instantiate(Resources.Load<GameObject>("Prefabs/TrajectoryPath"), new Vector3(0, 0, 0), Quaternion.identity, pathParent.transform);
            dot.name = "Dot";

            trajectoryPoints.Insert(i, dot);
        }
    }

    void SpawnEnemyBoat()
    {
        GameObject enemyBoat = Instantiate(enemyRef, new Vector3(1200, 0, 0), Quaternion.identity, m_Waves.transform);
        enemyIndex++;
     //   PlaceAnswer();
        enemyBoat.name = "Enemy Boat " + enemyIndex;
      //  activeFish.Add(fish);
    }

    void SpawnCannonBall()
    {
        GameObject cannonBall = Instantiate(cannonBallRef, muzzlePos.position, Quaternion.identity, gameObject.transform);
        cannonBall.name = "CannonBall";

        
        //   Debug.Log("Firing at " + point + " velocity " + velocity);

       // cannonBall.GetComponent<CannonBall>().physics.transform.position = transform.position;
       // cannonBall.GetComponent<CannonBall>().physics.velocity = velocity;

    }

    void setTrajectoryPoints(Vector3 pStartPosition, Vector3 pVelocity)
    {
        float velocity = Mathf.Sqrt((pVelocity.x * pVelocity.x) + (pVelocity.y * pVelocity.y));
        float angle = Mathf.Rad2Deg * (Mathf.Atan2(pVelocity.y, pVelocity.x));
        float fTime = 0;

        fTime += 0.1f;
        for (int i = 0; i < numOfTrajectoryPoints; i++)
        {
            float dx = velocity * fTime * Mathf.Cos(angle * Mathf.Deg2Rad);
            float dy = velocity * fTime * Mathf.Sin(angle * Mathf.Deg2Rad) - (Physics2D.gravity.magnitude * fTime * fTime / 2.0f);
            Vector3 pos = new Vector3(pStartPosition.x + dx, pStartPosition.y + dy, 2);
            trajectoryPoints[i].transform.localPosition = pos;
            //trajectoryPoints[i].renderer.enabled = true;
            trajectoryPoints[i].transform.localEulerAngles = new Vector3(0, 0, Mathf.Atan2(pVelocity.y - (Physics2D.gravity.magnitude) * fTime, pVelocity.x) * Mathf.Rad2Deg);
            fTime += 0.1f;
        }
    }

    public void Choice1()
    {
        SpawnCannonBall();

        if (answerButton == 0)
        {
         //   NextLetter();
            UIManager.instance.ScorePoints();
        }
        else
        {
         
            LevelManager.instance.CheckAnswer(false, UIManager.instance.heartsAmount, UIManager.instance.seahorseAnim);
          
           // if (LevelManager.instance.correctAnswerPoints < 3)
              //  NextLetter();
        }
    }
    public void Choice2()
    {

        if (answerButton == 1)
        {
           // NextLetter();
            UIManager.instance.ScorePoints();
        }
        else
        {
         
            LevelManager.instance.CheckAnswer(false, UIManager.instance.heartsAmount, UIManager.instance.seahorseAnim);

            //if (LevelManager.instance.correctAnswerPoints < 3)
               // NextLetter();
        }
    }
    public void Choice3()
    {

        if (answerButton == 2)
        {
          //  NextLetter();
            UIManager.instance.ScorePoints();
        }
        else
        {
           
            LevelManager.instance.CheckAnswer(false, UIManager.instance.heartsAmount, UIManager.instance.seahorseAnim);
           
            //if (LevelManager.instance.correctAnswerPoints < 3)
               // NextLetter();
        }
    }

    public void NextLetter()
    {
        PlaceAnswer();
    }

    public void Reset()
    {
  
    }

    public void PlaceAnswer()
    {
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

    private Vector2 GetForceFrom(Vector3 fromPos, Vector3 toPos)
    {
        return (new Vector2(toPos.x, toPos.y) - new Vector2(fromPos.x, fromPos.y)) * 25;
    }
    // Update is called once per frame
    void Update () {
        velocity = GetForceFrom(muzzlePos.localPosition, Camera.main.ScreenToWorldPoint(Input.mousePosition));
        float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
        m_Cannon.transform.localEulerAngles = new Vector3(0, 0, angle);
    //    muzzlePos.localEulerAngles = new Vector3(0, 0, angle);
        setTrajectoryPoints(muzzlePos.localPosition, velocity / 20);
        //setTrajectoryPoints(muzzlePos.position, velocity);
    }
}
