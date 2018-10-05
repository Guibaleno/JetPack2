using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[CreateAssetMenu(menuName = "Mission")]
public class MissionSeule : ScriptableObject
{
    int nombrePieceMissionCourante;
    System.Random randomNumber;
	// Use this for initialization
	void Awake () {
        GameObject[] test = GameObject.FindGameObjectsWithTag("uneMissionSeule");
        //print(test.name);
        /*if (test.Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            randomNumber = new System.Random();
            nombrePieceMissionCourante = randomNumber.Next(1, 3);
            DontDestroyOnLoad(gameObject);
        }*/

    }

    /*private void Start()
    {
        
    }

    // Update is called once per frame
    void Update () {
		
	}*/

    public int NombrePiece()
    {
        return nombrePieceMissionCourante;
    }
}
