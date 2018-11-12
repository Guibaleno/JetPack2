using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Timers;

public class Donnees {
    public static bool PopUpStatistiques { get; set; }
    public static int MissionPointsUnePartie { get; set; }
    public static int PointsPartieActuelle { get; set; }
    public static int MissionPointsTotaux { get; set; }
    public static int PointsTotauxActuel { get; set; }
    public static int PointsMaximumNiveau { get; set; }
    public static bool MissionPointsTotauxCompletee { get; set; }

    public static float VitessePiece { get; set; }
    public static bool DoublerPiece { get; set; }
    public static bool Chance { get; set; }

    public static int PointsAchat { get; set; }
    public static int PointsObtenusMission { get; set; }

    public static string[] LesMissions { get; set; }

    public static float MissionDistanceUnePartie { get; set; }
    public static float DistancePartieActuelle { get; set; }
    public static float MissionDistanceTotale { get; set; }
    public static float DistanceTotaleActuelle { get; set; }
    public static float DistanceMaximaleNiveau { get; set; }
    public static bool MissionDistanceTotaleCompletee { get; set; }

    public static int NombreMissionsReussieParPartie { get; set; }
    public static bool PartieTerminee { get; set; }


    public static List<bool> tableauJetPacks = new List<bool>();
    public static bool jetPackBonhomme { get; set; }
    public static bool jetPackEtoile { get; set; }

    public static bool jetPackBonhommeAchetee { get; set; }
    public static bool jetPackEtoileAchetee { get; set; }

    public static int invincible { get; set; }
    public static bool invincibleBool { get; set; }

    public static bool PartieCommencee { get; set; }
    public static void CommencerPartie()
    {
                   
            tableauJetPacks.Add(jetPackBonhomme);
            tableauJetPacks.Add(jetPackEtoile);
            for (int cptJetPack = 0; cptJetPack < tableauJetPacks.Count; cptJetPack++)
            {
                tableauJetPacks[cptJetPack] = false;
            }

            tableauJetPacks[0] = true;
            PartieCommencee = true;
            invincible = 0;
        MonoBehaviour.print("nouvelle partie");
    }

    public static int TrouverJetPackActuel()
    {
        int cptJetPack = 0;
        bool trouve = false;
        while (cptJetPack < tableauJetPacks.Count && trouve == false)
        {
            if (tableauJetPacks[cptJetPack] == true)
            {
                trouve = true;
            }
            cptJetPack++;
        }
        MonoBehaviour.print(tableauJetPacks.Count);
        MonoBehaviour.print(tableauJetPacks[0]);
        MonoBehaviour.print(tableauJetPacks[1]);
        return cptJetPack ;
    }

    public static void ChangerJetPack(string jetPackName)
    {
        int jetPackAActiver = 0;
        if (jetPackName == "jetPackEtoile")
        {
            jetPackAActiver = 1;
            jetPackEtoileAchetee = true;
            tableauJetPacks[1] = true;
            tableauJetPacks[0] = false;
            
            MonoBehaviour.print(tableauJetPacks[0]);
            MonoBehaviour.print(tableauJetPacks[1]);
        }
        else
        {
            jetPackAActiver = 0;
            jetPackBonhommeAchetee = true;
            tableauJetPacks[1] = false;
            tableauJetPacks[0] = true;
            
        }
        MonoBehaviour.print(jetPackName);
        for (int cptJetPack = 0; cptJetPack < tableauJetPacks.Count; cptJetPack++)
        {
            
            if (cptJetPack != jetPackAActiver)
            {
                tableauJetPacks[cptJetPack] = false;
            }
            else
            {
                tableauJetPacks[cptJetPack] = true;
            }
            
        }
    }

    public static bool DeterminerMissionPointsPartieAccomplie()
    {
        if (PointsPartieActuelle >= MissionPointsUnePartie)
        {
            NombreMissionsReussieParPartie += 1;
            MonoBehaviour.print("Mission Points une Partie complétée!");
            ManageMissions(5);
        }
        return PointsPartieActuelle >= MissionPointsUnePartie;
    }
    public static bool DeterminerMissionPointsTotauxAccomplie()
    {
        if (PointsTotauxActuel >= MissionPointsTotaux)
        {
            NombreMissionsReussieParPartie += 1;
            MissionPointsTotauxCompletee = true;
            ManageMissions(10);
            PointsTotauxActuel = 0;
        }
        return PointsTotauxActuel >= MissionPointsTotaux;
    }

    public static bool DeterminerBattreRecordPieces()
    {
        if (PointsPartieActuelle > PointsMaximumNiveau)
        {
            MonoBehaviour.print("Score battu!");
            JouerSonRecordBattu();
        }
        return PointsPartieActuelle > PointsMaximumNiveau;
    }

    public static bool DeterminerMissionDistancePartieAccomplie(float DistanceActuelle)
    {
        if (DistanceActuelle >= MissionDistanceUnePartie)
        {
            NombreMissionsReussieParPartie += 1;
            
            ManageMissions(5);
        }
        return DistanceActuelle >= MissionDistanceUnePartie;
    }
    
    public static bool DeterminerMissionDistanceTotaleAccomplie()
    {
        if (DistanceTotaleActuelle >= MissionDistanceTotale)
        {
            NombreMissionsReussieParPartie += 1;
            MissionDistanceTotaleCompletee = true;
            ManageMissions(10);
            DistanceTotaleActuelle = 0;
        }
        return DistanceTotaleActuelle >= MissionDistanceTotale;
    }

    public static bool DeterminerBattreRecordDistance()
    {
        if (DistancePartieActuelle > DistanceMaximaleNiveau)
        {
            MonoBehaviour.print("Distance battue!");
            JouerSonRecordBattu();
        }
        return DistancePartieActuelle > DistanceMaximaleNiveau;
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
        return "Distance parcourue " + Math.Round(Convert.ToDecimal(DistancePartieActuelle), 1).ToString() + "m.";
    }
    public static string AfficherArgentTotale()
    {
        return Math.Round(Convert.ToDecimal(PointsTotauxActuel)).ToString() ;
    }

    public static string AfficherPointsObtenusDurantLaPartie()
    {
        return "Vous avez obtenu " + PointsPartieActuelle.ToString() + " pièces durant la partie.";
    }

    public static string AfficherNombreMissionsReussiesDurantLaPartie()
    {
        return "Vous avez réussi " + NombreMissionsReussieParPartie.ToString() + " missions durant la partie pour un total de " + PointsObtenusMission.ToString() + " pièces supplémentaires.";
    }

    private static void ManageMissions(int bonusMission)
    {
        PointsAchat += bonusMission;
        PointsObtenusMission += bonusMission;
        JouerSonMission();
    }
    private static void JouerSonMission()
    {
        AudioSource sonMission = GameObject.FindGameObjectWithTag("AudioMission").GetComponent<AudioSource>();
        JouerSon(sonMission);
    }

    private static void JouerSonRecordBattu()
    {
        AudioSource sonRecord = GameObject.FindGameObjectWithTag("AudioRecord").GetComponent<AudioSource>();
        JouerSon(sonRecord);
    }

    private static void JouerSon(AudioSource sonAJouer)
    {
        sonAJouer.Play();
    }
}
