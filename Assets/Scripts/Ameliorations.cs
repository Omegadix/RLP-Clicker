using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Button))]
public class Ameliorations : MonoBehaviour {


    /* BOUTONS */
    
    public Button ClicBonus;
    public Button achatFollower;
    public Button connexionInternet;
    public Button titrePutaclic;
    public Button volerContenu;
    public Button featuring;
    public Button easterEggSanic;

    /* Textes */

    public Text textClic;
    public Text textAchatFollower;
    public Text textConnexionInternet;
    public Text textTitrePutaclic;
    public Text textVolerContenu;
    public Text textFeaturing;
    public Text textEasterEggSanic;

    /* Prix des Bonus */

    public static ulong prixMultiClic = 100;
    public static ulong prixAchatFollower = 25; 
    public static ulong prixConnexionInternet = 150;
    public static ulong prixTitrePutaclic = 1800;
    public static ulong prixVolerContenu = 8000;
    public static ulong prixFeaturing = 40000;
    public static ulong prixEasterEggSanic = 42;

    /* récompense des bonus */

    public static ulong AjoutMultiClic = 2;
    public static ulong AjoutAchatFollower = 5; 
    public static ulong AjoutConnexionInternet = 20;
    public static ulong AjoutTitrePutaclic = 200; 
    public static ulong AjoutVolerContenu = 800;
    public static ulong AjoutFeaturing = 1500;
    
    /* Nombre d'achat achetés */

    public static int nombreMultiClic;
    public static int nombreAchatFollower;
    public static int nombreConnexionInternet;
    public static int nombreTitrePutaclic;
    public static int nombreVolerContenu;
    public static int nombreFeaturing;

    /* Variables de calcul */

    public static ulong multiplicateurActu; // Multiplicateur actuel récupéré avec un GET
    public float scoreActu; // Valeur auxilière pour le calcul des scores
    public ulong SAV_APS;
    public ulong SAV_MultiClic;
    public bool Bonus;

    /* Sons */

    public AudioClip Sanic;
    public AudioClip mlg;

    /* UNITY */

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

        /* Déclaration des boutons + Fonctions */

        Button btn1Clic = ClicBonus.GetComponent<Button>();
        btn1Clic.onClick.AddListener(AchatMultiClic);

        Button btn2Follower = achatFollower.GetComponent<Button>();
        btn2Follower.onClick.AddListener(AchatFollower);

        Button btn3ConnexionInternet = connexionInternet.GetComponent<Button>();
        btn3ConnexionInternet.onClick.AddListener(AchatConnexionInternet);

        Button btn4TitrePutaclic = titrePutaclic.GetComponent<Button>();
        btn4TitrePutaclic.onClick.AddListener(AchatTitrePutaclic);

        Button btn5VolerContenu = volerContenu.GetComponent<Button>();
        btn5VolerContenu.onClick.AddListener(AchatVolerContenu);

        Button btn6Featuring = featuring.GetComponent<Button>();
        btn6Featuring.onClick.AddListener(AchatFeaturing);

