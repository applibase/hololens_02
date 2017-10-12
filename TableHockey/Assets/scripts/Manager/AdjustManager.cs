using HoloToolkit.Unity;
using HoloToolkit.Unity.InputModule;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustManager : Singleton<AdjustManager>
{

    public GameObject sharingPoint;
    float angle = 0.0F;
    Vector3 axis = Vector3.zero;

    void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        
    }
    
    public float getGazePoint()
    {
      
        this.gameObject.transform.position = GazeManager.Instance.HitPosition;
        return this.gameObject.transform.localPosition.x;
    }

    
}
