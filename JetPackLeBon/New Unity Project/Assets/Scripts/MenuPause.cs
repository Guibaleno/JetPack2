﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPause : MonoBehaviour
{
    public Button buttondouble;
    public Button vie;
    public GameObject pauseMenu;
    private Animator playerAnimator;
    void Start()
    {
        Donnees.PopUpStatistiques = false;
        playerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        vie.gameObject.SetActive(true);
        buttondouble.gameObject.SetActive(true);
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
        Donnees.DoublerPiece = true;
        Donnees.PointsAchat += Donnees.PointsPartieActuelle;
        Donnees.PointsAchat += Donnees.PointsObtenusMission;
        Donnees.PointsPartieActuelle = Donnees.PointsPartieActuelle * 2;
        Donnees.PointsObtenusMission = Donnees.PointsObtenusMission * 2;
        
        buttondouble.gameObject.SetActive(false);
    }
    public void Vie()
    {
        playerAnimator.SetBool("isDead", false);
        Donnees.Chance = true;
        Donnees.PopUpStatistiques = false;
        pauseMenu.SetActive(false);
        vie.gameObject.SetActive(false);
        playerAnimator.SetTrigger("isDeadOnetimeTrigger");
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
