using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Niveau : MonoBehaviour {
    GameObject lesMissions;
    ScoreManager scoreActuel;
    int scoreActuelint;
	// Use this for initialization
	void Start () {
        scoreActuelint = 0;
        
        lesMissions = GameObject.FindGameObjectWithTag("MissionManager");
        scoreActuel = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();

    }
	
	// Update is called once per frame
	void Update () {
        //int.TryParse(scoreActuel.text, out scoreActuelint);
        
        if (scoreActuel.GetScore() >= lesMissions.GetComponent<MissionManager>().NombrePiece())
        {
            print("Mission réussie");
        }
	}
}
