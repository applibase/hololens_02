using HoloToolkit.Sharing;
using HoloToolkit.Sharing.Tests;
using HoloToolkit.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteMalletManager : Singleton<RemoteMalletManager> {


    private GameObject mallet1;
    private GameObject mallet2;


    // Use this for initialization
    void Start () {

        CustomMessages.Instance.MessageHandlers[CustomMessages.TestMessageID.MalletTransform] = UpdateMalletTransform;

        mallet1 = GameObject.Find("Player1Mallet");
        mallet2 = GameObject.Find("Player2Mallet");


    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void UpdateMalletTransform(NetworkInMessage msg)
    {
        // Parse the message
        long userID = msg.ReadInt64();

        Vector3 malletPos = CustomMessages.Instance.ReadVector3(msg);

        Quaternion headRot = CustomMessages.Instance.ReadQuaternion(msg);
        var player = PlayerManager.Instance.Player;

        if (player == PlayerManager.PlayerType.Player1) {

            mallet2.transform.localPosition = malletPos;
        }

        if (player == PlayerManager.PlayerType.Player2)
        {

            mallet1.transform.localPosition = malletPos;
        }

    }
}
