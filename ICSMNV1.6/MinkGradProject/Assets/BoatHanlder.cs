using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatHanlder : MonoBehaviour {

    public GameObject[] m_RightBoats;
    public GameObject[] m_LeftBoats;
    public Vector3 boatPos;
    public int levelSection = 0;
    public GameObject m_Parent;
    public GameObject m_Child;
    public GameObject m_Waves;
    public int rightBoat, leftBoat; 

	// Use this for initialization
	void Start ()
    {
        ReRouteBoat();    
	}
	
    public void ReRouteBoat()
    {
        for(int i = 0; i < FindObjectsOfType<Level1C>().Length; i++)
          FindObjectsOfType<Level1C>()[i].NextLetter();

        levelSection = Random.Range(0, 2);

        if (levelSection == 0)//Boat cruising to left
        {
            rightBoat = Random.Range(0, m_RightBoats.Length+1);
            boatPos = m_RightBoats[rightBoat].transform.position;
            transform.position = boatPos;
            SetWaveLane(rightBoat);
            m_Parent.transform.rotation = new Quaternion(0, 0, 0, 0);
            m_Child.transform.localEulerAngles = new Vector3(0, 0, 0);
        }

        if (levelSection == 1)//Boat cruising to right
        {
            leftBoat = Random.Range(0, m_LeftBoats.Length+1);
            boatPos = m_LeftBoats[leftBoat].transform.position;
            transform.position = boatPos;
            SetWaveLane(leftBoat);
            m_Parent.transform.rotation = new Quaternion(0, -180, 0, 0);
            m_Child.transform.localEulerAngles = new Vector3(0,-180,0);
        }
    }

    public void SetWaveLane(int boatNumber)
    {
        m_Parent.transform.SetParent(m_Waves.transform);

        switch(boatNumber)
        {
            case 0:
                m_Parent.transform.SetSiblingIndex(1);
                break;
            case 1:
                m_Parent.transform.SetSiblingIndex(5);
                break;
            case 2:
                m_Parent.transform.SetSiblingIndex(7);
                break;
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
