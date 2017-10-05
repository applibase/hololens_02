using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEvent : MonoBehaviour {

    private Rigidbody rigidbody;
	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CountDown(TextMesh textMesh,int num)
    {
        StartCoroutine(DelayMethod(1f, () =>
        {
            if (num == 0)
            {
                textMesh.text = "Start!";
                //ゲームスタート
                var vect = new Vector3(0, 0, 1);
                rigidbody.AddRelativeForce(vect * 1f, ForceMode.Impulse);
                MovementAreaManager.Instance.movementArea.SetActive(true);

                StartCoroutine(DelayMethod(1f, () =>
                {
                    textMesh.text = "";
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
