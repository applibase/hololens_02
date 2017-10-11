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
    
    // Use this for initialization

    private GameObject textObj;

    void Start () {

        
	}
	
	// Update is called once per frame
	void Update () {

        
    }

    public float getGazePoint()
    {

        //sharingPoint.transform.rotation.ToAngleAxis(out angle, out axis);
        //this.gameObject.transform.rotation = Quaternion.AngleAxis(angle, axis);
        //this.gameObject.transform.rotation = new Quaternion(0f, -1f, 0f, 0f);

        //Math.Cos(sharingPoint.transform.eulerAngles.y);

        this.gameObject.transform.position = GazeManager.Instance.HitPosition;
        Debug.Log("sharingPoint.rotation : " + sharingPoint.transform.rotation);
        Debug.Log("this.rotation : " + this.gameObject.transform.rotation);
        //this.gameObject.transform.rotation = sharingPoint.transform.rotation;

        //var gX = this.gameObject.transform.position.x;
        //var gZ = this.gameObject.transform.position.z;

        //var sita = angle * (Math.PI / 180);
        //var cosθ = ((float)Math.Cos(sita));
        //var sinθ = ((float)Math.Sin(sita));

        //var angleX = gX * cosθ - gZ * sinθ;
        //var angleZ = gX * sinθ + gZ * cosθ;

        //float x = angleX - sharingPoint.transform.position.x;
        //float z = angleZ - sharingPoint.transform.position.z;

        //angle = sharingPoint.transform.eulerAngles.y;

        //var xx = x * ((float)Math.Cos(sita));
        //var zz = z * ((float)Math.Sin(sita));

        //var move =  xx + zz;
        var player = PlayerManager.Instance.Player;


        if (player == PlayerManager.PlayerType.Player1) {


            return this.gameObject.transform.position.x - sharingPoint.transform.position.x;
        }


        return (-(this.gameObject.transform.position.x)) - sharingPoint.transform.position.x;
    }

    
}
