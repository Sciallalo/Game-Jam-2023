using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class LanciaNeutrini : MonoBehaviour
{
    public List<GameObject> elettroni;
    public List<GameObject> neutrini;
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

    public GameObject Nucleo;
     public GameObject[] Elettroni;

    public  bool finish = false;

    [SerializeField] GameObject NextScene_new1;
    [SerializeField] GameObject NextScene_new2;
    private void Start()
    {
        currentTime = 0;
        tmpTime = 0;
        video.Stop();
    }

    private void OnEnable()
    {
        finish = false;
        currentTime = 0;
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

        if (!CheckState() && !finish){
            // SceneManager.LoadScene(0);
            scena.reload();
            currentTime = 0;

        }

        if(currentTime >= maxTime && CheckState() && !finish)
        {
            //canvas.gameObject.SetActive(true);
            finish = true;
            Nucleo.SetActive(false);
            for (int i = 0; i < Elettroni.Length; i++)
            {
                Elettroni[i].SetActive(false);
            }
            neutrini.ForEach(Destroy);
            video.clip = videoclip;
            video.Play();
            StartCoroutine(WaitVideo());
        }

        if(tmpTime >= Random.Range(.5f, 2f))
        {
            Vector2 orbitPos = ellisse.Evaluate(Random.Range(0f, 1f));

            if (!Player2)
            { neutrino.layer = 6; Instantiate(neutrino, new Vector3(orbitPos.x, 0, orbitPos.y), Quaternion.identity).transform.parent=this.transform; }
            else { neutrino.layer = 7; Instantiate(neutrino, new Vector3(orbitPos.x, 0, orbitPos.y ), Quaternion.identity).transform.parent = this.transform; ; }

            neutrini.Add(neutrino);
            tmpTime = 0;
        }
    }

    IEnumerator WaitVideo()
    {
       
        yield return new WaitForSeconds(4.176f);
        video.Stop();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        CurrentScene.SetActive(false);
        // NextScene.SetActive(true);
        GameObject s;
        if (Player2) { s=Instantiate(NextScene_new2, new Vector3(0f, 0f, 0f), Quaternion.identity);
            //multiplayer.Change_cam2(nextCamera); 
            s.GetComponentInChildren<Camera>().rect = new Rect(0.5f, 0f, 0.5f, 1f);
        }
        else { s=Instantiate(NextScene_new1, new Vector3(0f, 0f, 0f), Quaternion.identity);
            //multiplayer.Change_cam1(nextCamera); 
            s.GetComponentInChildren<Camera>().rect = new Rect(0f, 0f, 0.5f, 1f);
        }

        Destroy(CurrentScene);
       // scene1_1.GetComponentInChildren<Camera>().rect = new Rect(0f, 0f, 0.5f, 1f);
      //  s.GetComponentInChildren<Camera>().rect = new Rect(0.5f, 0f, 0.5f, 1f);




    }
}
