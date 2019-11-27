using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailFollowsPath : MonoBehaviour
{
    public iTweenPath tweenPath;
    public float time;

    // Use this for initialization
    void Start()
    {

        List<Vector3> path = new List<Vector3>();

        var cameraForward = Camera.current.transform.forward;
        var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
        var cameraRotation = Quaternion.LookRotation(cameraBearing);

        for (int i = 0; i < tweenPath.nodes.Count; i++)
        {
            path.Add(this.transform.position + (cameraRotation * tweenPath.nodes[i]));
        }

        iTween.MoveTo(gameObject, iTween.Hash("path", path.ToArray(), "easetype", iTween.EaseType.easeInOutSine, "time", time));
    }
}
