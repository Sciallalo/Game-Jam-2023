using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraMooveAway : MonoBehaviour
{
    [SerializeField] float initial_size = 10;
    [SerializeField] float final_size = 70;
    [SerializeField] BoundariesDimension boundariesDim;

    float lerpDuration = 2;
    float timeElapsed;

    // Start is called before the first frame update
    void Start()
    {
        Camera.main.orthographicSize = initial_size;
        lerpDuration = boundariesDim.getDuration();
        timeElapsed = 0;
    }

    // Update is called once per frame
    void Update()
    {   
        if (timeElapsed < lerpDuration)
        {
            Camera.main.orthographicSize = Mathf.Lerp(initial_size, final_size, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
        }
    }
}
