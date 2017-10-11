using HoloToolkit.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

#if UNITY_UWP
using Windows.Storage;
using System.Threading.Tasks;
#endif

public class LogManager : Singleton<LogManager>, IInputClickHandler
{

    private GameObject sphere;
    private bool isStarted;
    private Stream stream;
    private AudioSource audioSource;

    public void OnInputClicked(InputClickedEventData eventData)
    {
        if (this.isStarted)
        {
            this.isStarted = false;
            this.stream.Flush();
            this.stream.Dispose();

            this.audioSource.Play();

        }

    }

    // Use this for initialization
    void Start()
    {

        this.audioSource = GameObject.Find("SharingPoint").GetComponent<AudioSource>();
        sphere = GameObject.Find("Sphere");
#if UNITY_UWP
        Task.Run(async () =>
        {
            //読み書きの準備を行う
            var player = PlayerManager.Instance.Player.ToString();

            var folder = await ApplicationData.Current.LocalFolder.CreateFolderAsync(
                        "Log", CreationCollisionOption.OpenIfExists);
            var file = await folder.CreateFileAsync("log" + "_" + player + ".txt", CreationCollisionOption.ReplaceExisting);
            this.stream = await file.OpenStreamForWriteAsync();

            isStarted = true;
        });
#endif
    }

    // Update is called once per frame
    void Update()
    {

        if (!isStarted || this.stream == null)
        {
            return;
        }

        ////ボールの位置を取得する
        Vector3 spherePos = sphere.transform.localPosition;
        var pos = "(" + spherePos.x + " , " + spherePos.y + " , " + spherePos.z + ")";

        ////現在時刻を取得する
        var localTime = DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + ":" + DateTime.Now.Millisecond;

        ////ボールの位置と時間を書き込む
        var bytes = System.Text.Encoding.UTF8.GetBytes(localTime + " : " + pos + "\n");
        stream.Write(bytes, 0, bytes.Length);

    }
}
