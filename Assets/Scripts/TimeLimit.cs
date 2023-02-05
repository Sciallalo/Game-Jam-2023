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

    [SerializeField] GameObject[] list_disabling;
    [SerializeField] VideoClip videoclip;

    [SerializeField] GameObject NextScene;
    [SerializeField] GameObject CurrentScene;
    [SerializeField] Multiplayer_Manager multiplayer;
    [SerializeField] bool Player2;
    [SerializeField] Camera nextCamera;

    public bool win = false;
    void Start()
    {
        currentTime = maxTime;
        win = false;
    }

    private void OnEnable()
    {
        win = false;
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

    public void starting()
    {
        currentTime = 0;
    }

    IEnumerator GoBack()
    {
        if (!win)
        {
            //canvas.gameObject.SetActive(true);
            video.clip = videoclip;
            for (int i = 0; i < list_disabling.Length; i++) { list_disabling[i].SetActive(false); }
            video.Play();
            yield return new WaitForSeconds(seconds);
            CurrentScene.SetActive(false);
            NextScene.SetActive(true);
            if (Player2) { multiplayer.Change_cam2(nextCamera); }
            else { multiplayer.Change_cam1(nextCamera); }
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
