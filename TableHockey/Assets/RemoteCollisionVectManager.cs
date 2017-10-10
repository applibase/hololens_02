﻿using HoloToolkit.Sharing;
using HoloToolkit.Sharing.Tests;
using HoloToolkit.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteCollisionVectManager : Singleton<RemoteCollisionVectManager>
{
    public GameObject sphere;
    private Vector3 vect;

    private bool isStopped;
    private bool isReceived;

    public bool IsStopped
    {
        get
        {
            return isStopped;
        }
        set
        {
            this.isStopped = value;
        }
    }

    public bool IsReceived
    {
        get
        {
            return isReceived;
        }
        set
        {
            this.isReceived = value;
        }
    }


    public Vector3 Vect
    {
        get
        {
            return vect;
        }
    }
    
    public class CollisionVectInfo
    {
        public Vector3 vector;
    }

    // Use this for initialization
    void Start()
    {
        CustomMessages.Instance.MessageHandlers[CustomMessages.TestMessageID.CollisionVect] = UpdateCollisionVect;

    }

    // Update is called once per frame
    void Update()
    {

    }

    //受け取ったメッセージを処理する
    private void UpdateCollisionVect(NetworkInMessage msg)
    {
        msg.ReadInt64();

        //addForceするベクトル
        this.vect = CustomMessages.Instance.ReadCollisionVect(msg);
        isReceived = true;
        
        //玉にAddForceする
        //var rb = sphere.GetComponent<Rigidbody>();
        //rb.AddRelativeForce(vector * 1f, ForceMode.Impulse);
    }

    //メッセージを送る
    public void SendCollisionVectInfo(Vector3 vector)
    {

        if (!SharingStage.Instance.IsConnected)
        {
            return;
        }

        //メッセージを送る
        CustomMessages.Instance.SendCollisionVectInfo(vector);
    }
}