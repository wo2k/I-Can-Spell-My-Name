using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public static class GameObjectExtensions
{
    /// <summary>
    /// Checks if a GameObject has been destroyed.
    /// </summary>
    /// <param name="gameObject">GameObject reference to check for destructedness</param>
    /// <returns>If the game object has been marked as destroyed by UnityEngine</returns>
    public static bool IsDestroyed(this GameObject gameObject)
    {
        // UnityEngine overloads the == opeator for the GameObject type
        // and returns null when the object has been destroyed, but 
        // actually the object is still there but has not been cleaned up yet
        // if we test both we can determine if the object has been destroyed.
        return gameObject == null && !ReferenceEquals(gameObject, null);
    }
}

public class UIManager : MonoBehaviour {

    [Header("HUD")]
    public GameObject[] hearts;
    public GameObject healthBar;
    public int heartsAmount = 3;
    public GameObject HUD;
    public Text timetext;
    [HideInInspector]
    public float timer = 60.0f;
    [HideInInspector]
    public float minutes = 1;
    [HideInInspector]
    public float seconds = 0;
    public Text scoreText;
    [HideInInspector]
    public int score = 0;
    [HideInInspector]
    public int total = 0;
    public Animator seahorseAnim;
    public Text answerHint;

    [Space]

    [Header ("Menu Objects")]
    public GameObject startMenu;
    public GameObject endMenu;
    public GameObject pauseMenu;
   
    public GameObject confirmSubMenu;
    public GameObject pauseButton;
    public GameObject winScreen;

    [Space]

    [Header("Seahorse Settings")]
    [HideInInspector]
    public GameObject m_Bubble;
    public GameObject m_SeaHorse;
    public Transform bubblePos;
    public Animation bubbleAnim;
    [HideInInspector]
    public Text bubbleText;
    public string[] positiveResponse;
    public string[] negativeResponse;
    public Image bubbleType;
    public List<GameObject> bubbleQueue;

    [Space]

    [Header("Stats")]
    public string levelName;
    
    public enum subLevels1 { Level1A, Level1B, Level1C, Level1D, Level1E, None };
    public subLevels1 mode;
    public enum subLevels2 { Level2A, Level2B, Level2C, Level2D, Level2E, Level2F, None };
    public subLevels2 mode2;
    public bool[] hasWonAlready = { false, false, false, false, false };
    public bool[] hasWonAlready2 = { false, false, false, false, false, false };
    public int hasWonIndex;
    public int hasWonIndex2;
    public int hasWonDifficultyIndex;
    [HideInInspector]
    public bool gameStart = false;
  //  [HideInInspector]
    public bool inGame = false;

   // public Image spriteToGlow;

