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
