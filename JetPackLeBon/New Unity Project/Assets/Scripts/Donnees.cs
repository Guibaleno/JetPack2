using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Donnees {

    public static int PointsUnePartie { get; set; }
    public static int PointsTotaux { get; set; }
    public static int PointsTotauxActuel { get; set; }
    public static int PointsMaximumNiveau { get; set; }

    public static string[] LesMissions { get; set; }

    public static float DistanceUnePartie { get; set; }
    public static float DistanceTotale { get; set; }
    public static float DistanceTotaleActuelle { get; set; }
    public static float DistanceMaximaleNiveau { get; set; }

    public static bool DeterminerMissionPointsPartieAccomplie(int PointsPartieActuelle)
    {
        if (PointsPartieActuelle >= PointsUnePartie)
        {
            MonoBehaviour.print("Mission Points une Partie complétée!");
            JouerSonMission();
        }
        return PointsPartieActuelle >= PointsUnePartie;
    }
    public static bool DeterminerMissionPointsTotauxAccomplie()
    {
        if (PointsTotauxActuel >= PointsTotaux)
        {
            MonoBehaviour.print("Mission Points Totaux complétée!");
            JouerSonMission();
        }
        return PointsTotauxActuel >= PointsTotaux;
    }

    public static bool DeterminerMissionDistancePartieAccomplie(float DistanceActuelle)
    {
        if (DistanceActuelle >= DistanceUnePartie)
        {
            MonoBehaviour.print("Mission Distance une Partie complétée!");
            JouerSonMission();
        }
        return DistanceActuelle >= DistanceUnePartie;
    }
    
    public static bool DeterminerMissionDistanceTotaleAccomplie()
    {
        if (DistanceTotaleActuelle >= DistanceTotale)
        {
            MonoBehaviour.print("Mission Distance Totale complétée!");
            JouerSonMission();
        }
        return DistanceTotaleActuelle >= DistanceTotale;
    }

    public static void FinPartie(int pieceAmassees, float distanceParcourue)
    {
        if (pieceAmassees > PointsMaximumNiveau)
        {
            PointsMaximumNiveau = pieceAmassees;
        }
        if (distanceParcourue > DistanceMaximaleNiveau)
        {
            DistanceMaximaleNiveau = distanceParcourue;
        }
    }

    private static void JouerSonMission()
    {

    }
}
