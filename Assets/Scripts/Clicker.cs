using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour {
    ulong add = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnMouseDown()
    {
        ScoreManager.addAbo(add);
    }

}
