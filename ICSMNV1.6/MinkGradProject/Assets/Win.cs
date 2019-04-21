using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour {
	public GameObject endSub;
	// Use this for initialization
	void Start () {
		
	}
	public void WinState(){
        //UIManager.instance.WinGame(System.Enum.GetValues(typeof(UIManager.subLevels2)).Length);
        LevelManager.instance.CheckAnswer(true, UIManager.instance.heartsAmount, UIManager.instance.seahorseAnim, 1, System.Enum.GetValues(typeof(UIManager.subLevels2)).Length);
		//endSub.GetComponent<SetEndSubState> ().WinMessage ();
		//endSub.SetActive (true);
	}
	public void LoseState(){
		endSub.GetComponent<SetEndSubState> ().LoseMessage ();
		endSub.SetActive (true);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
