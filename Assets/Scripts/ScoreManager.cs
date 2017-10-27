using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ScoreManager : MonoBehaviour {

    /* VALEURS SCORE JOUEUR */

    public static ulong abonnés; // Score
    public static float abonnésAux; // Score quand abo > 1000000 pour calcul
    public static ulong multiplicateurClic = 1; // Abo par clic
    public static ulong aps; //Abo par seconde


    /* PARAMETRE JEU */

    private static float timer = 1;
    private static float Ntimer = 0;


    /* RECUPERATION BUTTON UNITY */

    public TextMeshProUGUI ScoreAbo_ScoreAboParSec;
    public TextMeshProUGUI MultiplicateurClic;


    /* Easter Eggs */ 

    private static int bonus = 0;


    // Use this for initialization
    void Awake () {
        ScoreAbo_ScoreAboParSec = GetComponent<TextMeshProUGUI>(); // Récupère le texte unity UI
    }
	
	// Update is called once per frame
	void Update () {

        /* Changement d'affichage si + d'un million ou + d'un milliard */

        if (IsMillionAtteint())
        {
            abonnésAux = (float)abonnés / 1000000;
        }
        else if (IsMilliardAtteint())
        {
            abonnésAux = (float)abonnés / 1000000000;
        }

        /* Ajout du Million / Milliard au texte + arrondi */
        if (abonnés < 1000000)
        {
            //text.SetText("Subscribers : {0}", abonnés); // Deux possibilités d'écrire le text avec le mesh
            ScoreAbo_ScoreAboParSec.text = "Subscribers : " + abonnés;
        }
        else if (abonnés >= 1000000 && abonnés < 1000000000)
        {
            ScoreAbo_ScoreAboParSec.text = "Subscribers : " + Mathf.Round(abonnésAux *1000f) / 1000f + " Millions";
        }
        else if (abonnés >= 1000000000 && abonnés < 100000000000)
        {
            ScoreAbo_ScoreAboParSec.text = "Subscribers : " + Mathf.Round(abonnésAux * 1000f) / 1000f + " Milliards";
        }
        else if (abonnés >= 100000000000)
        {
            ScoreAbo_ScoreAboParSec.text = "BRAVO. TU AS GAGNE <3<3";
        }

        /* Easter Egg SANIC
         * Si 42, bonus = 1 <=> aps *20 pdt 3 secondes 
         */

        if (bonus == 1)
        {
            ScoreAbo_ScoreAboParSec.text += "\nSubs/s : 2 FAST 4 U";
        }

        else ScoreAbo_ScoreAboParSec.text += "\nSubs/s : " + aps;

        MultiplicateurClic.text = "Multiplicateur Clic : " + multiplicateurClic;

        if (Time.time > Ntimer)
        {
            Ntimer = Time.time + timer;
            abonnés = abonnés + aps;
        }

	}

    /* GET & SETTERS */

    public static void addAbo(ulong points) {
        abonnés += points * multiplicateurClic;
    }
    public static void suppAbo(ulong points)
    {
        abonnés -= points;
    }

    public static float getScore()
    {
        return abonnés;
    }
    public static ulong getmultiplicateurClic()
    {
        return multiplicateurClic;
    }
    public static ulong getAps()
    {
        return aps;
    }



    public static void setmultiplicateurClic(ulong multi)
    {
        multiplicateurClic *= multi;
    }
    public static void setmultiplicateurClicPlus(ulong multi)
    {
        multiplicateurClic += multi;
    }
    public static void setAps(ulong apsmodif)
    {
        aps += apsmodif;

    }

    public static void setTimer(float tim)
    {
        timer = tim;
    }
    public static void setBonus(int bobo)
    {
        bonus = bobo;
    }


    public static void resetmultiplicateurClic(ulong multi)
    {
        multiplicateurClic = multi;
    }
    public static void resetAps(ulong apsmodif)
    {
        aps = apsmodif;

    }







    /* BOOLEAN pour Milliard ou non */

    private static bool IsMillionAtteint()
    {
        if (abonnés > 1000000 && abonnés < 1000000000)
        {
            return true;
            
        }
        else
        {
            return false;
        }
    }
    private static bool IsMilliardAtteint()
    {
        if (abonnés > 1000000000)
        {
            return true;

        }
        else
        {
            return false;
        }
    }



/*
private static bool IsMoreThanMilliard()
{
    if (abonnés > 1000000000000)
    {
        return true;

    }
    else
    {
        return false;
    }
}


*/

/* Méthode de SAVE */

public static void saveData()
    {
        print("on save les data : " + Application.persistentDataPath);
        MyData mydata = new MyData();
        mydata.abonnésSAV = abonnés;
        mydata.APSSAV = aps;
        mydata.MultiClicSAV = multiplicateurClic;

    
        mydata.achatClicMultiSAV = Ameliorations.nombreMultiClic;
        mydata.achatFollowerSAV = Ameliorations.nombreAchatFollower;
        mydata.achatConnexionInternetSAV = Ameliorations.nombreConnexionInternet;
        mydata.achatTitrePutaclicSAV = Ameliorations.nombreTitrePutaclic;
        mydata.achatVolerContenuSAV = Ameliorations.nombreVolerContenu;
        mydata.achatFeaturingSAV = Ameliorations.nombreFeaturing;


        mydata.AjoutMultiClicSAV = Ameliorations.AjoutMultiClic;
        mydata.AjoutAchatFollowerSAV = Ameliorations.AjoutAchatFollower;
        mydata.AjoutConnexionInternetSAV = Ameliorations.AjoutConnexionInternet;
        mydata.AjoutTitrePutaclicSAV = Ameliorations.AjoutTitrePutaclic;
        mydata.AjoutVolerContenuSAV = Ameliorations.AjoutVolerContenu;
        mydata.AjoutFeaturingSAV = Ameliorations.AjoutFeaturing;
        

        mydata.prixMultiClicSAV = Ameliorations.prixMultiClic;
        mydata.prixAchatFollowerSAV = Ameliorations.prixAchatFollower;
        mydata.prixConnexionInternetSAV = Ameliorations.prixConnexionInternet;
        mydata.prixTitrePutaclicSAV = Ameliorations.prixTitrePutaclic;
        mydata.prixVolerContenuSAV = Ameliorations.prixVolerContenu;
        mydata.prixFeaturingSAV = Ameliorations.prixFeaturing;


        MyDataManager.Save(mydata, "RLP.clicker");
    }

    public static void loadData()
    {
        print("chargement");
        MyData mydata = (MyData)MyDataManager.Load("RLP.clicker");
        abonnés = mydata.abonnésSAV;
        aps = mydata.APSSAV;
        multiplicateurClic = mydata.MultiClicSAV;

        Ameliorations.nombreMultiClic = mydata.achatClicMultiSAV;
        Ameliorations.nombreAchatFollower = mydata.achatFollowerSAV;
        Ameliorations.nombreConnexionInternet = mydata.achatConnexionInternetSAV;
        Ameliorations.nombreTitrePutaclic = mydata.achatTitrePutaclicSAV;
        Ameliorations.nombreVolerContenu = mydata.achatVolerContenuSAV;
        Ameliorations.nombreFeaturing = mydata.achatFeaturingSAV;


        Ameliorations.AjoutMultiClic = mydata.AjoutMultiClicSAV;
        Ameliorations.AjoutAchatFollower = mydata.AjoutAchatFollowerSAV;
        Ameliorations.AjoutConnexionInternet = mydata.AjoutConnexionInternetSAV;
        Ameliorations.AjoutTitrePutaclic = mydata.AjoutTitrePutaclicSAV;
        Ameliorations.AjoutVolerContenu = mydata.AjoutVolerContenuSAV;
        Ameliorations.AjoutFeaturing = mydata.AjoutFeaturingSAV;


        Ameliorations.prixMultiClic = mydata.prixMultiClicSAV;
        Ameliorations.prixAchatFollower = mydata.prixAchatFollowerSAV;
        Ameliorations.prixConnexionInternet = mydata.prixConnexionInternetSAV;
        Ameliorations.prixTitrePutaclic = mydata.prixTitrePutaclicSAV;
        Ameliorations.prixVolerContenu = mydata.prixVolerContenuSAV;
        Ameliorations.prixFeaturing = mydata.prixFeaturingSAV;
    }
}