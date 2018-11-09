using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPause : MonoBehaviour
{
    public Button buttondouble;
    public Button vie;
    public GameObject pauseMenu;
    void Start()
    {
        Donnees.PopUpStatistiques = false;

        
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
    public void doubler()
    {
        Donnees.PointsAchat += Donnees.PointsPartieActuelle;
        Donnees.PointsAchat += Donnees.PointsObtenusMission;
        Donnees.PointsPartieActuelle = Donnees.PointsPartieActuelle * 2;
        Donnees.PointsObtenusMission = Donnees.PointsObtenusMission * 2;
        
        buttondouble.gameObject.SetActive(false);
    }
    public void Vie()
    {
        Donnees.PopUpStatistiques = false;
        pauseMenu.SetActive(false);
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
