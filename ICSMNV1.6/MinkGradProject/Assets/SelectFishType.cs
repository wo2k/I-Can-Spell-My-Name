using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectFishType : MonoBehaviour {
	public List<GameObject> Types;
	public int Index = 0;
	public GameObject GameManager;
	public int color = 0;
	// Use this for initialization
	void Start () {
		SetColor ();
	}
	public void SetColor(){
		switch (GameManager.GetComponent<FirstPlayButtons> ().LoginNumber) {
		case 1:
			{
				color =	PlayerPrefs.GetInt ("firstColor");
				break;
			}
		case 2:
			{
				color = PlayerPrefs.GetInt ("secondColor");
				break;
			}
		case 3:
			{
				color = PlayerPrefs.GetInt ("thirdColor");
				break;
			}
		case 4:
			{
				color = PlayerPrefs.GetInt ("fourthColor");
				break;
			}
		}
		 
		switch (color) {
		case 1:
			{
				for (int i = 0; i < Types.Count; i++)
					Types [i].GetComponent<Image> ().color = Color.red;
				
				break;
			}
		case 2:
			{
				for (int i = 0; i < Types.Count; i++)
					Types [i].GetComponent<Image> ().color = Color.green;
				break;
			}
		case 3:
			{
				for (int i = 0; i < Types.Count; i++)
					Types [i].GetComponent<Image> ().color =  new Color (1.0F, (206.0F / 255.0F), 0, 1);
				break;
			}
		case 4:
			{
				for (int i = 0; i < Types.Count; i++)
					Types [i].GetComponent<Image> ().color = Color.cyan;
				break;
			}
		case 5:
			{
				for (int i = 0; i < Types.Count; i++)
					Types [i].GetComponent<Image> ().color = Color.magenta;
				break;
			}
		}
	
	}
	void TurnSelectedImageOn (int index) {
		for (int i = 0; i < Types.Count; i++)
			Types [i].SetActive (false);

		Types [index].SetActive (true);

	}
	public void RightClick () {
		Index++;

		if (Index >= Types.Count)
			Index = 0;
		TurnSelectedImageOn (Index);

	}
	public void LeftClick () {
		Index--;

		if (Index < 0)
			Index = Types.Count - 1;
		
		TurnSelectedImageOn (Index);

	}
	public void SelectType () {
		SaveType (Index);
	}

	public void SaveType(int index){
		switch(GameManager.GetComponent<FirstPlayButtons>().LoginNumber){
		case 1:{
				PlayerPrefs.SetInt("firstCharacter", index);
				break;
			}
		case 2:
			{
				PlayerPrefs.SetInt ("secondCharacter", index);
				break;
			}
		case 3:
			{
				PlayerPrefs.SetInt ("thirdCharacter", index);
				break;
			}
		case 4:
			{
				PlayerPrefs.SetInt ("fourthCharacter", index);
				break;
			}
		}

	}
	// Update is called once per frame
	void Update () {
		
	}
}
