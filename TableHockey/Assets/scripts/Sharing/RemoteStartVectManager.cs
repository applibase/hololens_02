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
    private TextMesh textMesh;
    private StartEvent startEvent;

    public class StartVectInfo
    {
        public Vector3 vector;
    }

    // Use this for initialization
    void Start()
    {
        CustomMessages.Instance.MessageHandlers[CustomMessages.TestMessageID.StartVect] = UpdateStartVect;
        textMesh = GameObject.Find("3DTextPrefab").GetComponent<TextMesh>();
        startEvent = GameObject.Find("Sphere").GetComponent<StartEvent>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //受け取ったメッセージを処理する
    private void UpdateStartVect(NetworkInMessage msg)
    {
        msg.ReadInt64();
        startEvent.CountDown(textMesh,3);


    }

    //メッセージを送る
    public void SendStartVectInfo()
    {
        if (!SharingStage.Instance.IsConnected)
        {
            return;
        }

        //メッセージを送る
        CustomMessages.Instance.SendStartVectInfo();
    }


}