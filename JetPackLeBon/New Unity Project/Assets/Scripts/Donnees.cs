using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Donnees {

    public static int MissionPointsUnePartie { get; set; }
    public static int PointsPartieActuelle { get; set; }
    public static int MissionPointsTotaux { get; set; }
    public static int PointsTotauxActuel { get; set; }
    public static int PointsMaximumNiveau { get; set; }

    public static string[] LesMissions { get; set; }

    public static float MissionDistanceUnePartie { get; set; }
    public static float DistancePartieActuelle { get; set; }
    public static float DistanceTotale { get; set; }
    public static float DistanceTotaleActuelle { get; set; }
    public static float DistanceMaximaleNiveau { get; set; }

    public static int NombreMissionsReussieParPartie { get; set; }

    public static bool DeterminerMissionPointsPartieAccomplie(int PointsPartieActuelle)
    {
        if (PointsPartieActuelle >= MissionPointsUnePartie)
        {
            MonoBehaviour.print("Mission Points une Partie complétée!");
            JouerSonMission();
        }
        return PointsPartieActuelle >= MissionPointsUnePartie;
    }
    public static bool DeterminerMissionPointsTotauxAccomplie()
    {
        if (PointsTotauxActuel >= MissionPointsTotaux)
        {
            MonoBehaviour.print("Mission Points Totaux complétée!");
            JouerSonMission();
        }
        return PointsTotauxActuel >= MissionPointsTotaux;
    }

    public static bool DeterminerBattreRecordPieces()
    {
        if (PointsPartieActuelle >= PointsMaximumNiveau)
        {
            MonoBehaviour.print("Score battu!");
        }
        return PointsPartieActuelle >= PointsMaximumNiveau;
    }

    public static bool DeterminerMissionDistancePartieAccomplie(float DistanceActuelle)
    {
        if (DistanceActuelle >= MissionDistanceUnePartie)
        {
            MonoBehaviour.print("Mission Distance une Partie complétée!");
            JouerSonMission();
        }
        return DistanceActuelle >= MissionDistanceUnePartie;
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

    public static bool DeterminerBattreRecordDistance()
    {
        if (DistancePartieActuelle >= DistanceMaximaleNiveau)
        {
            MonoBehaviour.print("Distance battue!");
        }
        return DistancePartieActuelle >= DistanceMaximaleNiveau;
    }

    public static void DeterminerRecords()
    {
        if (PointsPartieActuelle > PointsMaximumNiveau)
        {
            PointsMaximumNiveau = PointsPartieActuelle;
            MonoBehaviour.print(PointsMaximumNiveau);
        }
        if (DistancePartieActuelle > DistanceMaximaleNiveau)
        {
            DistanceMaximaleNiveau = DistancePartieActuelle;
            MonoBehaviour.print(DistanceMaximaleNiveau);
        }
    }

    public static string AfficherDistanceParcourueDurantLaPartie()
    {
        return "Distance parcourue " + DistancePartieActuelle.ToString() + "m.";
    }

    public static string AfficherPointsObtenusDurantLaPartie()
    {
        return "Vous avez obtenu " + PointsPartieActuelle.ToString() + " pièces durant la partie.";
    }

    public static string AfficherNombreMissionsReussiesDurantLaPartie()
    {
        return "Vous avez réussi " + NombreMissionsReussieParPartie.ToString() + " missions durant la partie.";
    }

    private static void JouerSonMission()
    {
        JouerSon();
    }

    private static void JouerSon()
    {

    }
}
