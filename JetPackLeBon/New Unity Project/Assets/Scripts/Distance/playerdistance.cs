using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerdistance : MonoBehaviour {


    private Rigidbody2D rb;

    private float dirX, moveSpeed = 5f;


    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {

        dirX = Input.GetAxisRaw("Horizontal") * moveSpeed;
    }

    private void FixedUpdate()
    {

        rb.velocity = new Vector2(dirX, rb.velocity.y);
    }
}