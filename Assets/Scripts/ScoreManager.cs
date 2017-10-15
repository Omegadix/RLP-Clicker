using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

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

    public Text text;


    /* Easter Eggs */ 

    private static int bonus = 0;


    // Use this for initialization
    void Awake () {
        text = GetComponent<Text>(); // Récupère le texte unity UI
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
        if (!IsMillionAtteint() && !IsMilliardAtteint())
        {
            text.text = "Subscribers : " + abonnés;
        }
        else if (IsMillionAtteint() && !IsMilliardAtteint())
        {
            text.text = "Subscribers : " + Mathf.Round(abonnésAux *1000f) / 1000f + " Millions";
        }
        else if (!IsMillionAtteint() && IsMilliardAtteint())
        {
            text.text = "subscribers : " + Mathf.Round(abonnésAux * 1000f) / 1000f + " Milliards";
        }
        else if (IsMoreThanMilliard())
        {
            text.text = "BRAVO. TU AS GAGNE <3<3";
        }

        /* Easter Egg SANIC
         * Si 42, bonus = 1 <=> aps *20 pdt 3 secondes 
         */

        if (bonus == 1)
        {
            text.text += "\nSubs/s : 2 FAST 4 U";
        }

        else text.text += "\nSubs/s : " + aps;



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

    /* Méthode de SAVE */

    public static void saveData()
    {
        print("on save les data : " + Application.persistentDataPath);
        MyData mydata = new MyData();
        mydata.abonnésSAV = abonnés;
        mydata.APSSAV = aps;
        mydata.MultiClicSAV = multiplicateurClic;

        MyDataManager.Save(mydata, "RLP.clicker");
    }

    public static void loadData()
    {
        print("chargement");
        MyData mydata = (MyData)MyDataManager.Load("RLP.clicker");
        abonnés = mydata.abonnésSAV;
        aps = mydata.APSSAV;
        multiplicateurClic = mydata.MultiClicSAV;
    }
}