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
    public GameObject levelParent;
    public GameObject levelParent2;

    void Start()
    {
        anim = GetComponent<Animator>();

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
                levelParent = LevelManager.instance.level1Capture.levelParent;

            }
        }

        for (int i = 0; i < System.Enum.GetValues(typeof(UIManager.subLevels2)).Length; i++)
        {
            if (UIManager.instance.mode2 == (UIManager.subLevels2)i)
            {
                switch (i)
                {
                    case 0:
                        LevelManager.instance.level2Capture = LevelManager.instance.level2A;
                        break;
                    case 1:
                        LevelManager.instance.level2Capture = LevelManager.instance.level2B;
                        break;
                    case 2:
                        LevelManager.instance.level2Capture = LevelManager.instance.level2C;
                        break;
                    case 3:
                        LevelManager.instance.level2Capture = LevelManager.instance.level2D;
                        break;
                    case 4:
                        LevelManager.instance.level2Capture = LevelManager.instance.level2E;
                        break;
                    case 5:
                        LevelManager.instance.level2Capture = LevelManager.instance.level2F;
                        break;
                }
                levelParent2 = LevelManager.instance.level2Capture.levelParent;

            }
        }
    }



    void Update()
    {
        if (UIManager.instance.levelName == "Campaign")
            SetState(LevelManager.instance.mainLocked);

        if (UIManager.instance.levelName == "Level1")
            SetState(LevelManager.instance.locked);

        if (UIManager.instance.levelName == "LevelDescription")
        {
            if (UIManager.instance.mode <= UIManager.subLevels1.Level1E && UIManager.instance.mode2 == UIManager.subLevels2.None)
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

            if (UIManager.instance.mode2 <= UIManager.subLevels2.Level2F && UIManager.instance.mode == UIManager.subLevels1.None)
            {
                for (int i = 0; i < 6; i++)
                {
                    if (UIManager.instance.mode2 == (UIManager.subLevels2)i)
                    {
                        switch (i)
                        {
                            case 0:
                                LevelManager.instance.level2Capture = LevelManager.instance.level2A;
                                break;
                            case 1:
                                LevelManager.instance.level2Capture = LevelManager.instance.level2B;
                                break;
                            case 2:
                                LevelManager.instance.level2Capture = LevelManager.instance.level2C;
                                break;
                            case 3:
                                LevelManager.instance.level2Capture = LevelManager.instance.level2D;
                                break;
                            case 4:
                                LevelManager.instance.level2Capture = LevelManager.instance.level2E;
                                break;
                            case 5:
                                LevelManager.instance.level2Capture = LevelManager.instance.level2F;
                                break;
                        }

                        SetState(LevelManager.instance.level2Capture.locked);
                    }
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
                if (UIManager.instance.levelName == "Campaign")
                {
                    LevelManager.instance.mainLockLevel = null;
                    Destroy(gameObject);
                    SetButtonsInteractable(true);
                    if (LevelManager.instance.levelPassed < 2)
                        LevelManager.instance.mainLockLevel = LevelManager.instance.InstantiateLock(LevelManager.instance.mainLevelParent.transform);

                    LevelManager.instance.CheckLevelState(true);
                    LevelManager.instance.mainLocked = true;
                }

                if (UIManager.instance.levelName == "Level1")
                {
                    LevelManager.instance.lockLevel = null;
                    Destroy(gameObject);
                    SetButtonsInteractable(true);
                    if (LevelManager.instance.subLevelPassed < 4)
                        LevelManager.instance.lockLevel = LevelManager.instance.InstantiateLock(LevelManager.instance.levelParent.transform);

                    LevelManager.instance.CheckLevelState(true);
                    LevelManager.instance.locked = true;

                    if (!LevelManager.instance.hasShownStoryAlready)
                        FindObjectOfType<ProgessionCheck>().StartCoroutine(FindObjectOfType<ProgessionCheck>().InstantiateStory(false, LevelManager.instance.level1Capture));
                    else
                        FindObjectOfType<ProgessionCheck>().ToggleStoryAssets(false);

                }

                if(UIManager.instance.levelName == "Level2")
                {
                    LevelManager.instance.lockLevel = null;
                    Destroy(gameObject);
                    SetButtonsInteractable(true);
                    if (LevelManager.instance.subLevelPassed < 10)
                        LevelManager.instance.lockLevel = LevelManager.instance.InstantiateLock(LevelManager.instance.levelParent.transform);

                    LevelManager.instance.CheckLevelState(true);
                    LevelManager.instance.locked = true;

                    if (!LevelManager.instance.hasShownStoryAlready)
                        FindObjectOfType<ProgessionCheck>().StartCoroutine(FindObjectOfType<ProgessionCheck>().InstantiateStory(false, LevelManager.instance.level2Capture));
                    else
                        FindObjectOfType<ProgessionCheck>().ToggleStoryAssets(false);

                }

                if (UIManager.instance.levelName == "LevelDescription")
                {
                    if (UIManager.instance.mode <= UIManager.subLevels1.Level1E && UIManager.instance.mode2 == UIManager.subLevels2.None)
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

                                UIManager.instance.MakeDifficultyButtonGlow(true);
                            }
                        }
                    }

                    if (UIManager.instance.mode2 <= UIManager.subLevels2.Level2F && UIManager.instance.mode == UIManager.subLevels1.None)
                    {
                        for (int i = 0; i < System.Enum.GetValues(typeof(UIManager.subLevels2)).Length; i++)
                        {
                            if (UIManager.instance.mode2 == (UIManager.subLevels2)i)
                            {
                                switch (i)
                                {
                                    case 0:
                                        LevelManager.instance.level2Capture = LevelManager.instance.level2A;
                                        break;
                                    case 1:
                                        LevelManager.instance.level2Capture = LevelManager.instance.level2B;
                                        break;
                                    case 2:
                                        LevelManager.instance.level2Capture = LevelManager.instance.level2C;
                                        break;
                                    case 3:
                                        LevelManager.instance.level2Capture = LevelManager.instance.level2D;
                                        break;
                                    case 4:
                                        LevelManager.instance.level2Capture = LevelManager.instance.level2E;
                                        break;
                                    case 5:
                                        LevelManager.instance.level2Capture = LevelManager.instance.level2F;
                                        break;
                                }
                                LevelManager.instance.level2Capture.lockMode = null;
                                Destroy(gameObject);
                                SetButtonsInteractable(true);
                                if (LevelManager.instance.level2Capture.modePassed < 3)
                                    LevelManager.instance.level2Capture.lockMode = LevelManager.instance.InstantiateLock(LevelManager.instance.level2Capture.levelParent.transform);

                                LevelManager.instance.CheckLevelState(true);
                                LevelManager.instance.level2Capture.locked = true;

                                UIManager.instance.MakeDifficultyButtonGlow(false);
                            }
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
