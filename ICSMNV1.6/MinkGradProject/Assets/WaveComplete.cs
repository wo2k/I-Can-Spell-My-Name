using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveComplete : MonoBehaviour {

    public Level1C level1C;
    public float time;
    public float animDuration;

    void Start()
    {
        level1C = FindObjectOfType<Level1C>();
    }

    private void Update()
    {
        time += Time.deltaTime;
        animDuration = gameObject.GetComponent<Animation>().clip.length;
        animDuration -= time;

            if (animDuration <= 0.0f)
            {
                level1C.NextLetter();
                level1C.rightBoat.Clear();
                time = 0;
            }
            
    }
}
