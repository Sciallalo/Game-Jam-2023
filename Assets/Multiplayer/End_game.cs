using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End_game : MonoBehaviour
{
    [SerializeField] Multiplayer_Manager multiplayer;
    [SerializeField] bool player2;

    [SerializeField] GameObject Canvas_win;
    [SerializeField] GameObject win1;
    [SerializeField] GameObject win2;
    // Start is called before the first frame update
    void Start()
    {
       


    }

    public void win() {

        Canvas_win.SetActive(true);
        multiplayer.scene1.SetActive(false); multiplayer.scene2.SetActive(false);
        if (player2) { win1.SetActive(true); }
        else win2.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
