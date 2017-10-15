using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Button))]
public class Ameliorations : MonoBehaviour {


    /* BOUTONS */
    
    public Button amelio1;
    public Button amelio2;
    public Button amelio3;

    /* Textes */

    public Text text1;
    public Text text2;
    public Text text3;

    /* Prix des Bonus */

    public static ulong PrixBonus1 = 5; // Prix actuel de l'amélio1
    public static ulong PrixBonus2 = 10; // Prix actuel de l'amélio2
    public static ulong PrixBonus3 = 42;

    /* récompense des bonus */

    public static ulong AjoutBonus1 = 2; // Ajout Bonus 1
    public static ulong AjoutBonus2 = 2; // Ajout Bonus 1
    public static ulong AjoutBonus3 = 2; // Ajout Bonus 1

    /* Variables de calcul */ 

    public static ulong multiplicateurActu; // Multiplicateur actuel récupéré avec un GET
    public float scoreActu; // Valeur auxiière pour le calcul des scores
    public ulong SAV_APS;
    public ulong SAV_MultiClic;
    public bool Bonus;

    /* Sons */

    public AudioClip Sanic;
    public AudioClip mlg;

    /* UNITY */

    public Text txt; // Button amélio 3
    Color baseColor;

/**
 * Fonction qui débute avant tout le reste
 * amelio.GetComponent<Button>() Permet de récupérer les boutons au démarrage (pour pas qu'ils soient nul)
 * onClick.AddListener ==> Permet le lancement d'une fonction au click du bouton
 * 
 * **BUG A CORRIGER** 
 * Actuellement, le onClick detecte le MOUSEUP et MOUSEDOWN ==> Double Achat
 * **/

    void Start () {
        Button btn1 = amelio1.GetComponent<Button>();
        Button btn2 = amelio2.GetComponent<Button>();
        Button btn3 = amelio3.GetComponent<Button>();
        btn1.onClick.AddListener(Multi1);
        btn2.onClick.AddListener(Multi2);
        btn3.onClick.AddListener(Multi3);
    }
	


	void Update () {
        Button btn1 = amelio1.GetComponent<Button>();
        Button btn2 = amelio2.GetComponent<Button>();
        Button btn3 = amelio3.GetComponent<Button>();

        scoreActu = ScoreManager.getScore(); // Permet le calcul pour les achats
        text1.text = "Améliorer souris\n(" + PrixBonus1 + ')';
        text2.text = "Acheter Followers\n(" + PrixBonus2 + ')';
        text3.text = "WOW BABY (?)";
        if (scoreActu >= PrixBonus1)
        {
            btn1.interactable = true;
        }
        else btn1.interactable = false;
        if (scoreActu >= PrixBonus2)
        {
            btn2.interactable = true;
        }
        else btn2.interactable = false;
        if (scoreActu == PrixBonus3)
        {
            btn3.interactable = true;
            txt.color = Color.black;
        }
        else
        {
            txt.color = new Color(0, 0, 0, 0);
            btn3.interactable = false;
        }
        if (Bonus)
        {
            Bonus = false;
            StartCoroutine(BonusTime(3));
        }
    }

    void Multi1()
    {
        if (scoreActu >= PrixBonus1)
        {

            ScoreManager.suppAbo(PrixBonus1);
            PrixBonus1 = PrixBonus1 * 2;
            ScoreManager.setmultiplicateurClic(AjoutBonus1);
            AjoutBonus1 += 1;


        }
        else if (scoreActu < PrixBonus1) print("PAS ASSEZ");
    }

    void Multi2()
    {
        if (scoreActu >= PrixBonus2)
        {
           
            ScoreManager.suppAbo(PrixBonus2);
           PrixBonus2 = PrixBonus2 * 2;
            ScoreManager.setAps(AjoutBonus2);
            AjoutBonus2 += 1;

        }
        else if (scoreActu < PrixBonus2) print("PAS ASSEZ");    
    }

    void Multi3()
    {
        if (scoreActu == PrixBonus3)
        {
            ScoreManager.suppAbo(PrixBonus3);
            Bonus = true;
            
        }
        else if (scoreActu < PrixBonus2)
        {
            print("PAS ASSEZ");
            Bonus = false;
        }
    }
    IEnumerator BonusTime(int sec)
    {
        SAV_APS = ScoreManager.getAps();
        SAV_MultiClic = ScoreManager.getmultiplicateurClic();
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = Sanic;
        audio.Play();
        ScoreManager.setAps(20);
        ScoreManager.setmultiplicateurClic(20);
        ScoreManager.setTimer(1 / 10);
        ScoreManager.setBonus(1);
        Debug.Log("Before Waiting" + sec + " seconds");
        yield return new WaitForSeconds(sec);
        Debug.Log("After Waiting " + sec + " Seconds");
        ScoreManager.resetAps(SAV_APS);
        ScoreManager.resetmultiplicateurClic(SAV_MultiClic);
        ScoreManager.setTimer(1);
        ScoreManager.setBonus(0);
        audio.Stop();
        audio.clip = mlg;
        audio.Play();

    }
}
