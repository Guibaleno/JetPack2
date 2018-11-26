using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class MissionManager : MonoBehaviour {

    string[] LesMissionsTexte;
    int nombreMission;
    // Use this for initialization
    void Awake ()
    {
        nombreMission = 4;
        GameObject[] currentMissions = GameObject.FindGameObjectsWithTag("MissionManager");

        
        if (currentMissions.Length <= 1)
        {
            Donnees.LesMissions = new string[nombreMission];
            LesMissionsTexte = FabriquerTypesMissions();
            ChoisirValeursMissions(LesMissionsTexte);
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
	
	// Update is called once per frame
	void Update () {
        
    }

    string[] FabriquerTypesMissions()
    {
        string[] Missions = new string[nombreMission];
        Missions[0] = "Ramasser @@ pièces en une partie.";
        Missions[1] = "Parcourir @@m en une partie.";
        Missions[2] = "Ramasser un total de @@ pièces.";
        Missions[3] = "Parcourir un total de @@m.";
        return Missions;
    }

    void ChoisirValeursMissions(string[] Missions)
    {
        for (int cptMissions = 0; cptMissions < Missions.Length; cptMissions ++)
        {
            int nombreAleatoire = ChoisirNombreAleatoire(cptMissions);
            Missions[cptMissions] = Missions[cptMissions].Replace("@@", nombreAleatoire.ToString());
            Donnees.LesMissions[cptMissions] = Missions[cptMissions];
        }
    }

    int ChoisirNombreAleatoire(int cptMission)
    {
        int nombreGenere = 0;
        if (cptMission == 0)
        {
            nombreGenere = UnityEngine.Random.Range(15, 30);
            Donnees.MissionPointsUnePartie = nombreGenere;    
        }
        else
        if (cptMission == 1)
        {
            nombreGenere = UnityEngine.Random.Range(75, 150);
            Donnees.MissionDistanceUnePartie = nombreGenere;           
        }
        else
        if (cptMission == 2)
        {
            nombreGenere = UnityEngine.Random.Range(40, 50);
            Donnees.MissionPointsTotaux = nombreGenere;
        }
        else
        if (cptMission == 3)
        {
            nombreGenere = UnityEngine.Random.Range(200, 300);
            Donnees.MissionDistanceTotale = nombreGenere;
        }
        return nombreGenere;
    }

    

    public int NombrePiece()
    {
        return Donnees.MissionPointsUnePartie;
    }
}
