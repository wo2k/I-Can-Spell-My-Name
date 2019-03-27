using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomInputField : MonoBehaviour {

    InputField inputField;

    private void Start()
    {
        inputField = GetComponent<InputField>();
    }
    public void UpdateField()
    {
        string text = inputField.text;
        text = text.Replace(" ", "");
        inputField.text = text;
    } 
}
