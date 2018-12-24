using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class LevelDescription : MonoBehaviour {

    public Text modeText;
    public GameObject levelModes;
    public GameObject levelIcon;
    public Text levelName;
    public VideoPlayer videoFile;
    public Text highscore;

	// Use this for initialization
	void Start () {

        PrepareCompleted(videoFile);
        SetDifficulty("Easy");
    }

    void PrepareCompleted(VideoPlayer vp)
    {
            vp.Play();
    }

    public void SetDifficulty(string mode)
    {
        switch (mode)
        {
            case "Easy":
                LevelManager.instance.m_Difficulty = LevelManager.Difficulty.Easy;
                break;
            case "Normal":
                LevelManager.instance.m_Difficulty = LevelManager.Difficulty.Normal;
                break;
            case "Hard":
                LevelManager.instance.m_Difficulty = LevelManager.Difficulty.Hard;
                break;
            case "Genius":
                LevelManager.instance.m_Difficulty = LevelManager.Difficulty.Genius;
                break;
        }

        for (int i = 0; i < System.Enum.GetValues(typeof(UIManager.subLevels1)).Length; i++)
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

                levelName.text = LevelManager.instance.level1Capture.levelName;
                levelIcon.GetComponent<Image>().sprite = LevelManager.instance.level1Capture.levelIcon;

                for (int j = 0; j < levelModes.transform.childCount; j++)
                    levelModes.transform.GetChild(j).GetComponent<Image>().sprite = LevelManager.instance.level1Capture.levelIcon;
              

                for (int modes = 0; modes < System.Enum.GetValues(typeof(LevelManager.Difficulty)).Length; modes++)
                {
                    if (LevelManager.instance.m_Difficulty == (LevelManager.Difficulty)modes)
                    {
                        LevelManager.instance.GetHighScore(UIManager.instance.mode, LevelManager.instance.m_Difficulty, highscore);
                        modeText.text = LevelManager.instance.level1Capture.level[i].levelDescription[modes].ToString();

                        videoFile.clip = LevelManager.instance.level1Capture.level[i].videoFile[modes];
                    }
                }
            }
        }


    }

}
