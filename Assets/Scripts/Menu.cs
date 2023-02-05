using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject blend;
    public GameObject cv_start;
    public GameObject cv_gameplay;

    public void StartGame()
    {
        blend.GetComponent<BlendCamera>().enabled = true;
        cv_start.SetActive(false);
        cv_gameplay.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
