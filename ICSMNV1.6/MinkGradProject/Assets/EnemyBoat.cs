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

	// Use this for initialization
	void Start() {

        level1E = FindObjectOfType<Level1E>();
        anim = GetComponentInChildren<Animation>();
        boatCollider = GetComponent<Collider2D>();
        SetWaves();
        anim["Boat-Cruise02"].speed = 0.3f;
	}
	
	// Update is called once per frame
	void Update () {
        boatCollider.offset = new Vector2(transform.GetChild(0).localPosition.x, -118.7f);
	}

    void SetWaves()
    {
        lane = Random.Range(0, 3);

        switch(lane)
        {
            case 0:// Top
                GetComponent<RectTransform>().sizeDelta = new Vector2(400, 400);
                transform.SetSiblingIndex(level1E.m_Lanes[0].transform.GetSiblingIndex()+1);
                transform.localPosition = Vector3.zero;
                transform.localPosition = new Vector3(1200, 14.7f, 0.0f);
                break;
            case 1:// Middle
                GetComponent<RectTransform>().sizeDelta = new Vector2(500, 500);
                transform.SetSiblingIndex(level1E.m_Lanes[1].transform.GetSiblingIndex()+1);
                transform.localPosition = Vector3.zero;
                transform.localPosition = new Vector3(1200, -75.17f, 0.0f);
                break;
            case 2:// Bottom
                GetComponent<RectTransform>().sizeDelta = new Vector2(600, 600);
                transform.SetSiblingIndex(level1E.m_Lanes[2].transform.GetSiblingIndex()+1);
                transform.localPosition = Vector3.zero;
                transform.localPosition = new Vector3(1200, -232.3f, 0.0f);
                break;
        }            

    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.name == "PlayerBoat")
        {
            Destroy(gameObject);
            LevelManager.instance.CheckAnswer(false, UIManager.instance.heartsAmount, UIManager.instance.seahorseAnim);
        }

        if(collider.gameObject.name == "CannonBall")
        {
            SoundManagement.TriggerEvent("PlayCannonHit");
            boatPos = transform.GetChild(0).localPosition;
            animate = true;
            anim.Play("Boat-Down");
            Destroy(collider.gameObject);
            
        }
    }

    private void OnDestroy()
    {
        UIManager.instance.ScorePoints(5);
    }

    private void LateUpdate()
    {
        if(animate)
            transform.GetChild(0).localPosition += boatPos;
    }

}
