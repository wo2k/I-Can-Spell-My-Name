using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechBubble : MonoBehaviour {

    Animation bubbleAnim;

	// Use this for initialization
	void Start () {
        StartCoroutine(InstantiateBubble());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public IEnumerator InstantiateBubble()
    {

        bubbleAnim = GetComponent<Animation>();

        bubbleAnim.Play();

        // if (!speechBubble.activeSelf)
        if (gameObject == null)
        {
            yield return new WaitUntil(() => GameObjectExtensions.IsDestroyed(gameObject));
            yield return null;
        }
        yield return new WaitForSeconds(2.5f);

        // if (!speechBubble.activeSelf)
        if (gameObject == null)
        {
            yield return new WaitUntil(() => GameObjectExtensions.IsDestroyed(gameObject));
            yield return null;
        }

        //Reverse animation
        bubbleAnim["Sea-Horse-Bubble"].time = bubbleAnim["Sea-Horse-Bubble"].length;
        bubbleAnim["Sea-Horse-Bubble"].speed = -1;
        bubbleAnim.Play();
        //Reverse animation

        yield return new WaitForSeconds(2.5f);

        //if (!speechBubble.activeSelf)
        if (gameObject == null)
        {
            yield return new WaitUntil(() => GameObjectExtensions.IsDestroyed(gameObject));
            yield return null;
        }

        //Deletes current instance of speech bubble after completing reverse animation
        Destroy(gameObject);
       // bubbleQueue.Clear();
    }
}
