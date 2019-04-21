using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockOn : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == FindObjectOfType<Level1E>().boatsInWave[0].name)
            FindObjectOfType<Level1E>().lockedOntoBoat = true;
    }

    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
