using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEvent : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnEnable()
    {
        var audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.Play();
    }
}
