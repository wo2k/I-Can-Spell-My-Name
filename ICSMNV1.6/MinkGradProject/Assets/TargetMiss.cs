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
            Destroy(collider.gameObject);
            FindObjectOfType<EnemyBoat>().gameObject.transform.GetChild(0).GetComponent<Animation>().Play();

        }
    }
}
