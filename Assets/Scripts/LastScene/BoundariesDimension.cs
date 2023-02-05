using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundariesDimension : MonoBehaviour
{
    [SerializeField] private float minWidth, maxWidth;
    [SerializeField] private float minHeight, maxHeight;
    private float currentWidth, currentHeight;

    [SerializeField] private float lerpDuration = 5;
    float timeElapsed;

    private void Start()
    {
        timeElapsed = 0;
    }

    public float getDuration() { return lerpDuration; }
    public float getMinWidth() { return minWidth; }
    public float getMaxWidth() { return maxWidth; }
    public float getMinHeight() { return minHeight; }
    public float getMaxHeight() { return maxHeight; }

    public Vector2 getCurrentDimension()
    {
        return new Vector2(currentWidth, currentHeight);
    }

    

    void Update()
    {
        if (timeElapsed < lerpDuration)
        {
            currentWidth = Mathf.Lerp(minWidth, maxWidth, timeElapsed / lerpDuration);
            currentHeight = Mathf.Lerp(minHeight, maxHeight, timeElapsed / lerpDuration);

            timeElapsed += Time.deltaTime;
        }
    }
}
