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

    [SerializeField] GameObject PreviousScene_new1;
    [SerializeField] GameObject PreviousScene_new2;

    public bool win = false;
    void Start()
    {
        currentTime = maxTime;
        win = false;
    }

    private void OnEnable()
    {
        win = false;
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

    public void winner()
    {
        if (win) { for (int i = 0; i < list_disabling.Length; i++) { list_disabling[i].SetActive(false); } }
    }

    public void starting()
    {
        currentTime = maxTime;
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
            /*
            CurrentScene.SetActive(false);
            NextScene.SetActive(true);
            
            if (Player2) { multiplayer.Change_cam2(nextCamera); }
            else { multiplayer.Change_cam1(nextCamera); }
            */

            GameObject s;
            if (Player2)
            {
                s = Instantiate(PreviousScene_new2, new Vector3(0f, 0f, 0f), Quaternion.identity);
                //multiplayer.Change_cam2(nextCamera); 
                s.GetComponentInChildren<Camera>().rect = new Rect(0.5f, 0f, 0.5f, 1f);
            }
            else
            {
                s = Instantiate(PreviousScene_new1, new Vector3(0f, 0f, 0f), Quaternion.identity);
                //multiplayer.Change_cam1(nextCamera); 
                s.GetComponentInChildren<Camera>().rect = new Rect(0f, 0f, 0.5f, 1f);
            }

            Destroy(CurrentScene);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
