using HoloToolkit.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : Singleton<SpeedManager> {

    [SerializeField, Range(0.01f, 1.0f)]
    private float addForceSpeed;
    [SerializeField, Range(0.01f, 1.0f)]
    private float startBallSpeed;

    public float AddForceSpeed
    {
        get
        {
            return addForceSpeed;
        }
    }

    public float StartBallSpeed
    {
        get
        {
            return startBallSpeed;
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
