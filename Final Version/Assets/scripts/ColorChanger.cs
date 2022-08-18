using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public Color inactive;
    public Color active;

    public void changeColor(MeshRenderer renderer)
    {
        renderer.material.color = getRandomColor();
    }

    public Color getRandomColor()
    {
        return new Color(UnityEngine.Random.Range(0.0f, 1.0f),
            UnityEngine.Random.Range(0.0f, 1.0f),
            UnityEngine.Random.Range(0.0f, 1.0f), 1.0f);
    }
}