using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierTexture : MonoBehaviour {

    public Shader shader;
    public Texture2D texture;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Donnees.article==true)
        {
            Renderer rend = GameObject.FindGameObjectWithTag("particle").GetComponent<Renderer>();
            rend.material = new Material(shader);
            rend.material.mainTexture = texture;
        }

    }
}
