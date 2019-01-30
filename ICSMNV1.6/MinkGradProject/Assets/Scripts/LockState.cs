using System.Collections;
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



    void Update()
    {
        if (UIManager.instance.levelName == "Level1")
            SetState(LevelManager.instance.locked);

        if (UIManager.instance.levelName == "LevelDescription")
        {
            for (int i = 0; i < 5; i++)
            {
                if (UIManager.instance.mode == (UIManager.subLevels1)i)
                {
                    switch (i)
                    {
                        case 0:
                            LevelManager.instance.level1Capture = LevelManager.instance.level1A;
                            break;
                        case 1:
                            LevelManager.instance.level1Capture = LevelManager.instance.level1B;
                            break;
                        case 2:
                            LevelManager.instance.level1Capture = LevelManager.instance.level1C;
                            break;
                        case 3:
                            LevelManager.instance.level1Capture = LevelManager.instance.level1D;
                            break;
                        case 4:
                            LevelManager.instance.level1Capture = LevelManager.instance.level1E;
                            break;
                    }

                    SetState(LevelManager.instance.level1Capture.locked);
                }
            }
        } 
           

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
                if (UIManager.instance.levelName == "Level1")
                {
                    LevelManager.instance.lockLevel = null;
                    Destroy(gameObject);
                    SetButtonsInteractable(true);
                    if (LevelManager.instance.subLevelPassed1 < 4)
                        LevelManager.instance.lockLevel = LevelManager.instance.InstantiateLock(LevelManager.instance.levelParent.transform);

                    LevelManager.instance.CheckLevelState(true);
                    LevelManager.instance.locked = true;

                    if (!LevelManager.instance.hasShownStoryAlready)
                        FindObjectOfType<ProgessionCheck>().StartCoroutine("InstantiateStory");
                    else
                        FindObjectOfType<ProgessionCheck>().ToggleStoryAssets(false);

                }
                if (UIManager.instance.levelName == "LevelDescription")
                {
                    for (int i = 0; i < System.Enum.GetValues(typeof(UIManager.subLevels1)).Length; i++)
                    {
                        if (UIManager.instance.mode == (UIManager.subLevels1)i)
                        {
                            switch (i)
                            {
                                case 0:
                                    LevelManager.instance.level1Capture = LevelManager.instance.level1A;
                                    break;
                                case 1:
                                    LevelManager.instance.level1Capture = LevelManager.instance.level1B;
                                    break;
                                case 2:
                                    LevelManager.instance.level1Capture = LevelManager.instance.level1C;
                                    break;
                                case 3:
                                    LevelManager.instance.level1Capture = LevelManager.instance.level1D;
                                    break;
                                case 4:
                                    LevelManager.instance.level1Capture = LevelManager.instance.level1E;
                                    break;
                            }
                            LevelManager.instance.level1Capture.lockMode = null;
                            Destroy(gameObject);
                            SetButtonsInteractable(true);
                            if (LevelManager.instance.level1Capture.modePassed < 3)
                                LevelManager.instance.level1Capture.lockMode = LevelManager.instance.InstantiateLock(LevelManager.instance.level1Capture.levelParent.transform);

                            LevelManager.instance.CheckLevelState(true);
                            LevelManager.instance.level1Capture.locked = true;
                        }
                    }
                }
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
