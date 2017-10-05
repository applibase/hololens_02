using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity.InputModule;
using UnityEngine;
using System.IO;

public class TapEvent : MonoBehaviour, HoloToolkit.Unity.InputModule.IInputClickHandler
{
    private new Rigidbody rigidbody;
    private PlayerManager playerManager;

    public void OnInputClicked(InputClickedEventData eventData)
    {

        
        if (playerManager.Player == PlayerManager.PlayerType.Player1)
        {
            //rigidbody.constraints = RigidbodyConstraints.None;
            //rigidbody.useGravity = true;

            var vect = new Vector3(0, 0, 1);
            rigidbody.AddRelativeForce(vect * 1f, ForceMode.Impulse);
            RemoteStartVectManager.Instance.SendStartVectInfo(vect);
            MovementAreaManager.Instance.movementArea.SetActive(true);

            return;
        }


        //if (player == PlayerManager.PlayerType.Player2)
        //{

        //    var vect = new Vector3(0, 0, 1);
        //    rigidbody.AddForce(vect * 1f, ForceMode.Impulse);
        //    RemoteStartVectManager.Instance.SendStartVectInfo(vect);
        //    return;
        //}

    }

    // Use this for initialization
    void Start()
    {
        playerManager = PlayerManager.Instance;
        rigidbody = GetComponent<Rigidbody>();
       
    }
	
	// Update is called once per frame
	void Update () {
	}
}
