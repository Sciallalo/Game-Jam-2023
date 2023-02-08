using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class TimeLimit : MonoBehaviour
{
    public float maxTime = 10f;
    public Canvas canvas;
    public Transform canvasError;
    public VideoPlayer video;
    public float seconds;
    private float currentTime;
    void Start()
    {
        currentTime = maxTime;
        canvasError = GameObject.FindWithTag("CanvasError").transform;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;
        if(currentTime <= 0)
        {
            StartCoroutine(GoBack());
        }
    }

    IEnumerator GoBack()
    {
        canvasError.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        canvas.gameObject.SetActive(true);
        video.Play();
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
