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

	public void Miss () {
	}
	void Start () {
		switch(GameManager.GetComponent<FirstPlayButtons>().LoginNumber){
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
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().SetLetter (LowerCasesImage [0]);
			return;
		}
		if (letter == 'A') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().SetLetter (UpperCasesImage [0]);
			return;
		}
		if (letter == 'b') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().SetLetter (LowerCasesImage [1]);
			return;
		}
		if (letter == 'B') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().SetLetter (UpperCasesImage [1]);
			return;
		}
		if (letter == 'c') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().SetLetter (LowerCasesImage [2]);
			return;
		}
		if (letter == 'C') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().SetLetter (UpperCasesImage [2]);
			return;
		}
		if (letter == 'd') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().SetLetter (LowerCasesImage [3]);
			return;
		}
		if (letter == 'D') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().SetLetter (UpperCasesImage [3]);
			return;
		}
		if (letter == 'e') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().SetLetter (LowerCasesImage [4]);
			return;
		}
		if (letter == 'E') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().SetLetter (UpperCasesImage [4]);
			return;
		}
		if (letter == 'f') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().SetLetter (LowerCasesImage [5]);
			return;
		}
		if (letter == 'F') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().SetLetter(UpperCasesImage [5]);
			return;
		}
		if (letter == 'g') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().SetLetter (LowerCasesImage [6]);
			return;
		}
		if (letter == 'G') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().SetLetter(UpperCasesImage [6]);
			return;
		}
		if (letter == 'h') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().SetLetter(LowerCasesImage [7]);
			return;
		}
		if (letter == 'H') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().SetLetter (UpperCasesImage [7]);
			return;
		}
		if (letter == 'i') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().SetLetter (LowerCasesImage [8]);
			return;
		}
		if (letter == 'I') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().SetLetter (UpperCasesImage [8]);
			return;
		}
		if (letter == 'j') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().SetLetter(LowerCasesImage [9]);
			return;
		}
		if (letter == 'J') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().SetLetter (UpperCasesImage [9]);
			return;
		}
		if (letter == 'k') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().SetLetter (LowerCasesImage [10]);
			return;
		}
		if (letter == 'K') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().SetLetter(UpperCasesImage [10]);
			return;
		}
		if (letter == 'l') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().SetLetter (LowerCasesImage [11]);
			return;
		}
		if (letter == 'L') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().SetLetter (UpperCasesImage [11]);
			return;
		}
		if (letter == 'm') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().SetLetter (LowerCasesImage [12]);
			return;
		}
		if (letter == 'M') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().SetLetter (UpperCasesImage [12]);
			return;
		}
		if (letter == 'n') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().SetLetter (LowerCasesImage [13]);
			return;
		}
		if (letter == 'N') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().SetLetter (UpperCasesImage [13]);
			return;
		}
		if (letter == 'o') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().SetLetter (LowerCasesImage [14]);
			return;
		}
		if (letter == 'O') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().SetLetter (UpperCasesImage [14]);
			return;
		}
		if (letter == 'p') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().SetLetter (LowerCasesImage [15]);
			return;
		}
		if (letter == 'P') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().SetLetter (UpperCasesImage [15]);
			return;
		}
		if (letter == 'q') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().SetLetter (LowerCasesImage [16]);
			return;
		}
		if (letter == 'Q') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().SetLetter (UpperCasesImage [16]);
			return;
		}
		if (letter == 'r') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().SetLetter (LowerCasesImage [17]);
			return;
		}
		if (letter == 'R') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().SetLetter (UpperCasesImage [17]);
			return;
		}
		if (letter == 's') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().SetLetter (LowerCasesImage [18]);
			return;
		}
		if (letter == 'S') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().SetLetter (UpperCasesImage [18]);
			return;
		}
		if (letter == 't') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().SetLetter (LowerCasesImage [19]);
			return;
		}
		if (letter == 'T') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().SetLetter (UpperCasesImage [19]);
			return;
		}
		if (letter == 'u') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().SetLetter (LowerCasesImage [20]);
			return;
		}
		if (letter == 'U') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().SetLetter (UpperCasesImage [20]);
			return;
		}
		if (letter == 'v') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().SetLetter (LowerCasesImage [21]);
			return;
		}
		if (letter == 'V') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().SetLetter (UpperCasesImage [21]);
			return;
		}
		if (letter == 'w') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().SetLetter (LowerCasesImage [22]);
			return;
		}
		if (letter == 'W') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().SetLetter (UpperCasesImage [22]);
			return;
		}
		if (letter == 'x') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().SetLetter (LowerCasesImage [23]);
			return;
		}
		if (letter == 'X') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().SetLetter (UpperCasesImage [23]);
			return;
		}
		if (letter == 'y') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().SetLetter (LowerCasesImage [24]);
			return;
		}
		if (letter == 'Y') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().SetLetter (UpperCasesImage [24]);
			return;
		}
		if (letter == 'z') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().SetLetter (LowerCasesImage [25]);
			return;
		}
		if (letter == 'Z') {
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().index = placement;
			LetterBlocks [index].GetComponent<LetterSearchSetUp> ().SetLetter (UpperCasesImage [25]);
			return;
		}
	}

	// Update is called once per frameS
	void Update () {
		
	}
}
