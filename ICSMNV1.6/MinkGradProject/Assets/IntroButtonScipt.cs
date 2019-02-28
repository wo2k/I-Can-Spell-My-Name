using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroButtonScipt : MonoBehaviour {

	public GameObject ThisMessage;
	public GameObject NextMessage;


	// Use this for initialization
	void Start () {
		
	}
	public void OnClick (){
		ThisMessage.SetActive (false);
		NextMessage.SetActive (true);

	}

    public void AbovePreK()
    {
        ThisMessage.SetActive(false);
        NextMessage.SetActive(true);
        LevelManager.instance.abovePreK = true;

    }
    public void LoadLevel()
    {
        SceneManager.LoadScene("MainMenu");
    }
	// Update is called once per frame
	void Update () {
		
	}
}
