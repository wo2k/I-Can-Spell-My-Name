using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour {
	public static FadeScript instance {set; get;}
	public Image FadeObject;
	bool isPlaying;
	float Ratio;
	bool isVisable;
	float Duration;
	// Use this for initialization
	void Start () {
		
	}

	void Awake () {
		instance = this;
	}
	public void Fade(bool On_Off , float duration) {

		isVisable = On_Off;
		isPlaying = true;
		Duration = duration;
		Ratio = (isVisable) ? 0 : 1;
	}
	// Update is called once per frame
	void Update () {

		if (!isPlaying) {
			FadeObject.raycastTarget = false;
			return;
		}
		FadeObject.raycastTarget = true;
		Ratio += (isVisable) ? Time.deltaTime * (1/ Duration) : -Time.deltaTime * (1/Duration);
	
		FadeObject.color =  Color.Lerp (Color.clear, Color.black, Ratio);

		if (Ratio >= 1 || Ratio <= 0)
			isPlaying = false;
		
	}
}
