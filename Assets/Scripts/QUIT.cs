using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;

public class QUIT : MonoBehaviour {

    /* Lancement du jeu */

    public Button Breset;
    public Text Trelancer;

public  void START_GAME()
    {
        if(File.Exists(Application.persistentDataPath + "/" + "RLP.clicker"))
            ScoreManager.loadData();
        SceneManager.LoadScene("Jeu");
    }

/* Arret du jeu
 * 
 * Soit par ECHAP, soit par menu
 */

    public void QUIT_GAME_SAV()
    {
        ScoreManager.saveData();
        Application.Quit();
    }

    public void QUIT_GAME()
    {
        Application.Quit();
    }

    public void RESET_SAVE()
    {
        if (File.Exists(Application.persistentDataPath + "/" + "RLP.clicker"))
        {
            File.Delete(Application.persistentDataPath + "/" + "RLP.clicker");
            SceneManager.LoadScene("_Main");
        }
            
    }


    void Start()
    {
    }

    void Update ()
    {
        Button resetbt1 = Breset.GetComponent<Button>();
        Text relancertxt1 = Trelancer.GetComponent<Text>();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QUIT_GAME();
        }
        if (File.Exists(Application.persistentDataPath + "/" + "RLP.clicker"))
        {
            resetbt1.interactable = true;
            relancertxt1.text = "Relancer Jeu";
        }
        else
        {
            resetbt1.interactable = false;
            relancertxt1.text = "Lancer Jeu";
        }
        
    }


}
