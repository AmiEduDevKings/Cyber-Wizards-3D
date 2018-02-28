using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {

    public GameObject target;
    public float cameraDepth;
    public float smoothTime = 0.3f;
    public Vector3 offset;

    private Vector3 velocity = Vector3.zero;
    Vector3 pos;
    Vector3 targetPos;

    // Use this for initialization
    void Start() {
        if (target) {
            pos = target.transform.position;
            pos.y = cameraDepth;
            transform.position = pos;
        }
    }

    private void FixedUpdate() {
    }

    private void LateUpdate() {
        if (target) {
            pos = target.transform.position;
            pos.y = cameraDepth;
            targetPos = new Vector3(pos.x, cameraDepth, pos.z);
            pos = Vector3.SmoothDamp(transform.position, targetPos + offset, ref velocity, smoothTime);
        }

        transform.position = new Vector3(pos.x, pos.y, pos.z);
    }
}
