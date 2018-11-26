using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
public class ControleButton : MonoBehaviour {

    public void StartButton()
    {       
        Donnees.DistancePartieActuelle = 0;
        Donnees.PointsPartieActuelle = 0;
        Donnees.NombreMissionsReussieParPartie = 0;
        if (Donnees.MissionDistanceTotaleCompletee)
        {
            Donnees.DistanceTotaleActuelle = 0;
            Donnees.MissionDistanceTotaleCompletee = false;
        }
        if (Donnees.MissionPointsTotauxCompletee)
        {
            Donnees.PointsTotauxActuel = 0;
            Donnees.MissionPointsTotauxCompletee = false;
        }
        SceneManager.LoadScene("Niveau");
    }
    public void ShopButton()
    {
        SceneManager.LoadScene("Shop");
    }
    public void QuitButton()
    {
        Application.Quit();
    }
    public void MissionButton()
    {
        SceneManager.LoadScene("Missions");
    }

    public void ArreterPartie()
    {
        Donnees.AimantAchetee = false;
        Donnees.DeterminerSiRageQuit();
        MainMenu();
    }
    public void MainMenu()
    {
        
        SceneManager.LoadScene("MainMenu");
    }
}
