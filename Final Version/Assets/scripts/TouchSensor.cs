using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchSensor : MonoBehaviour
{
    public Camera arCamera;

    public ButtonScript curr_active;
    private void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = arCamera.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;
            
            Debug.Log("Shooting raycast at something!");
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    ButtonScript button = hit.collider.GetComponent<ButtonScript>();

                    if (button != null)
                    {
                        if (curr_active != null)
                        {
                            curr_active.deactivate();
                        }
                        
                        button.OnPress();
                        curr_active = button;
                    }
                }
            }
            else
            {
                Debug.Log("Hit nothing!");
            }
        }
    }
}