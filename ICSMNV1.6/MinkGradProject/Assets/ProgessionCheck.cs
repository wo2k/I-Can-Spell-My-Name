using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ProgessionCheck : MonoBehaviour {

    public Transform previousParent;
    public Transform previousParentMode;
    public Transform bubblePos;
    public GameObject m_Seahorse;
    public Transform seahorsePos;
    public GameObject previousLock;
    public float parentX;
    public float parentY;
    public float parentZ;

    public List<Button> levelIcons = new List<Button>();

    public bool turnPage;
    public GameObject uiOverlay;
    public GameObject skipButton;
    public GameObject infoButton;
    public GameObject floatingBubbles;
    public List<GameObject> bubbleQueue;


    //Cheat Codes
    public GameObject ccLevelToBeat;
    public GameObject ccSkipMainLevel;
    public GameObject ccToggle;
    public Text ccLevelToBeatResult;
    public bool showCheatCodes;

    void Start ()
    {
  

        previousLock = new GameObject("PreviousLockLocation");
        previousParent = previousLock.transform;
        previousParentMode = previousLock.transform;
        GetParentID();
        LevelManager.instance.m_MainLevelToBeat = (LevelManager.MainLevelToBeat)LevelManager.instance.levelPassed;
        LevelManager.instance.m_LevelToBeat = (LevelManager.LevelToBeat)LevelManager.instance.subLevelPassed;

        switch (UIManager.instance.levelName)
        {
            case "MainMenu":
                break;
            case "Campaign":

                LevelManager.instance.level1 = GameObject.Find("Level1").GetComponent<Button>();
                LevelManager.instance.level2 = GameObject.Find("Level2").GetComponent<Button>();
                LevelManager.instance.level3 = GameObject.Find("Level3").GetComponent<Button>();

                for (int i = 0; i < System.Enum.GetValues(typeof(LevelManager.MainLevelToBeat)).Length; i++)
                {
                    if (LevelManager.instance.m_MainLevelToBeat == (LevelManager.MainLevelToBeat)i)
                    {
                        switch (i)
                        {
                            case 0://Level 1
                                UIManager.instance.MakeSpriteGlow(LevelManager.instance.level1.GetComponent<Image>());
                                LevelManager.instance.CheckLevelState(true);

                                LevelManager.instance.mainLevelParent = LevelManager.instance.level2.gameObject;
                                LevelManager.instance.mainLockLevel = LevelManager.instance.InstantiateLock(LevelManager.instance.mainLevelParent.transform);
                                SetParentID(LevelManager.instance.mainLevelParent.transform.position.x, LevelManager.instance.mainLevelParent.transform.position.y, LevelManager.instance.mainLevelParent.transform.position.z);

                                break;
                            case 1://Level 2
                                UIManager.instance.MakeSpriteGlow(LevelManager.instance.level2.GetComponent<Image>());
                                LevelManager.instance.CheckLevelState(true);

                                if (!LevelManager.instance.mainLockLevel)
                                    previousLock = LevelManager.instance.InstantiateLock(previousParent.transform);

                                if (!LevelManager.instance.mainHasLockedBefore)
                                {
                                    if (LevelManager.instance.mainLocked)
                                        LevelManager.instance.mainLocked = false;
                                    LevelManager.instance.mainHasLockedBefore = true;
                                    PlayerPrefs.SetInt("MainHasLockedBefore", UIManager.instance.BoolToInt(LevelManager.instance.mainHasLockedBefore));
                                }

                                LevelManager.instance.mainLevelParent = LevelManager.instance.level3.gameObject;

                                SetParentID(LevelManager.instance.mainLevelParent.transform.position.x, LevelManager.instance.mainLevelParent.transform.position.y, LevelManager.instance.mainLevelParent.transform.position.z);

                                break;
                            case 2://Level 3
                                UIManager.instance.MakeSpriteGlow(LevelManager.instance.level3.GetComponent<Image>());
                                LevelManager.instance.CheckLevelState(true);

                                if (!LevelManager.instance.mainHasLockedBefore)
                                {
                                    if (!LevelManager.instance.mainLockLevel)
                                        previousLock = LevelManager.instance.InstantiateLock(previousParent.transform);

                                    if (LevelManager.instance.mainLocked)
                                        LevelManager.instance.mainLocked = false;
                                    LevelManager.instance.mainHasLockedBefore = true;
                                    PlayerPrefs.SetInt("MainHasLockedBefore", UIManager.instance.BoolToInt(LevelManager.instance.mainHasLockedBefore));
                                }

                                break;
                        }
                    }
                }


                break;
            case "Level1":
                LevelManager.instance.level1_A = GameObject.Find("Level1Button").GetComponent<Button>();
                LevelManager.instance.level1_B = GameObject.Find("Level2Button").GetComponent<Button>(); levelIcons.Add(LevelManager.instance.level1_B);
                LevelManager.instance.level1_C = GameObject.Find("Level3Button").GetComponent<Button>(); levelIcons.Add(LevelManager.instance.level1_C);
                LevelManager.instance.level1_D = GameObject.Find("Level4Button").GetComponent<Button>(); levelIcons.Add(LevelManager.instance.level1_D);
                LevelManager.instance.level1_E = GameObject.Find("Level5Button").GetComponent<Button>(); levelIcons.Add(LevelManager.instance.level1_E);
                LevelManager.instance.SetIconOpacity(levelIcons, 0.5f, false);

                CheckProgression(LevelManager.instance.subLevelPassed);

                break;
            case "Level2":
                LevelManager.instance.level2_A = GameObject.Find("Level1Button").GetComponent<Button>();
                LevelManager.instance.level2_B = GameObject.Find("Level2Button").GetComponent<Button>(); levelIcons.Add(LevelManager.instance.level2_B);
                LevelManager.instance.level2_C = GameObject.Find("Level3Button").GetComponent<Button>(); levelIcons.Add(LevelManager.instance.level2_C);
                LevelManager.instance.level2_D = GameObject.Find("Level4Button").GetComponent<Button>(); levelIcons.Add(LevelManager.instance.level2_D);
                LevelManager.instance.level2_E = GameObject.Find("Level5Button").GetComponent<Button>(); levelIcons.Add(LevelManager.instance.level2_E);
                LevelManager.instance.level2_F = GameObject.Find("Level6Button").GetComponent<Button>(); levelIcons.Add(LevelManager.instance.level2_F);
                LevelManager.instance.SetIconOpacity(levelIcons, 0.5f, false);

                if (LevelManager.instance.levelPassed == 1)
                    CheckProgression(LevelManager.instance.subLevelPassed);
                break;
            case "Level3":

                break;

            case "LevelDescription":

                if (UIManager.instance.mode <= UIManager.subLevels1.Level1E && UIManager.instance.mode2 == UIManager.subLevels2.None)
                    CheckDifficultyProgression(System.Enum.GetValues(typeof(UIManager.subLevels1)).Length, LevelManager.instance.level1Capture);

                if (UIManager.instance.mode2 <= UIManager.subLevels2.Level2F && UIManager.instance.mode == UIManager.subLevels1.None)
                    CheckDifficultyProgression(System.Enum.GetValues(typeof(UIManager.subLevels2)).Length, LevelManager.instance.level2Capture);
                break;
        }

        LevelManager.instance.SavePlayerPrefs();
    }
	
	public void GetParentID()
    {
        switch(UIManager.instance.levelName)
        {
            case "Campaign":
                parentX = PlayerPrefs.GetFloat("ParentXMain");
                parentY = PlayerPrefs.GetFloat("ParentYMain");
                parentZ = PlayerPrefs.GetFloat("ParentZMain");
                previousParent.position = new Vector3(parentX, parentY, parentZ);

                if (GameObject.Find("CampaignMenu"))
                    previousParent.SetParent(GameObject.Find("CampaignMenu").transform);

                previousParent.localScale = Vector3.one;
                break;

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
                previousParentMode.position = new Vector3(parentX, parentY, parentZ);

                if (UIManager.instance.levelName == "LevelDescription")//Remove this line
                    previousParentMode.SetParent(GameObject.Find("Container").transform);

                previousParentMode.localScale = Vector3.one;
                break;
        }

        
    }
 
    public void SetParentID(float x, float y, float z)
    {
        switch (UIManager.instance.levelName)
        {
            case "Campaign":
                parentX = x; PlayerPrefs.SetFloat("ParentXMain", parentX);
                parentY = y; PlayerPrefs.SetFloat("ParentYMain", parentY);
                parentZ = z; PlayerPrefs.SetFloat("ParentZMain", parentZ);
                break;
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

    public void CheckProgression(int subLevel)
    {

        switch (subLevel)
        {
            case 0://Lock B                     
                LevelManager.instance.levelParent = GameObject.FindGameObjectWithTag("Level1B").gameObject;
                LevelManager.instance.lockLevel = LevelManager.instance.InstantiateLock(LevelManager.instance.levelParent.transform);
                SetParentID(LevelManager.instance.levelParent.transform.position.x, LevelManager.instance.levelParent.transform.position.y, LevelManager.instance.levelParent.transform.position.z);
                if (!LevelManager.instance.hasShownStoryAlready)
                {
                    ToggleStoryAssets(true, 5 - subLevel);
                    StartCoroutine(InstantiateStory(false, LevelManager.instance.level1Capture));
                }
                else
                    ToggleStoryAssets(false);
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

                if (!LevelManager.instance.hasShownStoryAlready)
                    ToggleStoryAssets(true, 5 - subLevel);
                else
                    ToggleStoryAssets(false);

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

                if (!LevelManager.instance.hasShownStoryAlready)
                    ToggleStoryAssets(true, 5 - subLevel);
                else
                    ToggleStoryAssets(false);
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

                if (!LevelManager.instance.hasShownStoryAlready)
                    ToggleStoryAssets(true, 5 - subLevel);
                else
                    ToggleStoryAssets(false);
                break;

            case 4:// All Unlocked if level 1               
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

                    if (!LevelManager.instance.hasShownStoryAlready)
                        ToggleStoryAssets(true, 5 - subLevel);
                    else
                        ToggleStoryAssets(false);                              
                break;

            case 5: // First unlock for Level2

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

                if (!LevelManager.instance.hasShownStoryAlready)
                {
                    ToggleStoryAssets(true, 5 - subLevel);
                    StartCoroutine(InstantiateStory(false, LevelManager.instance.level2Capture));
                }
                else
                    ToggleStoryAssets(false);
               

                break;

            case 6://Lock B                     
                LevelManager.instance.levelParent = GameObject.FindGameObjectWithTag("Level1B").gameObject;
                LevelManager.instance.lockLevel = LevelManager.instance.InstantiateLock(LevelManager.instance.levelParent.transform);
                SetParentID(LevelManager.instance.levelParent.transform.position.x, LevelManager.instance.levelParent.transform.position.y, LevelManager.instance.levelParent.transform.position.z);

                if (!LevelManager.instance.hasShownStoryAlready)
                    ToggleStoryAssets(true, 5 - subLevel);
                else
                    ToggleStoryAssets(false);
                break;

            case 7:// Lock C
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

                if (!LevelManager.instance.hasShownStoryAlready)
                    ToggleStoryAssets(true, 5 - subLevel);
                else
                    ToggleStoryAssets(false);

                break;

            case 8:// Lock D
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

                if (!LevelManager.instance.hasShownStoryAlready)
                    ToggleStoryAssets(true, 5 - subLevel);
                else
                    ToggleStoryAssets(false);
                break;

            case 9:// Lock E
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

                if (!LevelManager.instance.hasShownStoryAlready)
                    ToggleStoryAssets(true, 5 - subLevel);
                else
                    ToggleStoryAssets(false);
                break;

            case 10: // Lock F       
                    if (!LevelManager.instance.lockLevel)
                        previousLock = LevelManager.instance.InstantiateLock(previousParent.transform);

                    if (!LevelManager.instance.hasLockedBefore)
                    {
                        if (LevelManager.instance.locked)
                            LevelManager.instance.locked = false;
                        LevelManager.instance.hasLockedBefore = true;
                        PlayerPrefs.SetInt("HasLockedBefore", UIManager.instance.BoolToInt(LevelManager.instance.hasLockedBefore));
                    }

                    LevelManager.instance.levelParent = GameObject.FindGameObjectWithTag("Level2F").gameObject;
                    LevelManager.instance.CheckLevelState(true);
                    SetParentID(LevelManager.instance.levelParent.transform.position.x, LevelManager.instance.levelParent.transform.position.y, LevelManager.instance.levelParent.transform.position.z);

                    if (!LevelManager.instance.hasShownStoryAlready)
                        ToggleStoryAssets(true, 5 - subLevel);
                    else
                        ToggleStoryAssets(false);           
                break;

            case 11: //All unlocked for level 2

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

                if (!LevelManager.instance.hasShownStoryAlready)
                    ToggleStoryAssets(true, 5 - subLevel);
                else
                    ToggleStoryAssets(false);

                break;

        }


        LevelManager.instance.SavePlayerPrefs();
    }

    public void CheckDifficultyProgression(int subLevel, LevelSettings tempCapture)
    {
        for (int i = 0; i < subLevel; i++)
        {

            if (tempCapture.Equals(LevelManager.instance.level1Capture))
                tempCapture = LevelManager.instance.level1Container[i];

            if (tempCapture.Equals(LevelManager.instance.level2Capture))
                tempCapture = LevelManager.instance.level2Container[i];

            tempCapture.Easy = GameObject.Find("Easy").GetComponent<Button>();
            tempCapture.Normal = GameObject.Find("Normal").GetComponent<Button>();
            tempCapture.Hard = GameObject.Find("Hard").GetComponent<Button>();
            tempCapture.Genius = GameObject.Find("Genius").GetComponent<Button>();
            tempCapture.Normal.interactable = false; tempCapture.Hard.interactable = false; tempCapture.Genius.interactable = false;

            switch (tempCapture.modePassed)
            {
                case 0://Easy
                    tempCapture.levelParent = GameObject.FindGameObjectWithTag("Normal").gameObject;
                    tempCapture.lockMode = LevelManager.instance.InstantiateLock(tempCapture.levelParent.transform);
                    SetParentID(tempCapture.levelParent.transform.position.x, tempCapture.levelParent.transform.position.y, tempCapture.levelParent.transform.position.z);



                    UIManager.instance.MakeSpriteGlow(tempCapture.Easy.GetComponent<Image>());
                    break;

                case 1://Normal
                    if (!tempCapture.lockMode)
                        previousLock = LevelManager.instance.InstantiateLock(previousParentMode.transform);

                    if (!tempCapture.hasLockedBefore)
                    {
                        if (tempCapture.locked)
                            tempCapture.locked = false;
                        tempCapture.hasLockedBefore = true;
                        PlayerPrefs.SetInt(LevelManager.Difficulty.Normal + " HasLockedBefore " + i, UIManager.instance.BoolToInt(tempCapture.hasLockedBefore));
                    }

                    else
                        UIManager.instance.MakeSpriteGlow(tempCapture.Normal.GetComponent<Image>());

                    tempCapture.levelParent = GameObject.FindGameObjectWithTag("Hard").gameObject;
                    LevelManager.instance.CheckLevelState(true);
                    SetParentID(tempCapture.levelParent.transform.position.x, tempCapture.levelParent.transform.position.y, tempCapture.levelParent.transform.position.z);


                    break;

                case 2://Hard
                    if (!tempCapture.lockMode)
                        previousLock = LevelManager.instance.InstantiateLock(previousParentMode.transform);

                    if (!tempCapture.hasLockedBefore)
                    {
                        if (tempCapture.locked)
                            tempCapture.locked = false;
                        tempCapture.hasLockedBefore = true;
                        PlayerPrefs.SetInt(LevelManager.Difficulty.Hard + " HasLockedBefore " + i, UIManager.instance.BoolToInt(tempCapture.hasLockedBefore));
                    }

                    else
                        UIManager.instance.MakeSpriteGlow(tempCapture.Hard.GetComponent<Image>());

                    tempCapture.levelParent = GameObject.FindGameObjectWithTag("Genius").gameObject;
                    LevelManager.instance.CheckLevelState(true);
                    SetParentID(tempCapture.levelParent.transform.position.x, tempCapture.levelParent.transform.position.y, tempCapture.levelParent.transform.position.z);


                    break;

                case 3://Genius

                    if (tempCapture.usedCheatCode)
                    {
                        tempCapture.levelParent = GameObject.FindGameObjectWithTag("Genius").gameObject;
                        SetParentID(tempCapture.levelParent.transform.position.x, tempCapture.levelParent.transform.position.y, tempCapture.levelParent.transform.position.z);
                        GetParentID();
                        tempCapture.usedCheatCode = false;
                    }

                    if (!tempCapture.hasLockedBefore)
                    {
                        if (!tempCapture.lockMode)
                            previousLock = LevelManager.instance.InstantiateLock(previousParentMode.transform);

                        if (tempCapture.locked)
                            tempCapture.locked = false;

                        tempCapture.hasLockedBefore = true;

                        PlayerPrefs.SetInt(LevelManager.Difficulty.Genius + " HasLockedBefore " + i, UIManager.instance.BoolToInt(tempCapture.hasLockedBefore));

                    }

                    else
                        UIManager.instance.MakeSpriteGlow(tempCapture.Genius.GetComponent<Image>());


                    LevelManager.instance.CheckLevelState(true);
                    break;
            }

        }
    }

    

    /// <summary>
    /// Creates a speech bubble that is for the story
    /// </summary>
    /// <param name="storyTxt"></param>
    public GameObject InstantiateBubble(string storyTxt)
    {
        for (int i = 0; i < bubbleQueue.Count; i++)
        {
            if (bubbleQueue[i])
            {
                bubbleQueue[i].GetComponentInChildren<Animation>().Stop();
                bubbleQueue[i].GetComponentInChildren<Animation>().Rewind();
                Destroy(bubbleQueue[i]);
            }
        }
        bubbleQueue.Clear();
        turnPage = false;
        GameObject speechBubble = Instantiate(Resources.Load("Prefabs/StoryBubble") as GameObject, bubblePos.position, bubblePos.rotation, m_Seahorse.transform);
        bubbleQueue.Add(speechBubble);
    
        speechBubble.GetComponentInChildren<Text>().text = storyTxt;
        speechBubble.GetComponentInChildren<SpeechBubble>().animationTime = 5;
        return speechBubble;
    }

   public IEnumerator InstantiateStory(bool skipGlowEffect, LevelSettings tempCapture)
    {
        
        var sentences = new List<string>();
        int position = 0;
        int start = 0;

        for (int i = 0; i < System.Enum.GetValues(typeof(LevelManager.LevelToBeat)).Length; i++)
        {
            if (LevelManager.instance.m_LevelToBeat == (LevelManager.LevelToBeat)i)
            {
                if (tempCapture.Equals(LevelManager.instance.level1Capture))
                    tempCapture = LevelManager.instance.level1Container[i];

                if (tempCapture.Equals(LevelManager.instance.level2Capture))
                    tempCapture = LevelManager.instance.level2Container[i];
               
                if (!skipGlowEffect)
                {
                    //Reassures that there are no other components in level that are glowing
                    //If so then remove the glow and add priority glow to level icon
                    if (FindObjectOfType<GlowSprite>())
                    {
                        for (int j = 0; j < FindObjectsOfType<GlowSprite>().Length; j++)
                        {
                            FindObjectsOfType<GlowSprite>()[j].gameObject.GetComponent<Image>().material = null;
                            Destroy(FindObjectsOfType<GlowSprite>()[j]);
                        }
                    }

                    levelIcons[i].GetComponent<Image>().material = Resources.Load<Material>("Shaders/SpriteOutline");
                    levelIcons[i].gameObject.AddComponent<GlowSprite>();
                }

                levelIcons[i].enabled = false;
            }
        }

        do
        {
            position = tempCapture.levelIntro.IndexOf('.', start);
            if (position >= 0)
            {
                sentences.Add(tempCapture.levelIntro.Substring(start, position - start + 1).Trim());
                start = position + 1;
            }
        }
        while (position > 0);

        foreach(string sentence in sentences)
        {
            GameObject speechBubble = InstantiateBubble(sentence);
            yield return new WaitUntil(() => turnPage);
            if(speechBubble)
            speechBubble.GetComponentInChildren<SpeechBubble>().turnPage = turnPage;
            yield return new WaitForSeconds(2);
        }

        StartCoroutine(AnimateSeahorseOffScreen());
    }

    public void PlayStory()
    {
        turnPage = false;
        ToggleStoryAssets(true, 5 - LevelManager.instance.subLevelPassed);
        uiOverlay.GetComponent<Image>().color = new Color(0, 0, 0, 0.5f);

        m_Seahorse.transform.localPosition = seahorsePos.localPosition;

        if(LevelManager.instance.levelPassed == 0)
        StartCoroutine(InstantiateStory(true, LevelManager.instance.level1Capture));

        if (LevelManager.instance.levelPassed == 1)
            StartCoroutine(InstantiateStory(true, LevelManager.instance.level2Capture));
    }

    public void SkipStory()
    {
        for (int i = 0; i < bubbleQueue.Count; i++)
        {
            if(bubbleQueue[i])
            Destroy(bubbleQueue[i]);  
        }

        bubbleQueue.Clear();

        StartCoroutine(AnimateSeahorseOffScreen());
    }

    IEnumerator AnimateSeahorseOffScreen()
    {
        floatingBubbles.SetActive(true);
        m_Seahorse.GetComponent<Animation>().Play();
        yield return new WaitForSeconds(m_Seahorse.GetComponent<Animation>().clip.length);

        for (float i = 0; i < uiOverlay.GetComponent<Image>().color.a; i += 0.01f)
        {
            uiOverlay.GetComponent<Image>().color = new Color(0, 0, 0, uiOverlay.GetComponent<Image>().color.a - i);
            yield return new WaitForSeconds(0.01f);
        }

        uiOverlay.SetActive(false);
        floatingBubbles.SetActive(false);
        m_Seahorse.SetActive(false);
        skipButton.SetActive(false);
        infoButton.SetActive(true);

        LevelManager.instance.hasShownStoryAlready = true;
        PlayerPrefs.SetInt("HasShownStoryAlready", UIManager.instance.BoolToInt(LevelManager.instance.hasShownStoryAlready));

        for (int i = 0; i < System.Enum.GetValues(typeof(LevelManager.LevelToBeat)).Length; i++)
        {
            if (LevelManager.instance.m_LevelToBeat == (LevelManager.LevelToBeat)i)
            {
                levelIcons[i].enabled = true;
            }
        }
    }

    public void NextPage()
    {
        turnPage = true;
       // turnPage = false;
    }

    public void ToggleStoryAssets(bool show)
    {
        m_Seahorse.SetActive(show);
        uiOverlay.SetActive(show);
        skipButton.SetActive(show);
        infoButton.SetActive(!show);

        for (int i = 0; i < System.Enum.GetValues(typeof(LevelManager.LevelToBeat)).Length; i++)
        {
            if (LevelManager.instance.m_LevelToBeat == (LevelManager.LevelToBeat)i)
            {
                levelIcons[i].GetComponent<Image>().material = Resources.Load<Material>("Shaders/SpriteOutline");
                levelIcons[i].gameObject.AddComponent<GlowSprite>();
            }
        }        
    }

    /// <summary>
    /// Toggle Story Assets on screen
    /// </summary>
    /// <param name="show"></param>
    /// <param name="childIndex"> Set UI Overlay child index to set focus on current level </param>
    public void ToggleStoryAssets(bool show, int childIndex)
    {
        m_Seahorse.SetActive(show);
        uiOverlay.SetActive(show);
        skipButton.SetActive(show);
        infoButton.SetActive(!show);
        m_Seahorse.transform.SetAsLastSibling();

        for (int i = 0; i < System.Enum.GetValues(typeof(LevelManager.LevelToBeat)).Length; i++)
        {
            if (LevelManager.instance.m_LevelToBeat == (LevelManager.LevelToBeat)i)
            {
                uiOverlay.transform.SetSiblingIndex(childIndex);

                for (int j = 0; j < i; j++)
                    levelIcons[j].transform.SetAsFirstSibling();
            }
        }      
    }

    public void ToggleCheatCodes()
    {
        showCheatCodes = ccToggle.GetComponent<Toggle>().isOn;
        ccLevelToBeat.SetActive(showCheatCodes);
        ccSkipMainLevel.SetActive(showCheatCodes);

        if (showCheatCodes)
            ccLevelToBeatResult.text = LevelManager.instance.m_LevelToBeat.ToString();
    }

    public void SkipLevel(string levelCaptureType)
    {
        LevelSettings tempCapture = null;

        for (int i = 0; i < System.Enum.GetValues(typeof(LevelManager.LevelToBeat)).Length; i++)
        {
            if (LevelManager.instance.m_LevelToBeat == (LevelManager.LevelToBeat)i)
            {
                if (levelCaptureType == "level1Capture")
                    tempCapture = LevelManager.instance.level1Container[i];

                if (levelCaptureType == "level2Capture")
                    tempCapture = LevelManager.instance.level2Container[i];

                tempCapture.usedCheatCode = true;


                tempCapture.modePassed = 3;

                if (levelCaptureType == "level1Capture")
                    PlayerPrefs.SetInt(LevelManager.Difficulty.Hard + " ModePassed " + i, tempCapture.modePassed);
                if (levelCaptureType == "level2Capture")
                    PlayerPrefs.SetInt(LevelManager.Difficulty.Hard + " ModePassed2 " + i, tempCapture.modePassed);

                UIManager.instance.hasWonIndex = (int)LevelManager.instance.m_LevelToBeat;

                if (!UIManager.instance.hasWonAlready[UIManager.instance.hasWonIndex])
                {
                    UIManager.instance.hasWonAlready[UIManager.instance.hasWonIndex] = true;
                    LevelManager.instance.subLevelPassed++;
                   
                    PlayerPrefs.SetInt("SubLevelPassed", LevelManager.instance.subLevelPassed);
                    PlayerPrefs.SetInt("HasWonAlready " + i, UIManager.instance.BoolToInt(UIManager.instance.hasWonAlready[UIManager.instance.hasWonIndex]));
                    LevelManager.instance.hasLockedBefore = false;
                    LevelManager.instance.hasShownStoryAlready = false;
                    PlayerPrefs.SetInt("HasShownStoryAlready", UIManager.instance.BoolToInt(LevelManager.instance.hasShownStoryAlready));
                }

                turnPage = false;
             
                uiOverlay.GetComponent<Image>().color = new Color(0, 0, 0, 0.5f);

                m_Seahorse.transform.localPosition = seahorsePos.localPosition;
               
            }
        }
        LevelManager.instance.m_LevelToBeat = (LevelManager.LevelToBeat)LevelManager.instance.subLevelPassed;
      
        CheckProgression(LevelManager.instance.subLevelPassed);

        
       

        if (showCheatCodes)
            ccLevelToBeatResult.text = LevelManager.instance.m_LevelToBeat.ToString();
    }

    // Update is called once per frame
    void Update ()
    {
        
    }
}
