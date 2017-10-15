using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QUIT : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public  void START_GAME()
    { 
        SceneManager.LoadScene("Jeu");
    }

    public void QUIT_GAME()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            print("QDOJGDQPG");
            QUIT_GAME();
        }
    }
}
