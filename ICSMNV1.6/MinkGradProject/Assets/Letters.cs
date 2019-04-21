using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letters : MonoBehaviour {
	public List<GameObject> letter;
	// Use this for initialization

	void Start () {
		
	}
	public void SetLetters (int index) {
		for(int i = 0; i < letter.Count; i++)
		{
			if (i < index)
				letter [i].SetActive (true);
				else
				letter [i].SetActive (false);
		}
	}

    public void SetLetters(int index, Transform lettersPlacement, float sizeDelta, bool hasBubbleContainer)
    {
        float letterPosX = 0;
        for (int i = 0; i < index; i++)
        {
            GameObject letters = Instantiate(Resources.Load("Prefabs/LetterPlacement"), lettersPlacement)as GameObject;
            letters.transform.localPosition = Vector2.zero;
            letters.transform.position = Vector2.zero;
            letters.transform.localPosition = new Vector3(i*200, 0, 0);
            letter.Add(letters);
            letterPosX = i * -50;
        }

        lettersPlacement.localScale = new Vector2(sizeDelta, sizeDelta);

        AdjustLettersPlacement(lettersPlacement, hasBubbleContainer, letterPosX);
        
    }

    public void AdjustLettersPlacement(Transform lettersPlacement, bool hasBubbleContainer, float letterPosX)
    {

        float widthIncrease = 0;
        Transform bubbleContainer = null;

        if (hasBubbleContainer)
            bubbleContainer = lettersPlacement.transform.parent;
        

        switch (letter.Count)
        {
            case 1:
                lettersPlacement.localPosition = Vector2.zero;
                break;
            case 2:
                lettersPlacement.localPosition = new Vector2(lettersPlacement.localPosition.x - (-letterPosX), lettersPlacement.localPosition.y);
                break;
            case 3:
                lettersPlacement.localPosition = new Vector2(lettersPlacement.localPosition.x - (-letterPosX), lettersPlacement.localPosition.y);
                break;
            case 4:
                lettersPlacement.localPosition = new Vector2(lettersPlacement.localPosition.x - (-letterPosX), lettersPlacement.localPosition.y);
                break;
            case 5:
                lettersPlacement.localPosition = new Vector2(lettersPlacement.localPosition.x - (-letterPosX), lettersPlacement.localPosition.y);
                break;
            case 6:
                lettersPlacement.localPosition = new Vector2(lettersPlacement.localPosition.x - (-letterPosX), lettersPlacement.localPosition.y);
                break;

            case 7:
                widthIncrease = 88;
                if (hasBubbleContainer)
                    lettersPlacement.localPosition = new Vector2(lettersPlacement.localPosition.x - 240, lettersPlacement.localPosition.y);
                else
                    lettersPlacement.localPosition = new Vector2(lettersPlacement.localPosition.x - (-letterPosX+50), lettersPlacement.localPosition.y);
                break;
            case 8:
                widthIncrease = 176;
                if (hasBubbleContainer)
                {
                    bubbleContainer.localScale = new Vector2(0.9f, 0.9f);
                    lettersPlacement.localScale = new Vector2(0.35f, 0.35f);
                    lettersPlacement.localPosition = new Vector2(lettersPlacement.localPosition.x - 240, lettersPlacement.localPosition.y);
                }
                else
                    lettersPlacement.localPosition = new Vector2(lettersPlacement.localPosition.x - (-letterPosX+50), lettersPlacement.localPosition.y);

                break;
            case 9:
                widthIncrease = 176;
                if (hasBubbleContainer)
                {
                    bubbleContainer.localScale = new Vector2(0.9f, 0.9f);
                    lettersPlacement.localScale = new Vector2(0.35f, 0.35f);
                    lettersPlacement.localPosition = new Vector2(lettersPlacement.localPosition.x - 280, lettersPlacement.localPosition.y);
                }
                else
                    lettersPlacement.localPosition = new Vector2(lettersPlacement.localPosition.x - (-letterPosX+50), lettersPlacement.localPosition.y);

                break;
            case 10:
                widthIncrease = 264;
                if (hasBubbleContainer)
                {
                    bubbleContainer.localScale = new Vector2(0.8f, 0.8f);
                    lettersPlacement.localScale = new Vector2(0.35f, 0.35f);
                    lettersPlacement.localPosition = new Vector2(lettersPlacement.localPosition.x - 318.8f, lettersPlacement.localPosition.y);
                }
                else
                    lettersPlacement.localPosition = new Vector2(lettersPlacement.localPosition.x - (-letterPosX+50), lettersPlacement.localPosition.y);
                break;
        }

        if (hasBubbleContainer)
        {
            RectTransform lettersPlaceholderRect = bubbleContainer.GetComponent<RectTransform>();
            RectTransformExtensions.SetWidth(lettersPlaceholderRect, RectTransformExtensions.GetWidth(lettersPlaceholderRect) + widthIncrease);
            RectTransformExtensions.SetHeight(lettersPlaceholderRect, RectTransformExtensions.GetHeight(lettersPlaceholderRect) + widthIncrease);
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
