using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommencerPartie : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (Donnees.PartieCommencee == false)
        {
            Donnees.CommencerPartie();
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
