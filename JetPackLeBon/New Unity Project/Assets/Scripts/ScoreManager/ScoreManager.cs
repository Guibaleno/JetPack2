using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
     Text LabelScore;
    bool pointUnePartie;
    bool pointsTotaux;
    bool scoreBattu;
    // Use this for initialization
    void Awake () {
        pointUnePartie = false;
        pointsTotaux = false;
        scoreBattu = false;
        LabelScore = GetComponent<Text>();
        DontDestroyOnLoad(gameObject);
        Donnees.PointsObtenusMission = 0;
        
    }
    private void Update()
    {
        DisplayScore();
    }
    public void AjouterPoints(int nbPoints)
    {
        Donnees.PointsAchat += nbPoints;
        Donnees.PointsPartieActuelle += nbPoints;
        EnregistrerDonneesPoints(nbPoints);
        
    }

    private void EnregistrerDonneesPoints(int scoreAAjouter)
    {
        Donnees.PointsTotauxActuel += scoreAAjouter;
        if (pointUnePartie == false)
        {
            pointUnePartie = Donnees.DeterminerMissionPointsPartieAccomplie();
        }
        if (pointsTotaux == false && !Donnees.MissionPointsTotauxCompletee)
        {
            pointsTotaux = Donnees.DeterminerMissionPointsTotauxAccomplie();
        }
        if (scoreBattu == false)
        {
            scoreBattu = Donnees.DeterminerBattreRecordPieces();
        }
    }
    
    public void DisplayScore()
    {
        LabelScore.text = "Score : " + Donnees.PointsPartieActuelle.ToString();
    }

}
