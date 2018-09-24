using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MissionSeule : MonoBehaviour
{
    int nombrePieceMissionCourante;
    System.Random randomNumber;
	// Use this for initialization
	void Awake () {
        GameObject[] test = GameObject.FindGameObjectsWithTag("MissionCoins");
        //print(test.name);
        if (test.Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            randomNumber = new System.Random();
            nombrePieceMissionCourante = randomNumber.Next(0, 2);
            DontDestroyOnLoad(gameObject);
        }
       
	}

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update () {
		
	}

    public int NombrePiece()
    {
        return nombrePieceMissionCourante;
    }
}
