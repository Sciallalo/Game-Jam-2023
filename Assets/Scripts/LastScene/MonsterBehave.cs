using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterBehave : MonoBehaviour
{
    [SerializeField] float moveAwayVelocity = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float new_scale = moveAwayVelocity * Time.deltaTime;
        transform.localScale += new Vector3(new_scale, new_scale, new_scale);
    }
}