    public static UIManager instance;
    
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(instance);
    }

    public void CloseApplication()
    {
        if (LevelManager.instance.m_Console == LevelManager.AppPlatform.Windows)
        {
#if UNITY_EDITOR
             if (Application.platform == RuntimePlatform.WindowsEditor)
               UnityEditor.EditorApplication.isPlaying = false;
#endif
            if (Application.platform == RuntimePlatform.WindowsPlayer)
                Application.Quit();
        }

        if (LevelManager.instance.m_Console == LevelManager.AppPlatform.MacOS)
        {
#if UNITY_EDITOR
            if (Application.platform == RuntimePlatform.OSXEditor)
                UnityEditor.EditorApplication.isPlaying = false;
#endif
            if (Application.platform == RuntimePlatform.OSXPlayer)
                Application.Quit();
        }
    }

    #region Menu Options
    public void StartGame()
    {
        LevelManager.instance.m_Mode = LevelManager.LevelType.GameMode;
        answerHint.text = PlayerPrefs.GetString("firstName");
        switch (levelName)
        {
            case "Level1A":
                Level1A level1ARef = FindObjectOfType<Level1A>();
                level1ARef.PlaceAnswer();
                break;
            case "Level1B":
                Level1B level1BRef = FindObjectOfType<Level1B>();
                level1BRef.PlaceAnswer();
                break;
            case "Level1C":
                FindObjectOfType<Level1C>().PlaceAnswer();
                break;
            case "Level1D":
              //  Level1D level1DRef = FindObjectOfType<Level1D>();
             //   level1DRef.PlaceAnswer();
                break;
            case "Level1E":
              //  FindObjectOfType<Level1E>().PlaceAnswer();
                break;
        }
        ResetGameStats();

    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        gameStart = false;
        LevelManager.instance.m_Mode = LevelManager.LevelType.Menus;
        Time.timeScale = 0;    
    }
    public void UnPauseGame()
    {
        pauseMenu.SetActive(false);
        gameStart = true;
        LevelManager.instance.m_Mode = LevelManager.LevelType.GameMode;
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        endMenu.SetActive(true);
        gameStart = false;
        Time.timeScale = 0;
        inGame = false;
    }

    public void WinGame(int subLevel)
    {
        SoundManagement.TriggerEvent("PlayLevelComplete");
        winScreen.SetActive(true);
        gameStart = false;
        hasWonIndex = (int)mode;
        hasWonIndex2 = (int)mode2;
        hasWonDifficultyIndex = (int)LevelManager.instance.m_Difficulty;

      //  Debug.LogError(SceneManager.GetActiveScene().name.ToString());
        Time.timeScale = 0;

        for (int i = 0; i < subLevel; i++)
        {
            if ((SceneManager.GetActiveScene().name.ToString().Contains("Level1")))
            {
                if (mode == (subLevels1)i)
                {
                    switch (i)
                    {
                        case 0:
                            LevelManager.instance.level1Capture = LevelManager.instance.level1A;
                            break;
                        case 1:
                            LevelManager.instance.level1Capture = LevelManager.instance.level1B;
                            break;
                        case 2:
                            LevelManager.instance.level1Capture = LevelManager.instance.level1C;
                            break;
                        case 3:
                            LevelManager.instance.level1Capture = LevelManager.instance.level1D;
                            break;
                        case 4:
                            LevelManager.instance.level1Capture = LevelManager.instance.level1E;
                            if (FindObjectOfType<CannonBall>())
                                Destroy(FindObjectOfType<CannonBall>());

                            FindObjectOfType<Level1E>().lockedOntoBoat = false;
                            break;
                    }

                    LevelManager.instance.SetNewHighScore(System.Enum.GetValues(typeof(subLevels1)).Length, LevelManager.instance.m_Difficulty);

                    for (int j = 0; j < System.Enum.GetValues(typeof(LevelManager.Difficulty)).Length; j++)
                    {
                        if (LevelManager.instance.m_Difficulty == (LevelManager.Difficulty)j)
                        {
                            switch (j)
                            {
                                case 0:
                                    LevelManager.instance.m_DifficultyCapture = LevelManager.Difficulty.Easy;
                                    break;
                                case 1:
                                    LevelManager.instance.m_DifficultyCapture = LevelManager.Difficulty.Normal;
                                    break;
                                case 2:
                                    LevelManager.instance.m_DifficultyCapture = LevelManager.Difficulty.Hard;
                                    if (!hasWonAlready[hasWonIndex])
                                    {
                                        hasWonAlready[hasWonIndex] = true;
                                        if (mode != subLevels1.Level1E)
                                        {
                                            LevelManager.instance.subLevelPassed++;
                                            PlayerPrefs.SetInt("SubLevelPassed", LevelManager.instance.subLevelPassed);
                                        }
                                        else
                                        {
                                            LevelManager.instance.levelPassed++;
                                            PlayerPrefs.SetInt("LevelPassed", LevelManager.instance.levelPassed);
                                            LevelManager.instance.subLevelPassed++;
                                            PlayerPrefs.SetInt("SubLevelPassed", LevelManager.instance.subLevelPassed);
                                            LevelManager.instance.m_MainLevelToBeat = (LevelManager.MainLevelToBeat)LevelManager.instance.levelPassed;
                                        }
                                        LevelManager.instance.m_LevelToBeat = (LevelManager.LevelToBeat)LevelManager.instance.subLevelPassed;
                                        PlayerPrefs.SetInt("HasWonAlready " + i, BoolToInt(hasWonAlready[hasWonIndex]));
                                        LevelManager.instance.hasLockedBefore = false;
                                        LevelManager.instance.hasShownStoryAlready = false;
                                        PlayerPrefs.SetInt("HasShownStoryAlready", BoolToInt(LevelManager.instance.hasShownStoryAlready));
                                    }
                                    break;
                                case 3:
                                    LevelManager.instance.m_DifficultyCapture = LevelManager.Difficulty.Genius;
                                    break;
                            }

                            if (!LevelManager.instance.level1Capture.hasWonAlready[hasWonIndex, hasWonDifficultyIndex])
                            {
                                LevelManager.instance.level1Capture.hasWonAlready[hasWonIndex, hasWonDifficultyIndex] = true;
                                LevelManager.instance.level1Capture.modePassed++;
                                PlayerPrefs.SetInt(LevelManager.instance.m_DifficultyCapture + " ModePassed " + i, LevelManager.instance.level1Capture.modePassed);
                                PlayerPrefs.SetInt(LevelManager.instance.m_DifficultyCapture + " HasWonAlready " + i, BoolToInt(LevelManager.instance.level1Capture.hasWonAlready[hasWonIndex, hasWonDifficultyIndex]));
                                LevelManager.instance.level1Capture.hasLockedBefore = false;
                                LevelManager.instance.level1Capture.m_DifficultyToBeat = (LevelSettings.DifficultyToBeat)LevelManager.instance.level1Capture.modePassed;
                            }
                            else
                                return;
                        }
                    }
                }
            }

            if(SceneManager.GetActiveScene().name.ToString().Contains("Level2"))
            {
                if (mode2 == (subLevels2)i)
                {
                    switch (i)
                    {
                        case 0:
                            LevelManager.instance.level2Capture = LevelManager.instance.level2A;
                            break;
                        case 1:
                            LevelManager.instance.level2Capture = LevelManager.instance.level2B;
                            break;
                        case 2:
                            LevelManager.instance.level2Capture = LevelManager.instance.level2C;
                            break;
                        case 3:
                            LevelManager.instance.level2Capture = LevelManager.instance.level2D;
                            break;
                        case 4:
                            LevelManager.instance.level2Capture = LevelManager.instance.level2E;                   
                            break;
                        case 5:
                            LevelManager.instance.level2Capture = LevelManager.instance.level2F;
                            break;
                    }

                    LevelManager.instance.SetNewHighScore(System.Enum.GetValues(typeof(subLevels2)).Length, LevelManager.instance.m_Difficulty);

                    for (int j = 0; j < System.Enum.GetValues(typeof(LevelManager.Difficulty)).Length; j++)
                    {
                        if (LevelManager.instance.m_Difficulty == (LevelManager.Difficulty)j)
                        {
                            switch (j)
                            {
                                case 0:
                                    LevelManager.instance.m_DifficultyCapture = LevelManager.Difficulty.Easy;
                                    break;
                                case 1:
                                    LevelManager.instance.m_DifficultyCapture = LevelManager.Difficulty.Normal;
                                    break;
                                case 2:
                                    LevelManager.instance.m_DifficultyCapture = LevelManager.Difficulty.Hard;
                                    if (!hasWonAlready2[hasWonIndex2])
                                    {
                                        hasWonAlready2[hasWonIndex2] = true;
                                        LevelManager.instance.subLevelPassed++;
                                        LevelManager.instance.m_LevelToBeat = (LevelManager.LevelToBeat)LevelManager.instance.subLevelPassed;
                                        PlayerPrefs.SetInt("SubLevelPassed", LevelManager.instance.subLevelPassed);
                                        PlayerPrefs.SetInt("HasWonAlready2 " + i, BoolToInt(hasWonAlready2[hasWonIndex2]));
                                        LevelManager.instance.hasLockedBefore = false;
                                        LevelManager.instance.hasShownStoryAlready = false;
                                        PlayerPrefs.SetInt("HasShownStoryAlready", BoolToInt(LevelManager.instance.hasShownStoryAlready));
                                    }
                                    break;
                                case 3:
                                    LevelManager.instance.m_DifficultyCapture = LevelManager.Difficulty.Genius;
                                    break;
                            }

                            if (!LevelManager.instance.level2Capture.hasWonAlready2[hasWonIndex2, hasWonDifficultyIndex])
                            {
                                LevelManager.instance.level2Capture.hasWonAlready2[hasWonIndex2, hasWonDifficultyIndex] = true;
                                LevelManager.instance.level2Capture.modePassed++;
                                PlayerPrefs.SetInt(LevelManager.instance.m_DifficultyCapture + " ModePassed " + i, LevelManager.instance.level2Capture.modePassed);
                                PlayerPrefs.SetInt(LevelManager.instance.m_DifficultyCapture + " HasWonAlready " + i, BoolToInt(LevelManager.instance.level2Capture.hasWonAlready2[hasWonIndex, hasWonDifficultyIndex]));
                                LevelManager.instance.level2Capture.hasLockedBefore = false;
                                LevelManager.instance.level2Capture.m_DifficultyToBeat = (LevelSettings.DifficultyToBeat)LevelManager.instance.level2Capture.modePassed;
                            }
                            else
                                return;
                        }
                    }
                }
            }
        }

        LevelManager.instance.SavePlayerPrefs();       
    }

    public void RestartGame()
    {
        if (mode == subLevels1.Level1E && !inGame)
        {
            FindObjectOfType<Level1E>().AnswerCorrect = false;

            foreach (GameObject item in FindObjectsOfType<GameObject>())
            {
                if (item.scene == SceneManager.GetActiveScene())
                    Destroy(item);
            }
        }

       
        LevelManager.instance.m_Mode = LevelManager.LevelType.GameMode;
        SceneManager.LoadScene(levelName);
        ResetGameStats();       
    }

    public void GoToMainMenu()
    {
        LevelManager.instance.m_Mode = LevelManager.LevelType.Menus;
        switch (levelName)
        {
            case "Level1A":
                FindObjectOfType<Level1A>().Reset();
                break;
            case "Level1B":
                FindObjectOfType<Level1B>().Reset();
                break;
            case "Level1C":
                FindObjectOfType<Level1C>().Reset();
                break;
            case "Level1D":
                FindObjectOfType<Level1D>().Reset();
                break;
            case "Level1E":
               // FindObjectOfType<Level1E>().Reset();
                break;
        }
        ResetGameStats();
        
    }

    public void NextLevel()
    {
        SoundManagement.TriggerEvent("PlayPop");
        inGame = false;

        if ((SceneManager.GetActiveScene().name.ToString().Contains("Level1")))
        {
            for (int i = 0; i < System.Enum.GetValues(typeof(subLevels1)).Length; i++)
            {
                if (mode == (subLevels1)i)
                {
                    switch (i)
                    {
                        case 0:
                            LevelManager.instance.level1Capture = LevelManager.instance.level1A;
                            break;
                        case 1:
                            LevelManager.instance.level1Capture = LevelManager.instance.level1B;
                            break;
                        case 2:
                            LevelManager.instance.level1Capture = LevelManager.instance.level1C;
                            break;
                        case 3:
                            LevelManager.instance.level1Capture = LevelManager.instance.level1D;
                            break;
                        case 4:
                            LevelManager.instance.level1Capture = LevelManager.instance.level1E;

                            if (FindObjectOfType<EnemyBoat>())
                            {
                                foreach (EnemyBoat item in FindObjectsOfType<EnemyBoat>())
                                    Destroy(item.gameObject);
                            }

                            break;
                    }

                    if (mode == subLevels1.Level1E && LevelManager.instance.level1Capture.m_DifficultyToBeat >= LevelSettings.DifficultyToBeat.Genius && LevelManager.instance.m_LevelToBeat >= LevelManager.LevelToBeat.Level2A)
                    {
                        levelName = "Campaign";
                        SceneManager.LoadScene(levelName);
                        LevelManager.instance.m_Mode = LevelManager.LevelType.Menus;
                    }

                    if (LevelManager.instance.level1Capture.m_DifficultyToBeat <= LevelSettings.DifficultyToBeat.Hard && LevelManager.instance.level1Capture.m_DifficultyToBeat >= LevelSettings.DifficultyToBeat.Easy)
                    {
                        levelName = "LevelDescription";
                        SceneManager.LoadScene(levelName);
                        LevelManager.instance.m_Mode = LevelManager.LevelType.GameMode;
                    }
                    else
                    {
                        levelName = "Level1";
                        SceneManager.LoadScene(levelName);
                        LevelManager.instance.m_Mode = LevelManager.LevelType.Menus;
                    }

                }
            }
        }

        if ((SceneManager.GetActiveScene().name.ToString().Contains("Level2")))
        {
            for (int i = 0; i < System.Enum.GetValues(typeof(subLevels2)).Length; i++)
            {
                if (mode2 == (subLevels2)i)
                {
                    switch (i)
                    {
                        case 0:
                            LevelManager.instance.level2Capture = LevelManager.instance.level1A;
                            break;
                        case 1:
                            LevelManager.instance.level2Capture = LevelManager.instance.level1B;
                            break;
                        case 2:
                            LevelManager.instance.level2Capture = LevelManager.instance.level1C;
                            break;
                        case 3:
                            LevelManager.instance.level2Capture = LevelManager.instance.level1D;
                            break;
                        case 4:
                            LevelManager.instance.level2Capture = LevelManager.instance.level1E;
                            break;
                    }

                

                    if (LevelManager.instance.level2Capture.m_DifficultyToBeat <= LevelSettings.DifficultyToBeat.Hard && LevelManager.instance.level2Capture.m_DifficultyToBeat >= LevelSettings.DifficultyToBeat.Easy)
                    {
                        levelName = "LevelDescription";
                        SceneManager.LoadScene(levelName);
                        LevelManager.instance.m_Mode = LevelManager.LevelType.GameMode;
                    }
                    else
                    {
                        levelName = "Level2";
                        SceneManager.LoadScene(levelName);
                        LevelManager.instance.m_Mode = LevelManager.LevelType.Menus;
                    }

                }
            }
        }

        ResetGameStats();      
    }

    public void ResetGameStats()
    {
        Time.timeScale = 1;
        switch (LevelManager.instance.m_Mode)
        {
            case LevelManager.LevelType.GameMode:

                if (levelName == "LevelDescription")
                {
                    pauseButton.SetActive(false);
                    confirmSubMenu.SetActive(false);

                    inGame = false;

                    if (endMenu)
                        endMenu.SetActive(false);
                    if (winScreen)
                        winScreen.SetActive(false);
                    if (healthBar)
                        Destroy(healthBar);
                   // if (heartsAmount != 3)
                     //   heartsAmount = 3;
                    if (HUD)
                        HUD.SetActive(false);
                }
                else
                {
                    inGame = true;
                    gameStart = true;

                    pauseButton.SetActive(true);
                    HUD.SetActive(true);

                    if (startMenu)
                        startMenu.SetActive(false);
                    if (endMenu)
                        endMenu.SetActive(false);
                    if (winScreen)
                        winScreen.SetActive(false);
                    if (healthBar)
                        Destroy(healthBar);

                    healthBar = InstantiatePlayerHealth(FindObjectOfType<UIManager>().transform, heartsAmount);

                    hearts = new GameObject[heartsAmount];

                    for (int i = 0; i < heartsAmount; i++)
                    {
                        hearts[i] = healthBar.transform.GetChild(i).gameObject;
                    }

                    //if (heartsAmount != 3)
                      //  heartsAmount = 3;

                    for (int i = 0; i < bubbleQueue.Count; i++)
                        Destroy(bubbleQueue[i]);
                    bubbleQueue.Clear();

                    LevelManager.instance.correctAnswerPoints = 0;
                    timer = 60.0f;
                    minutes = 1;
                    seconds = 0;
                    scoreText.text = "0";
                    score = 0;
                    timetext.text = "1:00";
                    total = 0;
                }
                break;
                
            case LevelManager.LevelType.Menus:

                mode = subLevels1.None;
                mode2 = subLevels2.None;
                LevelManager.instance.levelCaptureEditor.m_DifficultyToBeat = LevelSettings.DifficultyToBeat.PleaseSelectLevelToView;
                LevelManager.instance.m_Difficulty = LevelManager.Difficulty.None;

                if (levelName == "Level1")
                {
                    pauseButton.SetActive(false);
                    confirmSubMenu.SetActive(false);

                    inGame = false;
                    if (endMenu)
                        endMenu.SetActive(false);
                    if (winScreen)
                        winScreen.SetActive(false);
                    if (healthBar)
                        Destroy(healthBar);
                  //  if (heartsAmount != 3)
                    //    heartsAmount = 3;
                    if (HUD)
                        HUD.SetActive(false);
                }
                else
                {
                    pauseButton.SetActive(false);
                    confirmSubMenu.SetActive(false);

                    inGame = false;
                    SceneManager.LoadScene("MainMenu");
                    if (endMenu)
                        endMenu.SetActive(false);
                    if (winScreen)
                        winScreen.SetActive(false);
                    if (healthBar)
                        Destroy(healthBar);
                   // if (heartsAmount != 3)
                   //     heartsAmount = 3;
                    if (HUD)
                        HUD.SetActive(false);
                }
                
                break;
        }
    }

    #endregion


    public void ScorePoints(bool needsPointsToWin)
    {
        score += 1;
        scoreText.text = score.ToString();
        total++;
        LevelManager.instance.CheckAnswer(true, needsPointsToWin, seahorseAnim, (int)mode);
    }

