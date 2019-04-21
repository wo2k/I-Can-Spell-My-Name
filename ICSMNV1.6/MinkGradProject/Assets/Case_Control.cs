using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Case_Control : MonoBehaviour {
    public GameObject Upper;
    public GameObject Lower;
    public static int index = 0;
    public string upper;
    public string lower;
    public bool UpperCaseFlag;
    public Button button;
    public static int HMindex = 0;
    public static int HMmisses = 0;
    public static bool miss = false;
    public bool isKeyboard;
    public Image imageCapture;
    public char[] wordSearchLetter = new char[5];

    // Use this for initialization
    void Start() {

        if (lower.Length >= 1)
            UpperCaseFlag = false;
        if (upper.Length >= 1)
            UpperCaseFlag = true;

         

    }
    public void SetImage() {
        SoundManagement.TriggerEvent("PlayPop");
        switch (upper) {
            case "A":
                { SoundManagement.TriggerEvent("PlayA");
                    break;
                }
            case "B":
                { SoundManagement.TriggerEvent("PlayB");
                    break;
                }
            case "C":
                { SoundManagement.TriggerEvent("PlayC");
                    break;
                }
            case "D":
                { SoundManagement.TriggerEvent("PlayD");
                    break;
                }
            case "E":
                { SoundManagement.TriggerEvent("PlayE");
                    break;
                }
            case "F":
                { SoundManagement.TriggerEvent("PlayF");
                    break;
                }
            case "G":
                { SoundManagement.TriggerEvent("PlayG");
                    break;
                }
            case "H":
                { SoundManagement.TriggerEvent("PlayH");
                    break;
                }
            case "I":
                { SoundManagement.TriggerEvent("PlayI");
                    break;
                }
            case "J":
                { SoundManagement.TriggerEvent("PlayJ");
                    break;
                }
            case "K":
                { SoundManagement.TriggerEvent("PlayK");
                    break;
                }
            case "L":
                { SoundManagement.TriggerEvent("PlayL");
                    break;
                }
            case "M":
                { SoundManagement.TriggerEvent("PlayM");
                    break;
                }
            case "N":
                { SoundManagement.TriggerEvent("PlayN");
                    break;
                }
            case "O":
                { SoundManagement.TriggerEvent("PlayO");
                    break;
                }
            case "P":
                { SoundManagement.TriggerEvent("PlayP");
                    break;
                }
            case "Q":
                { SoundManagement.TriggerEvent("PlayQ");
                    break;
                }
            case "R":
                { SoundManagement.TriggerEvent("PlayR");
                    break;
                }
            case "S":
                { SoundManagement.TriggerEvent("PlayS");
                    break;
                }
            case "T":
                { SoundManagement.TriggerEvent("PlayT");
                    break;
                }
            case "U":
                { SoundManagement.TriggerEvent("PlayU");
                    break;
                }
            case "V":
                { SoundManagement.TriggerEvent("PlayV");
                    break;
                }
            case "W":
                { SoundManagement.TriggerEvent("PlayW");
                    break;
                }
            case "X":
                { SoundManagement.TriggerEvent("PlayX");
                    break;
                }
            case "Y":
                { SoundManagement.TriggerEvent("PlayY");
                    break;
                }
            case "Z":
                { SoundManagement.TriggerEvent("PlayZ");
                    break;
                }

        }

        switch (lower)
        {
            case "a":
                {
                    SoundManagement.TriggerEvent("PlayA");
                    break;
                }
            case "b":
                {
                    SoundManagement.TriggerEvent("PlayB");
                    break;
                }
            case "c":
                {
                    SoundManagement.TriggerEvent("PlayC");
                    break;
                }
            case "d":
                {
                    SoundManagement.TriggerEvent("PlayD");
                    break;
                }
            case "e":
                {
                    SoundManagement.TriggerEvent("PlayE");
                    break;
                }
            case "f":
                {
                    SoundManagement.TriggerEvent("PlayF");
                    break;
                }
            case "g":
                {
                    SoundManagement.TriggerEvent("PlayG");
                    break;
                }
            case "h":
                {
                    SoundManagement.TriggerEvent("PlayH");
                    break;
                }
            case "i":
                {
                    SoundManagement.TriggerEvent("PlayI");
                    break;
                }
            case "j":
                {
                    SoundManagement.TriggerEvent("PlayJ");
                    break;
                }
            case "k":
                {
                    SoundManagement.TriggerEvent("PlayK");
                    break;
                }
            case "l":
                {
                    SoundManagement.TriggerEvent("PlayL");
                    break;
                }
            case "m":
                {
                    SoundManagement.TriggerEvent("PlayM");
                    break;
                }
            case "n":
                {
                    SoundManagement.TriggerEvent("PlayN");
                    break;
                }
            case "o":
                {
                    SoundManagement.TriggerEvent("PlayO");
                    break;
                }
            case "p":
                {
                    SoundManagement.TriggerEvent("PlayP");
                    break;
                }
            case "q":
                {
                    SoundManagement.TriggerEvent("PlayQ");
                    break;
                }
            case "r":
                {
                    SoundManagement.TriggerEvent("PlayR");
                    break;
                }
            case "s":
                {
                    SoundManagement.TriggerEvent("PlayS");
                    break;
                }
            case "t":
                {
                    SoundManagement.TriggerEvent("PlayT");
                    break;
                }
            case "u":
                {
                    SoundManagement.TriggerEvent("PlayU");
                    break;
                }
            case "v":
                {
                    SoundManagement.TriggerEvent("PlayV");
                    break;
                }
            case "w":
                {
                    SoundManagement.TriggerEvent("PlayW");
                    break;
                }
            case "x":
                {
                    SoundManagement.TriggerEvent("PlayX");
                    break;
                }
            case "y":
                {
                    SoundManagement.TriggerEvent("PlayY");
                    break;
                }
            case "z":
                {
                    SoundManagement.TriggerEvent("PlayZ");
                    break;
                }

        }

        if (lower.Length >= 1)
            UpperCaseFlag = false;
        if (upper.Length >= 1)
            UpperCaseFlag = true;

        bool capsCapture = false;

        if (!isKeyboard)
            capsCapture = UpperCaseFlag;
        else
            capsCapture = FindObjectOfType<Keyboard>().CapsLock;

        if (FindObjectOfType<Keyboard>().LevelNum == 3)
        {

            if (capsCapture)
            {

                HMindex = HMindex + 1;
                int lenght = FindObjectOfType<Keyboard>().PlayersName.Length;

                char[] thisletter = upper.ToCharArray();

                for (int i = 0; i < FindObjectOfType<Keyboard>().name.Length; i++)
                {
                    if (FindObjectOfType<Keyboard>().name[i] == thisletter[0] && FindObjectOfType<Keyboard>().Used[i] == true)
                    {
                        int letterDuplicatesInName = 0;

                        for (int j = 0; j < FindObjectOfType<Keyboard>().name.Length; j++)
                        {
                            if (FindObjectOfType<Keyboard>().name[j] == thisletter[0])
                            {
                                if (FindObjectOfType<Keyboard>().Used[j] == true)
                                {
                                    letterDuplicatesInName++;
                                    if (FindObjectOfType<Keyboard>().CheckLetterDuplicates(FindObjectOfType<Keyboard>().PlayersName, j) == letterDuplicatesInName)
                                    {
                                        /*   for (int item = 0; item < FindObjectOfType<ChoiceBlock>().LetterBlocks.Count; item++)
                                           {
                                               // {'B'};
                                               wordSearchLetter = FindObjectOfType<ChoiceBlock>().LetterBlocks[item].GetComponent<Case_Control>().upper.ToCharArray();

                                               if (wordSearchLetter[0] == thisletter[0])
                                               {
                                                   FindObjectOfType<ChoiceBlock>().LetterBlocks[item].GetComponentInChildren<Button>().interactable = false;
                                                   FindObjectOfType<ChoiceBlock>().LetterBlocks[item].GetComponentInChildren<Image>().color = new Color(1, 1, 1, 0.5f);
                                               }
                                           }*/

                                        // FindObjectOfType<ChoiceBlock>().LetterBlocks[FindObjectOfType<ChoiceBlock>().LetterBlocks.IndexOf(this.gameObject)].GetComponentInChildren<Button>().interactable = false;
                                        // FindObjectOfType<ChoiceBlock>().LetterBlocks[FindObjectOfType<ChoiceBlock>().LetterBlocks.IndexOf(this.gameObject)].GetComponentInChildren<Image>().color = new Color(1, 1, 1, 0.5f);
                                        miss = true;
                                    }
                                }

                            }
                        }
                    }

                    if (FindObjectOfType<Keyboard>().name[i] == thisletter[0] && FindObjectOfType<Keyboard>().Used[i] != true)
                    {
                        FindObjectOfType<Keyboard>().Used[i] = true;
                        if (!isKeyboard)
                            FindObjectOfType<Keyboard>().LetterBlocks[i].GetComponent<LetterPlacement>().SetLetter(GetComponent<LetterSearchSetUp>().image);
                        else
                        {
                            FindObjectOfType<Keyboard>().LetterBlocks[i].GetComponent<LetterPlacement>().SetLetter(Upper.GetComponent<Image>());


                            /*    for (int item = 0; item < FindObjectOfType<ChoiceBlock>().LetterBlocks.Count; item++)
                                 {
                                    // {'B'};
                                    wordSearchLetter = FindObjectOfType<ChoiceBlock>().LetterBlocks[item].GetComponent<Case_Control>().upper.ToCharArray();

                                    if(wordSearchLetter[0] == thisletter[0])
                                    {
                                        FindObjectOfType<ChoiceBlock>().LetterBlocks[item].GetComponentInChildren<Button>().interactable = false;
                                        FindObjectOfType<ChoiceBlock>().LetterBlocks[item].GetComponentInChildren<Image>().color = new Color(1, 1, 1, 0.5f);
                                    }
                                }*/


                        }
                        //  FindObjectOfType<ChoiceBlock>().LetterBlocks[FindObjectOfType<ChoiceBlock>().LetterBlocks.IndexOf(this.gameObject)].GetComponentInChildren<Button>().interactable = false;
                        //   FindObjectOfType<ChoiceBlock>().LetterBlocks[FindObjectOfType<ChoiceBlock>().LetterBlocks.IndexOf(this.gameObject)].GetComponentInChildren<Image>().color = new Color(1, 1, 1, 0.5f);
                        FindObjectOfType<Keyboard>().wordSearchBox.Push(i);
                        FindObjectOfType<Keyboard>().answerString = FindObjectOfType<Keyboard>().answerString + upper;
                        LevelManager.instance.CheckAnswer(true, UIManager.instance.heartsAmount, UIManager.instance.seahorseAnim, FindObjectOfType<Keyboard>().PlayersName.Length, System.Enum.GetValues(typeof(UIManager.subLevels2)).Length);
                        break;
                    }

                }

                if (FindObjectOfType<Keyboard>().PlayersName.Split(thisletter[0]).Length - 1 <= 0)
                {
                    //  FindObjectOfType<ChoiceBlock>().LetterBlocks[FindObjectOfType<ChoiceBlock>().LetterBlocks.IndexOf(this.gameObject)].GetComponentInChildren<Button>().interactable = false;
                    //  FindObjectOfType<ChoiceBlock>().LetterBlocks[FindObjectOfType<ChoiceBlock>().LetterBlocks.IndexOf(this.gameObject)].GetComponentInChildren<Image>().color = new Color(1, 1, 1, 0.5f);
                    miss = true;
                }
                if (miss == true)
                {
                    miss = false;
                    HMmisses++;
                    FindObjectOfType<Keyboard>().Miss();
                }

            }
            else
            {

                HMindex = HMindex + 1;
                int lenght = FindObjectOfType<Keyboard>().PlayersName.Length;

                char[] thisletter = lower.ToCharArray();

                for (int i = 0; i < FindObjectOfType<Keyboard>().name.Length; i++)
                {
                    if (FindObjectOfType<Keyboard>().name[i] == thisletter[0] && FindObjectOfType<Keyboard>().Used[i] == true)
                    {
                        int letterDuplicatesInName = 0;

                        for (int j = 0; j < FindObjectOfType<Keyboard>().name.Length; j++)
                        {
                            if (FindObjectOfType<Keyboard>().name[j] == thisletter[0])
                            {
                                if (FindObjectOfType<Keyboard>().Used[j] == true)
                                {
                                    letterDuplicatesInName++;
                                    if (FindObjectOfType<Keyboard>().CheckLetterDuplicates(FindObjectOfType<Keyboard>().PlayersName, j) == letterDuplicatesInName)
                                    {
                                        //   FindObjectOfType<ChoiceBlock>().LetterBlocks[FindObjectOfType<ChoiceBlock>().LetterBlocks.IndexOf(this.gameObject)].GetComponentInChildren<Button>().interactable = false;
                                        //   FindObjectOfType<ChoiceBlock>().LetterBlocks[FindObjectOfType<ChoiceBlock>().LetterBlocks.IndexOf(this.gameObject)].GetComponentInChildren<Image>().color = new Color(1, 1, 1, 0.5f);
                                        miss = true;
                                    }
                                }

                            }
                        }
                    }

                    if (FindObjectOfType<Keyboard>().name[i] == thisletter[0] && FindObjectOfType<Keyboard>().Used[i] != true)
                    {
                        FindObjectOfType<Keyboard>().Used[i] = true;
                        if (!isKeyboard)
                            FindObjectOfType<Keyboard>().LetterBlocks[i].GetComponent<LetterPlacement>().SetLetter(GetComponent<LetterSearchSetUp>().image);
                        else
                        {
                            FindObjectOfType<Keyboard>().LetterBlocks[i].GetComponent<LetterPlacement>().SetLetter(Lower.GetComponent<Image>());

                            /*  for (int item = 0; item < FindObjectOfType<ChoiceBlock>().LetterBlocks.Count; item++)
                              {
                                  char[] wordSearchLetter = { 'B' };
                                  wordSearchLetter[0] = FindObjectOfType<ChoiceBlock>().LetterBlocks[item].GetComponent<Case_Control>().lower.ToCharArray()[0];

                                  if (wordSearchLetter[0] == thisletter[0])
                                  {
                                      FindObjectOfType<ChoiceBlock>().LetterBlocks[item].GetComponentInChildren<Button>().interactable = false;
                                      FindObjectOfType<ChoiceBlock>().LetterBlocks[item].GetComponentInChildren<Image>().color = new Color(1, 1, 1, 0.5f);
                                  }
                              }*/
                        }
                        FindObjectOfType<Keyboard>().answerString = FindObjectOfType<Keyboard>().answerString + lower;
                        //FindObjectOfType<ChoiceBlock>().LetterBlocks[FindObjectOfType<ChoiceBlock>().LetterBlocks.IndexOf(this.gameObject)].GetComponentInChildren<Button>().interactable = false;
                        // FindObjectOfType<ChoiceBlock>().LetterBlocks[FindObjectOfType<ChoiceBlock>().LetterBlocks.IndexOf(this.gameObject)].GetComponentInChildren<Image>().color = new Color(1, 1, 1, 0.5f);
                        FindObjectOfType<Keyboard>().wordSearchBox.Push(i);
                        LevelManager.instance.CheckAnswer(true, UIManager.instance.heartsAmount, UIManager.instance.seahorseAnim, FindObjectOfType<Keyboard>().PlayersName.Length, System.Enum.GetValues(typeof(UIManager.subLevels2)).Length);
                        break;
                    }


                }

                if (FindObjectOfType<Keyboard>().PlayersName.Split(thisletter[0]).Length - 1 <= 0)
                {
                    //   FindObjectOfType<ChoiceBlock>().LetterBlocks[FindObjectOfType<ChoiceBlock>().LetterBlocks.IndexOf(this.gameObject)].GetComponentInChildren<Button>().interactable = false;
                    // FindObjectOfType<ChoiceBlock>().LetterBlocks[FindObjectOfType<ChoiceBlock>().LetterBlocks.IndexOf(this.gameObject)].GetComponentInChildren<Image>().color = new Color(1, 1, 1, 0.5f);
                    miss = true;
                }

                if (miss == true)
                {
                    miss = false;
                    HMmisses++;
                    FindObjectOfType<Keyboard>().Miss();
                    // FindObjectOfType<ChoiceBlock>().LetterBlocks[FindObjectOfType<ChoiceBlock>().LetterBlocks.IndexOf(this.gameObject)].GetComponentInChildren<Button>().interactable = false;
                    //FindObjectOfType<ChoiceBlock>().LetterBlocks[FindObjectOfType<ChoiceBlock>().LetterBlocks.IndexOf(this.gameObject)].GetComponentInChildren<Image>().color = new Color(1, 1, 1, 0.5f);
                }

            }
        }


        else
        {
            if (capsCapture)
            {
                if (UIManager.instance.levelName == "Level2D")
                {
                    char[] thisletter = upper.ToCharArray();
                    if (FindObjectOfType<Keyboard>().name[FindObjectOfType<Keyboard>().letterIndex] == thisletter[0])
                    {
                        LevelManager.instance.CheckAnswer(true, UIManager.instance.heartsAmount, UIManager.instance.seahorseAnim, FindObjectOfType<Keyboard>().PlayersName.Length, System.Enum.GetValues(typeof(UIManager.subLevels2)).Length);
                        
                        FindObjectOfType<Keyboard>().LetterBlocks[FindObjectOfType<Keyboard>().letterIndex].GetComponent<LetterPlacement>().SetLetter(Upper.GetComponent<Image>());
                        FindObjectOfType<Keyboard>().answerString = FindObjectOfType<Keyboard>().answerString + upper;
                        FindObjectOfType<Keyboard>().letterIndex++;
                    }
                    else
                    {
                        LevelManager.instance.CheckAnswer(false, UIManager.instance.heartsAmount, UIManager.instance.seahorseAnim, FindObjectOfType<Keyboard>().PlayersName.Length, System.Enum.GetValues(typeof(UIManager.subLevels2)).Length);
                        FindObjectOfType<Level2C>().incorrectPanel[FindObjectOfType<Level2C>().incorrectIndex].transform.GetChild(0).GetComponent<Image>().enabled = true;
                        FindObjectOfType<Level2C>().incorrectPanel[FindObjectOfType<Level2C>().incorrectIndex].transform.GetChild(0).GetComponent<Image>().sprite = Upper.GetComponent<Image>().sprite;
                        FindObjectOfType<Level2C>().incorrectIndex++;
                    }
                }
                else
                {
                    FindObjectOfType<Keyboard>().LetterBlocks[index].GetComponent<LetterPlacement>().SetLetter(Upper.GetComponent<Image>());
                    FindObjectOfType<Keyboard>().answerString = FindObjectOfType<Keyboard>().answerString + upper;
                }
            }
            else
            {
                if (UIManager.instance.levelName == "Level2D")
                {
                    char[] thisletter = lower.ToCharArray();
                    if (FindObjectOfType<Keyboard>().name[FindObjectOfType<Keyboard>().letterIndex] == thisletter[0])
                    {
                        LevelManager.instance.CheckAnswer(true, UIManager.instance.heartsAmount, UIManager.instance.seahorseAnim, FindObjectOfType<Keyboard>().PlayersName.Length, System.Enum.GetValues(typeof(UIManager.subLevels2)).Length);
                       
                        FindObjectOfType<Keyboard>().LetterBlocks[FindObjectOfType<Keyboard>().letterIndex].GetComponent<LetterPlacement>().SetLetter(Lower.GetComponent<Image>());
                        FindObjectOfType<Keyboard>().answerString = FindObjectOfType<Keyboard>().answerString + lower;
                        FindObjectOfType<Keyboard>().letterIndex++;
                    }
                    else
                    {
                        LevelManager.instance.CheckAnswer(false, UIManager.instance.heartsAmount, UIManager.instance.seahorseAnim, FindObjectOfType<Keyboard>().PlayersName.Length, System.Enum.GetValues(typeof(UIManager.subLevels2)).Length);
                        FindObjectOfType<Level2C>().incorrectPanel[FindObjectOfType<Level2C>().incorrectIndex].transform.GetChild(0).GetComponent<Image>().enabled = true;
                        FindObjectOfType<Level2C>().incorrectPanel[FindObjectOfType<Level2C>().incorrectIndex].transform.GetChild(0).GetComponent<Image>().sprite = Lower.GetComponent<Image>().sprite;
                        FindObjectOfType<Level2C>().incorrectIndex++;
                    }
                }
                else
                {
                    FindObjectOfType<Keyboard>().LetterBlocks[index].GetComponent<LetterPlacement>().SetLetter(Lower.GetComponent<Image>());
                    FindObjectOfType<Keyboard>().answerString = FindObjectOfType<Keyboard>().answerString + lower;
                }
            }
        }


            index++;
        


    }

	public void Change_Case(bool flag){
		UpperCaseFlag = flag;
		if (flag) {
			Upper.SetActive (true);
			Lower.SetActive (false);
		}else{
			Upper.SetActive (false);
			Lower.SetActive (true);
		}
	}
	public void Delete(){
		if (index != 0)
			index--;
	}
	public  int GetIndex(){
		return index;
	}
	// Update is called once per frame
	void Update () {
		
	}
}
