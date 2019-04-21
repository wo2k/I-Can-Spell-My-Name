using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level2C : MonoBehaviour {
	public GameObject ChoiceBlock;

	public string PlayersName;
	public string AnswerName;
	public bool gameStart = false;
	public Text timetext;
	float timer = 45.0f;
	float minutes = 0;
	float seconds = 0;
	int Score = 0;
	public Text ScoreText;
	int Multi = 1;
	int Total = 0;
	public GameObject GameManager;
	public GameObject StartMenu;
	public GameObject EndMenu;
	public int LevelNumber = 0;
    public GameObject Keyboard;
    public List<GameObject> incorrectPanel = new List<GameObject>();
    public int incorrectIndex = 0;

    // Use this for initialization
    public void StartGame(){
		StartMenu.SetActive (false);
		gameStart = true;
	}
	void Start () {

        UIManager.instance.heartsAmount = 3;
        UIManager.instance.StartGame();
        UIManager.instance.mode2 = UIManager.subLevels2.Level2C;
        Keyboard = FindObjectOfType<Keyboard>().gameObject;

        switch (FindObjectOfType<FirstPlayButtons>().LoginNumber){
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

        Keyboard.GetComponent<Keyboard>().PlayersName = PlayersName;



        if (UIManager.instance.levelName != "Level2D" && UIManager.instance.levelName != "Level2E")
        {
            ChoiceBlock.GetComponent<ChoiceBlock>().PlayersName = PlayersName;
            FindObjectOfType<Keyboard>().LevelNum = 3;
            Keyboard.GetComponent<Keyboard>().SetUpName(0.4f, false);
        }
        if(UIManager.instance.levelName == "Level2D")
        {
            Keyboard.GetComponent<Keyboard>().SetUpName(0.6f, false);
            FindObjectOfType<Keyboard>().LevelNum = 4;
            UIManager.instance.mode2 = UIManager.subLevels2.Level2D;
            for (int i = 0; i < incorrectPanel.Count; i++)
                incorrectPanel[i].transform.GetChild(0).GetComponent<Image>().enabled = false;
        }

        if (UIManager.instance.levelName == "Level2E")
        {
            FindObjectOfType<Keyboard>().LevelNum = 1;
            UIManager.instance.mode2 = UIManager.subLevels2.Level2F;
            Keyboard.GetComponent<Keyboard>().SetUpName(0.6f, true);

        }

        FindObjectOfType<Keyboard>().Used = new bool[PlayersName.Length];
        for (int i = 0; i < PlayersName.Length; i++)
            FindObjectOfType<Keyboard>().Used[i] = false;
    //    LettersBlockHM = FindObjectOfType<Keyboard>().LetterBlocks;

}
			

	

	// Update is called once per frame
	public void ScorePoints(){
		Score += 100 * Multi;
		ScoreText.text = Score.ToString ();
		Total++;
	}

	void Update () {
        FindObjectOfType<Keyboard>().KeyBoardInput();

        if (gameStart) {
			if (LevelNumber == 1 || LevelNumber == 3)
				ChoiceBlock.GetComponent<Keyboard> ().KeyBoardInput ();
			
			if (LevelNumber == 0) {
				if (timer > 0) {
					timer -= Time.deltaTime;
					if (timer <= 0)
						timer = 0;
				} else if (timer <= 0) {
					this.GetComponent<Win> ().LoseState ();

				}
				if (LetterSearchSetUp.count == PlayersName.Length) {
					LetterSearchSetUp.count = 0;
					this.GetComponent<Win> ().WinState ();
					gameStart = false;
				}
			
				minutes = Mathf.Floor (timer / 60);
				seconds = timer % 60;

				if (Mathf.RoundToInt (seconds) < 10)
					timetext.text = Mathf.RoundToInt (minutes).ToString () + ":0" + Mathf.RoundToInt (seconds).ToString ();
				else
					timetext.text = Mathf.RoundToInt (minutes).ToString () + ":" + Mathf.RoundToInt (seconds).ToString ();

			}
		}
	}

    public void ResetRace()
    {
        int count = Keyboard.GetComponent<Keyboard>().LetterBlocks.Count;
        for (int i = 0; i < count; i++)
            Keyboard.GetComponent<Keyboard>().LetterBlocks[i].GetComponent<LetterPlacement>().RemoveLetter();
        Keyboard.GetComponent<Keyboard>().answerString = "";
        Keyboard.GetComponent<Keyboard>().Home = false;
        Keyboard.GetComponent<Keyboard>().MoveFoward = false;
        Case_Control.index = 0;
        if (Keyboard.GetComponent<Keyboard>().CapsLock != true)
            Keyboard.GetComponent<Keyboard>().Shift();
    }

    public void Reset(){
		int count =	ChoiceBlock.GetComponent<ChoiceBlock> ().LetterBlocks.Count;
		for (int i = 0; i < count; i++)
			ChoiceBlock.GetComponent<ChoiceBlock> ().LetterBlocks [i].GetComponent<LetterPlacement> ().RemoveLetter ();

		LetterSearchSetUp.count = 0;
		ChoiceBlock.GetComponent<ChoiceBlock> ().SetUpName ();
		timer = 45.0f;
		minutes = 0;
		seconds = 0;
		Score = 0;

		Multi = 1;

		Total = 0;
		StartMenu.SetActive (true);
	}
	public void Restart(){
		EndMenu.SetActive (false);
		StartMenu.SetActive (true);
		if (LevelNumber == 0) {
			int count =	ChoiceBlock.GetComponent<ChoiceBlock> ().AnswerBlocks.Count;
			for (int i = 0; i < count - 1; i++)
				ChoiceBlock.GetComponent<ChoiceBlock> ().AnswerBlocks [i].GetComponent<LetterPlacement> ().RemoveLetter ();

			LetterSearchSetUp.count = 0;
			timer = 45.0f;
			minutes = 0;
			seconds = 0;
			Score = 0;

			Multi = 1;
			Total = 0;

			ChoiceBlock.GetComponent<ChoiceBlock> ().SetUpName ();
			ChoiceBlock.GetComponent<ChoiceBlock> ().FillRest ();
		}
		if (LevelNumber == 1) {

		}
	
	}
}