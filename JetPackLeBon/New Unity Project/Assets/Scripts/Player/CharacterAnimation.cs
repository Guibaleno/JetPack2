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
    //private bool isDead = false;


    //public int UnHit = 0;
    void Start()
    {
        Donnees.PartieTerminee = false;
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
        AdjustMagicBoots(magicBootsActive);



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
        //if (!isDead)
        //{
            playerPosition += 0.001f;
            Player.transform.Translate(new Vector3(0.1f, 0, 0));
        //}
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

        if (Input.GetAxis("Jump") > 0)
        {
            Jump();


        }

        if (Input.GetKeyDown(KeyCode.I) && Donnees.invincibleBool == false)
        {
            //if (Donnees.invincible > 0)
            //{
            Donnees.invincible -= 1;
            Donnees.invincibleBool = true;
            Invoke("MettreFinInvul", 5.0f);
            //}
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
            if (collision.gameObject.tag.Equals("Trap"))
            {
                //float timer = 3.0f;
                //if (timer < 0)
                //{


                //}

                Donnees.PartieTerminee = true;
                Donnees.DeterminerRecords();
                Donnees.PopUpStatistiques = true;
                //SceneManager.LoadScene("MainMenu");
                Resume.gameObject.SetActive(false);
                gameOver.gameObject.SetActive(true);
                doubler.gameObject.SetActive(true);
                vie.gameObject.SetActive(true);
                Mourir.clip = Meurt;
                Mourir.Play();
                //timer -= Time.deltaTime;

                //playerAnimator.SetBool("isDead", true);
                //HitByTrap(collision);


            }
        }
        if (collision.gameObject.layer == 13)
        {


            RunAudioSource.loop = true;
            RunAudioSource.Play();


        }
        
    }
    //void HitByTrap(Collision2D trapCollider)
    //{
    //    isDead = true;
    //}

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

    void MettreFinInvul()
    {
        Donnees.invincibleBool = false;
        GameObject[] piegesJeu = GameObject.FindGameObjectsWithTag("Trap");
        for (int cptPiege = 0; cptPiege < piegesJeu.Length; cptPiege++)
        {
            print(piegesJeu[cptPiege].ToString());
            piegesJeu[cptPiege].GetComponent<BoxCollider2D>().enabled = true;
        }
    }
}