using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatHanlder : MonoBehaviour {

    public List<GameObject> m_RightBoats = new List<GameObject>();
    public List<GameObject> m_LeftBoats = new List<GameObject>();
    public Vector3 boatPos;
    public int levelSection = 0;
    public GameObject m_Parent;
    public GameObject m_Child;
    public int rightBoat = 0;
    public int siblingIndex;

    public Level1C level1C;
	


	void Start ()
    {
        level1C = FindObjectOfType<Level1C>();
        ReRouteBoat();    
	}

    public void ReRouteBoat()
    {
        levelSection = Random.Range(0, 2);

        if (levelSection == 0)//Boat cruising to Right
        {         
            rightBoat = Random.Range(0, 3);
            SetWaveLane(rightBoat);

            boatPos = m_RightBoats[rightBoat].transform.localPosition;
            transform.parent.localPosition = boatPos;
            
            
            m_Parent.transform.rotation = new Quaternion(0, 0, 0, 0);
            m_Child.transform.localEulerAngles = new Vector3(0, 0, 0);

        }

        if (levelSection == 1)//Boat cruising to Left
        {
            rightBoat = Random.Range(0, 3);
            SetWaveLane(rightBoat);

            boatPos = m_LeftBoats[rightBoat].transform.localPosition;
            transform.parent.localPosition = boatPos;
            
            
            m_Parent.transform.rotation = new Quaternion(0, -180, 0, 0);
            m_Child.transform.localEulerAngles = new Vector3(0,-180,0);

        }

    }

    int RandomWithExclusion(int min, int max, int exclusion)
    {
        var result = Random.Range(min, max - 1);
        return (result < exclusion) ? result : result + 1;
    }

    public void SetWaveLane(int boatNumber)
    {
       // m_Parent.transform.SetParent(m_Waves.transform);

        switch(boatNumber)
        {
            case 0:
                // siblingIndex = 1;
                if (!level1C.rightBoat.Contains(0))
                    level1C.rightBoat.Add(boatNumber);
                else
                {
                    rightBoat = RandomWithExclusion(0, m_RightBoats.Count, 0);
                    SetWaveLane(rightBoat);
                }
                //m_Parent.transform.SetSiblingIndex(siblingIndex);
                break;
            case 1:
                // siblingIndex = 5;
                if (!level1C.rightBoat.Contains(1))
                    level1C.rightBoat.Add(boatNumber);
                else
                {
                    rightBoat = RandomWithExclusion(0, m_RightBoats.Count, 1);
                    SetWaveLane(rightBoat);
                }
                // m_Parent.transform.SetSiblingIndex(siblingIndex);
                break;
            case 2:
                if (!level1C.rightBoat.Contains(2))
                    level1C.rightBoat.Add(boatNumber);
                else
                {
                    rightBoat = RandomWithExclusion(0, m_RightBoats.Count, 2);
                    SetWaveLane(rightBoat);
                }
                // siblingIndex = 7;
                // m_Parent.transform.SetSiblingIndex(siblingIndex);
                break;
        }
    }

    public void RestartAnimation()
    {
        GetComponent<Animation>().Rewind();
        GetComponent<Animation>().Play();
    }

	// Update is called once per frame
	void Update () {

    }
}
