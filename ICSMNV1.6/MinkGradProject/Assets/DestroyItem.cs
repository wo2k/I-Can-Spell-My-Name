﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyItem : MonoBehaviour {

    Level1E level1E;
    public bool boatDestroyed;

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
        boatDestroyed = true;
        Destroy(gameObject.transform.parent.gameObject);
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
                if (UIManager.instance.inGame && boatDestroyed)
                {
                    boatDestroyed = false;
                    UIManager.instance.ScorePoints(false);
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
                if (UIManager.instance.inGame && boatDestroyed)
                {
                    level1E.AnswerCorrect = false;
                    LevelManager.instance.CheckAnswer(false, UIManager.instance.heartsAmount, UIManager.instance.seahorseAnim, (int)UIManager.instance.mode);
                    boatDestroyed = false;
                }
                else
                    return;
            }
        }
    }
}
