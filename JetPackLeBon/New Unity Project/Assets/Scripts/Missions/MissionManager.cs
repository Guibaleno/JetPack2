using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class MissionManager : MonoBehaviour {
    [SerializeField] String[] Mission1;
    [SerializeField] Text Mission2;
    [SerializeField] Text Mission3;
    [SerializeField] Canvas canvas;
    [SerializeField] GameObject missonPrefab;
    int nombrePiecesPartie;
    int distancePartie;
    int distanceTotale;
    System.Random randomNumber;
	// Use this for initialization
	void Start () {
       // Mission1 = GetComponent<Text>();
        Mission2 = GetComponent<Text>();
        Mission3 = GetComponent<Text>();
        randomNumber = new System.Random();
        nombrePiecesPartie = randomNumber.Next(50,101);
        //  Mission1.text = "Ramasser " + nombrePiecesPartie.ToString() + " pièces en une partie.";
        int positionMission = 0;
      foreach(String mission in Mission1)
        {
            GameObject missionObject = Instantiate(missonPrefab, canvas.transform);
            missionObject.GetComponent<Text>().text = mission;
            missionObject.transform.Translate(Vector3.down * positionMission);
            positionMission += 30;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
