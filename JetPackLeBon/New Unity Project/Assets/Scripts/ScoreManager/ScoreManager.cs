using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
     Text LabelScore;
    int Score;
    bool pointUnePartie;
    bool pointsTotaux;
    // Use this for initialization
    void Awake () {
        pointUnePartie = false;
        pointsTotaux = false;
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
        //Donnees.PointsUnePartie = Score;
        if (pointUnePartie == false)
        {
            pointUnePartie = Donnees.DeterminerMissionPointsPartieAccomplie(Score);
        }
        if (pointsTotaux == false)
        {
            pointsTotaux = Donnees.DeterminerMissionPointsTotauxAccomplie();
        }
    }

    public void FinPartie(float positionActuelle)
    {
        Donnees.FinPartie(Score, positionActuelle);
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
