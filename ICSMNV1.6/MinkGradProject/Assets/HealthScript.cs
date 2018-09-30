using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthScript : MonoBehaviour {
	public float HealthMax = 0;
	public float HealthTotal = 0;
	public int HealthCurrent = 0;
	public GameObject HealthBar;
	// Use this for initialization
	void Start () {
		
	}
	public void SetHealth (float i) {
		HealthMax = (float) i;
        HealthBar.GetComponent<Slider>().value = 1;
		HealthTotal = (float) i;
	}
	public int LoseHealth () {

		HealthTotal--;
        HealthBar.GetComponent<Slider>().value = HealthTotal /HealthMax;
		return (int) HealthTotal;
		}
	// Update is called once per frame
	void Update () {
		
	}
}
