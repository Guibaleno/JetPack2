using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class MissionManager : MonoBehaviour {
    [SerializeField] MissionSeule[] Mission1;
    Canvas canvas;
    [SerializeField] GameObject missonPrefab;
    int nombrePiece;
    System.Random randomNumber;
	// Use this for initialization
	void Start ()
    {
        canvas = FindObjectOfType<Canvas>();
        GameObject[] currentMissions = GameObject.FindGameObjectsWithTag("MissionCoins");
        if(currentMissions.Length > 1)
        {
            for (int cptMissions = 0;cptMissions < currentMissions.Length;cptMissions ++)
            {
                if (cptMissions < currentMissions.Length - 1)
                {
                    GameObject mission = currentMissions[cptMissions];
                    MissionSeule currentMission = mission.GetComponent<MissionSeule>();
                    GameObject missionObject = Instantiate(missonPrefab, canvas.transform);
                    missionObject.GetComponent<Text>().text = "Ramasser " + currentMission.NombrePiece().ToString() + " pièces en une partie.";
                    nombrePiece = currentMission.NombrePiece();
                }
            }
        }
        else
        {
            foreach(MissionSeule mission in Mission1)
            {
                GameObject missionObject = Instantiate(missonPrefab, canvas.transform);
                missionObject.GetComponent<Text>().text = "Ramasser " + mission.NombrePiece().ToString() + " pièces en une partie.";
                nombrePiece = mission.NombrePiece();
                DontDestroyOnLoad(gameObject);
            }
            
        }
        
      
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    public int NombrePiece()
    {
        return nombrePiece;
    }
}
