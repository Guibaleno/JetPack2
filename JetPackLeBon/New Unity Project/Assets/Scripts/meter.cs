using UnityEngine;
using UnityEngine.UI;

public class meter : MonoBehaviour
{


    [SerializeField]
    private Transform checkpoint;


    [SerializeField]
    private Text distanceText;

    private float distance;

  
    private void Update()
    {

        distance = transform.position.x;


        distanceText.text = "Distance: " + distance.ToString("F1") + " meters";

 

    }
}