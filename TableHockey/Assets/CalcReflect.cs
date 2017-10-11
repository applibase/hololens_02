using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalcReflect : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public float CalcReflectVectX(Vector3 spherePosition, Vector3 malletPosition)
    {
        var x = spherePosition.x - malletPosition.x;
        var xx = x * 20f;
        return xx;

        
    }


}
