using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    [SerializeField] Rigidbody2D Player;
    BoxCollider2D playerCollider;
    public float playerPosition;
    public Transform groundCheckTransform;
    private bool isGrounded;
    public LayerMask groundCheckLayerMask;
    private Animator playerAnimator;
    public ParticleSystem magicBoots;
    public float magicBootsForce = 75.0f;




    AudioSource RunAudioSource;
    void Start()
    {
        Player = GetComponent<Rigidbody2D>();
        playerPosition = Player.position.x;
        playerCollider = GetComponent<BoxCollider2D>();
        playerAnimator = GetComponent<Animator>();
        RunAudioSource = GameObject.FindGameObjectWithTag("AudioRun").GetComponent<AudioSource>();

    }
    void Update()
    {
        bool magicBootsActive = Input.GetButton("Jump");
        if (magicBootsActive)
        {
            Player.AddForce(new Vector2(0, magicBootsForce));
        }
        MovePlayer();
        ManageGroundSound();
        UpdateGroundedStatus();
        AdjustMagicBoots(magicBootsActive);



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
            
            Donnees.DeterminerRecords();
            SceneManager.LoadScene("MainMenu");
            
        }

        if (collision.gameObject.tag.Equals("floor"))
        {

           
            RunAudioSource.loop = true;
            RunAudioSource.Play();

          
        }
    }

    void UpdateGroundedStatus()
    {
        
        isGrounded = Physics2D.OverlapCircle(groundCheckTransform.position, 0.1f, groundCheckLayerMask);

        playerAnimator.SetBool("isGrounded", isGrounded);
    }

    void AdjustMagicBoots(bool magicBootsActive)
    {
        var magicBootsEmission = magicBoots.emission;
        magicBootsEmission.enabled = !isGrounded;
        if (magicBootsActive)
        {
            magicBootsEmission.rateOverTime = 300.0f;
        }
        else
        {
            magicBootsEmission.rateOverTime = 75.0f;
        }
    }





}