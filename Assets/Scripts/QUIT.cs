using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QUIT : MonoBehaviour {

/* Lancement du jeu */

    public  void START_GAME()
    {
        ScoreManager.loadData();
        SceneManager.LoadScene("Jeu");
    }

/* Arret du jeu
 * 
 * Soit par ECHAP, soit par menu
 */

    public void QUIT_GAME()
    {
        ScoreManager.saveData();
        Application.Quit();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QUIT_GAME();
        }
    }

}
