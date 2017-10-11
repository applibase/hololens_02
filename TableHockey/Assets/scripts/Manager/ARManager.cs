using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARManager : MonoBehaviour {

    public GameObject ImageTarget;
    public GameObject ARCamera;

	// Use this for initialization
	void Start () {

        //120フレーム後に実行する
        StartCoroutine(DelayMethod(120, () =>
        {
            ImageTarget.SetActive(true);
            ARCamera.SetActive(true);

            AudioEvent.Instance.Play();
        }));
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// 渡された処理を指定時間後に実行する
    /// </summary>
    /// <param name="delayFrameCount"></param>
    /// <param name="action">実行したい処理</param>
    /// <returns></returns>
    private IEnumerator DelayMethod(int delayFrameCount, Action action)
    {
        for (var i = 0; i < delayFrameCount; i++)
        {
            yield return null;
        }
        action();
    }
}
