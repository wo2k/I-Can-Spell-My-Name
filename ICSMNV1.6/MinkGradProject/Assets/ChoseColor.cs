using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoseColor : MonoBehaviour {
	public GameObject GameManager;
	// Use this for initialization
	void Start () {
		
	}

	public void ChoseRed () {
		switch(GameManager.GetComponent<FirstPlayButtons>().LoginNumber){
		case 1:{
				PlayerPrefs.SetInt("firstColor", 1);
				break;
			}
		case 2:
			{
				PlayerPrefs.SetInt ("secondColor", 1);
				break;
			}
		case 3:
			{
				PlayerPrefs.SetInt ("thirdColor", 1);
				break;
			}
		case 4:
			{
				PlayerPrefs.SetInt ("fourthColor", 1);
				break;
			}
		}
	}
	public void ChoseGreen() {
		switch (GameManager.GetComponent<FirstPlayButtons> ().LoginNumber) {
		case 1:
			{
				PlayerPrefs.SetInt ("firstColor", 2);
				break;
			}
		case 2:
			{
				PlayerPrefs.SetInt ("secondColor", 2);
				break;
			}
		case 3:
			{
				PlayerPrefs.SetInt ("thirdColor", 2);
				break;
			}
		case 4:
			{
				PlayerPrefs.SetInt ("fourthColor", 2);
				break;
			}
		}
	}
	public void ChoseOrange () {
		switch(GameManager.GetComponent<FirstPlayButtons>().LoginNumber){
		case 1:{
				PlayerPrefs.SetInt("firstColor", 3);
				break;
			}
		case 2:
			{
				PlayerPrefs.SetInt ("secondColor", 3);
				break;
			}
		case 3:
			{
				PlayerPrefs.SetInt ("thirdColor", 3);
				break;
			}
		case 4:
			{
				PlayerPrefs.SetInt ("fourthColor", 3);
				break;
			}
		}

	}
	public void ChoseBlue () {
		switch (GameManager.GetComponent<FirstPlayButtons> ().LoginNumber) {
		case 1:
			{
				PlayerPrefs.SetInt ("firstColor", 4);
				break;
			}
		case 2:
			{
				PlayerPrefs.SetInt ("secondColor", 4);
				break;
			}
		case 3:
			{
				PlayerPrefs.SetInt ("thirdColor", 4);
				break;
			}
		case 4:
			{
				PlayerPrefs.SetInt ("fourthColor", 4);
				break;
			}
		}
	}
	public void ChosePink() {
		switch (GameManager.GetComponent<FirstPlayButtons> ().LoginNumber) {
		case 1:
			{
				PlayerPrefs.SetInt ("firstColor", 5);
				break;
			}
		case 2:
			{
				PlayerPrefs.SetInt ("secondColor", 5);
				break;
			}
		case 3:
			{
				PlayerPrefs.SetInt ("thirdColor", 5);
				break;
			}
		case 4:
			{
				PlayerPrefs.SetInt ("fourthColor", 5);
				break;
			}
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
