using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceBlock : MonoBehaviour {
	public string PlayersName;
	public int Count;
	public GameObject GameManager;
	public List<GameObject> LetterBlocks;
	public List<GameObject> AnswerBlocks;
	public List<int>ChosenIndex;
	public GameObject Answers;

	// Use this for initialization
	public List<char> UpperCasesChar;
	public List<Image> UpperCasesImage;

	public List<char> LowerCasesChar;
	public List<Image> LowerCasesImage;
    public bool isUpper = false;
    public Image letterImage;

    public void Miss () {
	}
	void Start () {
		switch(FindObjectOfType<FirstPlayButtons>().LoginNumber){
		case 1:{
				PlayersName = PlayerPrefs.GetString ("firstName");

				break;
			}
		case 2:
			{
				PlayersName = PlayerPrefs.GetString ("secondName");
				break;
			}
		case 3:
			{

				PlayersName = PlayerPrefs.GetString ("thirdName");

				break;
			}
		case 4:
			{
				PlayersName = PlayerPrefs.GetString ("fourthName");
				break;
			}
		}
		SetUpName ();
		FillRest ();
	}
	public void FillRest(){
		for (int i = 0; i < 25; i++) {
			int caps = Random.Range (0, 2);
			bool Used = false;
			for (int j = 0; j < ChosenIndex.Count; j++) 
			{
				if (i == ChosenIndex [j]) {
					Used = true;
					break;
				}
			}

			if (Used == false) 
			{
				int letter = 0;
				bool NotInName = true;
				if (caps == 0) {
					
				while(NotInName) 
					{
						letter = Random.Range (0, 26);
						char[] name = PlayersName.ToCharArray();
						for (int j = 0; j < PlayersName.Length; j++) 
						{
							if ( UpperCasesChar[letter] == name[j]) {
								NotInName = true;
								break;
							}
							NotInName = false;
						}
					}
					PlaceLetter (i, UpperCasesChar[letter], -1);

				} else {
					while(NotInName) 
					{
					letter = Random.Range (0, 26);
						char[] name = PlayersName.ToCharArray();
					for (int j = 0; j < PlayersName.Length; j++) 
					{
						if ( LowerCasesChar[letter] == name[j]) {
							NotInName = true;
							break;
						}
						NotInName = false;
					}
				}
					PlaceLetter (i, LowerCasesChar[letter], -1);
				}
			}
		}
	}
	public void SetUpName(){
		ChosenIndex.Clear ();

		for (int i = 0; i < PlayersName.Length; i++) 
		{
			bool Used = true;
			int random = Random.Range (0, 25);

			if (i == 0) 
				{
					ChosenIndex.Add (random);
				} 
			else 
			{
				while (Used) 
				{
					random = Random.Range (0, 25);
					for (int j = 0; j < ChosenIndex.Count; j++) 
					{
						if (random == ChosenIndex [j]) {
							Used = true;
							break;
						}
						Used = false;
					}
				}
				ChosenIndex.Add (random);
			}
		}

		int Num_Boxes = PlayersName.Length;
		Answers.GetComponent<Letters> ().SetLetters (Num_Boxes);
		AnswerBlocks = Answers.GetComponent<Letters> ().letter;
		char[] name = PlayersName.ToCharArray ();
		for (int i = 0; i < ChosenIndex.Count; i++) {
			PlaceLetter (ChosenIndex [i], name [i], i);
		}



	}
	public void PlaceLetter(int index,char letter, int placement){

        

		if (letter == 'a') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
            letterImage = LowerCasesImage[0];
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().lower = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().lower = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().Lower = letterImage.gameObject;
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().SetLetter(letterImage);
            return;
		}
		if (letter == 'A') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
            letterImage = UpperCasesImage[0];  
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().upper = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().upper = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().Upper = letterImage.gameObject;
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().SetLetter(letterImage);
            return;
		}
		if (letter == 'b') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
            letterImage = LowerCasesImage[1]; 
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().lower = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().lower = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().Lower = letterImage.gameObject;
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().SetLetter(letterImage);
            return;
		}
		if (letter == 'B') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
            letterImage = UpperCasesImage[1]; 
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().upper = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().upper = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().Upper = letterImage.gameObject;
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().SetLetter(letterImage);
            return;
		}
		if (letter == 'c') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
            letterImage = LowerCasesImage[2]; 
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().lower = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().lower = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().Lower = letterImage.gameObject;
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().SetLetter(letterImage);
            return;
		}
		if (letter == 'C') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
            letterImage = UpperCasesImage[2]; 
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().upper = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().upper = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().Upper = letterImage.gameObject;
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().SetLetter(letterImage);
            return;
		}
		if (letter == 'd') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
            letterImage = LowerCasesImage[3]; 
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().lower = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().lower = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().Lower = letterImage.gameObject;
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().SetLetter(letterImage);
            return;
		}
		if (letter == 'D') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
            letterImage = UpperCasesImage[3]; 
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().upper = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().upper = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().Upper = letterImage.gameObject;
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().SetLetter(letterImage);
            return;
		}
		if (letter == 'e') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
            letterImage = LowerCasesImage[4]; 
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().lower = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().lower = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().Lower = letterImage.gameObject;
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().SetLetter(letterImage);
            return;
		}
		if (letter == 'E') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
            letterImage = UpperCasesImage[4]; 
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().upper = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().upper = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().Upper = letterImage.gameObject;
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().SetLetter(letterImage);
            return;
		}
		if (letter == 'f') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
            letterImage = LowerCasesImage[5]; 
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().lower = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().lower = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().Lower = letterImage.gameObject;
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().SetLetter(letterImage);
            return;
		}
		if (letter == 'F') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
            letterImage = UpperCasesImage[5];  
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().upper = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().upper = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().Upper = letterImage.gameObject;
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().SetLetter(letterImage);
            return;
		}
		if (letter == 'g') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
            letterImage = LowerCasesImage[6]; 
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().lower = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().lower = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().Lower = letterImage.gameObject;
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().SetLetter(letterImage);
            return;
		}
		if (letter == 'G') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
            letterImage = UpperCasesImage[6];  
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().upper = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().upper = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().Upper = letterImage.gameObject;
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().SetLetter(letterImage);
            return;
		}
		if (letter == 'h') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
            letterImage = LowerCasesImage[7];  
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().lower = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().lower = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().Lower = letterImage.gameObject;
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().SetLetter(letterImage);
            return;
		}
		if (letter == 'H') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
            letterImage = UpperCasesImage[7]; 
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().upper = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().upper = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().Upper = letterImage.gameObject;
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().SetLetter(letterImage);
            return;
		}
		if (letter == 'i') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
            letterImage = LowerCasesImage[8]; 
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().lower = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().lower = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().Lower = letterImage.gameObject;
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().SetLetter(letterImage);
            return;
		}
		if (letter == 'I') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
            letterImage = UpperCasesImage[8]; 
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().upper = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().upper = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().Upper = letterImage.gameObject;
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().SetLetter(letterImage);
            return;
		}
		if (letter == 'j') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
            letterImage = LowerCasesImage[9];  
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().lower = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().lower = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().Lower = letterImage.gameObject;
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().SetLetter(letterImage);
            return;
		}
		if (letter == 'J') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
            letterImage = UpperCasesImage[9]; 
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().upper = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().upper = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().Upper = letterImage.gameObject;
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().SetLetter(letterImage);
            return;
		}
		if (letter == 'k') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
            letterImage = LowerCasesImage[10]; 
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().lower = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().lower = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().Lower = letterImage.gameObject;
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().SetLetter(letterImage);
            return;
		}
		if (letter == 'K') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
            letterImage = UpperCasesImage[10];  
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().upper = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().upper = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().Upper = letterImage.gameObject;
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().SetLetter(letterImage);
            return;
		}
		if (letter == 'l') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
            letterImage = LowerCasesImage[11]; 
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().lower = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().lower = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().Lower = letterImage.gameObject;
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().SetLetter(letterImage);
            return;
		}
		if (letter == 'L') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
            letterImage = UpperCasesImage[11]; 
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().upper = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().upper = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().Upper = letterImage.gameObject;
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().SetLetter(letterImage);
            return;
		}
		if (letter == 'm') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
            letterImage = LowerCasesImage[12]; 
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().lower = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().lower = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().Lower = letterImage.gameObject;
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().SetLetter(letterImage);
            return;
		}
		if (letter == 'M') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
            letterImage = UpperCasesImage[12]; 
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().upper = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().upper = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().Upper = letterImage.gameObject;
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().SetLetter(letterImage);
            return;
		}
		if (letter == 'n') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
            letterImage = LowerCasesImage[13]; 
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().lower = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().lower = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().Lower = letterImage.gameObject;
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().SetLetter(letterImage);
            return;
		}
		if (letter == 'N') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
            letterImage = UpperCasesImage[13]; 
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().upper = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().upper = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().Upper = letterImage.gameObject;
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().SetLetter(letterImage);
            return;
		}
		if (letter == 'o') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
            letterImage = LowerCasesImage[14]; 
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().lower = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().lower = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().Lower = letterImage.gameObject;
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().SetLetter(letterImage);
            return;
		}
		if (letter == 'O') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
            letterImage = UpperCasesImage[14]; 
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().upper = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().upper = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().Upper = letterImage.gameObject;
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().SetLetter(letterImage);
            return;
		}
		if (letter == 'p') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
            letterImage = LowerCasesImage[15]; 
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().lower = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().lower = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().Lower = letterImage.gameObject;
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().SetLetter(letterImage);
            return;
		}
		if (letter == 'P') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
            letterImage = UpperCasesImage[15]; 
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().upper = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().upper = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().Upper = letterImage.gameObject;
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().SetLetter(letterImage);
            return;
		}
		if (letter == 'q') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
            letterImage = LowerCasesImage[16]; 
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().lower = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().lower = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().Lower = letterImage.gameObject;
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().SetLetter(letterImage);
            return;
		}
		if (letter == 'Q') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
            letterImage = UpperCasesImage[16]; 
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().upper = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().upper = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().Upper = letterImage.gameObject;
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().SetLetter(letterImage);
            return;
		}
		if (letter == 'r') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
            letterImage = LowerCasesImage[17]; 
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().lower = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().lower = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().Lower = letterImage.gameObject;
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().SetLetter(letterImage);
            return;
		}
		if (letter == 'R') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
            letterImage = UpperCasesImage[17]; 
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().upper = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().upper = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().Upper = letterImage.gameObject;
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().SetLetter(letterImage);
            return;
		}
		if (letter == 's') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
            letterImage = LowerCasesImage[18]; 
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().lower = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().lower = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().Lower = letterImage.gameObject;
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().SetLetter(letterImage);
            return;
		}
		if (letter == 'S') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
            letterImage = UpperCasesImage[18]; 
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().upper = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().upper = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().Upper = letterImage.gameObject;
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().SetLetter(letterImage);
            return;
		}
		if (letter == 't') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
            letterImage = LowerCasesImage[19]; 
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().lower = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().lower = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().Lower = letterImage.gameObject;
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().SetLetter(letterImage);
            return;
		}
		if (letter == 'T') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
            letterImage = UpperCasesImage[19]; 
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().upper = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().upper = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().Upper = letterImage.gameObject;
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().SetLetter(letterImage);
            return;
		}
		if (letter == 'u') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
            letterImage = LowerCasesImage[20]; 
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().lower = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().lower = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().Lower = letterImage.gameObject;
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().SetLetter(letterImage);
            return;
		}
		if (letter == 'U') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
            letterImage = UpperCasesImage[20]; 
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().upper = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().upper = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().Upper = letterImage.gameObject;
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().SetLetter(letterImage);
            return;
		}
		if (letter == 'v') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
            letterImage = LowerCasesImage[21];
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().lower = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().lower = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().Lower = letterImage.gameObject;
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().SetLetter(letterImage);
            return;
		}
		if (letter == 'V') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
            letterImage = UpperCasesImage[21]; 
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().upper = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().upper = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().Upper = letterImage.gameObject;
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().SetLetter(letterImage);
            return;
		}
		if (letter == 'w') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
            letterImage = LowerCasesImage[22]; 
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().lower = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().lower = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().Lower = letterImage.gameObject;
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().SetLetter(letterImage);
            return;
		}
		if (letter == 'W') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
            letterImage = UpperCasesImage[22]; 
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().upper = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().upper = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().Upper = letterImage.gameObject;
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().SetLetter(letterImage);
            return;
		}
		if (letter == 'x') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
            letterImage = LowerCasesImage[23]; 
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().lower = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().lower = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().Lower = letterImage.gameObject;
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().SetLetter(letterImage);
            return;
		}
		if (letter == 'X') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
            letterImage = UpperCasesImage[23]; 
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().upper = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().upper = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().Upper = letterImage.gameObject;
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().SetLetter(letterImage);
            return;
		}
		if (letter == 'y') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
            letterImage = LowerCasesImage[24]; 
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().lower = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().lower = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().Lower = letterImage.gameObject;
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().SetLetter(letterImage);
            return;
		}
		if (letter == 'Y') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
            letterImage = UpperCasesImage[24]; 
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().upper = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().upper = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().Upper = letterImage.gameObject;
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().SetLetter(letterImage);
            return;
		}
		if (letter == 'z') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
            letterImage = LowerCasesImage[25]; 
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().lower = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().lower = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().Lower = letterImage.gameObject;
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().SetLetter(letterImage);
            return;
		}
		if (letter == 'Z') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
            letterImage = UpperCasesImage[25]; 
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().upper = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().upper = letter.ToString();
            LetterBlocks[index].GetComponent<Case_Control>().Upper = letterImage.gameObject;
            LetterBlocks[index].GetComponent<LetterSearchSetUp>().SetLetter(letterImage);
            return;
		}
        LetterBlocks[index].GetComponent<Case_Control>().isKeyboard = false;
        
    }

	// Update is called once per frameS
	void Update () {
		
	}
}
