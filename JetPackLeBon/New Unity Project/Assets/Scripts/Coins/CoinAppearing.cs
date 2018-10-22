using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinAppearing : MonoBehaviour
{
    // [SerializeField] Rigidbody2D Player;
    ScoreManager scoreManager;
    public AudioClip coinSound;
    AudioSource coinAudioSource;
    // Use this for initialization
    private int Score;
    void Start()
    {
        Score = 0;
        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
        coinAudioSource = GameObject.FindGameObjectWithTag("AudioSource").GetComponent<AudioSource>();
        //   coinSound = coinAudioSource.GetComponent<AudioClip>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Destroy(gameObject);
            scoreManager.AjouterPoints(1);
            //print(coinSound.ToString());
            coinAudioSource.PlayOneShot(coinSound);
            // AudioSource.PlayClipAtPoint(coinSound, transform.position);
            // Destroy(this.gameObject);

        }
    }

}
