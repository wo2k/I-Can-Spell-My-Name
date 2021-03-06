﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CannonBall : MonoBehaviour
{

    public Rigidbody2D physics;
    //[SerializeField]
    //[Range(10f, 80f)]
    //private float angle = 45f;

    public GameObject target;
    public Vector3 targetPos;
    public Level1E level1E;
    //private int numOfTrajectoryPoints = 30;
    //private List<GameObject> trajectoryPoints = new List<GameObject>();

    bool hasFired = false;

    private CanvasScaler canvasScalar;
    private Vector2 ScreenScale
    {
        get
        {
            if (canvasScalar == null)
                canvasScalar = FindObjectOfType<CanvasScaler>();

            if (canvasScalar)
            {
                return new Vector2(canvasScalar.referenceResolution.x / Screen.width, canvasScalar.referenceResolution.y / Screen.height);
            }

            else
                return Vector2.one;
        }
    }

    public int lane;

    // Use this for initialization
    void Start()
    {
        canvasScalar = FindObjectOfType<CanvasScaler>();
        level1E = FindObjectOfType<Level1E>();
        physics = GetComponent<Rigidbody2D>();

        if (level1E.AnswerCorrect)
        {
            target = FindObjectOfType<EnemyBoat>().transform.GetChild(0).gameObject;
            targetPos = target.transform.position;
        }
        else
        {
            lane = Random.Range(0, level1E.targetMiss.Count);
            target = level1E.targetMiss[lane].gameObject;
            SetWaves(lane);
            targetPos = target.transform.localPosition;

            if (FindObjectOfType<EnemyBoat>())
            {
                foreach (EnemyBoat item in FindObjectsOfType<EnemyBoat>())
                    Physics2D.IgnoreCollision(GetComponent<CircleCollider2D>(), item.GetComponent<BoxCollider2D>());
            }
        }

    }

    void SetWaves(int lane)
    {
        transform.SetParent(level1E.m_Waves.transform);

        switch (lane)
        {
            case 0:// Top
                transform.SetSiblingIndex(level1E.m_Lanes[0].transform.GetSiblingIndex() + 1);
                break;
            case 1:// Middle
                transform.SetSiblingIndex(level1E.m_Lanes[1].transform.GetSiblingIndex() + 1);
                break;
            case 2:// Bottom
                transform.SetSiblingIndex(level1E.m_Lanes[2].transform.GetSiblingIndex() + 1);
                break;
        }

    }

    void FireAtWill()
    {
        //if(canvasScalar.referenceResolution == new Vector2(1920, 1080))
         //   physics.AddForce(GetForceFrom(transform.localPosition / 1, targetPos / 1, new Vector3(750, -250, 0)) / 1, ForceMode2D.Impulse);
       // else
            physics.AddForce(GetForceFrom(transform.localPosition / ScreenScale, targetPos / ScreenScale, new Vector3(900, -205, 0))/ ScreenScale, ForceMode2D.Impulse);
        hasFired = true;
    }

    void Update()
    {

        targetPos = target.transform.position;

        if (hasFired)
            return;

        if (!hasFired)
            FireAtWill();

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 1);
        Gizmos.DrawLine(level1E.muzzlePos.position, targetPos);
    }


    private Vector2 GetForceFrom(Vector3 fromPos, Vector3 toPos, Vector3 speed)
    {
        return (new Vector2(toPos.x, toPos.y) - new Vector2(fromPos.x, fromPos.y) - new Vector2(speed.x, speed.y));
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.name == "PlayerBoat")
        {
            if(gameObject && collider.gameObject)
                Physics2D.IgnoreCollision(GetComponent<CircleCollider2D>(), collider.gameObject.GetComponent<BoxCollider2D>());
        }
    }
}
