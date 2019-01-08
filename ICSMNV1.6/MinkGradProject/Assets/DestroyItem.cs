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
        level1E.boatsInWave.Remove(gameObject.transform.parent.gameObject);
        Destroy(gameObject.transform.parent.gameObject);
    }

    public void DestroyThis()
    {
        Destroy(gameObject);
    }
}
