using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinAppearing : MonoBehaviour
{

    ScoreManager scoreManager;
    public AudioClip coinSound;
    AudioSource coinAudioSource;
    // Use this for initialization
    private GameObject player;
    private float speed = 10f;
    private Vector3 PlayerPos;


    private int Score;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        Score = 0;
        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
        coinAudioSource = GameObject.FindGameObjectWithTag("AudioSource").GetComponent<AudioSource>();
        //   coinSound = coinAudioSource.GetComponent<AudioClip>();
    }
    void Update()
    {
        speed = Donnees.VitessePiece + 10 ;
        PlayerPos = player.transform.position;
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, PlayerPos, step);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {

            Destroy(gameObject);
            scoreManager.AjouterPoints(1);
            coinAudioSource.PlayOneShot(coinSound);
            // AudioSource.PlayClipAtPoint(coinSound, transform.position);
            // Destroy(this.gameObject);

        }
    }

}
