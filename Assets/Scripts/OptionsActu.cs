using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsActu : MonoBehaviour {

    private Button Fenetre;
    public bool Est_Fenetre;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void Changement_Fenetre(bool Est_Fenetre)
    {
        Screen.fullScreen = Est_Fenetre;
    }
}
