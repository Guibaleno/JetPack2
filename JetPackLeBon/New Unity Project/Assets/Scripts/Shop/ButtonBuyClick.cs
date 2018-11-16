using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Reflection;

public class ButtonBuyClick : MonoBehaviour {
    bool jetPackBonhomme = false;
    public void MouseClick()
    {
        
        if (name == "jetPackEtoile")
        {
            if (gameObject.GetComponentInChildren<Text>().text == "Acheté")
            {
                jetPackBonhomme = true;

            }

            DeterminerSiAchat();
            print("jetPackEtoile");
        }
        else
        if (name == "jetPackBonhomme")
        {
            if (gameObject.GetComponentInChildren<Text>().text == "Acheté")
            {
                jetPackBonhomme = true;

            }
            DeterminerSiAchat();
            print("jetPackBonhomme");
        }
        else
        if (name == "invincible")
        {
            if (Donnees.PointsAchat >= 15)
            {
                Donnees.PointsAchat -= 15;
                Donnees.invincible += 1;
                gameObject.GetComponentInChildren<Text>().text = "Buy (" + Donnees.invincible.ToString() + ")";
            }
        }
        else
        if (name == "AimantBouton")
        {
            if (Donnees.PointsAchat >= 30 && Donnees.AimantAchetee == false)
            {
                Donnees.PointsAchat -= 30;
                Donnees.AimantAchetee = true;
                gameObject.GetComponentInChildren<Text>().text = "Acheté";
            }
        }
    }
    void DeterminerSiAchat()
    {
        if (jetPackBonhomme || gameObject.GetComponentInChildren<Text>().text != "Acheté")
        {
            //if (Donnees.PointsAchat >= 10)
            // {
            if (gameObject.GetComponentInChildren<Text>().text != "Acheté")
            {
                Donnees.PointsAchat -= 10;
            }
                Donnees.ChangerJetPack(name.ToString());
                gameObject.GetComponentInChildren<Text>().text = "Acheté";
           // }
        }
    }
}
