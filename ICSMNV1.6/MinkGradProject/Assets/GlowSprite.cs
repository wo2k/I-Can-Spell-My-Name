using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlowSprite : MonoBehaviour {

    public float speed = 1.0f;
    public float timeTakenDuringLerp = 1f;
    public Color startColor = new Color(1, 1, 0, 1);
    public Color endColor = new Color(1, 1, 0, 0.3f);
    public Color glowEffect;
    public bool repeatable = true;
    public float alpha;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
        if(!repeatable)
        {
            float t = (Time.time - 0) * speed;
            Color glowEffect = Color.Lerp(startColor, endColor, t);
            GetComponent<Image>().material.SetColor("_OutlineColor", glowEffect); 
        }	
        else
        {
             float t = Mathf.PingPong(Time.time, 1);

            t = t * t * (3f - 2f * t);

            glowEffect = Color.Lerp(startColor, endColor,  t);
            alpha = glowEffect.a;
            GetComponent<Image>().material.SetColor("_OutlineColor", glowEffect);

        }
	}

}
