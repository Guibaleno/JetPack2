using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AfficherTexte : MonoBehaviour {
    [SerializeField] Text distance;
    [SerializeField] Text NbreMission ;
    [SerializeField] Text PtsObtenu;
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        distance.text = Donnees.AfficherDistanceParcourueDurantLaPartie();
        NbreMission.text = Donnees.AfficherNombreMissionsReussiesDurantLaPartie();
        PtsObtenu.text = Donnees.AfficherPointsObtenusDurantLaPartie();
    }
}
