using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadCannonAmmo : MonoBehaviour {

    public float currentValue;
    public float speed;
    public float duration = 0.02f;

    // Use this for initialization
    void Start () {

        currentValue = 100;
        StartCoroutine(ReloadCannon());
	}
	

    public IEnumerator ReloadCannon()
    {
        GetComponentInParent<Button>().enabled = false;
        while (currentValue > 0)
        {
            currentValue -= speed * Time.deltaTime;
            GetComponent<Image>().fillAmount = currentValue / 100;
            yield return new WaitForSeconds(duration);
        }
        GetComponentInParent<Button>().enabled = true;

    }

}
