using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour {
	public int HealthMax = 0;
	public int HealthTotal = 0;
	public int HealthCurrent = 0;
	public Slider HealthBar;
	// Use this for initialization
	void Start () {
		
	}
	public void SetHealth (int i) {
		HealthMax = i;
		HealthBar
		HealthTotal = i;
	}
	public int LoseHealth () {

		HealthTotal--;


		return HealthTotal;
	}
	// Update is called once per frame
	void Update () {
		
	}
}
