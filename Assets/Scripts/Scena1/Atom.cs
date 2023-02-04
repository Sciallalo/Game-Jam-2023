using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atom : MonoBehaviour
{
    public Transform orbitingObject;
    public Ellipse orbitPath;

    [Range(0f,1f)]
    public float orbitProgress = 0.25f;
    public float orbitPeriod = 3f;

    float orbitSpeed;
    float pressedValue = 0f;
    float addValue = 0.00001f;

    private void Start()
    {
        SetOrbitingObjectPosition();
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
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            pressedValue += addValue * 2;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            pressedValue += -addValue *2;
        }
        else
        {
            if(pressedValue != 0)
            {
                if(pressedValue > 0)
                {
                    pressedValue -= addValue;
                }
                else
                {
                    pressedValue += addValue;
                }
            }
        }
    }

    private void Update()
    {
        inputRead();

        if(orbitPeriod < 0.1f)
        {
            orbitPeriod = 0.1f;
        }

        orbitSpeed = 1f / orbitPeriod;

        orbitProgress += pressedValue * orbitSpeed;
        orbitProgress %= 1f;

        SetOrbitingObjectPosition();
    }
}
