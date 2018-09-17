using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letters : MonoBehaviour {
	public List<GameObject> letter;
	// Use this for initialization

	void Start () {
		
	}
	public void SetLetters (int index) {
		for(int i = 0; i < letter.Count; i++)
		{
			if (i < index)
				letter [i].SetActive (true);
				else
				letter [i].SetActive (false);
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
