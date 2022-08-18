using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Device : MonoBehaviour
{
    // Start is called before the first frame update

    public TextManager manager;

    void Start()
    {
        ButtonScript[] children = GetComponentsInChildren<ButtonScript>(true);
        for (int i = 0; i < children.Length; i++)
        {
            children[i].manager = manager;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}