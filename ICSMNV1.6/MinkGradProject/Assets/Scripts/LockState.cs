﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockState : MonoBehaviour {

    Animator anim;
    AnimatorStateInfo animState;
    AnimatorClipInfo[] animClip;
    public float animTime;
    public Button[] btnObjs;

	void Start ()
    {
        anim = GetComponent<Animator>();       
	}
	
	

	void Update ()
    {
        SetState(LevelManager.instance.locked);

        animClip = anim.GetCurrentAnimatorClipInfo(0);
        animState = anim.GetCurrentAnimatorStateInfo(0);
        animTime = animClip[0].clip.length * animState.normalizedTime;
    }

    public void SetState(bool lockState)
    {
        if (!lockState)
        {
            anim.SetTrigger("Unlock");
            SetButtonsInteractable(false);
            if (animTime >= 3.0f)
            {
                LevelManager.instance.lockLevel = null;
                Destroy(gameObject);
                SetButtonsInteractable(true);
                if(LevelManager.instance.subLevelPassed1 < 4)
                LevelManager.instance.lockLevel = LevelManager.instance.InstantiateLock(LevelManager.instance.levelParent.transform);

                LevelManager.instance.CheckLevelState(true);
                LevelManager.instance.locked = true;
            }
        }
        else
        {
        }
    }

    public float GetAnimTime(float animationDuration)
    {
        animClip = anim.GetCurrentAnimatorClipInfo(0);
        animState = anim.GetCurrentAnimatorStateInfo(0);
        animationDuration = animClip[0].clip.length * animState.normalizedTime;
        return animationDuration;
    }

    public void SetButtonsInteractable(bool interactable)
    {
        if (interactable)
        {
            btnObjs = FindObjectsOfType<Button>();

            foreach (Button button in btnObjs)
            { 
                button.interactable = true;
            }
        }
        else
        {
            btnObjs = FindObjectsOfType<Button>();

            foreach (Button button in btnObjs)
            {
                button.interactable = false;
            }
        }
    }
}
