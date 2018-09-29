using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockState : MonoBehaviour {

    Animator anim;
    AnimatorStateInfo animState;
    AnimatorClipInfo[] animClip;
    public float animTime;

	void Start ()
    {
        anim = GetComponent<Animator>();
        
	}
	
	

	void Update () {

        SetState(!GameManager.instance.locked);

        animClip = anim.GetCurrentAnimatorClipInfo(0);
        animState = anim.GetCurrentAnimatorStateInfo(0);
        animTime = animClip[0].clip.length * animState.normalizedTime;
        //  GetAnimTime(animTime);
    }

    public void SetState(bool lockState)
    {
        if (lockState)
        {
            anim.SetTrigger("Unlock");
            //if (animTime >= 3.0f)
               // Destroy(gameObject);
        }
        else
        {
            anim.StopPlayback();
            //GameManager.instance.InstantiateLock(GameManager.instance.level1Parent.transform);
            // gameObject.GetComponent<Image>().sprite = Resources.Load("Sprite Sheets/SpriteSheet_LevelUnlock_0") as Sprite;
            gameObject.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            //anim.SetTrigger("Lock");
        }
    }
    public float GetAnimTime(float animationDuration)
    {
        animClip = anim.GetCurrentAnimatorClipInfo(0);
        animState = anim.GetCurrentAnimatorStateInfo(0);
        animationDuration = animClip[0].clip.length * animState.normalizedTime;
        return animationDuration;
    }
}
