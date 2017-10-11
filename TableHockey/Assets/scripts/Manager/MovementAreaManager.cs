using HoloToolkit.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAreaManager : Singleton<MovementAreaManager> {

    public GameObject movementArea;

	// Use this for initialization
	void Start () {
        movementArea.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
