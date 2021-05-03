using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Movement : MonoBehaviour
{
 
    [SerializeField] float mainThrust=1000f;
    [SerializeField] float rotationThrust = 20f;
    [SerializeField] AudioClip mainEngine;

    [SerializeField] ParticleSystem leftBoostParticles;
    [SerializeField] ParticleSystem rightBoostParticles;
    [SerializeField] ParticleSystem mainBoostParticles;

    Rigidbody rb;
    AudioSource audioSource;

    //bool isAlive=false;

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
                audioSource.PlayOneShot(mainEngine);
            mainBoostParticles.Play();
        }
        else
        { 
            audioSource.Stop();
            mainBoostParticles.Stop();
        }
    }

    void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationThrust,rightBoostParticles);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationThrust,leftBoostParticles);
        }   
        else
        {
            leftBoostParticles.Stop();
            rightBoostParticles.Stop();
        }
    }

    void ApplyRotation(float rotationThisFrame,ParticleSystem LeftOrRightParticles)
    {
        rb.freezeRotation=true; //freezing rotation so we can manually rotate
        LeftOrRightParticles.Play();
        transform.Rotate(-Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation=false; //unfreezing rotation so the physics
    }
}

/*
    AddForce  : World
    AddRelativeForce : Local
*/