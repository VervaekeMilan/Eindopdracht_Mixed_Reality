using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARTrackedImageManager))]
public class ImageTracker : MonoBehaviour
{
    private ARTrackedImageManager manager;

    public TextManager textManager;

    public GameObject BackgroundBox;


    public Dictionary<int, GameObject> InstanciatedObject = new Dictionary<int, GameObject>();
    public GameObject[] PrefabArr;

    private readonly List<String> imageNames = new List<string>
    {
        "one",
        "lift",
        "rolluik",
        "mario",
        "remote",
        "bank",
        "headset"
    };

    // Start is called before the first frame update
    void OnEnable()
    {
        manager = GetComponent<ARTrackedImageManager>();
        manager.trackedImagesChanged += OnImageEvent;
    }

    void OnDisable()
    {
        manager.trackedImagesChanged -= OnImageEvent;
    }

    void OnImageEvent(ARTrackedImagesChangedEventArgs args)
    {
        foreach (ARTrackedImage i in args.added)
        {
            if (imageNames.Contains(i.referenceImage.name))
            {
                createAndAddInstance(PrefabArr[imageNames.IndexOf(i.referenceImage.name)], i);
                textManager.changeText(i.referenceImage.name);

                BackgroundBox.SetActive(true);
                //textManager.changeText(Convert.ToString(i.trackingState));
            }
        }

        
        foreach (ARTrackedImage i in args.updated)
        { 
            int id = i.GetInstanceID();
            
            //textManager.changeText(Convert.ToString(i.trackingState));
            if (InstanciatedObject.ContainsKey(id))
            {
                if (Convert.ToString(i.trackingState) == "Limited")
                {
                    Debug.Log("Removing object");
                    //Destroy(InstanciatedObject[id]);
                    //InstanciatedObject.Remove(id);

                    InstanciatedObject[id].SetActive(false);
                    
                    //BackgroundBox.SetActive(false);
                    //textManager.changeText(" ");

                    //InstanciatedObject.Add(id);
                    //createAndAddInstance(PrefabArr[imageNames.IndexOf(i.referenceImage.name)], i);
                }
                if (Convert.ToString(i.trackingState) == "Tracking")
                {
                    Debug.Log("updating object");
                    
                    //\\\\\\\\hier alle andere op not actief zetten
                    InstanciatedObject[id].SetActive(true);
                    //BackgroundBox.SetActive(true);
                    

                    InstanciatedObject[id].transform.position = i.transform.position;
                    InstanciatedObject[id].transform.rotation = i.transform.rotation;
                    
                }

            }
        }

        /*foreach (ARTrackedImage i in args.removed)
        {

            textManager.changeText("Removing object");
            id = i.GetInstanceID();
            if (InstanciatedObject.ContainsKey(id))
            {
                
                Debug.Log("Removing object");
                
                Destroy(InstanciatedObject[id]);
                InstanciatedObject.Remove(id);   
            }
        }*/
    }


    private void createAndAddInstance(GameObject prefab, ARTrackedImage i)
    {
        GameObject tmp = Instantiate(prefab, i.transform.position, i.transform.rotation);
        Device dev = tmp.GetComponent<Device>();
        dev.manager = textManager;
        InstanciatedObject.Add(i.GetInstanceID(), tmp);
    }
}