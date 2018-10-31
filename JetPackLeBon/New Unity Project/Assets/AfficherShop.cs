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
        Money.text ="Vous avez " +  Donnees.PointsTotauxActuel +" pieces";
	}
  public void acheterArticle()
    {
        if (Donnees.PointsTotauxActuel >= valeurArticle)
        {
            Donnees.PointsTotauxActuel -=valeurArticle;
            Prix.text = " acheté";
            Money.text = "Vous avez " + Donnees.PointsTotauxActuel + " pieces";
        }
    }
}
