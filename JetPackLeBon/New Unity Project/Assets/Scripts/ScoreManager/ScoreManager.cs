using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
     Text LabelScore;
    int Score;
    bool pointUnePartie;
    bool pointsTotaux;
    bool scoreBattu;
    // Use this for initialization
    void Awake () {
        pointUnePartie = false;
        pointsTotaux = false;
        scoreBattu = false;
        LabelScore = GetComponent<Text>();
        Score = 0;
        DisplayScore();
        DontDestroyOnLoad(gameObject);
    }
    public void AjouterPoints(int nbPoints)
    {
        Score+= nbPoints;
        DisplayScore();
        EnregistrerDonneesPoints(nbPoints);
    }

    private void EnregistrerDonneesPoints(int scoreAAjouter)
    {
        Donnees.PointsTotauxActuel += scoreAAjouter;
        Donnees.PointsPartieActuelle = Score;
        if (pointUnePartie == false)
        {
            pointUnePartie = Donnees.DeterminerMissionPointsPartieAccomplie(Score);
        }
        if (pointsTotaux == false)
        {
            pointsTotaux = Donnees.DeterminerMissionPointsTotauxAccomplie();
        }
        if (scoreBattu == false)
        {
            Donnees.DeterminerBattreRecordPieces();
        }
    }
    
    public void DisplayScore()
    {
        LabelScore.text = "Score : " + Score.ToString();
    }

    public int GetScore()
    {
        return this.Score;
    }
}
