using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity.InputModule;
using UnityEngine;
using System.IO;
using System;

public class TapEvent : MonoBehaviour, HoloToolkit.Unity.InputModule.IInputClickHandler
{
    private new Rigidbody rigidbody;
    private PlayerManager playerManager;
    private TextMesh textMesh;
    private StartEvent startEvent;
    private bool isStarted;

    public bool IsStarted
    {
        get
        {
            return isStarted;
        }

        set
        {
            this.isStarted = value;
        }
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {

        if (isStarted)
        {
            return;
        }

        if (playerManager.Player == PlayerManager.PlayerType.Player1)
        {
            //rigidbody.constraints = RigidbodyConstraints.None;
            //rigidbody.useGravity = true;

            RemoteStartVectManager.Instance.SendStartVectInfo();          
            startEvent.CountDown(textMesh,3);
            isStarted = true;

            return;
        }

    }


    // Use this for initialization
    void Start()
    {
        playerManager = PlayerManager.Instance;
        textMesh = GameObject.Find("3DTextPrefab").GetComponent<TextMesh>();
        startEvent = GameObject.Find("Sphere").GetComponent<StartEvent>();
    }
	
	// Update is called once per frame
	void Update () {
	}


}
