using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDescription : MonoBehaviour {

    [TextArea]
    public List<string> modeText = new List<string>();
	// Use this for initialization
	void Start () {
		
	}

    public void SetDifficulty(string mode)
    {
        switch (mode)
        {
            case "Easy":
                LevelManager.instance.m_Difficulty = LevelManager.Difficulty.Easy;
                break;
            case "Normal":
                LevelManager.instance.m_Difficulty = LevelManager.Difficulty.Normal;
                break;
            case "Hard":
                LevelManager.instance.m_Difficulty = LevelManager.Difficulty.Hard;
                break;
            case "Genius":
                LevelManager.instance.m_Difficulty = LevelManager.Difficulty.Genius;
                break;

        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
