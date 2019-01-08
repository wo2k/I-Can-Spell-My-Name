﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public bool[] hasWonAlready = { false, false, false, false, false };
    public int hasWonIndex;
    public int hasWonDifficultyIndex;
    [HideInInspector]
    public bool gameStart = false;
    [HideInInspector]
    public bool inGame = false;

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
    }

    public void WinGame()
    {
        SoundManagement.TriggerEvent("PlayLevelComplete");
        winScreen.SetActive(true);
        gameStart = false;
        hasWonIndex = (int)mode;
        hasWonDifficultyIndex = (int)LevelManager.instance.m_Difficulty;
        LevelManager.instance.SetNewHighScore(mode, LevelManager.instance.m_Difficulty);
        Time.timeScale = 0;

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
                        break;
                }

                for (int mode = 0; mode < System.Enum.GetValues(typeof(LevelManager.Difficulty)).Length; mode++)
                {
                    if (LevelManager.instance.m_Difficulty == (LevelManager.Difficulty)mode)
                    {
                        switch (mode)
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
                                    LevelManager.instance.subLevelPassed1++;
                                    PlayerPrefs.SetInt("SubLevelPassed", LevelManager.instance.subLevelPassed1);
                                    PlayerPrefs.SetInt("HasWonAlready " + i, BoolToInt(hasWonAlready[hasWonIndex]));
                                    LevelManager.instance.hasLockedBefore = false;
                                }
                                break;
                            case 3:
                                LevelManager.instance.m_DifficultyCapture = LevelManager.Difficulty.Genius;
                                break;
                        }

                        if (!LevelManager.instance.level1Capture.hasWonAlready[hasWonIndex,hasWonDifficultyIndex])
                        {
                            LevelManager.instance.level1Capture.hasWonAlready[hasWonIndex,hasWonDifficultyIndex] = true;
                            LevelManager.instance.level1Capture.modePassed++;
                            PlayerPrefs.SetInt(LevelManager.instance.m_DifficultyCapture + " ModePassed " + i, LevelManager.instance.level1Capture.modePassed);
                            PlayerPrefs.SetInt(LevelManager.instance.m_DifficultyCapture + " HasWonAlready " + i, BoolToInt(LevelManager.instance.level1Capture.hasWonAlready[hasWonIndex,hasWonDifficultyIndex]));
                            LevelManager.instance.level1Capture.hasLockedBefore = false;
                        }
                        else
                            return;
                    }
                }
            }
        }       
    }

    public void RestartGame()
    {
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
        LevelManager.instance.m_Mode = LevelManager.LevelType.GameMode;
        switch (mode)
        {
            case subLevels1.Level1A:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                levelName = SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex + 1).ToString();
                break;
            case subLevels1.Level1B:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                levelName = SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex + 1).ToString();
                break;
            case subLevels1.Level1C:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                levelName = SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex + 1).ToString();
                break;
            case subLevels1.Level1D:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                levelName = SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex + 1).ToString();
                break;
            case subLevels1.Level1E:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                levelName = SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex + 1).ToString();
                break;
        }
        ResetGameStats();
        
    }
    public void ResetGameStats()
    {
        Time.timeScale = 1;
        switch (LevelManager.instance.m_Mode)
        {
            case LevelManager.LevelType.GameMode:
                               
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

                if (heartsAmount != 3)
                    heartsAmount = 3;

                for (int i = 0; i < bubbleQueue.Count; i++)
                {
                    bubbleQueue[i].GetComponent<Animation>().Stop();
                    Destroy(bubbleQueue[i]);
                }
                bubbleQueue.Clear();

                LevelManager.instance.correctAnswerPoints = 0;
                timer = 60.0f;
                minutes = 1;
                seconds = 0;
                scoreText.text = "0";
                score = 0;
                timetext.text = "1:00";
                total = 0;
                break;
                
            case LevelManager.LevelType.Menus:

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
                if (heartsAmount != 3)
                    heartsAmount = 3;
                if (HUD)
                    HUD.SetActive(false);
                break;
        }
    }

    #endregion


    public void ScorePoints()
    {
        score += 1;
        scoreText.text = score.ToString();
        total++;
        LevelManager.instance.CheckAnswer(true, seahorseAnim);
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
        LevelManager.instance.CheckAnswer(true, seahorseAnim, correctAnswer);
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

    public IEnumerator InstantiateBubble(bool isCorrect)
    {
        //Checks to see if there are any existing speech bubbles in scene, if so remove them before creating a new one
        for (int i = 0; i < bubbleQueue.Count; i++)
        {
            bubbleQueue[i].GetComponent<Animation>().Stop();
            Destroy(bubbleQueue[i]);
        }
        bubbleQueue.Clear();
        //Checks to see if there are any existing speech bubbles in scene, if so remove them before creating a new one
        

        GameObject speechBubble =  Instantiate(m_Bubble, bubblePos.position, bubblePos.rotation, m_SeaHorse.transform);
        bubbleQueue.Add(speechBubble);
   
        bubbleAnim = speechBubble.GetComponent<Animation>();
        bubbleText = speechBubble.GetComponentInChildren<Text>();

        //If answer is correct, select a random positive response
        if (isCorrect)
            bubbleText.text = positiveResponse[Random.Range(0, positiveResponse.Length)];
        else
            bubbleText.text = negativeResponse[Random.Range(0, negativeResponse.Length)];
        //If answer is false, select a random negative response

        bubbleAnim.Play();

        if (!speechBubble.activeInHierarchy)
            yield return null;
    
        yield return new WaitForSeconds(2.5f);

        if (!speechBubble.activeInHierarchy)
            yield return null;

        //Reverse animation
        bubbleAnim["Sea-Horse-Bubble"].time = bubbleAnim["Sea-Horse-Bubble"].length;
        bubbleAnim["Sea-Horse-Bubble"].speed = -1;   
        bubbleAnim.Play();
        //Reverse animation

        yield return new WaitForSeconds(2.5f);

        if (!speechBubble.activeInHierarchy)
            yield return null;

        //Deletes current instance of speech bubble after completing reverse animation
        Destroy(speechBubble);
        bubbleQueue.Clear();
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
