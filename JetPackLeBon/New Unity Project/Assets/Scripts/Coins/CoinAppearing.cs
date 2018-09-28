using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinAppearing : MonoBehaviour {
   // [SerializeField] Rigidbody2D Player;
    [SerializeField] Text DisplayScore;
    ScoreManager scoreManager;
    // Use this for initialization
    private int Score;
    void Start () {
        Score = 0;
        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
    }
	

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Destroy(gameObject);
            scoreManager.AjouterPoints(1);
        }
    }

}
