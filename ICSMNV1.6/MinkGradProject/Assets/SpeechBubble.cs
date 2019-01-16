using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechBubble : MonoBehaviour {

    public Animation bubbleAnim;
    public bool turnPage;
    public string animationName;
    public float animationTime;
    public float animationTimeOut;

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
        bubbleAnim.Rewind();

        bubbleAnim.Play();

        foreach (AnimationState state in bubbleAnim)
            animationName = state.name;

      
        if (gameObject == null)
        {
            yield return new WaitUntil(() => GameObjectExtensions.IsDestroyed(gameObject));
            yield return null;
        }

        if (UIManager.instance.levelName == "Level1")
            yield return new WaitUntil(() => turnPage);
        else
            yield return new WaitForSeconds(animationTime);

        
        if (gameObject == null)
        {
            yield return new WaitUntil(() => GameObjectExtensions.IsDestroyed(gameObject));
            yield return null;
        }

        if (UIManager.instance.levelName == "Level1")
            yield return new WaitUntil(() => turnPage);

        //Reverse animation
        bubbleAnim[animationName].time = bubbleAnim[animationName].length;
        bubbleAnim[animationName].speed = -1;
        bubbleAnim.Play();
        //Reverse animation

     
        yield return new WaitForSeconds(animationTimeOut);

      
        if (gameObject == null)
        {
            yield return new WaitUntil(() => GameObjectExtensions.IsDestroyed(gameObject));
            yield return null;
        }

        //Deletes current instance of speech bubble after completing reverse animation
        if (UIManager.instance.levelName == "Level1")
        {
            Destroy(gameObject.transform.parent.gameObject);
            FindObjectOfType<ProgessionCheck>().turnPage = false;
            if (gameObject == null)
            {
                yield return new WaitUntil(() => GameObjectExtensions.IsDestroyed(gameObject));
                yield return null;
            }
        }
        else
            Destroy(gameObject);
       // bubbleQueue.Clear();
    }
}
