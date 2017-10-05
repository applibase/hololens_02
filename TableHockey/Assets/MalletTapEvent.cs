using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MalletTapEvent : MonoBehaviour, IInputClickHandler
{
    private bool isStart = false;

    public void OnInputClicked(InputClickedEventData eventData)
    {

        if (isStart)
        {
            return;
        }


        if (this.gameObject.name.Equals("Player1Mallet"))
        {
            PlayerManager.Instance.Player = PlayerManager.PlayerType.Player1;
            isStart = true;
            return;
        }

        MovementAreaManager.Instance.movementArea.SetActive(true);
        PlayerManager.Instance.Player = PlayerManager.PlayerType.Player2;
        isStart = true;

        
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}
}
