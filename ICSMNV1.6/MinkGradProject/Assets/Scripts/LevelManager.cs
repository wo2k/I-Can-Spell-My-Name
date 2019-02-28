using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.Video;
//using UnityEditor.SceneManagement;

[System.Serializable]
public class MultiDimensionalArray
{
    [TextArea]
    public string[] levelDescription = { "", "", "", "" };
    public VideoClip[] videoFile = new VideoClip[4];
}

[System.Serializable]
public class LevelSettings
{
    public string levelName;
    [TextArea]
    public string levelIntro;
    [TextArea]
    public string levelOutro;

    [TextArea]
    public string[,] levelDescription = { { "", "", "", "" }, { "", "", "", "" }, { "", "", "", "" }, { "", "", "", "" }, { "", "", "", "" } };
    public Sprite levelIcon;
    public Texture videoTexture;
    public VideoClip videoFile;
    public MultiDimensionalArray[] level = new MultiDimensionalArray[5];
    public float[,] highScore = new float[5,4];
    public int modePassed;
    public Button Easy, Normal, Hard, Genius;
    public List<Button> difficultyBtns = new List<Button>();
    public GameObject levelParent;
    public GameObject lockMode;
    public bool locked = true;
    public bool hasLockedBefore = false;
    public bool[,] hasWonAlready = { { false, false, false, false }, { false, false, false, false }, { false, false, false, false }, { false, false, false, false }, { false, false, false, false } }; //Easy-Hard for Level1A-E

    //Current difficulty Player needs to beat
    public enum DifficultyToBeat { Easy, Normal, Hard, Genius, None, PleaseSelectLevelToView };
    public DifficultyToBeat m_DifficultyToBeat;
}

public class LevelManager : MonoBehaviour
{
    //Main Level
    [Header("Main Level Settings")]
    public Button level1;
    public Button level2;
    public Button level3;
    public GameObject mainLevelParent;
    public GameObject mainLockLevel;
    public bool mainLocked = true;
    public bool mainHasLockedBefore = false;
    [Space]
    //Main Level

    //Sub Levels
    [Header("Sub Level Settings")]
    public Button level1_A, level1_B, level1_C, level1_D, level1_E;
    [SerializeField]
    public LevelSettings level1A;
    public LevelSettings level1B;
    public LevelSettings level1C;
    public LevelSettings level1D;
    public LevelSettings level1E;
    public LevelSettings level1Capture;
    /// <summary>
    /// Utilize to capture level difficulty to beat and place resultant to editor
    /// </summary>
    public LevelSettings levelCaptureEditor;
    public Difficulty m_DifficultyCapture;
    public GameObject levelParent;
    public GameObject lockLevel;
    public int levelPassed, subLevelPassed1;
    public bool locked = true;
    public bool hasLockedBefore = false;
    public bool hasShownStoryAlready = false;
    //Sub Levels 

    //LevelManager Editor Variables
    [HideInInspector]
    public int currentTab;
    [HideInInspector]
    public int mainTBCurrentTab;
    [HideInInspector]
    public int diffCurrentTab;
    [SerializeField]
    [HideInInspector]
    public int containerSize;
    [HideInInspector]
    public string sceneName;
    //LevelManager Editor Variables

#if UNITY_EDITOR
    [SerializeField]
    [HideInInspector]
    public List<SceneAsset> sceneAssets = new List<SceneAsset>();
#endif

    //LevelManager Editor Viewable Settings
    //App Platforms
    public enum AppPlatform { MacOS, Windows, iPhone, Andriod };
    public AppPlatform m_Console;
    //Type of Level in Unity
    public enum LevelType { GameMode, Menus };
    public LevelType m_Mode;
    //Type of difficulty of Level
    public enum Difficulty { Easy, Normal, Hard, Genius, None };
    public Difficulty m_Difficulty;
    //Current Sub Level Player needs to beat
    public enum LevelToBeat { Level1A, Level1B, Level1C, Level1D, Level1E, Level2A, Level2B, Level2C, Level2D, Level2E, Level2F, Level3A, None };
    public LevelToBeat m_LevelToBeat;
    //Current Main Level Player needs to beat
    public enum MainLevelToBeat { Level1, Level2, Level3 };
    public MainLevelToBeat m_MainLevelToBeat;
    //LevelManager Editor Viewable Settings

