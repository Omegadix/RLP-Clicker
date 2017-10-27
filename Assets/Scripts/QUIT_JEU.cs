using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;

public class QUIT_JEU : MonoBehaviour
{
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
            ScoreManager.saveData();
            SceneManager.LoadScene("_Main");
        }
    }


}
