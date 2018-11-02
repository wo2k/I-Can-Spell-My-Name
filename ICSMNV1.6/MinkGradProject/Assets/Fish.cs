﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Fish : MonoBehaviour {
    public Level1D level1D;

    [Header("Fish Physics")]
    public float torque;
    public float yForce;
    public float xForce;

    public enum FishDirection { Left, Right };
    public FishDirection fish;

    public enum FishMood { Good, Bad };
    public FishMood mood;

    public List<Sprite> fishTypes = new List<Sprite>();

    



    public bool isFalling = false;
    public bool hasChanged = false;

    // Use this for initialization
    void Start () {
        level1D = FindObjectOfType<Level1D>();

        GetComponentInChildren<Button>().onClick.AddListener(delegate { FindObjectOfType<Level1D>().Choice1(gameObject); });
        
        gameObject.GetComponent<Image>().sprite = fishTypes[Random.Range(0, fishTypes.Count)];

        CheckMood();
     
        Vector3 fishPos = new Vector3(Random.Range(-700, 700), Random.Range(-50, -80), -32);
        gameObject.transform.localPosition = fishPos;

        SetWaves();

        Vector3 throwForce;
        if (fish == FishDirection.Left)
        {
            throwForce = new Vector3(-xForce, yForce, 0);
        }
        else
        {
            throwForce = new Vector3(xForce, yForce, 0);
        }
        gameObject.GetComponent<Rigidbody2D>().AddForce(throwForce, ForceMode2D.Impulse);

     
    }
	
	// Update is called once per frame
	void Update () {
        if (gameObject.transform.position.y <= -150)
        {
            Destroy(gameObject);
        }

        if (gameObject.GetComponent<Rigidbody2D>().velocity.y <= 0 && !hasChanged)
            isFalling = true;

        ChangeLane();
    }

    private void FixedUpdate()
    {
        if (fish == FishDirection.Left)
        {
            gameObject.GetComponent<Rigidbody2D>().AddTorque(torque);
        }
        else
        {
            gameObject.GetComponent<Rigidbody2D>().AddTorque(-torque);
        }

    }

    void CheckMood()
    {
        switch (mood)
        {
            case FishMood.Good:
                break;
            case FishMood.Bad:
                GetComponent<Image>().color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
                break;
        }
    }

    void ChangeLane()
    {
        if (isFalling)
        {
            transform.SetSiblingIndex(Random.Range(1, 6));
            isFalling = false;
            hasChanged = true;
        }
    }

    void SetWaves()
    {

        float verticalFlip = Random.Range(0, 2) == 0 ? -180 : 0; //Sets if the fish will spawn facing right or left
        if (verticalFlip == -180)
            fish = FishDirection.Right;
        else
            fish = FishDirection.Left;

        Vector3 fishRot = new Vector3(0, verticalFlip, Random.Range(-30, 30));
        gameObject.transform.localEulerAngles = fishRot;
        gameObject.transform.GetChild(0).transform.localEulerAngles = new Vector3(0, verticalFlip, 0); //Aligns Text child to match fish verticle flip


        if (fish == FishDirection.Right)
        {
            transform.SetParent(level1D.m_Waves.transform);
            transform.SetSiblingIndex(Random.Range(1, 6));
        }

        if (fish == FishDirection.Left)
        {
            transform.SetParent(level1D.m_Waves.transform);
            transform.SetSiblingIndex(Random.Range(1, 6));

        }
    }
}
