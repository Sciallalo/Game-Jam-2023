using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Moovement : MonoBehaviour
{
    [SerializeField] GameObject other_hand;

    [SerializeField] BlendCamera cameraBlend;
    [SerializeField] float range_z;
    [SerializeField] Transform center;
    [SerializeField] float approachingVelocity;
    [SerializeField] float max_distance;
    float moovement_velocity;
    
    public Canvas canvas;
    public VideoPlayer video;

    bool WIN = false;
    float seed;
    bool alreadySetted = false;

    Vector3 top_hand_offset;

    Transform left_top, rightTop;

    //bool done = false;
    //[SerializeField] bool collided = false;

    // Start is called before the first frame update
    void Start()
    {
        Collider collider = GetComponent<Collider>();

        if(gameObject.name == "LeftHand")
        {
            left_top = gameObject.transform.GetChild(0).transform;
            rightTop = other_hand.transform.GetChild(0).transform;
            top_hand_offset = left_top.position - gameObject.transform.position;
        }
        else
        {
            left_top = other_hand.transform.GetChild(0).transform;
            rightTop = gameObject.transform.GetChild(0).transform;
            top_hand_offset = rightTop.position - gameObject.transform.position;
        }

        seed = UnityEngine.Random.Range(0, 100);

        
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraBlend.cameraPositioned)
        {
            if (!WIN)
            {
                if (!alreadySetted)
                {
                    moovement_velocity = UnityEngine.Random.Range(3f, 5f);

                    gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, UnityEngine.Random.Range(-range_z, range_z));

                    alreadySetted = true;
                }
                float new_z_val = Mathf.Sin(seed) * range_z;

                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, new_z_val);
                seed += moovement_velocity * Time.deltaTime;
            }

            else
            {
                Vector3 new_top_position = Vector3.MoveTowards(gameObject.transform.GetChild(0).position, center.position, approachingVelocity * Time.deltaTime);

                gameObject.transform.position = new_top_position - top_hand_offset;

            }
        }

        if (Input.GetKey(KeyCode.Space))
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
        yield return new WaitForSeconds(3);
        if(canvas != null)
        {
            canvas.gameObject.SetActive(true);
            video.Play();
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
