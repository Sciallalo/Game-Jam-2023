using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atom : MonoBehaviour
{
    [SerializeField] BlendCamera blendCam;
    
    public bool WIN = false;

    public Transform orbitingObject;
    public Ellipse orbitPath;

    [Range(0f,1f)]
    public float orbitProgress = 0.25f;
    public float orbitPeriod = 3f;

    float orbitSpeed;
    float pressedValue = 0f;
    float addValue = 0.005f;
    float maxValue = 1f;
    float atomVelocity;

    private void Start()
    {
        SetOrbitingObjectPosition();
        atomVelocity = 25;
    }

    void SetOrbitingObjectPosition()
    {
        Vector2 orbitPos = orbitPath.Evaluate(orbitProgress);
        if(orbitingObject != null)
        {
            orbitingObject.localPosition = new Vector3(orbitPos.x, 0, orbitPos.y);
        }
    }

    void inputRead()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && pressedValue <= maxValue)
        {
            pressedValue += addValue * atomVelocity * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow) && pressedValue >= -maxValue)
        {
            pressedValue += -addValue * atomVelocity * Time.deltaTime;
        }
        else
        {
            if(pressedValue != 0)
            {
                if(pressedValue > 0)
                {
                    pressedValue -= addValue * (atomVelocity * 2) * Time.deltaTime;
                }
                else
                {
                    pressedValue += addValue * (atomVelocity * 2) * Time.deltaTime;
                }
            }
        }
    }

    private void Update()
    {
        Debug.Log("pressedValue:  "+ pressedValue);

        if (Mathf.Abs(pressedValue) < maxValue)
        {
            inputRead();

            if(orbitPeriod < 0.1f)
            {
                orbitPeriod = 0.1f;
            }

        }
        else
        {
            Debug.Log("NICEEEEEEEEEEEEEE");
            WIN = true;
        }

        orbitSpeed = 1f / orbitPeriod;
        orbitProgress += pressedValue * orbitSpeed;
        orbitProgress %= 1f;
        SetOrbitingObjectPosition();
    }
}
