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
    private float distance = 0f;
    private bool missionDistancePartieAccomplie = false;
    private bool missionDistanceTotaleAccomplie = false;
    private bool distanceBattue = false;

    private float distancePrecedente;
    private void Update()
    {
        distancePrecedente = distance;
        distance = transform.position.x;
        distanceText.text = "Distance: " + distance.ToString("F1") + " meters";
        
        float DistanceParcourueDepuisDernierFrame = distance - distancePrecedente;
        Donnees.DistanceTotaleActuelle += DistanceParcourueDepuisDernierFrame;
        Donnees.DistancePartieActuelle = distance;
        DeterminerMissionDistance();
    }

    void DeterminerMissionDistance()
    {
        if (missionDistancePartieAccomplie == false)
        {   
            missionDistancePartieAccomplie = Donnees.DeterminerMissionDistancePartieAccomplie(distance);
        }   
        if (missionDistanceTotaleAccomplie == false)
        {   
            missionDistanceTotaleAccomplie = Donnees.DeterminerMissionDistanceTotaleAccomplie();
        }
        if (distanceBattue == false)
        {
            distanceBattue = Donnees.DeterminerBattreRecordDistance();
        }
    }
    
}