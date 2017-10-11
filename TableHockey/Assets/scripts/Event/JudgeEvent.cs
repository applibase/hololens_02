using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeEvent : MonoBehaviour {

    private PlayerManager player;
    private GameObject mallet1;
    private GameObject mallet2;
    private TextMesh textMesh;
    private StartEvent startEvent;

    // Use this for initialization
    void Start ()
    {
        mallet1 = MalletManager.Instance.mallet1;
        mallet2 = MalletManager.Instance.mallet2;
        player = PlayerManager.Instance;
        textMesh = GameObject.Find("3DTextPrefab").GetComponent<TextMesh>();
        startEvent = GameObject.Find("Sphere").GetComponent<StartEvent>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        var sphere = collision.gameObject;

        if (!sphere.name.Equals("Sphere"))
        {
            return;
        }
        var rigidbody = sphere.GetComponent<Rigidbody>();


        if (player.Player == PlayerManager.PlayerType.Player1 && this.gameObject.name.Equals("PlayerBackWall"))
        {
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;            
            rigidbody.isKinematic = true;

            sphere.transform.localRotation = new Quaternion(0, 0, 0, 1.0f);
            sphere.transform.localPosition = new Vector3(0, 0.075f, 0);
            //敗北時の処理
            textMesh.text = "YOU LOSE!!";

            //負けたという情報を送信する
            RemoteJudgeManager.Instance.SendJudgeInfo();

            return;
        }

        if (player.Player == PlayerManager.PlayerType.Player2 && this.gameObject.name.Equals("ChallengerBackWall"))
        {
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
            rigidbody.isKinematic = true;

            sphere.transform.localRotation = new Quaternion(0, 0, 0, 1.0f);
            sphere.transform.localPosition = new Vector3(0, 0.075f, 0);

            //敗北時の処理
            textMesh.text = "YOU LOSE!!";
            //負けたという情報を送信する
            RemoteJudgeManager.Instance.SendJudgeInfo();

            return;
        }

        
    }

}
