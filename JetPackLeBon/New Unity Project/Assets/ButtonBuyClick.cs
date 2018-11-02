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
        if (name == "jetPackBonhomme")
        {
            if (gameObject.GetComponentInChildren<Text>().text == "Acheté")
            {
                jetPackBonhomme = true;

            }
            DeterminerSiAchat();
            print("jetPackBonhomme");
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
