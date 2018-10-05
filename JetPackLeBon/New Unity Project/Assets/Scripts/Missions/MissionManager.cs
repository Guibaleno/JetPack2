using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class MissionManager : MonoBehaviour {
    Canvas canvas;
    [SerializeField] GameObject missonPrefab;
    string[] LesMissionsTexte;
    // Use this for initialization
    void Awake ()
    {
        GameObject[] currentMissions = GameObject.FindGameObjectsWithTag("MissionManager");
        canvas = FindObjectOfType<Canvas>();
        
        if (currentMissions.Length <= 1)
        {
            Donnees.LesMissions = new string[2];
            LesMissionsTexte = FabriquerTypesMissions();
            ChoisirValeursMissions(LesMissionsTexte);
            AfficherMissions();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            print("HELLO");
            Destroy(gameObject);
            AfficherMissions();
        }

    }
	
	// Update is called once per frame
	void Update () {
        
    }

    string[] FabriquerTypesMissions()
    {
        string[] Missions = new string[2];
        Missions[0] = "Ramasser @@ pièces en une partie.";
        Missions[1] = "Parcourir @@m en une partie.";
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
        System.Random randomNumber = new System.Random();
        int nombreGenere = 0;
        if (cptMission == 0)
        {
            nombreGenere = randomNumber.Next(5, 10);
            Donnees.PointsUnePartie = nombreGenere;
            
        }
        else
        if (cptMission == 1)
        {
            nombreGenere = randomNumber.Next(20, 30);
            Donnees.DistanceUnePartie = nombreGenere;
            
        }
        return nombreGenere;
    }

    void AfficherMissions()
    {
        for (int missionActuelle = 0; missionActuelle < Donnees.LesMissions.Length; missionActuelle++)
        {
            GameObject missionObject = Instantiate(missonPrefab, canvas.transform);
            missionObject.GetComponent<Text>().text = Donnees.LesMissions[missionActuelle];
            missionObject.transform.position = missionObject.transform.position + Vector3.up * missionActuelle * -20;
            DontDestroyOnLoad(gameObject);
        }
    }

    public int NombrePiece()
    {
        return Donnees.PointsUnePartie;
    }
}
