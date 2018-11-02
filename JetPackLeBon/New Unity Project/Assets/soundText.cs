using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;


    public class soundText : MonoBehaviour, IPointerEnterHandler
    {
    public AudioSource son;
    public AudioClip hover;
    public AudioSource sonMenu;
    public AudioClip[] myClip;


    void Start()
    {
    //    sonMenu.clip = myClip[Random.Range(0, myClip.Length)];
      //  sonMenu.Play();

    }
    public void OnPointerEnter(PointerEventData ped)
        {
        son.Play();
        }

        public void Onhover()
          {
        son.PlayOneShot(hover);
          }

    }
