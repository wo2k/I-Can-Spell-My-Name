﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestCheck : MonoBehaviour {
	public List<GameObject> Chests;
	public GameObject Keyboard;
	// Use this for initialization
	public bool FadeOn = false;
	public float FadeTime;
	public bool Playing = false;
	void Start () {
	}
	public void ResetAll() {
		for (int i = 0; i < Chests.Count; i++)
			Chests [i].SetActive (true);
	}
	public void Turnoff(int index) {
		Chests [index].SetActive (false);
		Keyboard.GetComponent<Keyboard> ().answerString = "";
		int count =	Keyboard.GetComponent<Keyboard> ().LetterBlocks.Count;
		for (int i = 0; i < count; i++)
			Keyboard.GetComponent<Keyboard> ().LetterBlocks [i].GetComponent<LetterPlacement> ().RemoveLetter ();
		Keyboard.GetComponent<Keyboard> ().RaceCount = 0;
		Keyboard.GetComponent<Keyboard> ().Home = false;
		Keyboard.GetComponent<Keyboard> ().MoveFoward = false;
		Case_Control.index = 0;
		if (Keyboard.GetComponent<Keyboard> ().CapsLock != true)
			Keyboard.GetComponent<Keyboard> ().Shift ();

		if (index == Keyboard.GetComponent<Keyboard> ().chestwin) {
			Keyboard.GetComponent<Keyboard> ().wintreasue = true;
		} else {
			FadeOn = true;
		}

	}

	// Update is called once per frame
	void Update () {

	
		float time = 2.0f;
		if (FadeOn == true) {
			FadeScript.instance.Fade (true, time);
			FadeOn = false;
			Playing = true;
		}

		if(Playing)
		FadeTime += Time.deltaTime;
		
		if (FadeTime > time) {
			Playing = false;
			FadeTime = 0;
			FadeScript.instance.Fade(false,time);
			Keyboard.GetComponent<Keyboard> ().TurnOffChestPanel ();
		}
	}
}
