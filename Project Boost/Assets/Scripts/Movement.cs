using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust=1000f;
    [SerializeField] float rotationThrust = 20f;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
        ProcessRotation();
    }

    private void ProcessInput()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up*Time.deltaTime*mainThrust);
        }
    }

    private void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationThrust);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationThrust);
        }   
    }

    void ApplyRotation(float rotationThisFrame)
    {
        transform.Rotate(-Vector3.forward * rotationThisFrame * Time.deltaTime);
    }
}

/*
    AddForce  : World
    AddRelativeForce : Local


*/