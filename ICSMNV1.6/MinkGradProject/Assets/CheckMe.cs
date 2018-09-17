using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMe : MonoBehaviour {
	public GameObject Check;
	// Use this for initialization
	void Start () {
		
	}
	public void CheckThis (bool AmIChecked) {
		Check.SetActive(AmIChecked);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
