using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
//public class soundText : MonoBehaviour {
    //[SerializeField] AudioSource son;

    public class soundText : MonoBehaviour, IPointerEnterHandler
    {
    public AudioSource son;
    public AudioClip hover;

    public void OnPointerEnter(PointerEventData ped)
        {
        son.Play();
        }

        public void Onhover()
          {
        son.PlayOneShot(hover);
          }

    }
