using HoloToolkit.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectManager : Singleton<ReflectManager> {

    private Vector3 vector;

    public Vector3 Vector
    {
        get
        {
            return vector;
        }

        set
        {
            vector = value;
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
