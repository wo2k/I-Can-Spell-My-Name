using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
	// Update is called once per frame
	void Update () {
		
	}
}
