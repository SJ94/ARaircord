using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailFollowsPath : MonoBehaviour
{
    public float time;
    private ObjectSpawner objectSpawner;

    // Use this for initialization
    void Start()
    {
        objectSpawner = FindObjectOfType<ObjectSpawner>();

        List<Vector3> randomPath = objectSpawner.GetPath();

        List<Vector3> path = new List<Vector3>();

        var cameraForward = Camera.current.transform.forward;
        var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
        var cameraRotation = Quaternion.LookRotation(cameraBearing);

        for (int i = 0; i < randomPath.Count; i++)
        {
            path.Add(this.transform.position + (cameraRotation * randomPath[i]));
        }

        iTween.MoveTo(gameObject, iTween.Hash("path", path.ToArray(), "easetype", iTween.EaseType.easeInOutSine, "time", time));
    }
}
