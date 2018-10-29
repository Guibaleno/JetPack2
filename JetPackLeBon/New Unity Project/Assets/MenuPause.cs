using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPause : MonoBehaviour {
  //  public static bool Pause = false;
    public GameObject pauseMenu;
    // Use this for initialization
    void Start () {
        Donnees.PopUpStatistiques = false;
        //GameObject.FindGameObjectWithTag("Respawn").GetComponent<Text>().text = "Terminer";
        print(GameObject.FindGameObjectWithTag("Respawn").GetComponent<Text>().text);
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           if (!PartieTerminee())
           {
             Donnees.PopUpStatistiques = !Donnees.PopUpStatistiques;
           }
        }
            
            if (Donnees.PopUpStatistiques)
            {
            //GameObject.FindGameObjectWithTag("Respawn").GetComponent<Text>().text = "Resume";
            JeuEnPause();
                
            }
            else
            {
                Resume();

            }

        
    }
    public void JeuEnPause()
    {        
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            //Pause = true;       
    }
   public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        //Pause = false;
    }

    private bool PartieTerminee()
    {
        return Donnees.PartieTerminee; //GameObject.FindGameObjectWithTag("Respawn").GetComponent<Text>().text != "Terminer";
    }
}