    string alphabet = "abcdefghijklmnopqrstuvwxyz";
    public int correctAnswerPoints = 0;
    public GameObject toggleVibration;
    public bool abovePreK = false;
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

        for (int i = 0; i < UIManager.instance.hasWonAlready.Length; i++)
            UIManager.instance.hasWonAlready[i] = UIManager.instance.IntToBool(PlayerPrefs.GetInt("HasWonAlready " + i));

        hasLockedBefore = UIManager.instance.IntToBool(PlayerPrefs.GetInt("HasLockedBefore"));
        hasShownStoryAlready = UIManager.instance.IntToBool(PlayerPrefs.GetInt("HasShownStoryAlready"));

        for (int i = 0; i < 5; i++)
        {
            switch (i)
            {
                case 0:
                    level1Capture = level1A;
                    break;
                case 1:
                    level1Capture = level1B;
                    break;
                case 2:
                    level1Capture = level1C;
                    break;
                case 3:
                    level1Capture = level1D;
                    break;
                case 4:
                    level1Capture = level1E;
                    break;
            }
            for(int mode = 0; mode < 4; mode++)
            {
                switch (mode)
                {
                    case 0:
                        m_DifficultyCapture = Difficulty.Easy;
                        break;
                    case 1:
                        m_DifficultyCapture = Difficulty.Normal;
                        break;
                    case 2:
                        m_DifficultyCapture = Difficulty.Hard;
                        break;
                    case 3:
                        m_DifficultyCapture = Difficulty.Genius;
                        break;
                }
                if (PlayerPrefs.HasKey(m_DifficultyCapture + " HighScore " + i))
                    level1Capture.highScore[i,mode] = PlayerPrefs.GetFloat(m_DifficultyCapture + " HighScore " + i);

                if (PlayerPrefs.HasKey(m_DifficultyCapture + " ModePassed " + i))
                    level1Capture.modePassed = PlayerPrefs.GetInt(m_DifficultyCapture + " ModePassed " + i);

                if (PlayerPrefs.HasKey(m_DifficultyCapture + " HasLockedBefore " + i))
                    level1Capture.hasLockedBefore = UIManager.instance.IntToBool(PlayerPrefs.GetInt(m_DifficultyCapture + " HasLockedBefore " + i));

                if (PlayerPrefs.HasKey(m_DifficultyCapture + " HasWonAlready " + i))
                    level1Capture.hasWonAlready[i,mode] = UIManager.instance.IntToBool(PlayerPrefs.GetInt(m_DifficultyCapture + " HasWonAlready " + i));

                if (PlayerPrefs.HasKey(mode + " levelDescription " + i))
                    level1Capture.levelDescription[i, mode] = PlayerPrefs.GetString(mode + " levelDescription " + i);
            }           
        }
    }

    void SavePlayerPrefs()
    {

        for (int i = 0; i < 5; i++)
        {
            switch (i)
            {
                case 0:
                    level1Capture = level1A;
                    break;
                case 1:
                    level1Capture = level1B;
                    break;
                case 2:
                    level1Capture = level1C;
                    break;
                case 3:
                    level1Capture = level1D;
                    break;
                case 4:
                    level1Capture = level1E;
                    break;
            }

            for (int mode = 0; mode < 4; mode++)
            {
                switch (mode)
                {
                    case 0:
                        m_DifficultyCapture = Difficulty.Easy;
                        break;
                    case 1:
                        m_DifficultyCapture = Difficulty.Normal;
                        break;
                    case 2:
                        m_DifficultyCapture = Difficulty.Hard;
                        break;
                    case 3:
                        m_DifficultyCapture = Difficulty.Genius;
                        break;
                }
                if (PlayerPrefs.HasKey(m_DifficultyCapture + " HighScore " + i))
                    PlayerPrefs.SetFloat(m_DifficultyCapture + " HighScore " + i, level1Capture.highScore[i,mode]);

                if (PlayerPrefs.HasKey(m_DifficultyCapture + " ModePassed " + i))
                    PlayerPrefs.SetInt(m_DifficultyCapture + " ModePassed " + i, level1Capture.modePassed);

                if (PlayerPrefs.HasKey(m_DifficultyCapture + " HasLockedBefore " + i))
                    PlayerPrefs.SetInt(m_DifficultyCapture + " HasLockedBefore " + i, UIManager.instance.BoolToInt(level1Capture.hasLockedBefore));

                if (PlayerPrefs.HasKey(m_DifficultyCapture + " HasWonAlready " + i))
                    PlayerPrefs.SetInt(m_DifficultyCapture + " HasWonAlready " + i, UIManager.instance.BoolToInt(level1Capture.hasWonAlready[i,mode]));
            }              
        }

        if(PlayerPrefs.HasKey("SubLevelPassed")) PlayerPrefs.SetInt("SubLevelPassed", subLevelPassed1);
        if (PlayerPrefs.HasKey("LevelPassed")) PlayerPrefs.SetInt("LevelPassed", levelPassed);
        for (int i = 0; i < UIManager.instance.hasWonAlready.Length; i++)
            if (PlayerPrefs.HasKey("HasWonAlready " + i)) PlayerPrefs.SetInt("HasWonAlready " + i, UIManager.instance.BoolToInt(UIManager.instance.hasWonAlready[i]));
        if (PlayerPrefs.HasKey("HasLockedBefore")) PlayerPrefs.SetInt("HasLockedBefore", UIManager.instance.BoolToInt(hasLockedBefore));
        if (PlayerPrefs.HasKey("HasShownStoryAlready")) PlayerPrefs.SetInt("HasShownStoryAlready", UIManager.instance.BoolToInt(hasShownStoryAlready));

        PlayerPrefs.Save();
    }

    void ResetPlayerPrefs()
    {
        subLevelPassed1 = 0; 
        levelPassed = 0; 

        for (int i = 0; i < UIManager.instance.hasWonAlready.Length; i++)
            UIManager.instance.hasWonAlready[i] = false;            

        hasLockedBefore = false;
        hasShownStoryAlready = false;

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

        for (int i = 0; i < 5; i++)
        {
            switch (i)
            {
                case 0:
                    level1Capture = level1A;
                    break;
                case 1:
                    level1Capture = level1B;
                    break;
                case 2:
                    level1Capture = level1C;
                    break;
                case 3:
                    level1Capture = level1D;
                    break;
                case 4:
                    level1Capture = level1E;
                    break;
            }
            level1Capture.modePassed = 0;
            level1Capture.hasLockedBefore = false;

            for (int mode = 0; mode < 4; mode++)
            {
                level1Capture.highScore[i, mode] = 0;
                level1Capture.hasWonAlready[i,mode] = false;
            }           
        }

        SavePlayerPrefs();
    }

    public void SetNewHighScore(UIManager.subLevels1 level, Difficulty levelDifficulty)
    {
        for (int i = 0; i < 5; i++)
        {
           if(level == (UIManager.subLevels1)i)
            {
                switch (i)
                {
                    case 0:
                        level1Capture = level1A;
                        break;
                    case 1:
                        level1Capture = level1B;
                        break;
                    case 2:
                        level1Capture = level1C;
                        break;
                    case 3:
                        level1Capture = level1D;
                        break;
                    case 4:
                        level1Capture = level1E;
                        break;
                }
                for (int mode = 0; mode < 4; mode++)
                {
                   if(levelDifficulty == (Difficulty)mode)
                    {
                        if (UIManager.instance.score > level1Capture.highScore[i, mode])
                        {
                            level1Capture.highScore[i, mode] = UIManager.instance.score;
                            PlayerPrefs.SetFloat(levelDifficulty + " HighScore " + i, level1Capture.highScore[i, mode]);
                        }
                    }
                }
            }
        }
    }

    public void GetHighScore(UIManager.subLevels1 level, Difficulty levelDifficulty, Text highscore)
    {
        for (int i = 0; i < 5; i++)
        {
            if (level == (UIManager.subLevels1)i)
            {
                switch (i)
                {
                    case 0:
                        level1Capture = level1A;
                        break;
                    case 1:
                        level1Capture = level1B;
                        break;
                    case 2:
                        level1Capture = level1C;
                        break;
                    case 3:
                        level1Capture = level1D;
                        break;
                    case 4:
                        level1Capture = level1E;
                        break;
                }
                for (int mode = 0; mode < 4; mode++)
                {
                    if (levelDifficulty == (Difficulty)mode)
                    {
                        level1Capture.highScore[i, mode] = PlayerPrefs.GetFloat(levelDifficulty + " HighScore " + i);
                        highscore.text = level1Capture.highScore[i, mode].ToString();
                    }         
                }                            
            }
        }
    }

    void Start()
    {
        LoadPlayerPrefs();
        m_Difficulty = Difficulty.Easy;

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

    public void SetIconOpacity(Button levelBtn, float alpha, bool interactable)
    {
        levelBtn.interactable = interactable;

        foreach (Image item in levelBtn.GetComponentsInChildren<Image>())
            item.color = new Color(item.color.r, item.color.g, item.color.b, alpha);

        Color txtColor = levelBtn.GetComponentInChildren<Text>().color;
        levelBtn.GetComponentInChildren<Text>().color = new Color(txtColor.r, txtColor.g, txtColor.b, alpha);
    }

    public void SetIconOpacity(List<Button> levelBtns, float alpha, bool interactable)
    {
        for (int i = 0; i < levelBtns.Count; i++)
        {
            levelBtns[i].interactable = interactable;

            foreach (Image item in levelBtns[i].GetComponentsInChildren<Image>())
                item.color = new Color(item.color.r, item.color.g, item.color.b, alpha);

            Color txtColor = levelBtns[i].GetComponentInChildren<Text>().color;
            levelBtns[i].GetComponentInChildren<Text>().color = new Color(txtColor.r, txtColor.g, txtColor.b, alpha);
        }
    }

    #region Set Level State
    public void CheckLevelState(bool disableLevelBtns)
    {
        switch (UIManager.instance.levelName)
        {
            case "Campaign":
                switch (levelPassed)
                {
                    case 0:
                        SetIconOpacity(level1, 1f, true);

                        if (disableLevelBtns)
                        {
                            SetIconOpacity(level2, 0.5f, false);
                            SetIconOpacity(level3, 0.5f, false);
                        }

                        break;
                    case 1:
                        SetIconOpacity(level1, 1f, true);
                        SetIconOpacity(level2, 1f, true);

                        if (disableLevelBtns)
                            SetIconOpacity(level3, 0.5f, false);

                        break;
                    case 2:
                        SetIconOpacity(level1, 1f, true);
                        SetIconOpacity(level2, 1f, true);
                        SetIconOpacity(level3, 1f, true);
                        break;
                }
                break;

            case "Level1":
                switch (subLevelPassed1)
                {
                    case 1: //Lock B
                        SetIconOpacity(level1_B, 1f, true);
                        //locked = false;

                        if (lockLevel)
                            lockLevel.GetComponent<Animator>().enabled = true;

                        if (disableLevelBtns)
                        {
                            SetIconOpacity(level1_C, 0.5f, false);
                            SetIconOpacity(level1_D, 0.5f, false);
                            SetIconOpacity(level1_E, 0.5f, false);
                        }

                        break;
                    case 2: //Lock C
                        SetIconOpacity(level1_B, 1f, true);
                        SetIconOpacity(level1_C, 1f, true);

                        if (lockLevel)
                            lockLevel.GetComponent<Animator>().enabled = true;

                        if (disableLevelBtns)
                        {
                            SetIconOpacity(level1_D, 0.5f, false);
                            SetIconOpacity(level1_E, 0.5f, false);
                        }

                        break;
                    case 3: //Lock D
                        SetIconOpacity(level1_B, 1f, true);
                        SetIconOpacity(level1_C, 1f, true);
                        SetIconOpacity(level1_D, 1f, true);

                        if (lockLevel)
                            lockLevel.GetComponent<Animator>().enabled = true;

                        if (disableLevelBtns)
                            SetIconOpacity(level1_E, 0.5f, false);

                        break;
                    case 4: //Lock E
                        SetIconOpacity(level1_B, 1f, true);
                        SetIconOpacity(level1_C, 1f, true);
                        SetIconOpacity(level1_D, 1f, true);
                        SetIconOpacity(level1_E, 1f, true);

                        if (lockLevel)
                            lockLevel.GetComponent<Animator>().enabled = true;
                        break;
                }
                break;

            case "LevelDescription":
                for (int i = 0; i < 5; i++)
                {
                    if (UIManager.instance.mode == (UIManager.subLevels1)i)
                    {
                        switch (i)
                        {
                            case 0:
                                level1Capture = level1A;
                                break;
                            case 1:
                                level1Capture = level1B;
                                break;
                            case 2:
                                level1Capture = level1C;
                                break;
                            case 3:
                                level1Capture = level1D;
                                break;
                            case 4:
                                level1Capture = level1E;
                                break;
                        }
                        switch (level1Capture.modePassed)
                        {
                            case 1://Normal
                                level1Capture.Easy.interactable = true;
                                level1Capture.Normal.interactable = true;

                                if (level1Capture.lockMode)
                                    level1Capture.lockMode.GetComponent<Animator>().enabled = true;

                                if (disableLevelBtns)
                                {
                                    level1Capture.Hard.interactable = false;
                                    level1Capture.Genius.interactable = false;
                                }

                                break;

                            case 2://Hard
                                level1Capture.Easy.interactable = true;
                                level1Capture.Normal.interactable = true;
                                level1Capture.Hard.interactable = true;

                                if (level1Capture.lockMode)
                                    level1Capture.lockMode.GetComponent<Animator>().enabled = true;

                                if (disableLevelBtns)
                                    level1Capture.Genius.interactable = false;
                                break;

                            case 3://Genius
                                level1Capture.Easy.interactable = true;
                                level1Capture.Normal.interactable = true;
                                level1Capture.Hard.interactable = true;
                                level1Capture.Genius.interactable = true;

                                if (level1Capture.lockMode)
                                    level1Capture.lockMode.GetComponent<Animator>().enabled = true;
                                break;
                        }
                    }
                }
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
        for (int i = 0; i < 5; i++)
        {
            switch (i)
            {
                case 0:
                    level1Capture = level1A;
                    break;
                case 1:
                    level1Capture = level1B;
                    break;
                case 2:
                    level1Capture = level1C;
                    break;
                case 3:
                    level1Capture = level1D;
                    break;
                case 4:
                    level1Capture = level1E;
                    break;
            }
            for (int mode = 0; mode < 4; mode++)
            {
                switch (mode)
                {
                    case 0:
                        m_DifficultyCapture = Difficulty.Easy;
                        break;
                    case 1:
                        m_DifficultyCapture = Difficulty.Normal;
                        break;
                    case 2:
                        m_DifficultyCapture = Difficulty.Hard;
                        break;
                    case 3:
                        m_DifficultyCapture = Difficulty.Genius;
                        break;
                }
                level1Capture.modePassed = 0; PlayerPrefs.SetInt(m_DifficultyCapture + " ModePassed " + i, level1Capture.modePassed);
                level1Capture.hasLockedBefore = false; PlayerPrefs.SetInt(m_DifficultyCapture + " HasLockedBefore " + i, UIManager.instance.BoolToInt(level1Capture.hasLockedBefore));
                level1Capture.hasWonAlready[i,mode] = false; PlayerPrefs.SetInt(m_DifficultyCapture + " HasWonAlready " + i, UIManager.instance.BoolToInt(level1Capture.hasWonAlready[i,mode]));
                level1Capture.locked = true;
                level1Capture.highScore[i, mode] = 0;
                if (PlayerPrefs.HasKey(m_DifficultyCapture + " HighScore " + i))
                    PlayerPrefs.SetFloat(m_DifficultyCapture + " HighScore " + i, level1Capture.highScore[i, mode]);
            }                
        }

        subLevelPassed1 = 0; PlayerPrefs.SetInt("SubLevelPassed", subLevelPassed1);
        levelPassed = 0; PlayerPrefs.SetInt("LevelPassed", levelPassed);
        for (int i = 0; i < UIManager.instance.hasWonAlready.Length; i++)
        {
            UIManager.instance.hasWonAlready[i] = false;
            PlayerPrefs.SetInt("HasWonAlready " + i, UIManager.instance.BoolToInt(UIManager.instance.hasWonAlready[i]));
        }
        hasLockedBefore = false; PlayerPrefs.SetInt("HasLockedBefore", UIManager.instance.BoolToInt(hasLockedBefore));
        hasShownStoryAlready = false; PlayerPrefs.SetInt("HasShownStoryAlready", UIManager.instance.BoolToInt(hasShownStoryAlready));

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

        if (UIManager.instance.levelName == "LevelDescription")
            _Lock.transform.localScale = new Vector3(_Lock.transform.localScale.x/2, _Lock.transform.localScale.y/2);

        return _Lock;
    }

    public string ShuffleCharInName(string name)
    {
        int charIndex = Random.Range(0, name.Length);       
        int letter = Random.Range(0, alphabet.Length);  
        name = name.Remove(charIndex, 1);
        int activate = Random.Range(0, 2);

        if (activate == 0)
          name = name.Insert(charIndex, alphabet[letter].ToString());

        return name;
    }

#if UNITY_IOS || UNITY_ANDROID
    public void VibrateOnHandHeld()
    {
        if (Application.isMobilePlatform && toggleVibration.GetComponent<Toggle>().isOn)
            Handheld.Vibrate();
        else
            return;
    }
#endif

    #region CheckAnswer
    public void CheckAnswer(bool isCorrect, int heartsQty)
    {
        if (isCorrect)
        {
            SoundManagement.TriggerEvent("PlayCorrect");
            correctAnswerPoints++;

            if (correctAnswerPoints >= 3)
                UIManager.instance.WinGame();

            else
                UIManager.instance.InstantiateBubble(isCorrect);
        }

        else
        {
            SoundManagement.TriggerEvent("PlayWrongAnswer");

#if UNITY_IOS || UNITY_ANDROID
            VibrateOnHandHeld();
#endif
            heartsQty--;
            UIManager.instance.hearts[heartsQty].GetComponent<Animation>().Play("HealthShake");
            if (heartsQty <= 0)
                UIManager.instance.GameOver();
            else
                UIManager.instance.InstantiateBubble(isCorrect);
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
            else
                UIManager.instance.InstantiateBubble(true);
        }

        else
        {
            SoundManagement.TriggerEvent("PlayWrongAnswer");

#if UNITY_IOS || UNITY_ANDROID
            VibrateOnHandHeld();
#endif
            heartsQty--;
            UIManager.instance.hearts[heartsQty].GetComponent<Animation>().Play("HealthShake");
            if (heartsQty <= 0)
                UIManager.instance.GameOver();
            else
               UIManager.instance.InstantiateBubble(false);
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
            else
                UIManager.instance.InstantiateBubble(isCorrect);
        }

        else
        {
            SoundManagement.TriggerEvent("PlayWrongAnswer");

#if UNITY_IOS || UNITY_ANDROID
            VibrateOnHandHeld();
#endif
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
            else
              UIManager.instance.InstantiateBubble(isCorrect);
        }

        else
        {
            SoundManagement.TriggerEvent("PlayWrongAnswer");

#if UNITY_IOS || UNITY_ANDROID
            VibrateOnHandHeld();
#endif
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
            else
                UIManager.instance.InstantiateBubble(isCorrect);
        }

        else
        {
            SoundManagement.TriggerEvent("PlayWrongAnswer");

#if UNITY_IOS || UNITY_ANDROID
            VibrateOnHandHeld();
#endif
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

#if UNITY_IOS || UNITY_ANDROID
                VibrateOnHandHeld();
#endif

            }
        }
    }
#endregion CheckAnswer


}

