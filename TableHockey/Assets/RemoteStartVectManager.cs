using HoloToolkit.Sharing;
using HoloToolkit.Sharing.Tests;
using HoloToolkit.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteStartVectManager : Singleton<RemoteStartVectManager>
{
    public GameObject sphere;

    public class StartVectInfo
    {
        public Vector3 vector;
    }

    // Use this for initialization
    void Start()
    {
        CustomMessages.Instance.MessageHandlers[CustomMessages.TestMessageID.StartVect] = UpdateStartVect;

    }

    // Update is called once per frame
    void Update()
    {

    }

    //受け取ったメッセージを処理する
    private void UpdateStartVect(NetworkInMessage msg)
    {
        msg.ReadInt64();

        //addForceするベクトル
        var vector = CustomMessages.Instance.ReadStartVect(msg);

        //玉にAddForceする
        var rb = sphere.GetComponent<Rigidbody>();
        rb.AddRelativeForce(vector * 1f, ForceMode.Impulse);


    }

    //メッセージを送る
    public void SendStartVectInfo(Vector3 vector)
    {
        if (!SharingStage.Instance.IsConnected)
        {
            return;
        }

        //メッセージを送る
        CustomMessages.Instance.SendStartVectInfo(vector);
    }
}