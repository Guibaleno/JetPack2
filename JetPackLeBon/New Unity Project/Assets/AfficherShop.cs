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
    }
	

	void Update () {
        Money.text ="Vous avez " +  Donnees.PointsAchat +" pieces";
	}

    
}
