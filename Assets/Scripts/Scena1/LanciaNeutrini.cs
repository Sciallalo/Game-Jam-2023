using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class LanciaNeutrini : MonoBehaviour
{
    public List<GameObject> elettroni;
    public GameObject neutrino;
    public Ellipse ellisse;
    public Canvas canvas;
    public VideoPlayer video;
    public float maxTime = 15f;
    private float currentTime;
    private float tmpTime;

    [SerializeField] GameObject NextScene;
    [SerializeField] GameObject CurrentScene;
    [SerializeField] Multiplayer_Manager multiplayer;
    [SerializeField] bool Player2;
    [SerializeField] Camera nextCamera;
    [SerializeField] Scene1_Reload scena;
    [SerializeField] VideoClip videoclip;

    [SerializeField] GameObject Nucleo;
     [SerializeField] GameObject[] Elettroni;
    private void Start()
    {
        currentTime = 0;
        tmpTime = 0;
        video.Stop();
    }
    
    bool CheckState()
    {
        for(int i = 0; i< elettroni.Count; i++)
        {
            if (elettroni[i].gameObject.activeSelf )
                return true;
        }

        return false;
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
        tmpTime += Time.deltaTime;

        if (!CheckState()){
            // SceneManager.LoadScene(0);
            scena.reload();
            currentTime = 0;

        }

        if(currentTime >= maxTime && CheckState())
        {
            //canvas.gameObject.SetActive(true);
            video.clip = videoclip;
            Nucleo.SetActive(false);
            for (int i = 0; i < Elettroni.Length; i++)
            {
                Elettroni[i].SetActive(false);
            }
            video.Play();
            StartCoroutine(WaitVideo());
        }

        if(tmpTime >= Random.Range(.5f, 2f))
        {
            Vector2 orbitPos = ellisse.Evaluate(Random.Range(0f, 1f));

            if (!Player2)
            { neutrino.layer = 6; Instantiate(neutrino, new Vector3(orbitPos.x, 0, orbitPos.y), Quaternion.identity).transform.parent=this.transform; }
            else { neutrino.layer = 7; Instantiate(neutrino, new Vector3(orbitPos.x, 0, orbitPos.y + 332.8f), Quaternion.identity).transform.parent = this.transform; ; }

            tmpTime = 0;
        }
    }

    IEnumerator WaitVideo()
    {
       
        yield return new WaitForSeconds(4.176f);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        CurrentScene.SetActive(false);
        NextScene.SetActive(true);
        if (Player2) { multiplayer.Change_cam2(nextCamera); }
        else { multiplayer.Change_cam1(nextCamera); }

    }
}
