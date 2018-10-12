using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditScreen : MonoBehaviour {

    [Header("Credit Settings")]
    public bool LoopCredits;
    public int CreditSpeed;

    public List<string> JobTitle;
    public List<string> PrimaryName;
    public List<string> SecondaryName;
    public List<string> ThirdName;
    [Space]
    public Text Job;
    public Text Person01;
    public Text Person02;
    public Text Person03;
    public Image BigBubbles;
    public Image SmallBubbles;

    bool isPaused;
    bool isPausedThird;

	void Start ()
    {
        UIManager.instance.mode = UIManager.subLevels1.None;
        Job.text = JobTitle[0].ToString();
        Person01.text = PrimaryName[0].ToString();
        StartCoroutine("JobRoleAnim");
        StartCoroutine("PrimaryNameAnim");
        StartCoroutine("SecondaryNameAnim");
        StartCoroutine("ThirdNameAnim");
    }
	

    IEnumerator JobRoleAnim()
    {
        foreach (string item in JobTitle)
        {
            Job.GetComponentInParent<Animation>().Play();
            BigBubbles.GetComponent<Animation>().Play();
            SoundManagement.TriggerEvent("Bubbles01");
            Job.text = item;
            yield return new WaitForSeconds(CreditSpeed);        
        }
        if (LoopCredits)
            yield return StartCoroutine("JobRoleAnim");
        else
            yield break;
    }

    IEnumerator PrimaryNameAnim()
    {
        isPaused = true;
        isPausedThird = true;

        foreach (string item in PrimaryName)
        {

            if (item == PrimaryName[1])
                isPaused = false;

            if (item == PrimaryName[3])
                isPaused = true;

            if (item == PrimaryName[4])
            {
                isPaused = false;
                isPausedThird = false;
            }

              if (item == PrimaryName[5])
                 isPausedThird = true;

            if (item == PrimaryName[6])
                isPaused = true;

            Person01.GetComponentInParent<Animation>().Play();
            SmallBubbles.GetComponent<Animation>().Play();
            Person01.text = item;
            yield return new WaitForSeconds(CreditSpeed);

    
        }
        if (LoopCredits)
            yield return StartCoroutine("PrimaryNameAnim");
        else
            yield break;
    }

    IEnumerator SecondaryNameAnim()
    {
        foreach (string item in SecondaryName)
        {
            while (isPaused)
            {
                Person02.text = "";
                yield return null;
            }

            Person02.GetComponentInParent<Animation>().Play();
            Person02.text = item;
            yield return new WaitForSeconds(CreditSpeed);

            while (isPaused)
            {
                Person02.text = "";
                yield return null;
            }
        }
        if (LoopCredits)
            yield return StartCoroutine("SecondaryNameAnim");
        else
            yield break;
    }

    IEnumerator ThirdNameAnim()
    {
        foreach (string item in ThirdName)
        {
            while (isPausedThird)
            {
                Person03.text = "";
                yield return null;
            }

            Person03.GetComponentInParent<Animation>().Play();
            Person03.text = item;
            yield return new WaitForSeconds(CreditSpeed);

            while (isPausedThird)
            {
                Person03.text = "";
                yield return null;
            }
        }
        if (LoopCredits)
            yield return StartCoroutine("ThirdNameAnim");
        else
            yield break;
    }
}
