using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Moovement : MonoBehaviour
{
    [SerializeField] GameObject other_hand;
    [SerializeField] float moovement_velocity = 0.3f;
    [SerializeField] float range_z;
    [SerializeField] Transform center;
    [SerializeField] float approachingVelocity = 1.5f;
    [SerializeField] float max_distance = 0.6f;
    public Canvas canvas;
    public VideoPlayer video;
    [SerializeField] VideoClip videoclip;

    bool WIN = false;
    float seed;

    Transform left_top, rightTop;

    [SerializeField] bool Player2;
    public bool instaced = false;
    [SerializeField] GameObject alieno;

    [SerializeField] GameObject NextScene;
    [SerializeField] GameObject CurrentScene;
    [SerializeField] Multiplayer_Manager multiplayer;
    [SerializeField] Camera nextCamera;
    [SerializeField] TimeLimit tl;

    [SerializeField] GameObject NextScene_new1;
    [SerializeField] GameObject NextScene_new2;
    //bool done = false;
    //[SerializeField] bool collided = false;

    // Start is called before the first frame update
    void Start()
    {
        Collider collider = GetComponent<Collider>();
        this.GetComponent<MeshRenderer>().enabled = true;

        if (gameObject.name == "LeftHand")
        {
            left_top = gameObject.transform.GetChild(0).transform;
            rightTop = other_hand.transform.GetChild(0).transform;
        }
        else
        {
            left_top = other_hand.transform.GetChild(0).transform;
            rightTop = gameObject.transform.GetChild(0).transform;
        }
        
        seed = UnityEngine.Random.Range(0, 100);
        moovement_velocity = UnityEngine.Random.Range(3f, 5f);
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, UnityEngine.Random.Range(-range_z, range_z));

    }

    private void OnEnable()
    {
        this.GetComponent<MeshRenderer>().enabled = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (!WIN)
        {
            float new_z_val = Mathf.Sin(seed) * range_z;

            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, new_z_val);
            seed += moovement_velocity * Time.deltaTime;
        }

        else
        {
            gameObject.transform.position += Vector3.MoveTowards(gameObject.transform.GetChild(0).position, center.position, approachingVelocity * Time.deltaTime) - gameObject.transform.GetChild(0).position;
        }

        if (!Player2 && Input.GetKey(KeyCode.W))
        {
            if (compute_offsetZ(left_top, rightTop, max_distance))
            {
                WIN = true;
                Debug.Log("Collision detected");
                StartCoroutine(WaitWin());
                
            }
            else
            {
                Debug.Log("Collision NOT detected");
            }
        }

        if (Player2 && Input.GetKey(KeyCode.UpArrow))
        {
            if (compute_offsetZ(left_top, rightTop, max_distance))
            {
                WIN = true;
                Debug.Log("Collision detected");
                StartCoroutine(WaitWin());

            }
            else
            {
                Debug.Log("Collision NOT detected");
            }
        }

    }


    bool compute_offsetZ(Transform p1, Transform p2, float max_offset)
    {
        float offset = Mathf.Abs(p1.position.z - p2.position.z);

        return offset < max_offset;
            
    }

    IEnumerator WaitWin()
    {
        if(!instaced){
            tl.win = true;
            //tl.winner();
            yield return new WaitForSeconds(3);
            video.clip = videoclip;
            video.Play();
            // alieno.SetActive(false);
            this.GetComponent<MeshRenderer>().enabled = false;
            yield return new WaitForSeconds(3);

            /*
            CurrentScene.SetActive(false);
            NextScene.SetActive(true);
            if (Player2) { multiplayer.Change_cam2(nextCamera); }
            else { multiplayer.Change_cam1(nextCamera); }
            */

            GameObject s;
            if (Player2)
            {
                s = Instantiate(NextScene_new2, new Vector3(0f, 0f, 0f), Quaternion.identity);
                //multiplayer.Change_cam2(nextCamera); 
                s.GetComponentInChildren<Camera>().rect = new Rect(0.5f, 0f, 0.5f, 1f);
            }
            else
            {
                s = Instantiate(NextScene_new1, new Vector3(0f, 0f, 0f), Quaternion.identity);
                //multiplayer.Change_cam1(nextCamera); 
                s.GetComponentInChildren<Camera>().rect = new Rect(0f, 0f, 0.5f, 1f);
            }

            Destroy(CurrentScene);
        }
        // video.enabled = true;
        /*
         if (canvas != null)
         {
             //canvas.gameObject.SetActive(true);
             //video.Play();
             yield return new WaitForSeconds(2);
             //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
         }
         */

    }
}
