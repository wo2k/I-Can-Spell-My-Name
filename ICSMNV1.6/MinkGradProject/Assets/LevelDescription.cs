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

	// Use this for initialization
	void Start () {

        PrepareCompleted(videoFile);

        switch (UIManager.instance.mode)
        {
            case UIManager.subLevels1.Level1A:

                levelName.text = LevelManager.instance.level1A.levelName;
                levelIcon.GetComponent<Image>().sprite = LevelManager.instance.level1A.levelIcon;
                for(int i = 0; i < levelModes.transform.childCount; i++)
                    levelModes.transform.GetChild(i).GetComponent<Image>().sprite = LevelManager.instance.level1A.levelIcon;
                modeText.text = LevelManager.instance.level1A.levelDescription;
                videoFile.clip = LevelManager.instance.level1A.videoFile;
                
                break;
            case UIManager.subLevels1.Level1B:

                levelName.text = LevelManager.instance.level1B.levelName;
                levelIcon.GetComponent<Image>().sprite = LevelManager.instance.level1B.levelIcon;
                for (int i = 0; i < levelModes.transform.childCount; i++)
                    levelModes.transform.GetChild(i).GetComponent<Image>().sprite = LevelManager.instance.level1B.levelIcon;
                modeText.text = LevelManager.instance.level1B.levelDescription;
                videoFile.clip = LevelManager.instance.level1B.videoFile;
                break;
            case UIManager.subLevels1.Level1C:

                levelName.text = LevelManager.instance.level1C.levelName;
                levelIcon.GetComponent<Image>().sprite = LevelManager.instance.level1C.levelIcon;
                for (int i = 0; i < levelModes.transform.childCount; i++)
                    levelModes.transform.GetChild(i).GetComponent<Image>().sprite = LevelManager.instance.level1C.levelIcon;
                modeText.text = LevelManager.instance.level1C.levelDescription;
                videoFile.clip = LevelManager.instance.level1C.videoFile;
                break;
            case UIManager.subLevels1.Level1D:

                levelName.text = LevelManager.instance.level1D.levelName;
                levelIcon.GetComponent<Image>().sprite = LevelManager.instance.level1D.levelIcon;
                for (int i = 0; i < levelModes.transform.childCount; i++)
                    levelModes.transform.GetChild(i).GetComponent<Image>().sprite = LevelManager.instance.level1D.levelIcon;
                modeText.text = LevelManager.instance.level1D.levelDescription;
                videoFile.clip = LevelManager.instance.level1D.videoFile;
                break;
            case UIManager.subLevels1.Level1E:

                levelName.text = LevelManager.instance.level1E.levelName;
                levelIcon.GetComponent<Image>().sprite = LevelManager.instance.level1E.levelIcon;
                for (int i = 0; i < levelModes.transform.childCount; i++)
                    levelModes.transform.GetChild(i).GetComponent<Image>().sprite = LevelManager.instance.level1E.levelIcon;
                modeText.text = LevelManager.instance.level1E.levelDescription;
                videoFile.clip = LevelManager.instance.level1E.videoFile;
                break;
        }
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
    }



    // Update is called once per frame
    void Update () {
		
	}
}
