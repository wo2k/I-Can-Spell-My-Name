using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    void Start ()
    {
        previousLock = new GameObject("PreviousLockLocation");
        previousParent = previousLock.transform;
        previousParentMode = previousLock.transform;
        GetParentID();
        LevelManager.instance.m_MainLevelToBeat = (LevelManager.MainLevelToBeat)LevelManager.instance.levelPassed;
        LevelManager.instance.m_LevelToBeat = (LevelManager.LevelToBeat)LevelManager.instance.subLevelPassed1;

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
                        switch(i)
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
                             //   LevelManager.instance.CheckLevelState(true);
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

                             //   LevelManager.instance.mainLevelParent = LevelManager.instance.level3.gameObject;
                                //   LevelManager.instance.CheckLevelState(true);
                             //   SetParentID(LevelManager.instance.mainLevelParent.transform.position.x, LevelManager.instance.mainLevelParent.transform.position.y, LevelManager.instance.mainLevelParent.transform.position.z);
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

                switch (LevelManager.instance.subLevelPassed1)
                {
                    case 0://Lock B                     
                        LevelManager.instance.levelParent = GameObject.FindGameObjectWithTag("Level1B").gameObject;
                        LevelManager.instance.lockLevel = LevelManager.instance.InstantiateLock(LevelManager.instance.levelParent.transform);
                        SetParentID(LevelManager.instance.levelParent.transform.position.x, LevelManager.instance.levelParent.transform.position.y, LevelManager.instance.levelParent.transform.position.z);
                        if (!LevelManager.instance.hasShownStoryAlready)
                        {
                            ToggleStoryAssets(true, 5 - LevelManager.instance.subLevelPassed1);
                            StartCoroutine(InstantiateStory(false));
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
                            ToggleStoryAssets(true, 5 - LevelManager.instance.subLevelPassed1);
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
                            ToggleStoryAssets(true, 5 - LevelManager.instance.subLevelPassed1);
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
                            ToggleStoryAssets(true, 5 - LevelManager.instance.subLevelPassed1);
                        else
                            ToggleStoryAssets(false);
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
                            case 0://Easy
                                LevelManager.instance.level1Capture.levelParent = GameObject.FindGameObjectWithTag("Normal").gameObject;
                                LevelManager.instance.level1Capture.lockMode = LevelManager.instance.InstantiateLock(LevelManager.instance.level1Capture.levelParent.transform);
                                SetParentID(LevelManager.instance.level1Capture.levelParent.transform.position.x, LevelManager.instance.level1Capture.levelParent.transform.position.y, LevelManager.instance.level1Capture.levelParent.transform.position.z);

                                //LevelManager.instance.level1Capture.m_DifficultyToBeat = LevelSettings.DifficultyToBeat.Easy;

                                UIManager.instance.MakeSpriteGlow(LevelManager.instance.level1Capture.Easy.GetComponent<Image>());
                                break;

                            case 1://Normal
                                if (!LevelManager.instance.level1Capture.lockMode)
                                    previousLock = LevelManager.instance.InstantiateLock(previousParentMode.transform);

                                if (!LevelManager.instance.level1Capture.hasLockedBefore)
                                {
                                    if (LevelManager.instance.level1Capture.locked)
                                        LevelManager.instance.level1Capture.locked = false;
                                    LevelManager.instance.level1Capture.hasLockedBefore = true;
                                    PlayerPrefs.SetInt(LevelManager.Difficulty.Hard + " HasLockedBefore " + i, UIManager.instance.BoolToInt(LevelManager.instance.level1Capture.hasLockedBefore));
                                }

                                else
                                    UIManager.instance.MakeSpriteGlow(LevelManager.instance.level1Capture.Normal.GetComponent<Image>());

                                LevelManager.instance.level1Capture.levelParent = GameObject.FindGameObjectWithTag("Hard").gameObject;
                                LevelManager.instance.CheckLevelState(true);
                                SetParentID(LevelManager.instance.level1Capture.levelParent.transform.position.x, LevelManager.instance.level1Capture.levelParent.transform.position.y, LevelManager.instance.level1Capture.levelParent.transform.position.z);

                               // LevelManager.instance.level1Capture.m_DifficultyToBeat = LevelSettings.DifficultyToBeat.Normal;
                                //  UIManager.instance.MakeSpriteGlow(LevelManager.instance.level1Capture.Normal.GetComponent<Image>());
                                break;

                            case 2://Hard
                                if (!LevelManager.instance.level1Capture.lockMode)
                                    previousLock = LevelManager.instance.InstantiateLock(previousParentMode.transform);

                                if (!LevelManager.instance.level1Capture.hasLockedBefore)
                                {
                                    if (LevelManager.instance.level1Capture.locked)
                                        LevelManager.instance.level1Capture.locked = false;
                                    LevelManager.instance.level1Capture.hasLockedBefore = true;
                                    PlayerPrefs.SetInt(LevelManager.Difficulty.Genius + " HasLockedBefore " + i, UIManager.instance.BoolToInt(LevelManager.instance.level1Capture.hasLockedBefore));
                                }

                                else
                                    UIManager.instance.MakeSpriteGlow(LevelManager.instance.level1Capture.Hard.GetComponent<Image>());

                                LevelManager.instance.level1Capture.levelParent = GameObject.FindGameObjectWithTag("Genius").gameObject;
                                 LevelManager.instance.CheckLevelState(true);
                                SetParentID(LevelManager.instance.level1Capture.levelParent.transform.position.x, LevelManager.instance.level1Capture.levelParent.transform.position.y, LevelManager.instance.level1Capture.levelParent.transform.position.z);

                               // LevelManager.instance.level1Capture.m_DifficultyToBeat = LevelSettings.DifficultyToBeat.Hard;
                                //  UIManager.instance.MakeSpriteGlow(LevelManager.instance.level1Capture.Hard.GetComponent<Image>());
                                break;

                            case 3://Genius
                                if (!LevelManager.instance.level1Capture.hasLockedBefore)
                                {
                                    if (!LevelManager.instance.level1Capture.lockMode)
                                        previousLock = LevelManager.instance.InstantiateLock(previousParentMode.transform);

                                    if (LevelManager.instance.level1Capture.locked)
                                        LevelManager.instance.level1Capture.locked = false;

                                    LevelManager.instance.level1Capture.hasLockedBefore = true;

                                    PlayerPrefs.SetInt(LevelManager.Difficulty.Hard + " HasLockedBefore " + i, UIManager.instance.BoolToInt(LevelManager.instance.level1Capture.hasLockedBefore));

                                }

                                else
                                    UIManager.instance.MakeSpriteGlow(LevelManager.instance.level1Capture.Genius.GetComponent<Image>());

                               // LevelManager.instance.level1Capture.m_DifficultyToBeat = LevelSettings.DifficultyToBeat.Genius;
                                //  UIManager.instance.MakeSpriteGlow(LevelManager.instance.level1Capture.Genius.GetComponent<Image>());
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
                previousParent.position = new Vector3(parentX, parentY, parentZ);

                if (UIManager.instance.levelName == "LevelDescription")//Remove this line
                    previousParent.SetParent(GameObject.Find("Container").transform);

                previousParent.localScale = Vector3.one;
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

   public IEnumerator InstantiateStory(bool skipGlowEffect)
    {
        
        var sentences = new List<string>();
        int position = 0;
        int start = 0;

        for (int i = 0; i < System.Enum.GetValues(typeof(LevelManager.LevelToBeat)).Length; i++)
        {
            if (LevelManager.instance.m_LevelToBeat == (LevelManager.LevelToBeat)i)
            {
                switch (i)
                {
                    case 0:
                        LevelManager.instance.level1Capture = LevelManager.instance.level1A;
                        if (!skipGlowEffect)
                        {
                            LevelManager.instance.level1_A.GetComponent<Image>().material = Resources.Load<Material>("Shaders/SpriteOutline");
                            LevelManager.instance.level1_A.gameObject.AddComponent<GlowSprite>();
                        }
                        LevelManager.instance.level1_A.enabled = false;
                        break;
                    case 1:
                        LevelManager.instance.level1Capture = LevelManager.instance.level1B;
                        if (!skipGlowEffect)
                        {
                            LevelManager.instance.level1_B.GetComponent<Image>().material = Resources.Load<Material>("Shaders/SpriteOutline");
                            LevelManager.instance.level1_B.gameObject.AddComponent<GlowSprite>();
                        }
                        LevelManager.instance.level1_B.enabled = false;
                        break;
                    case 2:
                        LevelManager.instance.level1Capture = LevelManager.instance.level1C;
                        if (!skipGlowEffect)
                        {
                            LevelManager.instance.level1_C.GetComponent<Image>().material = Resources.Load<Material>("Shaders/SpriteOutline");
                            LevelManager.instance.level1_C.gameObject.AddComponent<GlowSprite>();
                        }
                        LevelManager.instance.level1_C.enabled = false;
                        break;
                    case 3:
                        LevelManager.instance.level1Capture = LevelManager.instance.level1D;
                        if (!skipGlowEffect)
                        {
                            LevelManager.instance.level1_D.GetComponent<Image>().material = Resources.Load<Material>("Shaders/SpriteOutline");
                            LevelManager.instance.level1_D.gameObject.AddComponent<GlowSprite>();
                        }
                        LevelManager.instance.level1_D.enabled = false;
                        break;
                    case 4:
                        LevelManager.instance.level1Capture = LevelManager.instance.level1E;
                        if (!skipGlowEffect)
                        {
                            LevelManager.instance.level1_E.GetComponent<Image>().material = Resources.Load<Material>("Shaders/SpriteOutline");
                            LevelManager.instance.level1_E.gameObject.AddComponent<GlowSprite>();
                        }
                        LevelManager.instance.level1_E.enabled = false;
                        break;
                }
            }
        }

        do
        {
            position = LevelManager.instance.level1Capture.levelIntro.IndexOf('.', start);
            if (position >= 0)
            {
                sentences.Add(LevelManager.instance.level1Capture.levelIntro.Substring(start, position - start + 1).Trim());
                start = position + 1;
            }
        }
        while (position > 0);

        foreach(string sentence in sentences)
        {
            GameObject speechBubble = InstantiateBubble(sentence);
            yield return new WaitUntil(() => turnPage);
            speechBubble.GetComponentInChildren<SpeechBubble>().turnPage = turnPage;
            yield return new WaitForSeconds(2);
        }

        StartCoroutine(AnimateSeahorseOffScreen());
    }

    public void PlayStory()
    {
        turnPage = false;
        ToggleStoryAssets(true, 5 - LevelManager.instance.subLevelPassed1);
        m_Seahorse.transform.localPosition = seahorsePos.localPosition;
        StartCoroutine(InstantiateStory(true));
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
                switch (i)
                {
                    case 0:
                        LevelManager.instance.level1_A.enabled = true;
                        break;
                    case 1:
                        LevelManager.instance.level1_B.enabled = true;
                        break;
                    case 2:
                        LevelManager.instance.level1_C.enabled = true;
                        break;
                    case 3:
                        LevelManager.instance.level1_D.enabled = true;
                        break;
                    case 4:
                        LevelManager.instance.level1_E.enabled = true;
                        break;
                }
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

        switch (LevelManager.instance.m_LevelToBeat)
        {
            case LevelManager.LevelToBeat.Level1A:
                LevelManager.instance.level1_A.GetComponent<Image>().material = Resources.Load<Material>("Shaders/SpriteOutline");
                LevelManager.instance.level1_A.gameObject.AddComponent<GlowSprite>();
                break;

            case LevelManager.LevelToBeat.Level1B:
                LevelManager.instance.level1_B.GetComponent<Image>().material = Resources.Load<Material>("Shaders/SpriteOutline");
                LevelManager.instance.level1_B.gameObject.AddComponent<GlowSprite>();
                break;

            case LevelManager.LevelToBeat.Level1C:
                LevelManager.instance.level1_C.GetComponent<Image>().material = Resources.Load<Material>("Shaders/SpriteOutline");
                LevelManager.instance.level1_C.gameObject.AddComponent<GlowSprite>();
                break;

            case LevelManager.LevelToBeat.Level1D:
                LevelManager.instance.level1_D.GetComponent<Image>().material = Resources.Load<Material>("Shaders/SpriteOutline");
                LevelManager.instance.level1_D.gameObject.AddComponent<GlowSprite>();
                break;

            case LevelManager.LevelToBeat.Level1E:
                LevelManager.instance.level1_E.GetComponent<Image>().material = Resources.Load<Material>("Shaders/SpriteOutline");
                LevelManager.instance.level1_E.gameObject.AddComponent<GlowSprite>();
                break;
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

        switch (LevelManager.instance.m_LevelToBeat)
        {
            case LevelManager.LevelToBeat.Level1A:
                uiOverlay.transform.SetSiblingIndex(childIndex);

 
                break;
            case LevelManager.LevelToBeat.Level1B:
                uiOverlay.transform.SetSiblingIndex(childIndex);
                LevelManager.instance.level1_A.transform.SetSiblingIndex(childIndex - 1);


                break;
            case LevelManager.LevelToBeat.Level1C:
                uiOverlay.transform.SetSiblingIndex(childIndex);
                LevelManager.instance.level1_B.transform.SetSiblingIndex(childIndex - 1);
                LevelManager.instance.level1_A.transform.SetSiblingIndex(childIndex - 2);


                break;
            case LevelManager.LevelToBeat.Level1D:
                uiOverlay.transform.SetSiblingIndex(childIndex);
                LevelManager.instance.level1_C.transform.SetSiblingIndex(childIndex - 1);
                LevelManager.instance.level1_B.transform.SetSiblingIndex(childIndex - 2);
                LevelManager.instance.level1_A.transform.SetSiblingIndex(childIndex - 3);



                break;
            case LevelManager.LevelToBeat.Level1E:
                uiOverlay.transform.SetSiblingIndex(childIndex);
                LevelManager.instance.level1_D.transform.SetSiblingIndex(childIndex - 1);
                LevelManager.instance.level1_C.transform.SetSiblingIndex(childIndex - 2);
                LevelManager.instance.level1_B.transform.SetSiblingIndex(childIndex - 3);
                LevelManager.instance.level1_A.transform.SetSiblingIndex(childIndex - 4);


                break;
        }
        
    }

    // Update is called once per frame
    void Update ()
    {
        
    }
}
