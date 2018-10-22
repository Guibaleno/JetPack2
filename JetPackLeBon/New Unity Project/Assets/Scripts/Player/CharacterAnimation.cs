using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    [SerializeField] Rigidbody2D Player;
    BoxCollider2D playerCollider;
    public float playerPosition;
    AudioSource RunAudioSource;
    void Start()
    {
        Player = GetComponent<Rigidbody2D>();
        playerPosition = Player.position.x;
        playerCollider = GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        MovePlayer();
        ManageGroundSound();

    }

    void ManageGroundSound()
    {
        
        if (playerCollider.IsTouchingLayers(13))
        {
           

        }else{
            RunAudioSource.Stop();

        }

    }
    private void MovePlayer()
    {

        playerPosition += 0.001f;
        Player.transform.Translate(new Vector3(0.1f, 0, 0));
        if (Input.GetAxis("Jump") > 0)
        {
            Jump();


        }

    }
    private void Jump()
    {
        Player.AddForce(new Vector2(0, 20));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.tag.Equals("Trap"))
        {
            SceneManager.LoadScene("MainMenu");

        }

        if (collision.gameObject.tag.Equals("floor"))
        {

            RunAudioSource = GameObject.FindGameObjectWithTag("AudioRun").GetComponent<AudioSource>();
            RunAudioSource.loop = true;
            RunAudioSource.Play();

          
        }
    }



}