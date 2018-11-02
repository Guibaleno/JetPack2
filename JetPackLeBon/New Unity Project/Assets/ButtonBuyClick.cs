using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Reflection;

public class ButtonBuyClick : MonoBehaviour {
    
    public void MouseClick()
    {
        if (gameObject.GetComponentInChildren<Text>().text != "Acheté")
        {
            //if (Donnees.PointsAchat >= 10)
           /// {

                Donnees.PointsAchat -= 10;
                Donnees.ChangerJetPack(name.ToString());
                gameObject.GetComponentInChildren<Text>().text = "Acheté";
            //}
        }
    }
}
