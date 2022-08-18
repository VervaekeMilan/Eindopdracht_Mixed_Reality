using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public Text textarea;


    // Update is called once per frame
    public void changeText(string new_text)
    {
        textarea.text = new_text;
    }
}