using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour {
	public int HealthMax = 0;
	public int HealthTotal = 0;
	public int HealthCurrent = 0;
	public List<GameObject> HealthBar;
	// Use this for initialization
	void Start () {
		
	}
	public void SetHealth (int i) {
		HealthMax = i;
		for(int num  = 0; i < HealthBar.Count ; num++)
			HealthBar [num].SetActive (false);


		for(int num  = 0; num < i;  num++)
		{
			HealthBar [num].SetActive (true);
		}
		HealthTotal = i;
	}
	public int LoseHealth () {

		HealthTotal--;

		for(int num  = 0; num < HealthBar.Count ; num++)
			HealthBar [num].SetActive (false);
		
		for(int num  = 0; num < HealthTotal;  num++)
		{
			HealthBar [num].SetActive (true);
		}
		return HealthTotal;
	}
	// Update is called once per frame
	void Update () {
		
	}
}
