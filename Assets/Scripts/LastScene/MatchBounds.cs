using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MatchBounds : MonoBehaviour
{
    [SerializeField] float start_pos;
    [SerializeField] float final_pos;
    [SerializeField] float lerpDuration = 5;

    float timeElapsed;
    [SerializeField] bool horizzontal_moving;

    float distance;
    Bounds bounds;

    // Start is called before the first frame update
    void Start()
    {
        if (horizzontal_moving)
        {
            transform.position = new Vector3(start_pos, 0, 0);
        }
        else
        {
            transform.position = new Vector3(0, 0, start_pos);
        }
        timeElapsed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeElapsed < lerpDuration)
        {
            float new_pos = Mathf.Lerp(start_pos, final_pos, timeElapsed / lerpDuration);

            if (horizzontal_moving)
            {
                transform.position = new Vector3(new_pos, transform.position.y, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, new_pos);
            }

            timeElapsed += Time.deltaTime;
            Debug.Log(timeElapsed);
        }
    }

}
