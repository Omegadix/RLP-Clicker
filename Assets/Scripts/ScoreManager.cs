using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public static ulong abonnés;
    public static float abonnésAux;
    public static ulong multiplicateurClic = 1;
    public static ulong aps = 0; //Abonnés par seconde
    private static float timer = 1;
    private static float Ntimer = 0;
    public Text text;
    public static int bonus = 0;

	// Use this for initialization
	void Awake () {
        text = GetComponent<Text>();
        abonnés = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (IsMillionAtteint())
        {
            abonnésAux = (float)abonnés / 1000000;
        }

        if (IsMilliardAtteint())
        {
            abonnésAux = (float)abonnés / 1000000000;
        }

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

        //text.text += "\nMultiplicateur Clic : " + multiplicateurClic;
        if(bonus == 1) text.text += "\nSubs/s : 2 FAST FOR U";
        else text.text += "\nSubs/s : " + aps;
        if (Time.time > Ntimer)
        {
            Ntimer = Time.time + timer;
            abonnés = abonnés + aps;
        }
	}

    public static float getScore()
    {
        return abonnés;
    }

    public static void addAbo(ulong points) {
        abonnés += points * multiplicateurClic;
    }

    public static void suppAbo(ulong points)
    {
        abonnés -= points;
    }

    public static ulong getmultiplicateurClic()
    {
        return multiplicateurClic;
    }

    public static void setmultiplicateurClic(ulong multi)
    {
        multiplicateurClic += multi;
    }
    public static void resetmultiplicateurClic(ulong multi)
    {
        multiplicateurClic = multi;
    }
    public static ulong getAps()
    {
        return aps;
    }

    public static void setAps(ulong apsmodif)
    {
        aps += apsmodif;
        
    }
    public static void resetAps(ulong apsmodif)
    {
        aps = apsmodif;

    }

    public static void setTimer(float tim)
    {
        timer = tim;
    }
    public static void setBonus(int bobo)
    {
        bonus = bobo;
    }
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

}