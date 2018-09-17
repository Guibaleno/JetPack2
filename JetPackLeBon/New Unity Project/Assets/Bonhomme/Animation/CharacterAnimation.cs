using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour {
    [SerializeField] Rigidbody2D Player;
    public float playerPosition;
	// Use this for initialization
	void Start () {
        Player = GetComponent<Rigidbody2D>();
        playerPosition = Player.position.x;
    }

    // Update is called once per frame
    void Update () {
        MovePlayer();        
    }
    private void MovePlayer()
    {
        
        playerPosition += 0.001f;
        Player.transform.Translate(new Vector3(0.1f,0, 0));
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
        print("mort");
        if (collision.gameObject.tag.Equals("Trap"))
        {
            SceneManager.LoadScene("MainMenu");
            
        }
    }
}
