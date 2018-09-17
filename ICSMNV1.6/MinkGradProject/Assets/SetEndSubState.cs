using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetEndSubState : MonoBehaviour {
	public Text message;
	// Use this for initialization
	void Start () {
		
	}
	public void WinMessage () {
		message.text = "You Win!!!";
	}
	public void LoseMessage () {
		message.text = "Try Again?";
	}
	// Update is called once per frame
	void Update () {
		
	}
}
