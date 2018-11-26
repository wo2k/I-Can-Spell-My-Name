using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorAnswer : MonoBehaviour {
    Level1E level1E;

    public Color green;
    public Color red;

	// Use this for initialization
	void Start () {
        level1E = FindObjectOfType<Level1E>();

        
	}
	
	// Update is called once per frame
	void Update () {
        if (GetComponentInChildren<Text>().text == level1E.answer)
            GetComponent<Image>().color = green;
        else
            GetComponent<Image>().color = red;
    }
}
