using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScrollingTexture : MonoBehaviour {
	public float ScrollX = 0.05f;
	bool Negative = false;
	public Image Wave;
	// Use this for initialization
	void Start () {
		if (Negative == true)
			ScrollX = -ScrollX;
	}
	
	// Update is called once per frame
	void Update () {

	}
}