        Button btnBonusEasterEggSanic = easterEggSanic.GetComponent<Button>();
        btnBonusEasterEggSanic.onClick.AddListener(BonusSanic);
    }
	


	void Update () {

        scoreActu = ScoreManager.getScore(); // Permet le calcul pour les achats


        /* Redéclaration des boutons (pour éviter les erreurs) */
        Button btn1Clic = ClicBonus.GetComponent<Button>();
        Button btn2Follower = achatFollower.GetComponent<Button>();
        Button btn3ConnexionInternet = connexionInternet.GetComponent<Button>();
        Button btn4TitrePutaclic = titrePutaclic.GetComponent<Button>();
        Button btn5VolerContenu = volerContenu.GetComponent<Button>();
        Button btn6Featuring = featuring.GetComponent<Button>();
        Button btnBonusEasterEggSanic = easterEggSanic.GetComponent<Button>();


        /* Champs textes qui s'actualise */

        textClic.text = "Améliorer souris\nBonus Clic : +" + AjoutMultiClic + "\nPrix : (" + prixMultiClic + ") [" + nombreMultiClic + "]";
        textAchatFollower.text = "Acheter Followers\nBonus Subs/s : +" + AjoutAchatFollower + "\n(" + prixAchatFollower + ") [" + nombreAchatFollower + "]";
        textConnexionInternet.text = "Améliorer connexion internet\nBonus Subs/s : +" + AjoutConnexionInternet + "\nPrix : (" + prixConnexionInternet + ") [" + nombreConnexionInternet + "]";
        textTitrePutaclic.text = "Chercher des titres 'Putaclic'\nBonus Subs/s : +" + AjoutTitrePutaclic + "\nPrix : (" + prixTitrePutaclic + ") [" + nombreTitrePutaclic + "]";
        textVolerContenu.text = "Voler du contenu\nBonus Subs/s : +" + AjoutVolerContenu + "\nPrix : (" + prixVolerContenu + ") [" + nombreVolerContenu + "]";
        textFeaturing.text = "Faire un featuring\nBonus Subs/s : +" + AjoutFeaturing + "\nPrix : (" + prixFeaturing + ") [" + nombreFeaturing + "]";
        textEasterEggSanic.text = "WOW BABY (?)";

        
        if (scoreActu >= prixMultiClic)
        {
            btn1Clic.interactable = true;
        }
        else btn1Clic.interactable = false;



        if (scoreActu >= prixAchatFollower)
        {
            btn2Follower.interactable = true;
        }
        else btn2Follower.interactable = false;



        if (scoreActu >= prixConnexionInternet)
        {
            btn3ConnexionInternet.interactable = true;
        }
        else btn3ConnexionInternet.interactable = false;



        if (scoreActu >= prixTitrePutaclic)
        {
            btn4TitrePutaclic.interactable = true;
        }
        else btn4TitrePutaclic.interactable = false;




        if (scoreActu >= prixVolerContenu)
        {
            btn5VolerContenu.interactable = true;
        }
        else btn5VolerContenu.interactable = false;



        if (scoreActu >= prixFeaturing)
        {
            btn6Featuring.interactable = true;
        }
        else btn6Featuring.interactable = false;



        if (scoreActu == prixEasterEggSanic)
        {
            btnBonusEasterEggSanic.interactable = true;
            textEasterEggSanic.color = Color.black;
        }
        else
        {
            textEasterEggSanic.color = new Color(0, 0, 0, 0);
            btnBonusEasterEggSanic.interactable = false;
        }



        if (Bonus)
        {
            Bonus = false;
            StartCoroutine(BonusTime(3));
        }
    }




    void AchatMultiClic()
    {
            ScoreManager.suppAbo(prixMultiClic);
            prixMultiClic = prixMultiClic * 2;
            ScoreManager.setmultiplicateurClic(AjoutMultiClic);
            nombreMultiClic += 1;
    }



    void AchatFollower()
    {
            ScoreManager.suppAbo(prixAchatFollower);
           prixAchatFollower *= 2;
            ScoreManager.setAps(AjoutAchatFollower);
            nombreAchatFollower += 1;    
    }



    void AchatConnexionInternet()
    {
            ScoreManager.suppAbo(prixConnexionInternet);
            prixConnexionInternet *= 2;
            ScoreManager.setAps(AjoutConnexionInternet);
            nombreConnexionInternet += 1;
    }



    void AchatTitrePutaclic()
    {
            ScoreManager.suppAbo(prixTitrePutaclic);
            prixTitrePutaclic *= 2;
            ScoreManager.setAps(AjoutTitrePutaclic);
            nombreTitrePutaclic += 1;
    }




    void AchatVolerContenu()
    {
            ScoreManager.suppAbo(prixVolerContenu);
            prixVolerContenu *= 2;
            ScoreManager.setAps(AjoutVolerContenu);
            nombreVolerContenu += 1;
    }




    void AchatFeaturing()
    {
            ScoreManager.suppAbo(prixFeaturing);
            prixFeaturing *= 2;
            ScoreManager.setAps(AjoutFeaturing);
            nombreFeaturing += 1;
    }



    void BonusSanic()
    {
        if (scoreActu == prixEasterEggSanic)
        {
            ScoreManager.suppAbo(prixEasterEggSanic);
            Bonus = true;
            
        }
        else if (scoreActu < prixAchatFollower)
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
