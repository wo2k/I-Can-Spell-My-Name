using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BubbleParticle : MonoBehaviour {

    private Color randomAlpha;
    private float currentAlpha;
    private float ranTorque;
    public float torque;
    
    void Start()
    {
        randomAlpha = new Color(1, 1, 1, Random.Range(0.3f, 0.5f));
        ranTorque = Random.Range(0, 2) == 0 ? -torque : torque;
        gameObject.GetComponent<Image>().color = randomAlpha;
        InvokeRepeating("ReduceAlpha", 0.3f, 0.5f);
    }

    void ReduceAlpha()
    {
        currentAlpha = gameObject.GetComponent<Image>().color.a;

        if (gameObject.GetComponent<Image>().color.a <= 0.1f)
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.GetComponent<Image>().color = new Color(1, 1, 1, currentAlpha - 0.1f);
        }
    }

    private void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().AddTorque(ranTorque); 
    }
}

