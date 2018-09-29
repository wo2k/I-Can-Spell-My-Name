using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public Button level2;
    public Button level3;
    public Button level1_B, level1_C, level1_D, level1_E;
    public int levelPassed, subLevelPassed1;
    public GameObject level1Parent;
    public GameObject lockLevel;
    public bool locked = true;
    public static GameManager instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start ()
    {
        levelPassed = PlayerPrefs.GetInt("LevelPassed");
        subLevelPassed1 = PlayerPrefs.GetInt("SubLevelPassed");
        lockLevel = InstantiateLock(level1Parent.transform);
      //  level1_B.interactable = false; level1_C.interactable = false; level1_D.interactable = false; level1_E.interactable = false;
       // level2.interactable = false;
      //  level3.interactable = false;
        CheckLevelState();
    }

    public void CheckLevelState()
    {
        switch (subLevelPassed1)
        {
            case 1:
                level1_B.interactable = true;
                lockLevel.GetComponent<Animator>().enabled = true;  
                locked = false;
                break;
            case 2:
                level1_B.interactable = true;
                level1_C.interactable = true;
                break;
            case 3:
                level1_B.interactable = true;
                level1_C.interactable = true;
                level1_D.interactable = true;
                break;
            case 4:
                level1_B.interactable = true;
                level1_C.interactable = true;
                level1_D.interactable = true;
                level1_E.interactable = true;
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

    public void Reset()
    {
        subLevelPassed1 = 0; PlayerPrefs.SetInt("SubLevelPassed", subLevelPassed1);
        levelPassed = 0;     PlayerPrefs.SetInt("LevelPassed", levelPassed);
        AllLevelsLockState(false);
        locked = true;
    }

    public GameObject InstantiateLock(Transform ButtonPos)
    {
        GameObject _Lock = Instantiate((GameObject)Resources.Load("Prefabs/UnlockLevel"), ButtonPos);
        //_Lock.GetComponent<Animator>().enabled = false;
        return _Lock;
    }

    public bool LevelLocked(bool locked)
    {
        return locked;
    }

    void Update () {
		
	}
}
