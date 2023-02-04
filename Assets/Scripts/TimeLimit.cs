using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class TimeLimit : MonoBehaviour
{
    public float maxTime = 10f;
    public Canvas canvas;
    public VideoPlayer video;
    public float seconds;
    private float currentTime;
    void Start()
    {
        currentTime = maxTime;
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
        canvas.gameObject.SetActive(true);
        video.Play();
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
