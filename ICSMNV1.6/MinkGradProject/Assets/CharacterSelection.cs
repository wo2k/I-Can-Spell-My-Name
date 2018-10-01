using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour {
	public GameObject Jelly;
	public GameObject Fish;
	public GameObject Star;
	public GameObject Urchin;
	public GameObject Shark;
	public GameObject Whale;
	public GameObject Angel;

	public GameObject Character;

	public GameObject JellyText;
	public GameObject FishText;
	public GameObject StarText;
	public GameObject UrchinText;
	public GameObject SharkText;
	public GameObject WhaleText;
	public GameObject AngelText;
	public GameObject GameManager;
	public int selected = 0;
	public int color = 0;
	public int Variation = 0;
	// Use this for initialization
	void Start () {

        GameManager = FindObjectOfType<LevelManager>().gameObject;

        switch (GameManager.GetComponent<FirstPlayButtons>().LoginNumber){

		case 1:{
				selected = PlayerPrefs.GetInt("firstCharacter");
				color = PlayerPrefs.GetInt("firstColor");
				Variation = PlayerPrefs.GetInt("firstVar");
				break;
			}
		case 2:
			{
				selected = PlayerPrefs.GetInt ("secondCharacter");
				color = PlayerPrefs.GetInt("secondColor");
				Variation = PlayerPrefs.GetInt("secondVar");
				break;
			}
		case 3:
			{
				selected = PlayerPrefs.GetInt ("thirdCharacter");
				color = PlayerPrefs.GetInt("thirdColor");
				Variation = PlayerPrefs.GetInt("thirdVar");
				break;
			}
		case 4:
			{
				selected = PlayerPrefs.GetInt ("fourthCharacter");
				color = PlayerPrefs.GetInt("fourthColor");
				Variation = PlayerPrefs.GetInt("fourthVar");
				break;
			}
		}
		if (selected == 0) {
			SelectFish ();
	
		}
		if (selected == 1)
			SelectJelly ();
		if (selected == 2)
			SelectFish ();
		if (selected == 3)
			SelectStar ();
		if (selected == 4)
			SelectUrchin ();
		if (selected == 5)
			SelectShark();
		if (selected == 6)
			SelectAngel();
		if (selected == 7)
			SelectWhale();
		
		if (color == 0)
			Red ();
		if (color == 1)
			Red ();
		if (color == 2)
			Green ();
		if (color == 3)
			Orange ();
		if (color == 4)
			Blue ();
	}
	public void Red () {
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
		Character.GetComponent<Image> ().color = Color.red;
		Jelly.GetComponent<Image> ().color = Color.red;
		Star.GetComponent<Image> ().color = Color.red;
		Fish.GetComponent<Image> ().color = Color.red;
		Angel.GetComponent<Image> ().color = Color.red;
		Shark.GetComponent<Image> ().color = Color.red;
		Urchin.GetComponent<Image> ().color = Color.red;
		Whale.GetComponent<Image> ().color = Color.red;
		Fish.GetComponent<ColorMe> ().SetColor (Color.red);
		Jelly.GetComponent<ColorMe> ().SetColor (Color.red);
		Star.GetComponent<ColorMe> ().SetColor (Color.red);
		Whale.GetComponent<ColorMe> ().SetColor (Color.red);
		Urchin.GetComponent<ColorMe> ().SetColor (Color.red);
		Shark.GetComponent<ColorMe> ().SetColor (Color.red);
		Angel.GetComponent<ColorMe> ().SetColor (Color.red); 

	}
	public void Green () {
		switch(GameManager.GetComponent<FirstPlayButtons>().LoginNumber){
		case 1:{
				PlayerPrefs.SetInt("firstColor", 2);
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
		Character.GetComponent<Image> ().color = Color.green;
		Jelly.GetComponent<Image> ().color = Color.green;
		Star.GetComponent<Image> ().color = Color.green;
		Fish.GetComponent<Image> ().color = Color.green;
		Angel.GetComponent<Image> ().color = Color.green;
		Shark.GetComponent<Image> ().color = Color.green;
		Urchin.GetComponent<Image> ().color = Color.green;
		Whale.GetComponent<Image> ().color = Color.green;
		Fish.GetComponent<ColorMe> ().SetColor (Color.green);
		Jelly.GetComponent<ColorMe> ().SetColor (Color.green);
		Star.GetComponent<ColorMe> ().SetColor (Color.green);
		Whale.GetComponent<ColorMe> ().SetColor (Color.green);
		Urchin.GetComponent<ColorMe> ().SetColor (Color.green);
		Shark.GetComponent<ColorMe> ().SetColor (Color.green);
		Angel.GetComponent<ColorMe> ().SetColor (Color.green); 

	}
	public void SetVariation (int Var) {
		switch(GameManager.GetComponent<FirstPlayButtons>().LoginNumber){
		case 1:{
				PlayerPrefs.SetInt("firstVar", Var);
				break;
			}
		case 2:
			{

				PlayerPrefs.SetInt("secondVar", Var);
				break;
			}
		case 3:
			{
				
				PlayerPrefs.SetInt("thirdtVar", Var);
				break;
			}
		case 4:
			{
				PlayerPrefs.SetInt ("fourthVar", Var);
				break;
			}
		}
	}
	public void Orange () {
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
		Character.GetComponent<Image> ().color = new Color (1.0F, (206.0F / 255.0F), 0, 1);
		Jelly.GetComponent<Image> ().color = new Color (1.0F, (206.0F / 255.0F), 0, 1);
		Star.GetComponent<Image> ().color =  new Color (1.0F, 206.0F / 255.0F, 0, 1);
		Fish.GetComponent<Image> ().color =  new Color (1.0F, 206.0F / 255.0F, 0, 1);
		Shark.GetComponent<Image> ().color = new Color (1.0F, (206.0F / 255.0F), 0, 1);
		Angel.GetComponent<Image> ().color =  new Color (1.0F, 206.0F / 255.0F, 0, 1);
		Whale.GetComponent<Image> ().color =  new Color (1.0F, 206.0F / 255.0F, 0, 1);
		Urchin.GetComponent<Image> ().color =  new Color (1.0F, 206.0F / 255.0F, 0, 1);
		Color temp = new Color (1.0F, 206.0F / 255.0F, 0, 1);
		Fish.GetComponent<ColorMe> ().SetColor (temp);
		Jelly.GetComponent<ColorMe> ().SetColor (temp);
		Star.GetComponent<ColorMe> ().SetColor (temp);
		Whale.GetComponent<ColorMe> ().SetColor (temp);
		Urchin.GetComponent<ColorMe> ().SetColor (temp);
		Shark.GetComponent<ColorMe> ().SetColor (temp);
		Angel.GetComponent<ColorMe> ().SetColor (temp);
	}
	public void Blue () {
		switch(GameManager.GetComponent<FirstPlayButtons>().LoginNumber){
		case 1:{
				PlayerPrefs.SetInt("firstColor", 4);
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
		Jelly.GetComponent<Image> ().color = Color.cyan;
		Character.GetComponent<Image> ().color = Color.cyan;
		Star.GetComponent<Image> ().color = Color.cyan;
		Fish.GetComponent<Image> ().color = Color.cyan;
		Shark.GetComponent<Image> ().color = Color.cyan;
		Whale.GetComponent<Image> ().color = Color.cyan;
		Angel.GetComponent<Image> ().color = Color.cyan;
		Urchin.GetComponent<Image> ().color = Color.cyan;

		Fish.GetComponent<ColorMe> ().SetColor (Color.cyan);
		Jelly.GetComponent<ColorMe> ().SetColor (Color.cyan);
		Star.GetComponent<ColorMe> ().SetColor (Color.cyan);
		Whale.GetComponent<ColorMe> ().SetColor (Color.cyan);
		Urchin.GetComponent<ColorMe> ().SetColor (Color.cyan);
		Shark.GetComponent<ColorMe> ().SetColor (Color.cyan);
		Angel.GetComponent<ColorMe> ().SetColor (Color.cyan);




	}

    public void SelectFish()
    {
        Fish.GetComponent<ColorMe>().SetUp(Variation);
        switch (GameManager.GetComponent<FirstPlayButtons>().LoginNumber)
        {
            case 1:
                {
                    PlayerPrefs.SetInt("firstCharacter", 1);
                    PlayerPrefs.SetInt("firstVar", Variation);
                    break;
                }
            case 2:
                {
                    PlayerPrefs.SetInt("secondCharacter", 1);
                    PlayerPrefs.SetInt("secondVar", Variation);
                    break;
                }
            case 3:
                {
                    PlayerPrefs.SetInt("thirdCharacter", 1);
                    PlayerPrefs.SetInt("thirdVar", Variation);
                    break;
                }
            case 4:
                {
                    PlayerPrefs.SetInt("fourthCharacter", 1);
                    PlayerPrefs.SetInt("fourthVar", Variation);
                    break;
                }
        }

        JellyText.SetActive(false);
        FishText.SetActive(true);
        StarText.SetActive(false);
        AngelText.SetActive(false);
        SharkText.SetActive(false);
        WhaleText.SetActive(false);
        UrchinText.SetActive(false);
    }

    public void SelectJelly () {
		Jelly.GetComponent<ColorMe> ().SetUp (Variation);
		switch(GameManager.GetComponent<FirstPlayButtons>().LoginNumber){
		case 1:{
				PlayerPrefs.SetInt("firstCharacter", 2);
				PlayerPrefs.SetInt("firstVar", Variation);
				break;
			}
		case 2:
			{
				PlayerPrefs.SetInt ("secondCharacter", 2);
				PlayerPrefs.SetInt("secondVar", Variation);
				break;
			}
		case 3:
			{
				PlayerPrefs.SetInt ("thirdCharacter", 2);
				PlayerPrefs.SetInt("thirdVar", Variation);
				break;
			}
		case 4:
			{
				PlayerPrefs.SetInt ("fourthCharacter", 2);
				PlayerPrefs.SetInt("fourthVar", Variation);
				break;
			}
		}
	
		JellyText.SetActive (true);
		FishText.SetActive (false);
		StarText.SetActive (false);
		AngelText.SetActive (false);
		SharkText.SetActive (false);
		WhaleText.SetActive (false);
		UrchinText.SetActive (false);
	}

	public void SelectStar () {
		Star.GetComponent<ColorMe> ().SetUp (Variation);
	switch(GameManager.GetComponent<FirstPlayButtons>().LoginNumber){
		case 1:{
				PlayerPrefs.SetInt("firstCharacter", 3);
				PlayerPrefs.SetInt("firstVar", Variation);
				break;
			}
		case 2:
			{
				PlayerPrefs.SetInt ("secondCharacter", 3);
				PlayerPrefs.SetInt("secondVar", Variation);
				break;
			}
		case 3:
			{
				PlayerPrefs.SetInt ("thirdCharacter", 3);
				PlayerPrefs.SetInt("thirdVar", Variation);
				break;
			}
		case 4:
			{
				PlayerPrefs.SetInt ("fourthCharacter", 3);
				PlayerPrefs.SetInt("fourthVar", Variation);
				break;
			}
	}

		JellyText.SetActive (false);
		FishText.SetActive (false);
		StarText.SetActive (true);
		AngelText.SetActive (false);
		SharkText.SetActive (false);
		WhaleText.SetActive (false);
		UrchinText.SetActive (false);
}

	public void SelectUrchin () {
		Urchin.GetComponent<ColorMe> ().SetUp (Variation);
		switch(GameManager.GetComponent<FirstPlayButtons>().LoginNumber){
		case 1:{
				PlayerPrefs.SetInt("firstCharacter", 4);
				PlayerPrefs.SetInt("firstVar", Variation);
				break;
			}
		case 2:
			{
				PlayerPrefs.SetInt ("secondCharacter", 4);
				PlayerPrefs.SetInt("secondVar", Variation);
				break;
			}
		case 3:
			{
				PlayerPrefs.SetInt ("thirdCharacter", 4);
				PlayerPrefs.SetInt("thirdVar", Variation);
				break;
			}
		case 4:
			{
				PlayerPrefs.SetInt ("fourthCharacter", 4);
				PlayerPrefs.SetInt("fourthVar", Variation);
				break;
			}
		}

		JellyText.SetActive (false);
		FishText.SetActive (false);
		StarText.SetActive (false);
		AngelText.SetActive (false);
		SharkText.SetActive (false);
		WhaleText.SetActive (false);
		UrchinText.SetActive (true);
	}
	public void SelectShark () {
		Shark.GetComponent<ColorMe> ().SetUp (Variation);
		switch(GameManager.GetComponent<FirstPlayButtons>().LoginNumber){
		case 1:{
				PlayerPrefs.SetInt("firstCharacter", 6);
				PlayerPrefs.SetInt("firstVar", Variation);
				break;
			}
		case 2:
			{
				PlayerPrefs.SetInt ("secondCharacter", 6);
				PlayerPrefs.SetInt("secondVar", Variation);
				break;
			}
		case 3:
			{
				PlayerPrefs.SetInt ("thirdCharacter", 6);
				PlayerPrefs.SetInt("thirdVar", Variation);
				break;
			}
		case 4:
			{
				PlayerPrefs.SetInt ("fourthCharacter", 6);
				PlayerPrefs.SetInt("fourthVar", Variation);
				break;
			}
		}

		JellyText.SetActive (false);
		FishText.SetActive (false);
		StarText.SetActive (false);
		AngelText.SetActive (false);
		SharkText.SetActive (true);
		WhaleText.SetActive (false);
		UrchinText.SetActive (false);
	}
	public void SelectAngel () {
		Angel.GetComponent<ColorMe> ().SetUp (Variation);
		switch(GameManager.GetComponent<FirstPlayButtons>().LoginNumber){
		case 1:{
				PlayerPrefs.SetInt("firstCharacter", 5);
				PlayerPrefs.SetInt("firstVar", Variation);
				break;
			}
		case 2:
			{
				PlayerPrefs.SetInt ("secondCharacter", 5);
				PlayerPrefs.SetInt("secondVar", Variation);
				break;
			}
		case 3:
			{
				PlayerPrefs.SetInt ("thirdCharacter", 5);
				PlayerPrefs.SetInt("thirdVar", Variation);
				break;
			}
		case 4:
			{
				PlayerPrefs.SetInt ("fourthCharacter", 5);
				PlayerPrefs.SetInt("fourthVar", Variation);
				break;
			}
		}

		JellyText.SetActive (false);
		FishText.SetActive (false);
		StarText.SetActive (false);
		AngelText.SetActive (true);
		SharkText.SetActive (false);
		WhaleText.SetActive (false);
		UrchinText.SetActive (false);
	}
	public void SelectWhale () {
		Whale.GetComponent<ColorMe> ().SetUp (Variation);
		switch(GameManager.GetComponent<FirstPlayButtons>().LoginNumber){
		case 1:{
				PlayerPrefs.SetInt("firstCharacter", 7);
				PlayerPrefs.SetInt("firstVar", Variation);
				break;
			}
		case 2:
			{
				PlayerPrefs.SetInt ("secondCharacter", 7);
				PlayerPrefs.SetInt("secondVar", Variation);
				break;
			}
		case 3:
			{
				PlayerPrefs.SetInt ("thirdCharacter", 7);
				PlayerPrefs.SetInt("thirdVar", Variation);
				break;
			}
		case 4:
			{
				PlayerPrefs.SetInt ("fourthCharacter", 7);
				PlayerPrefs.SetInt("fourthVar", Variation);
				break;
			}
		}

		JellyText.SetActive (false);
		FishText.SetActive (false);
		StarText.SetActive (false);
		AngelText.SetActive (false);
		SharkText.SetActive (false);
		WhaleText.SetActive (true);
		UrchinText.SetActive (false);
	}
	public void SetVariation(int VariationToSet,Sprite spriteToSet){
		Character.GetComponent<Image> ().sprite = spriteToSet;
		Variation = VariationToSet;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
