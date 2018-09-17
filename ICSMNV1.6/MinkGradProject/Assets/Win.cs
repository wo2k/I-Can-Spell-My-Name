using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour {
	public GameObject endSub;
	// Use this for initialization
	void Start () {
		
	}
	public void WinState(){
		endSub.GetComponent<SetEndSubState> ().WinMessage ();
		endSub.SetActive (true);
	}
	public void LoseState(){
		endSub.GetComponent<SetEndSubState> ().LoseMessage ();
		endSub.SetActive (true);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
