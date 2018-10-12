using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgessionCheck : MonoBehaviour {

    public Transform previousParent;
    public GameObject previousLock;
    public float parentX;
    public float parentY;
    public float parentZ;

    void Start ()
    {
        previousLock = new GameObject("PreviousLockLocation");
        previousParent = previousLock.transform;
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
                LevelManager.instance.level1_B = GameObject.Find("Level2Button").GetComponent<Button>();
                LevelManager.instance.level1_C = GameObject.Find("Level3Button").GetComponent<Button>();
                LevelManager.instance.level1_D = GameObject.Find("Level4Button").GetComponent<Button>();
                LevelManager.instance.level1_E = GameObject.Find("Level5Button").GetComponent<Button>();
                LevelManager.instance.level1_B.interactable = false; LevelManager.instance.level1_C.interactable = false; LevelManager.instance.level1_D.interactable = false; LevelManager.instance.level1_E.interactable = false;

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

                }                                              

                

                break;
            case "Level2":

                break;
            case "Level3":

                break;
        }
    }
	
	public void GetParentID()
    {
        parentX = PlayerPrefs.GetFloat("ParentX");
        parentY = PlayerPrefs.GetFloat("ParentY");
        parentZ = PlayerPrefs.GetFloat("ParentZ");
        previousParent.position = new Vector3(parentX, parentY, parentZ);
        previousParent.SetParent(GameObject.Find("Level1").transform);
        previousParent.localScale = Vector3.one;
        
    }
    public void SetParentID(float x, float y, float z)
    {
        parentX = x; PlayerPrefs.SetFloat("ParentX", parentX);
        parentY = y; PlayerPrefs.SetFloat("ParentY", parentY);
        parentZ = z; PlayerPrefs.SetFloat("ParentZ", parentZ);
    }

    // Update is called once per frame
	void Update ()
    {
        
    }
}
