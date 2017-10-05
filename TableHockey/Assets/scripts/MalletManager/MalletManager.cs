using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using HoloToolkit.Unity.InputModule;
using HoloToolkit.Sharing.Tests;

public class MalletManager : MonoBehaviour
{
    public GameObject mallet1;
    public GameObject mallet2;
    private float preX = 0f;
    //private int timeCount = 0;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {

        var player = PlayerManager.Instance.Player;

        if (player == PlayerManager.PlayerType.None)
        {
            return;

        }

        GameObject sharingPoint = GameObject.Find("SharingPoint");

        if (sharingPoint != null)
        {
            GameObject mallet;
            if (player == PlayerManager.PlayerType.Player1)
            {
                mallet = mallet1;
            }
            else
            {
                mallet = mallet2;
            }

            var hitInfo = GazeManager.Instance.HitInfo.transform;

            if (hitInfo == null)
            {
                return;
            }

            float x = AdjustManager.Instance.getGazePoint();
            float y = mallet.transform.localPosition.y;
            float z = mallet.transform.localPosition.z;
            
            if (hitInfo.gameObject != null && hitInfo.gameObject.name.Equals("MovementArea"))
            {
                if (x > 0.2f)
                {
                    x = 0.2f;
                }
                else if (x < -0.2f)
                {
                    x = -0.2f;
                }

                mallet.transform.localPosition = new Vector3(x, y, z);

                if (Math.Abs(preX - x) > 0.001)
                {
                    CustomMessages.Instance.SendMalletTransform(mallet.transform.localPosition, mallet.transform.localRotation);
                }

                //if (timeCount == 6)
                //{
                //    CustomMessages.Instance.SendMalletTransform(mallet.transform.localPosition, mallet.transform.localRotation);
                //    timeCount = 0;
                //}
                //timeCount++;

                preX = x;
            }

        }

    }
}
