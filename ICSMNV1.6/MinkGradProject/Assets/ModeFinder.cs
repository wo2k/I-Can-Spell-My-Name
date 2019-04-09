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

        switch (UIManager.instance.mode2)
        {
            case UIManager.subLevels2.Level2A:
                LevelManager.instance.m_Mode = LevelManager.LevelType.GameMode;
                break;
            case UIManager.subLevels2.Level2B:
                LevelManager.instance.m_Mode = LevelManager.LevelType.GameMode;
                break;
            case UIManager.subLevels2.Level2C:
                LevelManager.instance.m_Mode = LevelManager.LevelType.GameMode;
                break;
            case UIManager.subLevels2.Level2D:
                LevelManager.instance.m_Mode = LevelManager.LevelType.GameMode;
                break;
            case UIManager.subLevels2.Level2E:
                LevelManager.instance.m_Mode = LevelManager.LevelType.GameMode;
                break;
            case UIManager.subLevels2.Level2F:
                LevelManager.instance.m_Mode = LevelManager.LevelType.GameMode;
                break;
            case UIManager.subLevels2.None:
                LevelManager.instance.m_Mode = LevelManager.LevelType.Menus;
                break;
        }
    }

    public void SetMode()
    {
         LevelManager.instance.m_Mode = m_ButtonToMode;
    }

    public void SetLevel(string levelName)
    {
        switch(levelName)
        {
            case "level1A":
                UIManager.instance.mode = UIManager.subLevels1.Level1A;
                LevelManager.instance.levelCaptureEditor = LevelManager.instance.level1A;
                break;
            case "level1B":
                UIManager.instance.mode = UIManager.subLevels1.Level1B;
                LevelManager.instance.levelCaptureEditor = LevelManager.instance.level1B;
                break;
            case "level1C":
                UIManager.instance.mode = UIManager.subLevels1.Level1C;
                LevelManager.instance.levelCaptureEditor = LevelManager.instance.level1C;
                break;
            case "level1D":
                UIManager.instance.mode = UIManager.subLevels1.Level1D;
                LevelManager.instance.levelCaptureEditor = LevelManager.instance.level1D;
                break;
            case "level1E":
                UIManager.instance.mode = UIManager.subLevels1.Level1E;
                LevelManager.instance.levelCaptureEditor = LevelManager.instance.level1E;
                break;

            case "level2A":
                UIManager.instance.mode2 = UIManager.subLevels2.Level2A;
                LevelManager.instance.levelCaptureEditor = LevelManager.instance.level2A;
                break;
            case "level2B":
                UIManager.instance.mode2 = UIManager.subLevels2.Level2B;
                LevelManager.instance.levelCaptureEditor = LevelManager.instance.level2B;
                break;
            case "level2C":
                UIManager.instance.mode2 = UIManager.subLevels2.Level2C;
                LevelManager.instance.levelCaptureEditor = LevelManager.instance.level2C;
                break;
            case "level2D":
                UIManager.instance.mode2 = UIManager.subLevels2.Level2D;
                LevelManager.instance.levelCaptureEditor = LevelManager.instance.level2D;
                break;
            case "level2E":
                UIManager.instance.mode2 = UIManager.subLevels2.Level2E;
                LevelManager.instance.levelCaptureEditor = LevelManager.instance.level2E;
                break;
            case "level2F":
                UIManager.instance.mode2 = UIManager.subLevels2.Level2E;
                LevelManager.instance.levelCaptureEditor = LevelManager.instance.level2E;
                break;
        }
        
    }
}
	

