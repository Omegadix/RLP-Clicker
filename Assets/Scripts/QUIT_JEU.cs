using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;

public class QUIT_JEU : MonoBehaviour
{
    public void QUIT_GAME_SAV()
    {
        ScoreManager.saveData();
        Application.Quit();
    }

    public void QUIT_GAME()
    {
        Application.Quit();
    }

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QUIT_GAME_SAV();
        }
    }


}
