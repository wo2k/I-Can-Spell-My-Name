using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoat : MonoBehaviour {

    public int lane;
    public Level1E level1E;
    Animation anim;
    public Collider2D boatCollider;
    public Vector3 boatPos;
    public bool animate = false;
    public int boatNumber;

	// Use this for initialization
	void Start() {

        level1E = FindObjectOfType<Level1E>();
        anim = GetComponentInChildren<Animation>();
        boatCollider = GetComponent<Collider2D>();

        boatNumber = Random.Range(0, 3);

        SetWaves();

        anim["Boat-Cruise02"].speed = 0.2f;
	}
	
	// Update is called once per frame
	void Update () {
        boatCollider.offset = new Vector2(transform.GetChild(0).localPosition.x, -118.7f);
	}

    int RandomWithExclusion(int min, int max, int exclusion)
    {
        var result = Random.Range(min, max - 1);
        return (result < exclusion) ? result : result + 1;
    }

    void SetWaves()
    {
        switch (boatNumber)
        {
            case 0:// Top

                if (!level1E.boatIDNum.Contains(0))
                    level1E.boatIDNum.Add(boatNumber);
                else
                {
                    boatNumber = RandomWithExclusion(0, level1E.boatsInWave.Count, 0);
                    SetWaves();
                }

                GetComponent<RectTransform>().sizeDelta = new Vector2(400, 400);
                transform.SetSiblingIndex(level1E.m_Lanes[0].transform.GetSiblingIndex() + 1);
                transform.localPosition = Vector3.zero;
                transform.localPosition = new Vector3(1200, 14.7f, 0.0f);
                break;

            case 1:// Middle

                if (!level1E.boatIDNum.Contains(1))
                    level1E.boatIDNum.Add(boatNumber);
                else
                {
                    boatNumber = RandomWithExclusion(0, level1E.boatsInWave.Count, 0);
                    SetWaves();
                }

                GetComponent<RectTransform>().sizeDelta = new Vector2(500, 500);
                transform.SetSiblingIndex(level1E.m_Lanes[1].transform.GetSiblingIndex() + 1);
                transform.localPosition = Vector3.zero;
                transform.localPosition = new Vector3(1200, -75.17f, 0.0f);
                break;

            case 2:// Bottom

                if (!level1E.boatIDNum.Contains(2))
                    level1E.boatIDNum.Add(boatNumber);
                else
                {
                    boatNumber = RandomWithExclusion(0, level1E.boatsInWave.Count, 0);
                    SetWaves();
                }

                GetComponent<RectTransform>().sizeDelta = new Vector2(600, 600);
                transform.SetSiblingIndex(level1E.m_Lanes[2].transform.GetSiblingIndex() + 1);
                transform.localPosition = Vector3.zero;
                transform.localPosition = new Vector3(1200, -232.3f, 0.0f);
                break;
        }

    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.name == "PlayerBoat")
        {
            level1E.boatsInWave.Remove(gameObject);
            level1E.AnswerCorrect = false;
            level1E.lockedOntoBoat = false;
            Destroy(gameObject);
            
        }

        if(collider.gameObject.name == "CannonBall" && level1E.AnswerCorrect)
        {           
            SoundManagement.TriggerEvent("PlayCannonHit");
            boatPos = transform.GetChild(0).localPosition;
            animate = true;
            anim.Play("Boat-Down");
            UIManager.instance.gameStart = false; // Pause Timer
            level1E.lockedOntoBoat = false;
            Destroy(collider.gameObject);

            
        }
    }

  

    private void OnDestroy()
    {
        
        if (level1E.AnswerCorrect)
        {
            UIManager.instance.ScorePoints(5);
            UIManager.instance.gameStart = true; // Un Pause Timer

            if (FindObjectOfType<EnemyBoat>())
            {
                foreach (EnemyBoat item in FindObjectsOfType<EnemyBoat>())
                {
                    item.gameObject.transform.GetChild(0).GetComponent<Animation>()["Boat-Cruise02"].speed = 0.2f;
                }
            }
            else
                return;
        }
        else
        {
            level1E.AnswerCorrect = false;
            LevelManager.instance.CheckAnswer(false, UIManager.instance.heartsAmount, UIManager.instance.seahorseAnim);
        }
    }

    private void LateUpdate()
    {
        if(animate)
            transform.GetChild(0).localPosition += boatPos;
    }

}
