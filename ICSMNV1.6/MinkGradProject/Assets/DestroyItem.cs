using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyItem : MonoBehaviour {

    Level1E level1E;

	// Use this for initialization
	void Start () {

        if(FindObjectOfType<Level1E>())
        level1E = FindObjectOfType<Level1E>();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DestroyBoat()
    {
        Destroy(gameObject);
    }

    public void DestroyThis()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        if (UIManager.instance.mode == UIManager.subLevels1.Level1E)
        {
            if (level1E.AnswerCorrect)
            {
                if (UIManager.instance.inGame)
                {
                    UIManager.instance.ScorePoints(5);
                    UIManager.instance.gameStart = true; // Un Pause Timer
                    FindObjectOfType<Level1E>().PlaceAnswer();
                    if (FindObjectOfType<EnemyBoat>())
                    {
                        foreach (EnemyBoat item in FindObjectsOfType<EnemyBoat>())
                        {
                            item.gameObject.transform.GetChild(0).GetComponent<Animation>()["Boat-Cruise02"].speed = 0.2f;
                        }
                    }
                    else
                        return;
                }
            }
            else
            {
                if (UIManager.instance.inGame)
                {
                    level1E.AnswerCorrect = false;
                    LevelManager.instance.CheckAnswer(false, UIManager.instance.heartsAmount, UIManager.instance.seahorseAnim);
                }
                else
                    return;
            }
        }
    }
}
