using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keyboard : MonoBehaviour {
	
	public List<GameObject> KeyboardButtons;
	public List<GameObject> LetterBlocks;
	public string PlayersName;
	public GameObject Answers;
	public GameObject Level;
	public string answerString = "";
	public bool CapsLock = true;
	public int LevelNum = 0;
	public bool Home = false;
	public bool MoveFoward = false;
	public int RaceCount = 0;
	public Image PlayerCharcter;

	public Image Racer1;
	public Image Racer2;/// Use this for initialization
	public GameObject GameManager;
	public int selected = 0;
	public int color = 0;
	public Vector3 PlayerCharcterPosition;
	public Vector3 Racer1Position;
	public Vector3 Racer2Position;


	public float Racer1timer = 0;
	public float Racer2timer = 0;

	public int Racer1count = 0;
	public int Racer2count = 0;



	public GameObject RPSChoices;
	public int RPSPlayerChoice =0;
	public GameObject PlayerHealth;
	public GameObject BossHealth;



	public GameObject LettersBlockHM;
	public int HMmiss = 0;
	public List<bool> Used;

	public int chestwin = 0;
	public GameObject ChestPanel;
	public bool wintreasue = false;
	public float FadeTime;
	public bool FadeOn = true;
	void SetName () {
		int Num_Boxes = PlayersName.Length;
		Answers.GetComponent<Letters> ().SetLetters (Num_Boxes);
	//	Answers = Answers.GetComponent<Letters> ().letter;
	}
	void Start () {
		if (LevelNum == 4) {
			chestwin = Random.Range (0, 6);
		}
		if (LevelNum == 1) {
			Racer1timer = 15.0f;
			Racer2timer = 20.0f;
			PlayerCharcterPosition = PlayerCharcter.transform.localPosition;
			Racer1Position = Racer1.transform.transform.localPosition;
			Racer2Position = Racer2.transform.transform.localPosition;
		}
		if (LevelNum == 2) {
			BossHealth.GetComponent<HealthScript> ().SetHealth (4);
			PlayerHealth.GetComponent<HealthScript> ().SetHealth (4);
		}
		if (LevelNum == 3) {
		}
		switch(GameManager.GetComponent<FirstPlayButtons>().LoginNumber){

		case 1:{
				selected = PlayerPrefs.GetInt("firstCharacter");
				color = PlayerPrefs.GetInt("firstColor");
				break;
			}
		case 2:
			{
				selected = PlayerPrefs.GetInt ("secondCharacter");
				color = PlayerPrefs.GetInt("secondColor");
				break;
			}
		case 3:
			{
				selected = PlayerPrefs.GetInt ("thirdCharacter");
				color = PlayerPrefs.GetInt("thirdColor");
				break;
			}
		case 4:
			{
				selected = PlayerPrefs.GetInt ("fourthCharacter");
				color = PlayerPrefs.GetInt("fourthColor");
				break;
			}
		}
		HMmiss = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayersName == answerString && LevelNum == 0)
			this.GetComponentInParent<Win> ().WinState ();
		
		if (LevelNum == 1) {

			if (PlayersName == answerString) {

				for (int i = 0; i < Answers.GetComponent<Letters> ().letter.Count; i++)
					Answers.GetComponent<Letters> ().letter [i].GetComponent<LetterPlacement> ().RemoveLetter ();
				PlayerCharcter.transform.localPosition = new Vector3 (PlayerCharcter.transform.localPosition.x + 300, PlayerCharcter.transform.localPosition.y, PlayerCharcter.transform.localPosition.z);
				RaceCount++;
				MoveFoward = false;
				this.GetComponentInParent<Level2A> ().ResetRace ();
				if (RaceCount == 4) {
					RaceCount = 0;
					Home = true;
				}

				if (Home == true)
					this.GetComponentInParent<Win> ().WinState ();
			}

			if (Racer1timer > 0) {
				Racer1timer -= Time.deltaTime;
				if (Racer1timer <= 0) {
					Racer1timer = 0;
					Racer1count++;
					Racer1timer = 15.0f;
					Racer1.transform.localPosition = new Vector3 (Racer1.transform.localPosition.x + 300, Racer1.transform.localPosition.y, Racer1.transform.localPosition.z);
				}
			} 
			if (Racer2timer > 0) {
				Racer2timer -= Time.deltaTime;
				if (Racer2timer <= 0) {
					Racer2timer = 0;
					Racer2count++;
					Racer2timer = 20.0f;
					Racer2.transform.localPosition = new Vector3 (Racer2.transform.localPosition.x + 300, Racer2.transform.localPosition.y, Racer2.transform.localPosition.z);
				}
			} 
			if (Racer1count == 4 || Racer2count == 4) {

				this.GetComponentInParent<Win> ().LoseState ();
			}

		}

		if (LevelNum == 2) {
			if (PlayersName == answerString) {
				int BossChoice = 0;
				RPSChoices.SetActive (true);

				switch(RPSPlayerChoice){

				case 0:{

						break;
					}
				case 1:
					{
						RPSPlayerChoice =0;
						this.GetComponentInParent<Level2A> ().ResetRace ();
						BossChoice = Random.Range (1, 101);
						if (BossChoice < 76) {
							BossChoice = 0;
							if(BossHealth.GetComponent<HealthScript> ().LoseHealth () == 0)
								this.GetComponentInParent<Win> ().WinState ();
						} else {
							BossChoice = 0;
							if(PlayerHealth.GetComponent<HealthScript> ().LoseHealth () == 0)
							this.GetComponentInParent<Win> ().LoseState ();
						}
						RPSChoices.SetActive (false);
						break;
					}
				case 2:
					{
						RPSPlayerChoice =0;
						this.GetComponentInParent<Level2A> ().ResetRace ();
						BossChoice = Random.Range (1, 101);
						if (BossChoice < 76) {
							BossChoice = 0;
							if(BossHealth.GetComponent<HealthScript> ().LoseHealth () == 0)
								this.GetComponentInParent<Win> ().WinState ();

						} else {
							BossChoice = 0;
							if(PlayerHealth.GetComponent<HealthScript> ().LoseHealth () == 0)
							this.GetComponentInParent<Win> ().LoseState ();
						}
						RPSChoices.SetActive (false);
						break;
					}
				case 3:
					{
						RPSPlayerChoice =0;
						this.GetComponentInParent<Level2A> ().ResetRace ();
						BossChoice = Random.Range (1, 101);
						if (BossChoice < 76) {
							BossChoice = 0;

							if(BossHealth.GetComponent<HealthScript> ().LoseHealth () == 0)
								this.GetComponentInParent<Win> ().WinState ();
								
						} else {
							BossChoice = 0;
							if(PlayerHealth.GetComponent<HealthScript> ().LoseHealth () == 0)
							this.GetComponentInParent<Win> ().LoseState ();
						}
						RPSChoices.SetActive (false);
						break;
					}
				}
				
			}
		}

		if (LevelNum == 3) {

		
			if (PlayersName == answerString) {
				HMmiss = 0;
				this.GetComponentInParent<Win> ().WinState ();
			}
			
			if (HMmiss == 3) {
				HMmiss = 0;
				this.GetComponentInParent<Win> ().LoseState ();
			}
				
		}
		if (LevelNum == 4) 
		{

			if (PlayersName == answerString) 
			{
				float time = 2.0f;
				if (FadeOn == true) {
					FadeScript.instance.Fade (true, time);
					FadeOn = false;
				}
				FadeTime += Time.deltaTime;
				if (FadeTime > time) {
					FadeTime = 0;
					FadeScript.instance.Fade(false,time);
					ChestPanel.SetActive (true);
					answerString = "";
					FadeOn = true;
				}
			}

			if (wintreasue) {

				this.GetComponentInParent<Win> ().WinState ();
			}
		}
	}
	public void TurnOffChestPanel(){
		
		ChestPanel.SetActive(false);
	}
	
	public void RPSChoicesRock(){
		
		RPSPlayerChoice = 1;
	}
	public void RPSChoicesPaper(){

		RPSPlayerChoice = 2;
	}
	public void RPSChoicesScissor(){

		RPSPlayerChoice = 3;
	}


	public void KeyBoardInput(){
	if (Input.GetKeyDown(KeyCode.Q)) {
			KeyboardButtons [0].GetComponent<Case_Control> ().button.onClick.Invoke ();

		}
		if (Input.GetKeyDown(KeyCode.W)) {
			KeyboardButtons [1].GetComponent<Case_Control> ().button.onClick.Invoke ();

		}
		if (Input.GetKeyDown(KeyCode.E)) {
			KeyboardButtons [2].GetComponent<Case_Control> ().button.onClick.Invoke ();
		
		}
		if (Input.GetKeyDown(KeyCode.R)) {
			KeyboardButtons [3].GetComponent<Case_Control> ().button.onClick.Invoke ();

		}
		if (Input.GetKeyDown(KeyCode.T)) {
			KeyboardButtons [4].GetComponent<Case_Control> ().button.onClick.Invoke ();

		}
		if (Input.GetKeyDown(KeyCode.Y)) {
			KeyboardButtons [5].GetComponent<Case_Control> ().button.onClick.Invoke ();

		}
		if (Input.GetKeyDown(KeyCode.U)) {
			KeyboardButtons [6].GetComponent<Case_Control> ().button.onClick.Invoke ();

		}
		if (Input.GetKeyDown(KeyCode.I)) {
			KeyboardButtons [7].GetComponent<Case_Control> ().button.onClick.Invoke ();

		}
		if (Input.GetKeyDown(KeyCode.O)) {
			KeyboardButtons [8].GetComponent<Case_Control> ().button.onClick.Invoke ();

		}
		if (Input.GetKeyDown(KeyCode.P)) {
			KeyboardButtons [9].GetComponent<Case_Control> ().button.onClick.Invoke ();

		}
		if (Input.GetKeyDown(KeyCode.A)) {
			KeyboardButtons [10].GetComponent<Case_Control> ().button.onClick.Invoke ();
		}
		if (Input.GetKeyDown(KeyCode.S)) {
			KeyboardButtons [11].GetComponent<Case_Control> ().button.onClick.Invoke ();

		}
		if (Input.GetKeyDown(KeyCode.D)) {
			KeyboardButtons [12].GetComponent<Case_Control> ().button.onClick.Invoke ();
		
		}
		if (Input.GetKeyDown(KeyCode.F)) {
			KeyboardButtons [13].GetComponent<Case_Control> ().button.onClick.Invoke ();
		}
		if (Input.GetKeyDown(KeyCode.G)) {
			KeyboardButtons [14].GetComponent<Case_Control> ().button.onClick.Invoke ();
		}
		if (Input.GetKeyDown(KeyCode.H)) {
			KeyboardButtons [15].GetComponent<Case_Control> ().button.onClick.Invoke ();
		}
		if (Input.GetKeyDown(KeyCode.J)) {
			KeyboardButtons [16].GetComponent<Case_Control> ().button.onClick.Invoke ();

		}
		if (Input.GetKeyDown(KeyCode.K)) {
			KeyboardButtons [17].GetComponent<Case_Control> ().button.onClick.Invoke ();


		}
		if (Input.GetKeyDown(KeyCode.L)) {
			KeyboardButtons [18].GetComponent<Case_Control> ().button.onClick.Invoke ();
		
		}
		if (Input.GetKeyDown(KeyCode.Z)) {
			KeyboardButtons [19].GetComponent<Case_Control> ().button.onClick.Invoke ();
		
		}
		if (Input.GetKeyDown(KeyCode.X)) {
			KeyboardButtons [20].GetComponent<Case_Control> ().button.onClick.Invoke ();

		}
		if (Input.GetKeyDown(KeyCode.C)) {
			KeyboardButtons [21].GetComponent<Case_Control> ().button.onClick.Invoke ();

		}
		if (Input.GetKeyDown(KeyCode.V)) {
			KeyboardButtons [22].GetComponent<Case_Control> ().button.onClick.Invoke ();

		}
		if (Input.GetKeyDown(KeyCode.B)) {
			KeyboardButtons [23].GetComponent<Case_Control> ().button.onClick.Invoke ();

		}
		if (Input.GetKeyDown(KeyCode.N)) {
			KeyboardButtons [24].GetComponent<Case_Control> ().button.onClick.Invoke ();
		
		}
		if (Input.GetKeyDown(KeyCode.M)) {
			KeyboardButtons [25].GetComponent<Case_Control> ().button.onClick.Invoke ();
		}
		if (Input.GetKeyDown(KeyCode.LeftShift) ||Input.GetKeyDown(KeyCode.RightShift)) {
			Shift ();
		}
		if (Input.GetKeyDown (KeyCode.Delete ) || Input.GetKeyDown (KeyCode.Backspace)) {
			Delete ();
		}
	}
	public void SetUpName(){
		int Num_Boxes = PlayersName.Length;
		Answers.GetComponent<Letters> ().SetLetters (Num_Boxes);
		LetterBlocks = Answers.GetComponent<Letters> ().letter;
		/*	int x = 0;
	for (int i = 0; i < Num_Boxes; i++) {

			GameObject Temp = Instantiate (Backgrounds);
			Temp.transform.SetParent (Answers.transform);
			Temp.transform.localPosition = new Vector3 (x, 0, 0);
			x += 200;
			LetterBlocks.Add (Temp);

		} */
	}
	public void Miss () {
		HMmiss++;

	}
	public void Shift () {
		CapsLock = !CapsLock;

		for (int i = 0; i < KeyboardButtons.Count; i++)
			KeyboardButtons [i].GetComponent<Case_Control> ().Change_Case (CapsLock);
		
		}
	public void Delete (){
		int index	= KeyboardButtons [0].GetComponent<Case_Control> ().GetIndex () - 1;
		if (index != -1) {
			LetterBlocks [index].GetComponent<LetterPlacement> ().RemoveLetter ();
			char[] newAnswer =	answerString.ToCharArray ();

			if (index == 0) {
				answerString = "";
			} else {
				answerString = "";
				for (int i = 0; i < index; i++) {
					answerString += newAnswer [i].ToString ();
				}
			}
			KeyboardButtons [0].GetComponent<Case_Control> ().Delete ();
		}
	}
	}

