using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OnClick : MonoBehaviour {
	public GameObject MenuToGoTo;
	public GameObject CurrentMenu;


	// Use this for initialization
	void Start () {
		
	}
	public void PlayPop(){
		SoundManagement.TriggerEvent ("PlayPop");
	}
	public void CLICKY(){
		SoundManagement.TriggerEvent ("PlayPop");
		MenuToGoTo.SetActive (true);
		CurrentMenu.SetActive(false);
        LevelManager.instance.CheckLevelState(false);
    } 

    public void LoadLevel(string LevelName)
    {
        SoundManagement.TriggerEvent("PlayPop");
        SceneManager.LoadScene(LevelName);
        UIManager.instance.levelName = LevelName;
        
        switch (LevelName)
        {
            case "MainMenu":
                break;
            case "Campaign":
                break;
            case "Level1":
                LevelManager.instance.level1_B = GameObject.Find("Level1Button").GetComponent<Button>();
                LevelManager.instance.level1_C = GameObject.Find("Level2Button").GetComponent<Button>();
                LevelManager.instance.level1_D = GameObject.Find("Level3Button").GetComponent<Button>();
                LevelManager.instance.level1_E = GameObject.Find("Level4Button").GetComponent<Button>();
                LevelManager.instance.lockLevel = LevelManager.instance.InstantiateLock(LevelManager.instance.levelParent.transform);
                LevelManager.instance.CheckLevelState(false);
                break;
            case "Level2":
                LevelManager.instance.CheckLevelState(false);
                break;
            case "Level3":
                LevelManager.instance.CheckLevelState(false);
                break;
        }
    }

    public void GoToGameMode(string GameLevel)
    {
        SoundManagement.TriggerEvent("PlayPop");
        UIManager.instance.levelName = GameLevel;
        SceneManager.LoadScene(GameLevel);
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
		

	// Update is called once per frgaame
	void Update () {
		
	}
}
