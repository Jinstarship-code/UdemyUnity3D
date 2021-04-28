using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    MeshRenderer renderer;
    Rigidbody rigidbody;
    [SerializeField] float Time_to_Wait=0f;

    void Start() 
    {
        renderer=GetComponent<MeshRenderer>();
        rigidbody=GetComponent<Rigidbody>();

        renderer.enabled=false;
        rigidbody.useGravity=false;
    }


    // Update is called once per frame
    void Update()
    {
       if(Time.time>Time_to_Wait)
       {
           Debug.Log(Time_to_Wait + " seconds has elapsed");
            renderer.enabled=true;
            rigidbody.useGravity=true;
       }

    }
}
