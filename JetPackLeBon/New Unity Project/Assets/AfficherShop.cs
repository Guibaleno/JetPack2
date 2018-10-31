using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AfficherShop : MonoBehaviour {
    [SerializeField] Text Money;
    [SerializeField] Text Prix;
    int valeurArticle = 10;
  //  int ArgentTotale = int.Parse(Donnees.AfficherArgentTotale());
    void Start () {
        Prix.text = valeurArticle + " pieces";
	}
	

	void Update () {
        Money.text ="Vous avez " +  Donnees.PointsAchat +" pieces";
	}
  public void acheterArticle()
    {
        if (Donnees.PointsAchat >= valeurArticle)
        {
            Donnees.PointsAchat -= valeurArticle;
            Donnees.article = true;
            Prix.text = " acheté";
            Money.text = "Vous avez " + Donnees.PointsAchat + " pieces";
        }
    }
}
