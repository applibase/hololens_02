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
        if (RemoteCollisionVectManager.Instance.IsReceived == true)
        {
            var vect = RemoteCollisionVectManager.Instance.Vect;
            reflectManager.Vector = vect;

            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;

            sphere.transform.localRotation = new Quaternion(0, 0, 0, 1.0f);
            sphere.transform.localPosition = RemoteCollisionVectManager.Instance.Positon;

            rigidbody.AddRelativeForce(vect * 1f, ForceMode.Impulse);


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
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
            sphere.transform.localRotation = new Quaternion(0, 0, 0, 1.0f);

            var vect = new Vector3(random, 0, 1f);
            var position = sphere.transform.localPosition;
            reflectManager.Vector = vect;

            rigidbody.AddRelativeForce(vect * 0.8f, ForceMode.Impulse);
            //メッセージをsendする
            RemoteCollisionVectManager.Instance.SendCollisionVectInfo(vect,position);


            return;

        }

        if (playerManger.Player == PlayerManager.PlayerType.Player2)
        {

            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
            sphere.transform.localRotation = new Quaternion(0, 0, 0, 1.0f);

            var vect = new Vector3(random, 0, -1f);
            reflectManager.Vector = vect;
            var position = sphere.transform.localPosition;

            rigidbody.AddRelativeForce(vect * 0.8f, ForceMode.Impulse);

            //メッセージをsendする
            RemoteCollisionVectManager.Instance.SendCollisionVectInfo(vect,position);


            return;

        }
    }


}
