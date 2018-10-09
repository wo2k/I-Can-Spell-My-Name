using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeFinder : MonoBehaviour
{
    public LevelManager.LevelType m_ButtonToMode;

    void Start()
    {
        switch (UIManager.instance.mode)
        {
            case UIManager.subLevels1.Level1A:
                LevelManager.instance.m_Mode = LevelManager.LevelType.GameMode;
                break;
            case UIManager.subLevels1.Level1B:
                LevelManager.instance.m_Mode = LevelManager.LevelType.GameMode;
                break;
            case UIManager.subLevels1.Level1C:
                LevelManager.instance.m_Mode = LevelManager.LevelType.GameMode;
                break;
            case UIManager.subLevels1.Level1D:
                LevelManager.instance.m_Mode = LevelManager.LevelType.GameMode;
                break;
            case UIManager.subLevels1.Level1E:
                LevelManager.instance.m_Mode = LevelManager.LevelType.GameMode;
                break;
            case UIManager.subLevels1.None:
                LevelManager.instance.m_Mode = LevelManager.LevelType.Menus;
                break;
        }
    }

    public void SetMode()
    {
         LevelManager.instance.m_Mode = m_ButtonToMode;
    }
}
	

