using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        if (!GameManager.instance.locked)
            anim.SetTrigger("Unlock");
        animClip = anim.GetCurrentAnimatorClipInfo(0);
        animState = anim.GetCurrentAnimatorStateInfo(0);
        animTime = animClip[0].clip.length * animState.normalizedTime;
    }
}
