using UnityEngine;
using UnityEngine.UI;

public class meter : MonoBehaviour
{


    [SerializeField]
    private Transform checkpoint;
    [SerializeField]
    private Text distanceText;
    //[SerializeField]
    //private Text disatnceRestante;
    //private float metre=2000;
    private float distance;

  
    private void Update()
    {
        distance = transform.position.x;
        distanceText.text = "Distance: " + distance.ToString("F1") + " meters";
       // metre = metre - distance;
      //  disatnceRestante.text = "Distance: " + distance.ToString("F1") + " meters";

        //if (distance>=500)
        //{

        //}
 

    }
}