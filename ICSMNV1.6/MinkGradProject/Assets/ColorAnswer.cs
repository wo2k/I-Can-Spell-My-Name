using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Serialization;

public class ColorAnswer : MonoBehaviour {

    Level1A level1A;
    Level1B level1B;
    Level1C level1C;
    Level1D level1D;
    Level1E level1E;
    
    object[] level = new object[5];
    object[] castToLevel = new object[5];
    public Color green;
    public Color red;
    bool setColor;
    public Image imageToColor; 

	// Use this for initialization
	void Start () {
           for (int i = 0; i < 5; i++)
           {
               if (UIManager.instance.mode == (UIManager.subLevels1)i)
               {
                   switch (i)
                   {
                       case 0:
                           level1A = FindObjectOfType<Level1A>();
                           break;
                       case 1:
                           level1B = FindObjectOfType<Level1B>();
                           break;
                       case 2:
                           level1C = FindObjectOfType<Level1C>();
                           break;
                       case 3:
                           level1D = FindObjectOfType<Level1D>();
                           break;
                       case 4:
                           level1E = FindObjectOfType<Level1E>();
                           break;
                   }
               }
           }
    }

    void AssignOnMode(object[] variable, object[] castTo )
    {
        variable = new object[5];
        castTo = new object[5];
        for (int i = 0; i < 5; i++)
        {
            if (UIManager.instance.mode == (UIManager.subLevels1)i)
            {
                switch (i)
                {
                    case 0:
                        variable[i] = castTo[i];
                        break;
                    case 1:
                        variable[i] = castTo[i];
                        break;
                    case 2:
                        variable[i] = castTo[i];
                        break;
                    case 3:
                        variable[i] = castTo[i];
                        break;
                    case 4:
                        variable[i] = castTo[i];
                        break;
                }
            }
        }
    }
	
	// Update is called once per frame
	void Update () {

        for (int i = 0; i < 5; i++)
        {
            if (UIManager.instance.mode == (UIManager.subLevels1)i && LevelManager.instance.m_Difficulty == LevelManager.Difficulty.Easy)
            {
                switch (i)
                {
                    case 0:
                        if (GetComponentInChildren<Text>().text == level1A.answer)
                            GetComponent<Image>().color = green;
                        else
                            GetComponent<Image>().color = red;
                        break;
                    case 1:
                        if (GetComponentInParent<Text>().text == level1B.answer)
                        {
                            if (GetComponentInParent<Text>())
                                GetComponentInParent<Text>().color = green;
                            imageToColor.color = green;
                        }
                        else
                        {
                            if (GetComponentInParent<Text>())
                                GetComponentInParent<Text>().color = red;
                            imageToColor.color = red;
                        }
                        break;
                    case 2:
                        if (GetComponentInChildren<Text>().text == level1C.answer)
                            GetComponent<Image>().color = green;
                        else
                            GetComponent<Image>().color = red;
                        break;
                    case 3:
                        if (GetComponentInChildren<Text>().text == level1D.answer)
                            GetComponent<Image>().color = green;
                        else
                            GetComponent<Image>().color = red;
                        break;
                    case 4:
                        if (GetComponentInChildren<Text>().text == level1E.answer)
                            GetComponent<Image>().color = green;
                        else
                            GetComponent<Image>().color = red;
                        break;
                }
            }
        }

    }
}
