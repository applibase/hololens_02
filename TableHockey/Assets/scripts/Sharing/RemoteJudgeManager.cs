using HoloToolkit.Sharing;
using HoloToolkit.Sharing.Tests;
using HoloToolkit.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteJudgeManager : Singleton<RemoteJudgeManager>
{
    public GameObject sphere;
    private PlayerManager player;
    private new Rigidbody rigidbody;
    private TextMesh textMesh;

    // Use this for initialization
    void Start ()
    {
        CustomMessages.Instance.MessageHandlers[CustomMessages.TestMessageID.Judge] = UpdateJudge;
        player = PlayerManager.Instance;
        rigidbody = sphere.GetComponent<Rigidbody>();
        textMesh = GameObject.Find("3DTextPrefab").GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update () {
		
	}

    //受け取ったメッセージを処理する
    private void UpdateJudge(NetworkInMessage msg)
    {

        msg.ReadInt64();

        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
        rigidbody.isKinematic = true;

        sphere.transform.localRotation = new Quaternion(0, 0, 0, 1.0f);
        sphere.transform.localPosition = new Vector3(0, 0.075f, 0);

        //勝ち負け表示
        textMesh.text = "YOU WIN!!";

    }

    //メッセージを送る
    public void SendJudgeInfo()
    {
        if (!SharingStage.Instance.IsConnected)
        {
            return;
        }

        //メッセージを送る
        CustomMessages.Instance.SendJudgeInfo();
    }

}
