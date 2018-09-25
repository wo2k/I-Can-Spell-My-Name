using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


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
        GameManager.instance.CheckLevelState();
	} 

    public void GoToGameMode()
    {
        SoundManagement.TriggerEvent("PlayPop");
        MenuToGoTo.SetActive(true);
        CurrentMenu.SetActive(false);
        UIManager.instance.inGame = true;
        UIManager.instance.pauseButton.SetActive(true);
        UIManager.instance.levelName = MenuToGoTo;
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
