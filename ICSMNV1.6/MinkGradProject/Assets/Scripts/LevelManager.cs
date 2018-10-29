using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using UnityEditor;
//using UnityEditor.SceneManagement;


public class LevelManager : MonoBehaviour
{

    public int correctAnswerPoints = 0;
    [Header("Main Buttons")]
    public Button level2;
    public Button level3;
    [Space]
    [Header("Sub Level Buttons")]
    public Button level1_B, level1_C, level1_D, level1_E;

    public int levelPassed, subLevelPassed1;

    public GameObject levelParent;
    public GameObject lockLevel;

    public bool locked = true;
    public bool hasLockedBefore = false;

    public GameObject toggleVibration;
    public static LevelManager instance;

    //LevelManager Editor Variables
    [HideInInspector]
    public int currentTab;
    [SerializeField]
    [HideInInspector]
    public int containerSize;
    [HideInInspector]
    public string sceneName;
   // [SerializeField]
   // [HideInInspector]
   // public List<SceneAsset> sceneAssets = new List<SceneAsset>();
    public enum AppPlatform { MacOS, Windows, iPhone, Andriod };
    public AppPlatform m_Console;
    public enum LevelType { GameMode, Menus };
    public LevelType m_Mode;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(instance);
    }

    void LoadPlayerPrefs()
    {
        levelPassed = PlayerPrefs.GetInt("LevelPassed");
        subLevelPassed1 = PlayerPrefs.GetInt("SubLevelPassed");

        for (int i = 0; i < UIManager.instance.hasWonAlready.Length; i++)
            UIManager.instance.hasWonAlready[i] = UIManager.instance.IntToBool(PlayerPrefs.GetInt("HasWonAlready " + i));

        hasLockedBefore = UIManager.instance.IntToBool(PlayerPrefs.GetInt("HasLockedBefore"));

    }

    void ResetPlayerPrefs()
    {
        subLevelPassed1 = 0; PlayerPrefs.SetInt("SubLevelPassed", subLevelPassed1);
        levelPassed = 0; PlayerPrefs.SetInt("LevelPassed", levelPassed);

        for (int i = 0; i < UIManager.instance.hasWonAlready.Length; i++)
        {
            UIManager.instance.hasWonAlready[i] = false;
            PlayerPrefs.SetInt("HasWonAlready " + i, UIManager.instance.BoolToInt(UIManager.instance.hasWonAlready[i]));
        }

        hasLockedBefore = false; PlayerPrefs.SetInt("HasLockedBefore", UIManager.instance.BoolToInt(hasLockedBefore));

        PlayerPrefs.SetString("firstName", "Add Player");
        PlayerPrefs.SetString("secondName", "Add Player");
        PlayerPrefs.SetString("thirdName", "Add Player");
        PlayerPrefs.SetString("fourthName", "Add Player");
        PlayerPrefs.SetInt("firstPlay1", 0);
        PlayerPrefs.SetInt("firstPlay2", 0);
        PlayerPrefs.SetInt("firstPlay3", 0);
        PlayerPrefs.SetInt("firstPlay4", 0);
        PlayerPrefs.SetInt("firstColor", 0);
        PlayerPrefs.SetInt("secondColor", 0);
        PlayerPrefs.SetInt("thirdColor", 0);
        PlayerPrefs.SetInt("fourthColor", 0);
        PlayerPrefs.SetInt("firstCharacter", 0);
        PlayerPrefs.SetInt("secondCharacter", 0);
        PlayerPrefs.SetInt("thirdCharacter", 0);
        PlayerPrefs.SetInt("fourthCharacter", 0);
    }

    void Start()
    {
        LoadPlayerPrefs();

        switch (Application.platform)
        {
            case RuntimePlatform.WindowsEditor:
                m_Console = AppPlatform.Windows;
                break;
            case RuntimePlatform.WindowsPlayer:
                m_Console = AppPlatform.Windows;
                break;
            case RuntimePlatform.OSXEditor:
                m_Console = AppPlatform.MacOS;
                break;
            case RuntimePlatform.OSXPlayer:
                m_Console = AppPlatform.MacOS;
                break;
            case RuntimePlatform.IPhonePlayer:
                m_Console = AppPlatform.iPhone;
                break;
            case RuntimePlatform.Android:
                m_Console = AppPlatform.Andriod;
                break;
        }
    }

    #region Set Level State
    public void CheckLevelState(bool disableLevelBtns)
    {
        switch (subLevelPassed1)
        {
            case 1: //Lock B
                level1_B.interactable = true;
                //locked = false;

                if (lockLevel)
                    lockLevel.GetComponent<Animator>().enabled = true;

                if (disableLevelBtns)
                {
                    level1_C.interactable = false;
                    level1_D.interactable = false;
                    level1_E.interactable = false;
                }

                break;
            case 2: //Lock C
                level1_B.interactable = true;
                level1_C.interactable = true;
                if (lockLevel)
                    lockLevel.GetComponent<Animator>().enabled = true;

                if (disableLevelBtns)
                {
                    level1_D.interactable = false;
                    level1_E.interactable = false;
                }

                break;
            case 3: //Lock D
                level1_B.interactable = true;
                level1_C.interactable = true;
                level1_D.interactable = true;
                if (lockLevel)
                    lockLevel.GetComponent<Animator>().enabled = true;

                if (disableLevelBtns)
                    level1_E.interactable = false;

                break;
            case 4: //Lock E
                level1_B.interactable = true;
                level1_C.interactable = true;
                level1_D.interactable = true;
                level1_E.interactable = true;
                if (lockLevel)
                    lockLevel.GetComponent<Animator>().enabled = true;
                break;
        }

        switch (levelPassed)
        {
            case 1:
                level2.interactable = true;
                break;
            case 2:
                level2.interactable = true;
                level3.interactable = true;
                break;
        }
    }

    public void AllLevelsLockState(bool isLocked)
    {
        //Sub Levels
        level1_B.interactable = isLocked; level1_C.interactable = isLocked; level1_D.interactable = isLocked; level1_E.interactable = isLocked;
        //Sub Levels

        //Main Levels
        level2.interactable = isLocked; level3.interactable = isLocked;
        //Main Levels
    }
    #endregion Set Level State

    public void ResetProgression()
    {
        subLevelPassed1 = 0; PlayerPrefs.SetInt("SubLevelPassed", subLevelPassed1);
        levelPassed = 0; PlayerPrefs.SetInt("LevelPassed", levelPassed);
        for (int i = 0; i < UIManager.instance.hasWonAlready.Length; i++)
        {
            UIManager.instance.hasWonAlready[i] = false;
            PlayerPrefs.SetInt("HasWonAlready " + i, UIManager.instance.BoolToInt(UIManager.instance.hasWonAlready[i]));
        }
        hasLockedBefore = false; PlayerPrefs.SetInt("HasLockedBefore", UIManager.instance.BoolToInt(hasLockedBefore));

        UIManager.instance.heartsAmount = 3;

        for (int i = 0; i < UIManager.instance.hearts.Length; i++)
        {
            if (UIManager.instance.hearts[i] != null)
                UIManager.instance.hearts[i].GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }

        // AllLevelsLockState(false);
        locked = true;

        if (lockLevel != null)
            lockLevel = InstantiateLock(levelParent.transform);
        else
            return;
    }

    public void Reset()
    {
        ResetPlayerPrefs();
        UIManager.instance.heartsAmount = 3;

        for (int i = 0; i < UIManager.instance.hearts.Length; i++)
        {
            if (UIManager.instance.hearts[i] != null)
                UIManager.instance.hearts[i].GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }

        // AllLevelsLockState(false);
        locked = true;

        if (lockLevel != null)
            lockLevel = InstantiateLock(levelParent.transform);
        else
            return;
    }

    public GameObject InstantiateLock(Transform ButtonPos)
    {
        GameObject _Lock = Instantiate((GameObject)Resources.Load("Prefabs/UnlockLevel"), ButtonPos);
        //_Lock.transform.position = ButtonPos.position;
        _Lock.transform.localPosition = Vector3.zero;
        return _Lock;
    }

    public void VibrateOnHandHeld()
    {
       // if (Application.isMobilePlatform && toggleVibration.GetComponent<Toggle>().isOn)
           // Handheld.Vibrate();
        //else
          //  return;
    }

    #region CheckAnswer
    public void CheckAnswer(bool isCorrect, int heartsQty)
    {
        if (isCorrect)
        {
            SoundManagement.TriggerEvent("PlayCorrect");
            correctAnswerPoints++;

            if (correctAnswerPoints >= 3)
                UIManager.instance.WinGame();
        }

        else
        {
            SoundManagement.TriggerEvent("PlayWrongAnswer");
            VibrateOnHandHeld();
            heartsQty--;
            UIManager.instance.hearts[heartsQty].GetComponent<Animation>().Play("HealthShake");
            if (heartsQty <= 0)
                UIManager.instance.GameOver();
        }

        UIManager.instance.heartsAmount = heartsQty;
    }

    public void CheckAnswer(bool isCorrect, int heartsQty, Animator seahorseAnim)
    {


        if (isCorrect)
        {
            SoundManagement.TriggerEvent("PlayCorrect");
            correctAnswerPoints++;
            seahorseAnim.SetTrigger("Wink");
            seahorseAnim.SetTrigger("Idle");
            if (correctAnswerPoints >= 3)
                UIManager.instance.WinGame();
        }

        else
        {
            SoundManagement.TriggerEvent("PlayWrongAnswer");
            VibrateOnHandHeld();
            heartsQty--;
            UIManager.instance.hearts[heartsQty].GetComponent<Animation>().Play("HealthShake");
            if (heartsQty <= 0)
                UIManager.instance.GameOver();
        }

        UIManager.instance.heartsAmount = heartsQty;
    }

    public void CheckAnswer(bool isCorrect)
    {
        if (isCorrect)
        {
            SoundManagement.TriggerEvent("PlayCorrect");
            correctAnswerPoints++;

            if (correctAnswerPoints >= 3)
                UIManager.instance.WinGame();
        }

        else
        {
            SoundManagement.TriggerEvent("PlayWrongAnswer");
            VibrateOnHandHeld();
        }
    }

    public void CheckAnswer(bool isCorrect, Animator seahorseAnim)
    {


        if (isCorrect)
        {
            SoundManagement.TriggerEvent("PlayCorrect");
            correctAnswerPoints++;
            seahorseAnim.SetTrigger("Wink");
            seahorseAnim.SetTrigger("Idle");
            if (correctAnswerPoints >= 3)
                UIManager.instance.WinGame();
        }

        else
        {
            SoundManagement.TriggerEvent("PlayWrongAnswer");
            VibrateOnHandHeld();
        }
    }

    public void CheckAnswer(bool isCorrect, Animator seahorseAnim, int answerAmount)
    {


        if (isCorrect)
        {
            SoundManagement.TriggerEvent("PlayCorrect");
            correctAnswerPoints++;
            seahorseAnim.SetTrigger("Wink");
            seahorseAnim.SetTrigger("Idle");
            if (correctAnswerPoints >= answerAmount)
                UIManager.instance.WinGame();
        }

        else
        {
            SoundManagement.TriggerEvent("PlayWrongAnswer");
            VibrateOnHandHeld();
        }
    }

    public void CheckAnswer(bool isCorrect, bool isTutorial, int heartsQty, Animator seahorseAnim)
    {

        if (isTutorial)
        {
            if (isCorrect)
            {
                SoundManagement.TriggerEvent("PlayCorrect");
                correctAnswerPoints++;
                seahorseAnim.SetTrigger("Wink");
                seahorseAnim.SetTrigger("Idle");
                if (correctAnswerPoints >= 26)
                {
                    int LoginNumber = PlayerPrefs.GetInt("loginNumber");
                    switch (LoginNumber)
                    {
                        case 1:
                            {
                                PlayerPrefs.SetInt("firstPlay1", 1);
                                break;
                            }
                        case 2:
                            {
                                PlayerPrefs.SetInt("firstPlay2", 1);
                                break;
                            }
                        case 3:
                            {
                                PlayerPrefs.SetInt("firstPlay3", 1);
                                break;
                            }
                        case 4:
                            {
                                PlayerPrefs.SetInt("firstPlay4", 1);
                                break;
                            }
                    }
                    SceneManager.LoadScene("MainMenu");
                    correctAnswerPoints = 0;
                    UIManager.instance.HUD.SetActive(false);
                    UIManager.instance.HUD.transform.GetChild(1).gameObject.SetActive(true);
                }

            }

            else
            {
                SoundManagement.TriggerEvent("PlayWrongAnswer");
                VibrateOnHandHeld();
            }
        }
    }
    #endregion CheckAnswer


}

