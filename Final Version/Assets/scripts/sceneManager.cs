using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneManager : MonoBehaviour
{

    public GameObject[] ImgArr;

    public short toggleButton;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject i in ImgArr)
            i.SetActive(false);
    }

    public void onClick()
    {
        if (toggleButton == 0)
        {
            ImgArr[0].SetActive(true);
            toggleButton++;
        }
        else if (toggleButton == 1)
        {
            ImgArr[0].SetActive(false);
            ImgArr[1].SetActive(true);
            toggleButton++;
        }
        else if (toggleButton == 2)
        {
            ImgArr[1].SetActive(false);
            toggleButton = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
