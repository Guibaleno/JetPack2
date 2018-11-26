using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class AfficherMissions : MonoBehaviour {
    Canvas canvas;
    [SerializeField] GameObject missonPrefab;
    // Use this for initialization
    void Start () {
        canvas = FindObjectOfType<Canvas>();
        AffichageMissions();
	}
	
	// Update is called once per frame
	void Update () {
        
    }
    void AffichageMissions()
    {
        for (int missionActuelle = 0; missionActuelle < Donnees.LesMissions.Length; missionActuelle++)
        {
            GameObject missionObject = Instantiate(missonPrefab, canvas.transform);
            missionObject.GetComponent<Text>().text = Donnees.LesMissions[missionActuelle];
            missionObject.transform.position = missionObject.transform.position + Vector3.up * missionActuelle * -20;
            DontDestroyOnLoad(gameObject);
        }
    }
}
