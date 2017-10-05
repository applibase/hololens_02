using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflectEvent : MonoBehaviour
{

    private new Rigidbody rigidbody;
    private ReflectManager reflectManager;
    // Use this for initialization
    void Start()
    {
        reflectManager = ReflectManager.Instance;
        rigidbody = GameObject.Find("Sphere").GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        rigidbody.velocity = Vector3.zero;

        var vect = reflectManager.Vector;
        var reflect = new Vector3(-vect.x, vect.y, vect.z);

        rigidbody.AddRelativeForce(reflect * 1f, ForceMode.Impulse);

        reflectManager.Vector = reflect;

    }

    private void OnCollisionExit(Collision collision)
    {

    }
    private void OnCollisionStay(Collision collision)
    {

    }


}
