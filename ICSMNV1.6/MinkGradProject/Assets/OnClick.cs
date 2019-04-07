using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OnClick : MonoBehaviour {
	public GameObject MenuToGoTo;
	public GameObject CurrentMenu;
    public Animator anim;
    [HideInInspector]
    public string level;
    public bool isBackButton;
    // Use this for initialization
    void Start () {
		
	}
	public void PlayPop(){
		SoundManagement.TriggerEvent ("PlayPop");
	}
	public void CLICKY(){

		SoundManagement.TriggerEvent ("PlayPop");

        if (!LevelManager.instance.abovePreK)
            SceneManager.LoadScene("MainMenu");
            // MenuToGoTo.SetActive(true);
        else
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
            LevelManager.instance.correctAnswerPoints = 0;
            UIManager.instance.HUD.SetActive(false);
            UIManager.instance.HUD.transform.GetChild(1).gameObject.SetActive(true);
        }
		CurrentMenu.SetActive(false);
        LevelManager.instance.CheckLevelState(false);
    } 

    public void LoadLevel(string LevelName)
    {
        SoundManagement.TriggerEvent("PlayPop");
        SceneManager.LoadScene(LevelName);
        UIManager.instance.levelName = LevelName;

        if(isBackButton)
        {
            UIManager.instance.mode = UIManager.subLevels1.None;
            UIManager.instance.mode2 = UIManager.subLevels2.None;
            LevelManager.instance.levelCaptureEditor.m_DifficultyToBeat = LevelSettings.DifficultyToBeat.PleaseSelectLevelToView;
            LevelManager.instance.m_Difficulty = LevelManager.Difficulty.None;
        }
    }

    public void GoToGameMode()
    {
        string GameLevel;
        switch (UIManager.instance.mode)
        {
            case UIManager.subLevels1.Level1A:
                GameLevel = "Level1A";
                UIManager.instance.levelName = GameLevel;
                SceneManager.LoadScene(GameLevel);
                break;
            case UIManager.subLevels1.Level1B:
                GameLevel = "Level1B";
                UIManager.instance.levelName = GameLevel;
                SceneManager.LoadScene(GameLevel);
                break;
            case UIManager.subLevels1.Level1C:
                GameLevel = "Level1C";
                UIManager.instance.levelName = GameLevel;
                SceneManager.LoadScene(GameLevel);
                break;
            case UIManager.subLevels1.Level1D:
                GameLevel = "Level1D";
                UIManager.instance.levelName = GameLevel;
                SceneManager.LoadScene(GameLevel);
                break;
            case UIManager.subLevels1.Level1E:
                GameLevel = "Level1E";
                UIManager.instance.levelName = GameLevel;
                SceneManager.LoadScene(GameLevel);
                break;
        }
        SoundManagement.TriggerEvent("PlayPop");
        UIManager.instance.inGame = true;
        UIManager.instance.pauseButton.SetActive(true);      
        if (UIManager.instance.heartsAmount <= 0)
            UIManager.instance.heartsAmount = 3;
    }


	public void PlayLevelA1Music(){
		SoundManagement.TriggerEvent ("PlayLevel1A");
	
	}
	public void PlayLevelB1Music(){
		SoundManagement.TriggerEvent ("PlayLevel1B");

	}
	public void PlayLevel2Music(){
		SoundManagement.TriggerEvent ("PlayLevel2");

	}
	public void PlayLevel3Music(){
		SoundManagement.TriggerEvent ("PlayLevel3");

	}
		
    public void PlaySeaHorseAnim(string LevelName)
    {
        level = LevelName;
        anim.SetTrigger("Wink");
        anim.SetTrigger("Idle");
        StartCoroutine(LoadAfterAnim());
    }

    public IEnumerator LoadAfterAnim()
    {
        yield return new WaitForSeconds(anim.GetCurrentAnimatorClipInfo(0).Length);
        SoundManagement.TriggerEvent("PlayPop");
        SceneManager.LoadScene(level);
        UIManager.instance.levelName = level;
    }

	// Update is called once per frgaame
	void Update () {
		
	}
}
