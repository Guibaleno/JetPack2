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
    private bool missionDistancePartieAccomplie;
    private bool missionDistanceTotaleAccomplie;
    private bool distanceBattue;

    private float distancePrecedente;
    private void Awake()
    {
        missionDistancePartieAccomplie = false;
        missionDistanceTotaleAccomplie = false;
        distanceBattue = false;
    }
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