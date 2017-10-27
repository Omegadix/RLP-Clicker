using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour {
    ulong add = 1;
    private Animator Clic;
	// Use this for initialization
	void Start () {
        Clic = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnMouseDown()
    {
        ScoreManager.addAbo(add);
        Clic.SetBool("Clic", true);
    }

    void OnMouseUp()
    {
        Clic.SetBool("Clic", false);
    }
}
