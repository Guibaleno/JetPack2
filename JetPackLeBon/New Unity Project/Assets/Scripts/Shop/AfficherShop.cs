using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AfficherShop : MonoBehaviour {
    [SerializeField] Text Money;
    [SerializeField] Text Prix;
    [SerializeField] Text Prix2;
    public Button buttonBonhomme;
    public Button buttonEtoile;
    public Button buttonAimant;
    public Button buttonInvincible;
    int valeurArticle = 10;
  //  int ArgentTotale = int.Parse(Donnees.AfficherArgentTotale());
    void Start () {
        Prix.text = valeurArticle + " pieces";
        Prix2.text = valeurArticle + " pieces";
        if (Donnees.jetPackBonhommeAchetee)
        {
            buttonBonhomme.GetComponentInChildren<Text>().text = "Acheté";
        }
        if (Donnees.jetPackEtoileAchetee)
        {
            buttonEtoile.GetComponentInChildren<Text>().text = "Acheté";
        }
        if (Donnees.AimantAchetee)
        {
            buttonAimant.GetComponentInChildren<Text>().text = "Acheté";
        }
        buttonInvincible.GetComponentInChildren<Text>().text = "Buy (" + Donnees.invincible.ToString() + ")";
    }
	

	void Update () {
        Money.text ="Vous avez " +  Donnees.PointsAchat +" pieces";
	}

    
}
