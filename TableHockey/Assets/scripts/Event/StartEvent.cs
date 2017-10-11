using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEvent : MonoBehaviour {

    private Rigidbody rigidbody;
    private TextTapEvent textTapEvent;
    private GameObject sphere;

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
        textTapEvent = GameObject.Find("Text").GetComponent<TextTapEvent>();
        sphere = GameObject.Find("Sphere");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CountDown(TextMesh textMesh,int num)
    {
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
        rigidbody.isKinematic = true;

        sphere.transform.localRotation = new Quaternion(0, 0, 0, 1.0f);
        sphere.transform.localPosition = new Vector3(0, 0.075f, 0);

        RemoteCollisionVectManager.Instance.IsReceived = false;

        StartCoroutine(DelayMethod(1f, () =>
        {
            if (num == 0)
            {
                textMesh.text = "Start!";
                //ゲームスタート
                var vect = new Vector3(0, 0, 1);
                rigidbody.isKinematic = false; 
                rigidbody.AddRelativeForce(vect * 1f, ForceMode.Impulse);
                MovementAreaManager.Instance.movementArea.SetActive(true);

                StartCoroutine(DelayMethod(1f, () =>
                {
                    textMesh.text = "Reset";
                    textTapEvent.IsStarted = false;
                }));
            }
            else
            {
                textMesh.text = "" + num;
                num -= 1;
                CountDown(textMesh,num);
            }

        }));
    }

    private IEnumerator DelayMethod(float waitTime, Action action)
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }
}
