using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMiss : MonoBehaviour {

    public Level1E level1E;
	// Use this for initialization
	void Start () {
        level1E = FindObjectOfType<Level1E>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collider)
    {

        if (collider.gameObject.name == "CannonBall" && !level1E.AnswerCorrect)
        {
            SoundManagement.TriggerEvent("PlayCannonMiss");
            LevelManager.instance.CheckAnswer(false, UIManager.instance.heartsAmount, UIManager.instance.seahorseAnim, (int)UIManager.instance.mode);
            //level1E.lockedOntoBoat = true;
            Destroy(collider.gameObject);

            foreach (EnemyBoat item in FindObjectsOfType<EnemyBoat>())
            {
                item.gameObject.transform.GetChild(0).GetComponent<Animation>()["Boat-Cruise02"].speed = 0.2f;
            }
        

        }
    }
}
