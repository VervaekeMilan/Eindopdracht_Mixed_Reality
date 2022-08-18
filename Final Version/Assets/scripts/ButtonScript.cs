using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public string info;

    public TextManager manager;

    public Color activeColor = new Color(0,1,0,1);
    public Color unactiveColor = new Color(1,1,1,1);

    private void Start()
    {
        deactivate();
    }

    public void OnPress()
    {
        manager.changeText(info);
        ChangeColor(activeColor);
    }

    public void deactivate()
    {
        ChangeColor(unactiveColor);
    }


    public void ChangeColor(Color c)
    {
        Debug.Log("Changing color to "+ c.ToString());
        GetComponent<MeshRenderer>().material.color = c;
    }
}