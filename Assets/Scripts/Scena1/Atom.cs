using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atom : MonoBehaviour
{
    public Transform orbitingObject;
    public Ellipse orbitPath;
    public Camera camera;

    [Range(0f,1f)]
    public float orbitProgress = 0.25f;
    public float orbitPeriod = 3f;

    float orbitSpeed;
    float pressedValue = 0f;
    float addValue = 0.00001f;
    float winValue = 0.06f;

    float initCamera = 3.6f;
    float finishCamera = 12f;

    private void Start()
    {
        SetOrbitingObjectPosition();
    }

    void SetOrbitingObjectPosition()
    {
        Vector2 orbitPos = orbitPath.Evaluate(orbitProgress);
        orbitingObject.localPosition = new Vector3(orbitPos.x, 0, orbitPos.y);
    }

    void inputRead()
    {
        if (Input.GetMouseButton(0))
        {
            pressedValue += addValue;
        }
        else if (Input.GetMouseButton(1))
        {
            pressedValue += -addValue;
        }
        else
        {
            if(pressedValue != 0)
            {
                if(pressedValue > 0)
                {
                    pressedValue -= addValue * 5;
                }
                else
                {
                    pressedValue += addValue * 5;
                }
            }
        }
    }

    void controlCamera()
    {
        float inter = pressedValue / winValue;
        camera.orthographicSize = finishCamera * inter + (1 - inter) * initCamera;
    }

    private void Update()
    {
        inputRead();
        controlCamera();

        if(orbitPeriod < 0.1f)
        {
            orbitPeriod = 0.1f;
        }

        orbitSpeed = 1f / orbitPeriod;

        orbitProgress += pressedValue * orbitSpeed;
        orbitProgress %= 1f;

        SetOrbitingObjectPosition();

        if(pressedValue >= winValue || pressedValue <= -winValue)
        {
            Debug.Log("Vinto");
        }
    }
}
