using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MatchBounds : MonoBehaviour
{
    [SerializeField] Camera cam;
    float cameraDistance;
    Bounds bounds;

    // Start is called before the first frame update
    void Start()
    {
        cameraDistance = Mathf.Abs(cam.transform.position.y - transform.position.y); // Constant factor
        bounds = GetComponent<BoxCollider>().bounds;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 objectSizes = bounds.max - bounds.min;
        float objectSize = Mathf.Max(objectSizes.x, objectSizes.y, objectSizes.z);
        float cameraView = 2.0f * Mathf.Tan(0.5f * Mathf.Deg2Rad * cam.fieldOfView); // Visible height 1 meter in front
        float distance = cameraDistance * objectSize / cameraView; // Combined wanted distance from the object
        distance += 0.5f * objectSize; // Estimated offset from the center to the outside of the object
        cam.transform.position = bounds.center - distance * cam.transform.forward;

    }
}
