using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    private PlacementIndicator placementIndicator;

    void Start()
    {
        placementIndicator = FindObjectOfType<PlacementIndicator>();
    }

    void Update()
    {
        // get first finger on screen and check if it's the first frame of the finger touching the screen 
        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            var cameraForward = Camera.current.transform.forward;
            var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
            var cameraRotation = Quaternion.LookRotation(cameraBearing);
            
            GameObject obj = Instantiate(objectToSpawn, new Vector3(placementIndicator.transform.position.x - 0.02f, placementIndicator.transform.position.y, placementIndicator.transform.position.z), placementIndicator.transform.rotation);
            GameObject obj1 = Instantiate(objectToSpawn, placementIndicator.transform.position, placementIndicator.transform.rotation);
            GameObject obj3 = Instantiate(objectToSpawn, new Vector3(placementIndicator.transform.position.x + 0.02f, placementIndicator.transform.position.y, placementIndicator.transform.position.z), placementIndicator.transform.rotation);
        }

    }
}
