using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Fish : MonoBehaviour {

    [Header("Fish Physics")]
    public float torque;
    public float yForce;
    public float xForce;

    public enum FishDirection { Left, Right };
    public FishDirection fish;

    public List<Sprite> fishTypes = new List<Sprite>();


	// Use this for initialization
	void Start () {

        GetComponentInChildren<Button>().onClick.AddListener(delegate { FindObjectOfType<Level1D>().Choice1(gameObject); });
        
        gameObject.GetComponent<Image>().sprite = fishTypes[Random.Range(0, fishTypes.Count)];
        Vector3 fishPos = new Vector3(Random.Range(-700, 700), Random.Range(-50, -80), -32);
        gameObject.transform.localPosition = fishPos;

        float verticalFlip = Random.Range(0, 2) == 0 ? -180 : 0; //Sets if the fish will spawn facing right or left
        if (verticalFlip == -180)
            fish = FishDirection.Right;
        else
            fish = FishDirection.Left;

        Vector3 fishRot = new Vector3(0, verticalFlip, Random.Range(-30, 30));      
        gameObject.transform.localEulerAngles = fishRot;
        gameObject.transform.GetChild(0).transform.localEulerAngles = new Vector3(0, verticalFlip, 0); //Aligns Text child to match fish verticle flip

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
        if (gameObject.transform.position.y <= 200)
        {
            Destroy(gameObject);
        }
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
}
