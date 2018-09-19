using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditScreen : MonoBehaviour {

    public List<string> JobTitle;
    public List<string> Name;

    public Text Job;
    public Text Person;
    public Image BigBubbles;
    public Image SmallBubbles;

	void Start ()
    {
        Job.text = JobTitle[0].ToString();
        Person.text = Name[0].ToString();
        StartCoroutine("JobRoleAnim");
        StartCoroutine("NamesAnim");
	}
	

    IEnumerator JobRoleAnim()
    {
        foreach (string item in JobTitle)
        {
            Job.GetComponentInParent<Animation>().Play();
            BigBubbles.GetComponent<Animation>().Play();
            Job.text = item;
            yield return new WaitForSeconds(5);        
        }
        yield return StartCoroutine("JobRoleAnim");
    }

    IEnumerator NamesAnim()
    {
        foreach (string item in Name)
        {
            Person.GetComponentInParent<Animation>().Play();
            SmallBubbles.GetComponent<Animation>().Play();
            Person.text = item;
            yield return new WaitForSeconds(5);
        }
        yield return StartCoroutine("NamesAnim");
    }
}
