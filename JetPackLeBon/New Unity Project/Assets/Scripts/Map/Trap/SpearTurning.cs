using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearTurning : MonoBehaviour
{
    [SerializeField] Rigidbody2D Trap;
    float StartingPosition;
    bool Direction;
    // Use this for initialization
    void Start()
    {
        Trap = GetComponent<Rigidbody2D>();
        StartingPosition = Trap.position.x;
        Direction = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Donnees.PopUpStatistiques)
        {
            if (Trap.position.x >= (StartingPosition + 10))
            {
                Direction = false;
            }
            if (Trap.position.x <= (StartingPosition - 10))
            {
                Direction = true;
            }
            if (Direction == true)
            {
                Trap.transform.Translate(new Vector3(0.07f, 0, 0));
            }
            else
            {
                Trap.transform.Translate(new Vector3(-0.07f, 0, 0));
            }
            Trap.transform.Rotate(new Vector3(0, 0, 10), new Space());
        }
    }
}
