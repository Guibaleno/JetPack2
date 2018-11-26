using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierTexture : MonoBehaviour {

    public Shader shader;
    public Texture2D[] texture;
    // Use this for initialization
    void Start () {
        Renderer rend = GameObject.FindGameObjectWithTag("particle").GetComponent<Renderer>();
        rend.material = new Material(shader);
        rend.material.mainTexture = texture[Donnees.TrouverJetPackActuel() - 1];
    }
	
	// Update is called once per frame
	void Update () {

            
        

    }
}
