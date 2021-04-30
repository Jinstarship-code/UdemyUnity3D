using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust=1000f;
    [SerializeField] float rotationThrust = 20f;
    
    Rigidbody rb;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();        
        audioSource=GetComponent<AudioSource>();
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
            if(!audioSource.isPlaying)
                audioSource.Play();
        }
        else
        {
            audioSource.Stop();
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
        rb.freezeRotation=true; //freezing rotation so we can manually rotate
        transform.Rotate(-Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation=false; //unfreezing rotation so the physics
    }
}

/*
    AddForce  : World
    AddRelativeForce : Local
*/