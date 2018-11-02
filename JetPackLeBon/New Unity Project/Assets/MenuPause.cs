using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPause : MonoBehaviour
{
    
    public GameObject pauseMenu;
    void Start()
    {
        Donnees.PopUpStatistiques = false;

        print(GameObject.FindGameObjectWithTag("Respawn").GetComponent<Text>().text);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!PartieTerminee())
            {
                Donnees.PopUpStatistiques = !Donnees.PopUpStatistiques;
            }
        }

        if (Donnees.PopUpStatistiques)
        {
            JeuEnPause();
        }
        else
        {
            Resume();
        }

    }
    public void JeuEnPause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        Donnees.PopUpStatistiques = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    private bool PartieTerminee()
    {
        return Donnees.PartieTerminee;
    }
}
