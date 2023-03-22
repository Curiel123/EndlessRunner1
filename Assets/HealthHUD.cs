using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class HealthHUD : MonoBehaviour
{
    public PlayerMovement player;
    public GameObject health3;
    public GameObject health2;
    public GameObject health1;
    public GameObject health0;

    void Update()
    {
        if (player.playerHealth == 3f)
        {
            health3.SetActive(true);
            health2.SetActive(false);
            health1.SetActive(false);
            health0.SetActive(false);
        }

        else if (player.playerHealth == 2f)
        {
            health3.SetActive(false);
            health2.SetActive(true);
            health1.SetActive(false);
            health0.SetActive(false);
        }

        else if (player.playerHealth == 1f)
        {
            health3.SetActive(false);
            health2.SetActive(false);
            health1.SetActive(true);
            health0.SetActive(false);
        }

        else if (player.playerHealth == 0f)
        {
            health3.SetActive(false);
            health2.SetActive(false);
            health1.SetActive(false);
            health0.SetActive(true);
            SceneManager.LoadScene("FinalResults");
        }
    }
}
