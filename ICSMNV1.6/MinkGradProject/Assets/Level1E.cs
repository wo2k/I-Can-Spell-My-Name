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
    public GameObject muzzleFlashRef;
    public GameObject cannonBallRef;
    public GameObject pathParent;
    public GameObject m_Cannon;
    private int numOfTrajectoryPoints = 30;
    private List<GameObject> trajectoryPoints = new List<GameObject>();
    public Vector3 velocity;

    //Miss
    public List<Transform> targetMiss = new List<Transform>();
    public bool AnswerCorrect;
    public bool lockedOntoBoat;
    int fireMissTimer;
    public enum randomOpperand { Add, Subtract};

    //Cannonball Loading
    float currentValue;
    public float speed;
    public bool canShoot;
    public ReloadCannonAmmo[] LoadingBars;

    //Waves
    public int currentWaveIndex = 0;
    public int MaxWaveIndex = 3;
    public List<GameObject> boatsInWave = new List<GameObject>();
    public List<int> boatIDNum = new List<int>();

    void Start()
    {
        

        switch (LevelManager.instance.m_Difficulty)
        {
            case LevelManager.Difficulty.Easy:
                UIManager.instance.heartsAmount = 5;
                break;

            case LevelManager.Difficulty.Normal:
                UIManager.instance.heartsAmount = 4;
                break;

            case LevelManager.Difficulty.Hard:
                UIManager.instance.heartsAmount = 3;
                break;

            case LevelManager.Difficulty.Genius:
                UIManager.instance.heartsAmount = 2;
                break;
        }

        NameData = FindObjectOfType<LevelManager>().gameObject;

        UIManager.instance.StartGame();
        UIManager.instance.mode = UIManager.subLevels1.Level1A;

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
        StartCoroutine(SpawnEnemyWaves());
     

        LoadingBars = FindObjectsOfType<ReloadCannonAmmo>();
    
    }

    IEnumerator SpawnEnemyWaves()
    {
        for (; currentWaveIndex < MaxWaveIndex; currentWaveIndex++)
        {
            switch(currentWaveIndex)
            {
                case 0:
                    StartCoroutine(SpawnEnemyBoat(1));
                    break;
                case 1:
                    StartCoroutine(SpawnEnemyBoat(2));
                    break;
                case 2:
                    StartCoroutine(SpawnEnemyBoat(3));
                    break;
            }

            yield return new WaitUntil(() => boatsInWave.Count <= 0);
            boatIDNum.Clear();
        }
    }

    IEnumerator SpawnEnemyBoat(int enemyQty)
    {
        for (int i = 0; i < enemyQty; i++)
        {
            GameObject enemyBoat = Instantiate(enemyRef, new Vector3(1200, 0, 0), Quaternion.identity, m_Waves.transform);
            enemyIndex++;
            PlaceAnswer();
            enemyBoat.name = "Enemy Boat " + enemyIndex;
            boatsInWave.Add(enemyBoat);
            float duration = Random.Range(0f, 5f);

            yield return new WaitForSeconds(duration);
        }
        lockedOntoBoat = true;
    }

    void SpawnCannonBall()
    {
        GameObject cannonBall = Instantiate(cannonBallRef, muzzlePos.position, Quaternion.identity, gameObject.transform);
        cannonBall.name = "CannonBall";

        GameObject muzzleFlash = Instantiate(muzzleFlashRef, muzzlePos.position, Quaternion.identity, m_Cannon.transform);
        muzzleFlash.name = "MuzzleFlash";
        muzzleFlash.transform.localEulerAngles = new Vector3(0, 0, 543);

        SoundManagement.TriggerEvent("PlayCannonShot");
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
        foreach (EnemyBoat item in FindObjectsOfType<EnemyBoat>())
        {
            item.gameObject.transform.GetChild(0).GetComponent<Animation>()["Boat-Cruise02"].speed = 0;
        }

        for(int i = 0; i < LoadingBars.Length; i++)
        {
            LoadingBars[i].currentValue = 100;
            StartCoroutine(LoadingBars[i].ReloadCannon());
        }
        
        if (answerButton == 0)
        {
            AnswerCorrect = true;
            SpawnCannonBall();
        }
        else
        {
            lockedOntoBoat = false;
            AnswerCorrect = false;
            StartCoroutine("AnimateCannon");
            
        }
    }
    public void Choice2()
    {
        foreach (EnemyBoat item in FindObjectsOfType<EnemyBoat>())
        {
            item.gameObject.transform.GetChild(0).GetComponent<Animation>()["Boat-Cruise02"].speed = 0;
        }

        for (int i = 0; i < LoadingBars.Length; i++)
        {
            LoadingBars[i].currentValue = 100;
            StartCoroutine(LoadingBars[i].ReloadCannon());
        }

        if (answerButton == 1)
        {
            AnswerCorrect = true;
            SpawnCannonBall();
        }
        else
        {
            lockedOntoBoat = false;
            AnswerCorrect = false;
            StartCoroutine("AnimateCannon");
        }
    }
    public void Choice3()
    {
        foreach (EnemyBoat item in FindObjectsOfType<EnemyBoat>())
        {
            item.gameObject.transform.GetChild(0).GetComponent<Animation>()["Boat-Cruise02"].speed = 0;
        }


        for (int i = 0; i < LoadingBars.Length; i++)
        {
            LoadingBars[i].currentValue = 100;
            StartCoroutine(LoadingBars[i].ReloadCannon());
        }

        if (answerButton == 2)
        {
            AnswerCorrect = true;
            
            SpawnCannonBall();
        }
        else
        {
            lockedOntoBoat = false;
            
            AnswerCorrect = false;
            StartCoroutine("AnimateCannon");
        }
    }

    public void NextLetter()
    {
        PlaceAnswer();
    }

    void ScorePoints()
    {
        switch (LevelManager.instance.m_Difficulty)
        {
            case LevelManager.Difficulty.Easy:
                UIManager.instance.ScorePoints(3);
                break;

            case LevelManager.Difficulty.Normal:
                UIManager.instance.ScorePoints(3);
                break;

            case LevelManager.Difficulty.Hard:
                UIManager.instance.ScorePoints(3);
                break;

            case LevelManager.Difficulty.Genius:
                UIManager.instance.ScorePoints(3);
                break;
        }
    }

    public void PlaceAnswer()
    {
        NamesChosen = new string[3];
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


    private Vector2 GetForceFrom(Vector3 fromPos, Vector3 toPos, Vector3 speed)
    {
        return (new Vector2(toPos.x, toPos.y) - new Vector2(fromPos.x, fromPos.y) - new Vector2(speed.x, speed.y));
    }

    private Vector3 GetRandomOpperand(Vector2 a, Vector2 b, randomOpperand opperand)
    {
        if (opperand == randomOpperand.Add) return a + b;
        if (opperand == randomOpperand.Subtract) return b - a;
        throw new System.NotImplementedException();
    }

    public IEnumerator AnimateCannon()
    {
        Vector3 targetPos = targetMiss[Random.Range(0, targetMiss.Count)].transform.position;
       // var calculate = Random.Range(0, 2) == 0 ? randomOpperand.Add : randomOpperand.Subtract;

        while (!lockedOntoBoat)
        {
            fireMissTimer++;
            velocity = new Vector2(velocity.x, velocity.y) + GetForceFrom(muzzlePos.localPosition, targetPos, new Vector3(750, -300, 0));
            float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
            angle /= 2.5f;
            m_Cannon.transform.localEulerAngles = new Vector3(0, 0, angle);
            yield return new WaitForSeconds(0.1f);
            if(fireMissTimer >= 2)
              lockedOntoBoat = true;
        }
        SpawnCannonBall();
        yield return null;
    }

   

    // Update is called once per frame
    void Update () {

        if (lockedOntoBoat)
        {
            velocity = GetForceFrom(muzzlePos.localPosition, FindObjectOfType<EnemyBoat>().gameObject.transform.GetChild(0).gameObject.transform.position, new Vector3(750, -300, 0));
            float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;
            angle /= 2.5f;
            m_Cannon.transform.localEulerAngles = new Vector3(0, 0, angle);
        }

    }
}
