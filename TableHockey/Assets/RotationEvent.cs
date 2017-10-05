using HoloToolkit.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationEvent : Singleton<RotationEvent>
{

    private PlayerManager player;

	// Use this for initialization
	void Start () {
        player = PlayerManager.Instance;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Rotate()
    {
        GameObject.Find("3DTextPrefab").GetComponent<TextMesh>().text = "Start?";

        var quaternion = this.gameObject.transform.localRotation;

        if (player.Player == PlayerManager.PlayerType.Player1)
        {
            //プレイヤー1の時の処理
           
            this.gameObject.transform.localRotation =  new Quaternion(0,0,0,quaternion.w);
            return;
        }

        this.gameObject.transform.localRotation = new Quaternion(0, 180, 0, quaternion.w);

        return;
    }
}
