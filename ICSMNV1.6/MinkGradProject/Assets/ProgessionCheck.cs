using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgessionCheck : MonoBehaviour {

    public Transform previousParent;
    public Transform previousParentMode;
    public GameObject previousLock;
    public float parentX;
    public float parentY;
    public float parentZ;

    public List<Button> levelIcons = new List<Button>();

    void Start ()
    {
        previousLock = new GameObject("PreviousLockLocation");
        previousParent = previousLock.transform;
        previousParentMode = previousLock.transform;
        GetParentID();
      
        switch (UIManager.instance.levelName)
        {
            case "MainMenu":
                break;
            case "Campaign":
                LevelManager.instance.level2 = GameObject.Find("Level2").GetComponent<Button>();
                LevelManager.instance.level3 = GameObject.Find("Level3").GetComponent<Button>();
                LevelManager.instance.level3.interactable = false;
                LevelManager.instance.level2.interactable = false;
                break;
            case "Level1":
                LevelManager.instance.level1_B = GameObject.Find("Level2Button").GetComponent<Button>(); levelIcons.Add(LevelManager.instance.level1_B);
                LevelManager.instance.level1_C = GameObject.Find("Level3Button").GetComponent<Button>(); levelIcons.Add(LevelManager.instance.level1_C);
                LevelManager.instance.level1_D = GameObject.Find("Level4Button").GetComponent<Button>(); levelIcons.Add(LevelManager.instance.level1_D);
                LevelManager.instance.level1_E = GameObject.Find("Level5Button").GetComponent<Button>(); levelIcons.Add(LevelManager.instance.level1_E);
                LevelManager.instance.SetIconOpacity(levelIcons, 0.5f, false);

                switch (LevelManager.instance.subLevelPassed1)
                {
                    case 0://Lock B                     
                        LevelManager.instance.levelParent = GameObject.FindGameObjectWithTag("Level1B").gameObject;
                        LevelManager.instance.lockLevel = LevelManager.instance.InstantiateLock(LevelManager.instance.levelParent.transform);
                        SetParentID(LevelManager.instance.levelParent.transform.position.x, LevelManager.instance.levelParent.transform.position.y, LevelManager.instance.levelParent.transform.position.z);
                        break;

                    case 1:// Lock C
                        if (!LevelManager.instance.lockLevel)
                            previousLock = LevelManager.instance.InstantiateLock(previousParent.transform);

                        if (!LevelManager.instance.hasLockedBefore)
                        {
                            if (LevelManager.instance.locked)
                                LevelManager.instance.locked = false;
                            LevelManager.instance.hasLockedBefore = true;
                            PlayerPrefs.SetInt("HasLockedBefore", UIManager.instance.BoolToInt(LevelManager.instance.hasLockedBefore));
                        }

                        LevelManager.instance.levelParent = GameObject.FindGameObjectWithTag("Level1C").gameObject;
                        LevelManager.instance.CheckLevelState(true);
                        SetParentID(LevelManager.instance.levelParent.transform.position.x, LevelManager.instance.levelParent.transform.position.y, LevelManager.instance.levelParent.transform.position.z);
                        break;

                    case 2:// Lock D
                        if (!LevelManager.instance.lockLevel)
                            previousLock = LevelManager.instance.InstantiateLock(previousParent.transform);

                        if (!LevelManager.instance.hasLockedBefore)
                        {
                            if (LevelManager.instance.locked)
                                LevelManager.instance.locked = false;
                            LevelManager.instance.hasLockedBefore = true;
                            PlayerPrefs.SetInt("HasLockedBefore", UIManager.instance.BoolToInt(LevelManager.instance.hasLockedBefore));
                        }

                        LevelManager.instance.levelParent = GameObject.FindGameObjectWithTag("Level1D").gameObject;
                        LevelManager.instance.CheckLevelState(true);
                        SetParentID(LevelManager.instance.levelParent.transform.position.x, LevelManager.instance.levelParent.transform.position.y, LevelManager.instance.levelParent.transform.position.z);
                        break;

                    case 3:// Lock E
                        if (!LevelManager.instance.lockLevel)
                            previousLock = LevelManager.instance.InstantiateLock(previousParent.transform);

                        if (!LevelManager.instance.hasLockedBefore)
                        {
                            if (LevelManager.instance.locked)
                                LevelManager.instance.locked = false;
                            LevelManager.instance.hasLockedBefore = true;
                            PlayerPrefs.SetInt("HasLockedBefore", UIManager.instance.BoolToInt(LevelManager.instance.hasLockedBefore));
                        }

                        LevelManager.instance.levelParent = GameObject.FindGameObjectWithTag("Level1E").gameObject;
                        LevelManager.instance.CheckLevelState(true);
                        SetParentID(LevelManager.instance.levelParent.transform.position.x, LevelManager.instance.levelParent.transform.position.y, LevelManager.instance.levelParent.transform.position.z);
                        break;
                    case 4:// All Unlocked!                      

                        if (!LevelManager.instance.hasLockedBefore)
                        {
                            if (!LevelManager.instance.lockLevel)
                                previousLock = LevelManager.instance.InstantiateLock(previousParent.transform);

                            if (LevelManager.instance.locked)
                                LevelManager.instance.locked = false;

                            LevelManager.instance.hasLockedBefore = true;

                            PlayerPrefs.SetInt("HasLockedBefore", UIManager.instance.BoolToInt(LevelManager.instance.hasLockedBefore));

                        }                       
                        LevelManager.instance.CheckLevelState(true);                     
                        break;
                }                                              

                

                break;
            case "Level2":

                break;
            case "Level3":

                break;

            case "LevelDescription":

                for (int i = 0; i < 5; i++)
                {
                    if (UIManager.instance.mode == (UIManager.subLevels1)i)
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

                        LevelManager.instance.level1Capture.Easy = GameObject.Find("Easy").GetComponent<Button>();
                        LevelManager.instance.level1Capture.Normal = GameObject.Find("Normal").GetComponent<Button>();
                        LevelManager.instance.level1Capture.Hard = GameObject.Find("Hard").GetComponent<Button>();
                        LevelManager.instance.level1Capture.Genius = GameObject.Find("Genius").GetComponent<Button>();
                        LevelManager.instance.level1Capture.Normal.interactable = false; LevelManager.instance.level1Capture.Hard.interactable = false; LevelManager.instance.level1Capture.Genius.interactable = false;

                        switch (LevelManager.instance.level1Capture.modePassed)
                        {
                            case 0://Normal
                                LevelManager.instance.level1Capture.levelParent = GameObject.FindGameObjectWithTag("Normal").gameObject;
                                LevelManager.instance.level1Capture.lockMode = LevelManager.instance.InstantiateLock(LevelManager.instance.level1Capture.levelParent.transform);
                                SetParentID(LevelManager.instance.level1Capture.levelParent.transform.position.x, LevelManager.instance.level1Capture.levelParent.transform.position.y, LevelManager.instance.level1Capture.levelParent.transform.position.z);
                                break;
                            case 1://Hard
                                if (!LevelManager.instance.level1Capture.lockMode)
                                    previousLock = LevelManager.instance.InstantiateLock(previousParentMode.transform);

                                if (!LevelManager.instance.level1Capture.hasLockedBefore)
                                {
                                    if (LevelManager.instance.level1Capture.locked)
                                        LevelManager.instance.level1Capture.locked = false;
                                    LevelManager.instance.level1Capture.hasLockedBefore = true;
                                    PlayerPrefs.SetInt(LevelManager.Difficulty.Hard + " HasLockedBefore " + i, UIManager.instance.BoolToInt(LevelManager.instance.level1Capture.hasLockedBefore));
                                }

                                LevelManager.instance.level1Capture.levelParent = GameObject.FindGameObjectWithTag("Hard").gameObject;
                                LevelManager.instance.CheckLevelState(true);
                                SetParentID(LevelManager.instance.level1Capture.levelParent.transform.position.x, LevelManager.instance.level1Capture.levelParent.transform.position.y, LevelManager.instance.level1Capture.levelParent.transform.position.z);
                                break;
                            case 2://Genius
                                if (!LevelManager.instance.level1Capture.lockMode)
                                    previousLock = LevelManager.instance.InstantiateLock(previousParentMode.transform);

                                if (!LevelManager.instance.level1Capture.hasLockedBefore)
                                {
                                    if (LevelManager.instance.level1Capture.locked)
                                        LevelManager.instance.level1Capture.locked = false;
                                    LevelManager.instance.level1Capture.hasLockedBefore = true;
                                    PlayerPrefs.SetInt(LevelManager.Difficulty.Genius + " HasLockedBefore " + i, UIManager.instance.BoolToInt(LevelManager.instance.level1Capture.hasLockedBefore));
                                }

                                LevelManager.instance.level1Capture.levelParent = GameObject.FindGameObjectWithTag("Genius").gameObject;
                                 LevelManager.instance.CheckLevelState(true);
                                SetParentID(LevelManager.instance.level1Capture.levelParent.transform.position.x, LevelManager.instance.level1Capture.levelParent.transform.position.y, LevelManager.instance.level1Capture.levelParent.transform.position.z);
                                break;
                            case 3://All Unlocked!
                                if (!LevelManager.instance.level1Capture.hasLockedBefore)
                                {
                                    if (!LevelManager.instance.level1Capture.lockMode)
                                        previousLock = LevelManager.instance.InstantiateLock(previousParentMode.transform);

                                    if (LevelManager.instance.level1Capture.locked)
                                        LevelManager.instance.level1Capture.locked = false;

                                    LevelManager.instance.level1Capture.hasLockedBefore = true;

                                    PlayerPrefs.SetInt(LevelManager.Difficulty.Hard + " HasLockedBefore " + i, UIManager.instance.BoolToInt(LevelManager.instance.level1Capture.hasLockedBefore));

                                }
                                LevelManager.instance.CheckLevelState(true);
                                break;
                        }
                    }
                }              
                break;
        }
    }
	
	public void GetParentID()
    {
        switch(UIManager.instance.levelName)
        {
            case "Level1":
                parentX = PlayerPrefs.GetFloat("ParentX");
                parentY = PlayerPrefs.GetFloat("ParentY");
                parentZ = PlayerPrefs.GetFloat("ParentZ");
                previousParent.position = new Vector3(parentX, parentY, parentZ);

                if (GameObject.Find("Level1"))
                    previousParent.SetParent(GameObject.Find("Level1").transform);

                previousParent.localScale = Vector3.one;
                break;

            case "LevelDescription":
                parentX = PlayerPrefs.GetFloat("ParentXMode");
                parentY = PlayerPrefs.GetFloat("ParentYMode");
                parentZ = PlayerPrefs.GetFloat("ParentZMode");
                previousParent.position = new Vector3(parentX, parentY, parentZ);

                if (UIManager.instance.levelName == "LevelDescription")
                    previousParent.SetParent(GameObject.Find("Container").transform);

                previousParent.localScale = Vector3.one;
                break;
        }

        
    }
 
    public void SetParentID(float x, float y, float z)
    {
        switch (UIManager.instance.levelName)
        {
            case "Level1":
                parentX = x; PlayerPrefs.SetFloat("ParentX", parentX);
                parentY = y; PlayerPrefs.SetFloat("ParentY", parentY);
                parentZ = z; PlayerPrefs.SetFloat("ParentZ", parentZ);
                break;
            case "LevelDescription":
                parentX = x; PlayerPrefs.SetFloat("ParentXMode", parentX);
                parentY = y; PlayerPrefs.SetFloat("ParentYMode", parentY);
                parentZ = z; PlayerPrefs.SetFloat("ParentZMode", parentZ);
                break;
        }
      
    }

 

    // Update is called once per frame
    void Update ()
    {
        
    }
}
