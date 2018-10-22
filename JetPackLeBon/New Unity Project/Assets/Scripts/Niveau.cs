using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Niveau : MonoBehaviour {
    GameObject lesMissions;
    ScoreManager scoreActuel;
    MissionManager missionsNiveau;
    int scoreActuelint;
    bool MissionDejaReussie;
	// Use this for initialization
	void Start () {
        scoreActuelint = 0;
        MissionDejaReussie = false;
        lesMissions = GameObject.FindGameObjectWithTag("MissionManager");
        missionsNiveau = lesMissions.GetComponent<MissionManager>();
        scoreActuel = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
    }
	
	// Update is called once per frame
	void Update () {
        //if (scoreActuel.GetScore() >= missionsNiveau.NombrePiece() && MissionDejaReussie == false)
        //{
        //    MissionDejaReussie = true;
        //    print("Mission réussie");
        //}
	}
}
