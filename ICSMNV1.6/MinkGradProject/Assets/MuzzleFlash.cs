using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuzzleFlash : MonoBehaviour {

    public float smokeLength = 0;
    public float duration = 0.5f;

	
	void Start () {

        StartCoroutine(AnimateOverTime(GetComponent<Image>().color, new Color(1, 1, 1, 0), duration));
	}
	

    IEnumerator AnimateOverTime(Color start, Color end, float duration)
    {
        for (float t = 0f; t < duration; t += Time.deltaTime)
        {
            float normalizedTime = t / duration;
            //right here, you can now use normalizedTime as the third parameter in any Lerp from start to end
            GetComponent<Image>().color = Color.Lerp(start, end, normalizedTime);
            smokeLength += 0.3f;
            transform.localPosition += new Vector3(smokeLength, 0, 0);
            yield return null;
        }
        GetComponent<Image>().color = end; //without this, the value will end at something like 0.9992367
    }
}
