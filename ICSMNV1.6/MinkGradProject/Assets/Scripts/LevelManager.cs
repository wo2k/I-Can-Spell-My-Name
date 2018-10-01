using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public int correctAnswerPoints = 0;
    [Header("Main Buttons")]
    public Button level2;
    public Button level3;
    [Space]
    [Header("Sub Level Buttons")]
    public Button level1_B, level1_C, level1_D, level1_E;

    public int levelPassed, subLevelPassed1;

    public GameObject level1Parent;
    public GameObject lockLevel;

    public bool locked = true;

    public GameObject toggleVibration;
    public static LevelManager instance;

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
    }

    void Start ()
    {
        if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer ||
            Application.platform == RuntimePlatform.OSXPlayer || Application.platform == RuntimePlatform.OSXEditor)
            toggleVibration.SetActive(false);

        LoadPlayerPrefs();

        lockLevel = InstantiateLock(level1Parent.transform);
        level1_B.interactable = false; level1_C.interactable = false; level1_D.interactable = false; level1_E.interactable = false;
      //  level2.interactable = false;
       // level3.interactable = false;
        CheckLevelState(false);
    }

    #region Set Level State
    public void CheckLevelState(bool disableLevelBtns)
    {
        switch (subLevelPassed1)
        {
            case 1:
                level1_B.interactable = true;
                locked = false;

                if (lockLevel)
                    lockLevel.GetComponent<Animator>().enabled = true;

                if(disableLevelBtns)
                {
                    level1_C.interactable = false;
                    level1_D.interactable = false;
                    level1_E.interactable = false;
                }

                break;
            case 2:
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
            case 3:
                level1_B.interactable = true;
                level1_C.interactable = true;
                level1_D.interactable = true;

                if (lockLevel)
                    lockLevel.GetComponent<Animator>().enabled = true;

                if (disableLevelBtns)
                    level1_E.interactable = false;

                break;
            case 4:
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

    public void Reset()
    {
        subLevelPassed1 = 0; PlayerPrefs.SetInt("SubLevelPassed", subLevelPassed1);
        levelPassed = 0;     PlayerPrefs.SetInt("LevelPassed", levelPassed);
        UIManager.instance.heartsAmount = 3;

        for (int i = 0; i < UIManager.instance.hearts.Length; i++)
        {
            UIManager.instance.hearts[i].GetComponent<Image>().color = new Color(1,1,1,1);
           // UIManager.instance.hearts[i].transform.position = UIManager.instance.heartTransform[i].position;
        }

        AllLevelsLockState(false);
        locked = true;

        if (!lockLevel)
           lockLevel = InstantiateLock(level1Parent.transform);
        else
            return;
    }

    public GameObject InstantiateLock(Transform ButtonPos)
    {
        GameObject _Lock = Instantiate((GameObject)Resources.Load("Prefabs/UnlockLevel"), ButtonPos);
        return _Lock;
    }

    public void VibrateOnHandHeld()
    {
        if (Application.isMobilePlatform && toggleVibration.GetComponent<Toggle>().isOn)
            Handheld.Vibrate();
        else
            return;
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
    #endregion CheckAnswer

    void Update () {
		
	}
}
