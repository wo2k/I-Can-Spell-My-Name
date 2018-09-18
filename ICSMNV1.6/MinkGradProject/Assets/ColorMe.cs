using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ColorMe : MonoBehaviour {
	public List<GameObject> Choices;
	public CharacterSelection Controller;

	// Use this for initialization
	void Start () {
		
	}
	public void SetUp(int index){
		switch (index) {
		case 0:
			{
				SetVar1 ();
				break;
			}
		case 1:
			{
				SetVar2 ();
				break;
			}
		case 2:
			{
				SetVar3 ();
				break;
			}
		case 3:
			{
				SetVar4 ();
				break;
			}
		case 4:
			{
				SetVar5 ();
				break;
			}
		case 5:
			{
				SetVar6 ();
				break;
			}
	
		}

	}
	public void SetColor(Color color){
		for(int i = 0; i < Choices.Count;i++){
			Choices [i].GetComponent<Image> ().color = color;
		}
	}
	public void SetVar1(){
		for(int i = 0; i < Choices.Count;i++){
			Choices [i].GetComponent<CheckMe> ().CheckThis (false);
		}
		Choices [0].GetComponent<CheckMe> ().CheckThis (true);
		Controller.SetVariation(1,Choices[0].GetComponent<Image>().sprite);
		Controller.SetVariation (1);
	}
	public void SetVar2(){
		for(int i = 0; i < Choices.Count;i++){
			Choices [i].GetComponent<CheckMe> ().CheckThis (false);
		}
		Choices [1].GetComponent<CheckMe> ().CheckThis (true);
		Controller.SetVariation(2,Choices[1].GetComponent<Image>().sprite);
		Controller.SetVariation (2);
	}

	public void SetVar3(){
		for(int i = 0; i < Choices.Count;i++){
			Choices [i].GetComponent<CheckMe> ().CheckThis (false);
		}
		Choices [2].GetComponent<CheckMe> ().CheckThis (true);
		Controller.SetVariation(3,Choices[2].GetComponent<Image>().sprite);
		Controller.SetVariation (3);

	}

	public void SetVar4(){
		for(int i = 0; i < Choices.Count;i++){
			Choices [i].GetComponent<CheckMe> ().CheckThis (false);
		}
		Choices [3].GetComponent<CheckMe> ().CheckThis (true);
		Controller.SetVariation(4,Choices[3].GetComponent<Image>().sprite);
		Controller.SetVariation (4);

	}

	public void SetVar5(){
		for(int i = 0; i < Choices.Count;i++){
			Choices [i].GetComponent<CheckMe> ().CheckThis (false);
		}
		Choices [4].GetComponent<CheckMe> ().CheckThis (true);
		Controller.SetVariation(5,Choices[4].GetComponent<Image>().sprite);
		Controller.SetVariation (5);

	}
	public void SetVar6(){
		for(int i = 0; i < Choices.Count;i++){
			Choices [i].GetComponent<CheckMe> ().CheckThis (false);
		}
		Choices [5].GetComponent<CheckMe> ().CheckThis (true);
		Controller.SetVariation(6,Choices[5].GetComponent<Image>().sprite);
		Controller.SetVariation (6);

	}


	// Update is called once per frame
	void Update () {
		
	}
}
