using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    private PlacementIndicator placementIndicator;
    private List<Vector3> randomPath;

    void Start()
    {
        placementIndicator = FindObjectOfType<PlacementIndicator>();
    }

    void Update()
    {
        // get first finger on screen and check if it's the first frame of the finger touching the screen 
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            CreateRandomPath(placementIndicator.transform.position);

            Quaternion rot = Quaternion.LookRotation(Camera.main.transform.forward);

            // Left stroke
            GameObject obj1 = Instantiate(objectToSpawn, placementIndicator.transform.position, rot);
            obj1.transform.Translate(-0.02f, 0, 0);

            // Center
            GameObject obj2 = Instantiate(objectToSpawn, placementIndicator.transform.position, rot);

            // Right
            GameObject obj3 = Instantiate(objectToSpawn, placementIndicator.transform.position, rot);
            obj3.transform.Translate(0.02f, 0, 0);
        }

    }
    private void CreateRandomPath(Vector3 indicatorPosition)
    {
        List<Vector3> path = new List<Vector3>();

        float x = indicatorPosition.x;
        float y = indicatorPosition.y;
        float z = indicatorPosition.z;

        // 5 is node count
        for (int i = 0; i < 5; i++)
        {
            x = x + Random.Range(-0.1f, 0.1f);
            y = y + Random.Range(-0.1f, 0.1f);
            z = z + Random.Range(0.0f, 0.1f);

            path.Add(new Vector3(x, y, z));
        }
        randomPath = path;
    }

    public List<Vector3> GetPath()
    {
        return randomPath;
    }
}
