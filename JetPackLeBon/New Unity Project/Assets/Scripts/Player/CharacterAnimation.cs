using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using TMPro;
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
    [SerializeField] Button Resume;
    public AudioSource Mourir;
    AudioSource RunAudioSource;
    public AudioClip Meurt;
    [SerializeField]TextMeshProUGUI gameOver;
    [SerializeField] Button doubler;
    [SerializeField] Button vie;
    float tempsAnimation = 0;
    bool etatAnimation = false;
    private float playerSpeed = 1f;



    //public int UnHit = 0;
    void Start()
    {
        Donnees.PartieTerminee = false;
        print("Player");
        Player = GetComponent<Rigidbody2D>();
        playerPosition = Player.position.x;
        playerCollider = GetComponent<BoxCollider2D>();
        playerAnimator = GetComponent<Animator>();
        RunAudioSource = GameObject.FindGameObjectWithTag("AudioRun").GetComponent<AudioSource>();
        Donnees.PopUpStatistiques = false;
           
}
    void Update()
    {
        
        bool magicBootsActive = Input.GetButton("Jump");
        if (magicBootsActive)
        {
            //Player.AddForce(new Vector2(0, magicBootsForce));
            
        }
        if (Donnees.DistancePartieActuelle > 0.1f)
        {
            if (playerSpeed < 5f)
            {
                playerSpeed *= 1.001f;
                Donnees.VitessePiece = playerSpeed;
            }
            else
            {
                playerSpeed = 5f;
            }
           
        }

        if (Donnees.PopUpStatistiques == false)
        {
            
            MovePlayer();
            RunAudioSource.UnPause();
        }
        else
        {
            RunAudioSource.Pause();
        }
        ManageGroundSound();
        UpdateGroundedStatus();
        if(!playerAnimator.GetBool("isDead"))
        {
            AdjustMagicBoots(magicBootsActive);
        }
       
        if (gameOver.IsActive() && !playerAnimator.GetBool("isDead"))
        {
            gameOver.gameObject.SetActive(false);
            Resume.gameObject.SetActive(true);
        }


}




    void ManageGroundSound()
    {

        if (!playerCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            RunAudioSource.Stop();
        }



    }
    private void MovePlayer()
    {
        if (!playerAnimator.GetBool("isDead"))
        {
            
            playerPosition += 0.001f;
            Player.transform.Translate(new Vector3(0.1f + (playerSpeed * Time.smoothDeltaTime), 0, 0));

            if (Input.GetAxis("Jump") > 0)
            {
                Jump();


            }
        }
        if (Donnees.invincibleBool)
        {

            if (tempsAnimation > 0.5)
            {
                etatAnimation = !etatAnimation;
                tempsAnimation = 0;
            }
            tempsAnimation += Time.deltaTime;
            if (etatAnimation)
            {
                Player.GetComponent<SpriteRenderer>().color = new Color(255, 213, 0, 255);
            }
            else
            {
                Player.GetComponent<SpriteRenderer>().color = new Color(0, 255, 0, 255);
            }
        }
        else
        {
            Player.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
        }



        if (Input.GetKeyDown(KeyCode.I) && Donnees.invincibleBool == false)
        {
            if (Donnees.invincible > 0)
            {
                Donnees.invincible -= 1;
                Donnees.invincibleBool = true;
                
                DesactiverBoxColliderPieges();
                Invoke("MettreFinInvul", 5.0f);
            }
        }
    }
    private void Jump()
    {
        Player.AddForce(new Vector2(0, 20));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Donnees.invincibleBool == false)
        {
            DeclencherMort(collision);
            


            //SceneManager.LoadScene("MainMenu");
         


            if (collision.gameObject.layer == 13)
            {

                if (!playerAnimator.GetBool("isDead"))
                {
                    RunAudioSource.loop = true;
                    RunAudioSource.Play();
                }

            }
        }

        
    }
    private void DeclencherMort(Collision2D collision)
    {
        if ((collision.gameObject.tag.Equals("Trap") || collision.gameObject.tag.Equals("TrapCeiling")) && playerAnimator.GetBool("isDead") == false)
        {
            playerAnimator.SetBool("isDead", true);
            HitByTrap(collision);
            playerSpeed = 1f;
            Invoke("AfficherStatistiqueDeMort", 3);
            magicBoots.enableEmission = false;
        }
    }

    private void AfficherStatistiqueDeMort()
    {
        if (playerAnimator.GetBool("isDead"))
        {

            Donnees.PartieTerminee = true;
            Donnees.DeterminerRecords();
            Donnees.PopUpStatistiques = true;
            gameOver.gameObject.SetActive(true);
            if(Donnees.Chance==false)
            {               
                vie.gameObject.SetActive(true);
            }
            if (Donnees.DoublerPiece == false)
            {
                doubler.gameObject.SetActive(true);
            }
               
            
            Resume.gameObject.SetActive(false);
        }


    }
    void HitByTrap(Collision2D trapCollider)
    {
        Mourir.clip = Meurt;
        Mourir.Play();
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
            magicBootsEmission.rateOverTime = 20.0f;
        }
        else
        {
            magicBootsEmission.rateOverTime = 0f;
           
        }
    }

    void DesactiverBoxColliderPieges()
    {
        GameObject[] piegesJeu = GameObject.FindGameObjectsWithTag("Trap");
        GameObject[] piegesJeu2 = GameObject.FindGameObjectsWithTag("TrapCeiling");
        for (int cptPiege = 0; cptPiege < piegesJeu.Length; cptPiege++)
        {
           
            piegesJeu[cptPiege].GetComponent<BoxCollider2D>().enabled = false;
        }
        for (int cptPiege = 0; cptPiege < piegesJeu2.Length; cptPiege++)
        {
            
            piegesJeu2[cptPiege].GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    void MettreFinInvul()
    {
        Donnees.invincibleBool = false;
        GameObject[] piegesJeu = GameObject.FindGameObjectsWithTag("Trap");
        GameObject[] piegesJeu2 = GameObject.FindGameObjectsWithTag("TrapCeiling");
        for (int cptPiege = 0; cptPiege < piegesJeu.Length; cptPiege++)
        {
           
            piegesJeu[cptPiege].GetComponent<BoxCollider2D>().enabled = true;
        }
        for (int cptPiege = 0; cptPiege < piegesJeu2.Length; cptPiege++)
        {
            
            piegesJeu2[cptPiege].GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}