/// <summary>
/// Specific to levels that have more than 3 Correct Answers
/// </summary>
/// <param name="correctAnswer"> Total amount of answers before game is won </param>
    public void ScorePoints(int correctAnswer)
    {
        score += 1;
        scoreText.text = score.ToString();
        total++;
        LevelManager.instance.CheckAnswer(true, seahorseAnim, correctAnswer, (int)mode);
    }

    public void BonusPoints()
    {
        score += 4;
        scoreText.text = score.ToString();
    }
    public int BoolToInt(bool value)
    {
        if (value)
            return 1;
        else
            return 0;
    }

    public bool IntToBool(int value)
    {
        if (value != 0)
            return true;
        else
            return false;
    }

    public GameObject InstantiatePlayerHealth(Transform hpPlacement, int heartAmount)
    {
        GameObject hpHolder = Instantiate(Resources.Load("Prefabs/PlayerHealth"), hpPlacement) as GameObject;
        hpHolder.transform.SetSiblingIndex(0);
        for (int i = 0; i < heartAmount; i++)
        {
            GameObject heart = Instantiate(Resources.Load("Prefabs/Heart"), hpHolder.transform) as GameObject;
            heart.transform.localPosition = Vector3.zero;
            heart.transform.localPosition = new Vector3(heart.transform.localPosition.x + 112 * i+1, heart.transform.localPosition.y);
        }
        return hpHolder;
    }

    /// <summary>
    /// Creates a speech bubble that gives positive and negative feedback to the player when choosing a answer in game.
    /// </summary>
    /// <param name="isCorrect"> Is answer of choice chosen correct?</param>
    public void InstantiateBubble(bool isCorrect)
    {
        //Checks to see if there are any existing speech bubbles in scene, if so remove them before creating a new one
        for (int i = 0; i < bubbleQueue.Count; i++)
            Destroy(bubbleQueue[i]);
        bubbleQueue.Clear();
        //Checks to see if there are any existing speech bubbles in scene, if so remove them before creating a new one

        m_Bubble = Resources.Load("Prefabs/SpeechBubble") as GameObject;
        GameObject speechBubble =  Instantiate(m_Bubble, bubblePos.position, bubblePos.rotation, m_SeaHorse.transform);
        bubbleQueue.Add(speechBubble);
   
        bubbleText = speechBubble.GetComponentInChildren<Text>();

        //If answer is correct, select a random positive response
        if (isCorrect)
            bubbleText.text = positiveResponse[Random.Range(0, positiveResponse.Length)];
        else
            bubbleText.text = negativeResponse[Random.Range(0, negativeResponse.Length)];
        //If answer is false, select a random negative response
    }

    public Image MakeSpriteGlow(Image sprite)
    {
        sprite.GetComponent<Image>().material = Resources.Load<Material>("Shaders/SpriteOutline");
        sprite.gameObject.AddComponent<GlowSprite>();
        return sprite;
    }

    public void MakeDifficultyButtonGlow(bool isLevel1)
    {
        if (isLevel1)
        {
            for (int i = 0; i < System.Enum.GetValues(typeof(subLevels1)).Length; i++)
            {
                if (mode == (subLevels1)i)
                {
                    switch (i)
                    {
                        case 0:
                            LevelManager.instance.level1Capture = LevelManager.instance.level1A;
                            LevelManager.instance.level1Capture.difficultyBtns.Clear();
                            break;
                        case 1:
                            LevelManager.instance.level1Capture = LevelManager.instance.level1B;
                            LevelManager.instance.level1Capture.difficultyBtns.Clear();
                            break;
                        case 2:
                            LevelManager.instance.level1Capture = LevelManager.instance.level1C;
                            LevelManager.instance.level1Capture.difficultyBtns.Clear();
                            break;
                        case 3:
                            LevelManager.instance.level1Capture = LevelManager.instance.level1D;
                            LevelManager.instance.level1Capture.difficultyBtns.Clear();
                            break;
                        case 4:
                            LevelManager.instance.level1Capture = LevelManager.instance.level1E;
                            LevelManager.instance.level1Capture.difficultyBtns.Clear();
                            break;
                    }

                    for (int mode = 0; mode < System.Enum.GetValues(typeof(LevelSettings.DifficultyToBeat)).Length; mode++)
                    {
                        if (LevelManager.instance.level1Capture.m_DifficultyToBeat == (LevelSettings.DifficultyToBeat)mode)
                        {
                            switch (mode)
                            {
                                case 0:
                                    LevelManager.instance.m_DifficultyCapture = LevelManager.Difficulty.Easy;

                                    LevelManager.instance.level1Capture.difficultyBtns.Add(LevelManager.instance.level1Capture.Easy);
                                    LevelManager.instance.level1Capture.difficultyBtns.Add(LevelManager.instance.level1Capture.Normal);
                                    LevelManager.instance.level1Capture.difficultyBtns.Add(LevelManager.instance.level1Capture.Hard);
                                    LevelManager.instance.level1Capture.difficultyBtns.Add(LevelManager.instance.level1Capture.Genius);
                                    break;

                                case 1:
                                    LevelManager.instance.m_DifficultyCapture = LevelManager.Difficulty.Normal;

                                    LevelManager.instance.level1Capture.difficultyBtns.Add(LevelManager.instance.level1Capture.Easy);
                                    LevelManager.instance.level1Capture.difficultyBtns.Add(LevelManager.instance.level1Capture.Normal);
                                    LevelManager.instance.level1Capture.difficultyBtns.Add(LevelManager.instance.level1Capture.Hard);
                                    LevelManager.instance.level1Capture.difficultyBtns.Add(LevelManager.instance.level1Capture.Genius);
                                    break;

                                case 2:
                                    LevelManager.instance.m_DifficultyCapture = LevelManager.Difficulty.Hard;

                                    LevelManager.instance.level1Capture.difficultyBtns.Add(LevelManager.instance.level1Capture.Easy);
                                    LevelManager.instance.level1Capture.difficultyBtns.Add(LevelManager.instance.level1Capture.Normal);
                                    LevelManager.instance.level1Capture.difficultyBtns.Add(LevelManager.instance.level1Capture.Hard);
                                    LevelManager.instance.level1Capture.difficultyBtns.Add(LevelManager.instance.level1Capture.Genius);
                                    break;

                                case 3:
                                    LevelManager.instance.m_DifficultyCapture = LevelManager.Difficulty.Genius;

                                    LevelManager.instance.level1Capture.difficultyBtns.Add(LevelManager.instance.level1Capture.Easy);
                                    LevelManager.instance.level1Capture.difficultyBtns.Add(LevelManager.instance.level1Capture.Normal);
                                    LevelManager.instance.level1Capture.difficultyBtns.Add(LevelManager.instance.level1Capture.Hard);
                                    LevelManager.instance.level1Capture.difficultyBtns.Add(LevelManager.instance.level1Capture.Genius);
                                    break;

                            }

                            MakeSpriteGlow(LevelManager.instance.level1Capture.difficultyBtns[mode].GetComponent<Image>());
                        }
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i < System.Enum.GetValues(typeof(subLevels2)).Length; i++)
            {
                if (mode2== (subLevels2)i)
                {
                    switch (i)
                    {
                        case 0:
                            LevelManager.instance.level2Capture = LevelManager.instance.level2A;
                            LevelManager.instance.level2Capture.difficultyBtns.Clear();
                            break;
                        case 1:
                            LevelManager.instance.level2Capture = LevelManager.instance.level2B;
                            LevelManager.instance.level2Capture.difficultyBtns.Clear();
                            break;
                        case 2:
                            LevelManager.instance.level2Capture = LevelManager.instance.level2C;
                            LevelManager.instance.level2Capture.difficultyBtns.Clear();
                            break;
                        case 3:
                            LevelManager.instance.level2Capture = LevelManager.instance.level2D;
                            LevelManager.instance.level2Capture.difficultyBtns.Clear();
                            break;
                        case 4:
                            LevelManager.instance.level2Capture = LevelManager.instance.level2E;
                            LevelManager.instance.level2Capture.difficultyBtns.Clear();
                            break;
                        case 5:
                            LevelManager.instance.level2Capture = LevelManager.instance.level2F;
                            LevelManager.instance.level2Capture.difficultyBtns.Clear();
                            break;
                    }

                    for (int mode = 0; mode < System.Enum.GetValues(typeof(LevelSettings.DifficultyToBeat)).Length; mode++)
                    {
                        if (LevelManager.instance.level2Capture.m_DifficultyToBeat == (LevelSettings.DifficultyToBeat)mode)
                        {
                            switch (mode)
                            {
                                case 0:
                                    LevelManager.instance.m_DifficultyCapture = LevelManager.Difficulty.Easy;

                                    LevelManager.instance.level2Capture.difficultyBtns.Add(LevelManager.instance.level2Capture.Easy);
                                    LevelManager.instance.level2Capture.difficultyBtns.Add(LevelManager.instance.level2Capture.Normal);
                                    LevelManager.instance.level2Capture.difficultyBtns.Add(LevelManager.instance.level2Capture.Hard);
                                    LevelManager.instance.level2Capture.difficultyBtns.Add(LevelManager.instance.level2Capture.Genius);
                                    break;

                                case 1:
                                    LevelManager.instance.m_DifficultyCapture = LevelManager.Difficulty.Normal;

                                    LevelManager.instance.level2Capture.difficultyBtns.Add(LevelManager.instance.level2Capture.Easy);
                                    LevelManager.instance.level2Capture.difficultyBtns.Add(LevelManager.instance.level2Capture.Normal);
                                    LevelManager.instance.level2Capture.difficultyBtns.Add(LevelManager.instance.level2Capture.Hard);
                                    LevelManager.instance.level2Capture.difficultyBtns.Add(LevelManager.instance.level2Capture.Genius);
                                    break;

                                case 2:
                                    LevelManager.instance.m_DifficultyCapture = LevelManager.Difficulty.Hard;

                                    LevelManager.instance.level2Capture.difficultyBtns.Add(LevelManager.instance.level2Capture.Easy);
                                    LevelManager.instance.level2Capture.difficultyBtns.Add(LevelManager.instance.level2Capture.Normal);
                                    LevelManager.instance.level2Capture.difficultyBtns.Add(LevelManager.instance.level2Capture.Hard);
                                    LevelManager.instance.level2Capture.difficultyBtns.Add(LevelManager.instance.level2Capture.Genius);
                                    break;

                                case 3:
                                    LevelManager.instance.m_DifficultyCapture = LevelManager.Difficulty.Genius;

                                    LevelManager.instance.level2Capture.difficultyBtns.Add(LevelManager.instance.level2Capture.Easy);
                                    LevelManager.instance.level2Capture.difficultyBtns.Add(LevelManager.instance.level2Capture.Normal);
                                    LevelManager.instance.level2Capture.difficultyBtns.Add(LevelManager.instance.level2Capture.Hard);
                                    LevelManager.instance.level2Capture.difficultyBtns.Add(LevelManager.instance.level2Capture.Genius);
                                    break;

                            }

                            MakeSpriteGlow(LevelManager.instance.level2Capture.difficultyBtns[mode].GetComponent<Image>());
                        }
                    }
                }
            }
        }
    }

    public void SetButtonsInteractable(bool interactable)
    {
        Button[] btnObjs;

        if (interactable)
        {
            btnObjs = FindObjectsOfType<Button>();

            foreach (Button button in btnObjs)
            {
                button.interactable = true;
            }
        }
        else
        {
            btnObjs = FindObjectsOfType<Button>();

            foreach (Button button in btnObjs)
            {
                button.interactable = false;
            }
        }
    }


    public void DeductTime(float deduction)
    {
        timer -= deduction;
    }
    public void AddTime(float addition)
    {
        timer += addition;
    }

    // Update is called once per frame
    void Update ()
    {
        if (gameStart)
        {

            if (timer > 0)
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                    timer = 0;
            }
            else if (timer <= 0)
            {
                if (mode == subLevels1.Level1E)
                    WinGame((int)mode);
                else
                    GameOver();
            }

            minutes = Mathf.Floor(timer / 60);
            seconds = timer % 60;

            if (Mathf.RoundToInt(seconds) < 10)
                timetext.text = Mathf.RoundToInt(minutes).ToString() + ":0" + Mathf.RoundToInt(seconds).ToString();
            else
                timetext.text = Mathf.RoundToInt(minutes).ToString() + ":" + Mathf.RoundToInt(seconds).ToString();
        }

    }
}
