using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionEvent : MonoBehaviour
{
    private PlayerManager playerManger;
    private new Rigidbody rigidbody;
    public GameObject sphere;
    private ReflectManager reflectManager;
    // Use this for initialization
    void Start()
    {

        playerManger = PlayerManager.Instance;
        reflectManager = ReflectManager.Instance;
        rigidbody = sphere.GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {
        //isReceived = trueの時
        if (RemoteCollisionVectManager.Instance.IsStopped == true && RemoteCollisionVectManager.Instance.IsReceived == true)
        {
            var vect = RemoteCollisionVectManager.Instance.Vect;
            reflectManager.Vector = vect;

            rigidbody.AddRelativeForce(vect * 1f, ForceMode.Impulse);

            RemoteCollisionVectManager.Instance.IsStopped = false;
            RemoteCollisionVectManager.Instance.IsReceived = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {

    }

    private void OnCollisionStay(Collision collision)
    {

    }


    private void OnCollisionEnter(Collision collision)
    {
        var rigidbody = collision.gameObject.GetComponent<Rigidbody>();
        var random = Random.Range(-1.0f, 1.0f);

        if (playerManger.Player == PlayerManager.PlayerType.Player1)
        {
            //random = 1;
            //challengerWallの時
            //if (this.gameObject.name.Equals("ChallengerBackWall"))
                if (this.gameObject.name.Equals("Player2Mallet"))
                {
                //止める
                rigidbody.velocity = Vector3.zero;
                RemoteCollisionVectManager.Instance.IsStopped = true;

                //var vect1 = new Vector3(random, 0, -1f);
                //reflectManager.Vector = vect1;

                //rigidbody.AddRelativeForce(vect1 * 1f, ForceMode.Impulse);
                return;
            }


            rigidbody.velocity = Vector3.zero;

            var vect = new Vector3(random, 0, 1f);
            reflectManager.Vector = vect;

            rigidbody.AddRelativeForce(vect * 1f, ForceMode.Impulse);
            //メッセージをsendする
            RemoteCollisionVectManager.Instance.SendCollisionVectInfo(vect);


            return;

        }

        if (playerManger.Player == PlayerManager.PlayerType.Player2)
        {
            //playerWallの時
            if (this.gameObject.name.Equals("Player1Mallet"))
            //if (this.gameObject.name.Equals("PlayerBackWall"))
            {
                //止める
                rigidbody.velocity = Vector3.zero;
                RemoteCollisionVectManager.Instance.IsStopped = true;
                return;
            }

            //random = 1;
            rigidbody.velocity = Vector3.zero;

            var vect = new Vector3(random, 0, -1f);
            reflectManager.Vector = vect;
            rigidbody.AddRelativeForce(vect * 1f, ForceMode.Impulse);

            //メッセージをsendする
            RemoteCollisionVectManager.Instance.SendCollisionVectInfo(vect);


            return;

        }
    }


}
