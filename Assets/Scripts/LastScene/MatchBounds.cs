using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MatchBounds : MonoBehaviour
{
    [SerializeField] BoundariesDimension boundariesDim;
    float start_pos;
    float final_pos;


    float timeElapsed;
    float lerpDuration;

    private void Awake()
    {
        if (gameObject.name == "LeftB") {
            start_pos = - boundariesDim.getMinWidth() * 0.5f;
            final_pos = - boundariesDim.getMaxWidth() * 0.5f;
            transform.position = new Vector3(start_pos, 0, 0);
        }
        else if (gameObject.name == "RightB"){
            start_pos = boundariesDim.getMinWidth() * 0.5f;
            final_pos = boundariesDim.getMaxWidth() * 0.5f;
            transform.position = new Vector3(start_pos, 0, 0);
        }
        else if (gameObject.name == "TopB") {
            start_pos = boundariesDim.getMinHeight() * 0.5f;
            final_pos = boundariesDim.getMaxHeight() * 0.5f;
            transform.position = new Vector3(0, 0, start_pos);
        }
        else if (gameObject.name == "BottomB") {
            start_pos = - boundariesDim.getMinHeight() * 0.5f;
            final_pos = - boundariesDim.getMaxHeight() * 0.5f;
            transform.position = new Vector3(0, 0, start_pos);
        }
       
        lerpDuration = boundariesDim.getDuration();
    }

    // Start is called before the first frame update
    void Start()
    {
        
        timeElapsed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeElapsed < lerpDuration)
        {
            float new_pos = Mathf.Lerp(start_pos, final_pos, timeElapsed / lerpDuration);

            if (gameObject.name == "LeftB" || gameObject.name == "RightB")
            {
                transform.position = new Vector3(new_pos, transform.position.y, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, new_pos);
            }

            timeElapsed += Time.deltaTime;
            //Debug.Log(timeElapsed);
        }
    }

}
