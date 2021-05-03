using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay=2f;
    [SerializeField] AudioClip explosionSound;
    [SerializeField] AudioClip finishSound;

    [SerializeField] ParticleSystem sucessParticles;
    [SerializeField] ParticleSystem crashParticles;

   
    AudioSource audioSource;

    bool isTransitioning=false;
    bool collisionDisable=false;
     private void Start() 
    {
        audioSource=GetComponent<AudioSource>();     
    }

    void Update() 
    {
       RespondToDebugKeys();
        

    }

    void RespondToDebugKeys()
    {
        if(Input.GetKeyDown(KeyCode.L))
            LoadNextLevel();
        else if(Input.GetKeyDown(KeyCode.C))
        {
            collisionDisable= !collisionDisable; //toggle collision
        }
    }

    void OnCollisionEnter(Collision other) 
    {
        if(isTransitioning||collisionDisable)
            return;

         switch(other.gameObject.tag)
         {
             case "Friendly" :
                 Debug.Log("This thing is friendly");
                 break;

             case "Finish" :
                 StartSuccessSequence();
                 break;

             default :
                 StartCrashSequence();
                 break;
         }

    }

    void StartSuccessSequence()
    {
        isTransitioning=true;
        audioSource.Stop();
        audioSource.PlayOneShot(finishSound);

        sucessParticles.Play();
        //todo add particle esffect upon sucess
        GetComponent<Movement>().enabled=false;
        Invoke("LoadNextLevel",levelLoadDelay);
    }

    void StartCrashSequence()
    {
        isTransitioning=true;
        audioSource.Stop();
        audioSource.PlayOneShot(explosionSound);

        crashParticles.Play();
        //todo add particle effect upon crash
        GetComponent<Movement>().enabled=false;
        Invoke("ReloadLevel",levelLoadDelay);
    }

    void ReloadLevel()
    {
        int currentSceneIndex=SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void LoadNextLevel()
    {
        int currentSceneIndex=SceneManager.GetActiveScene().buildIndex;
        int nextScneneIndex=currentSceneIndex+1;
        if(nextScneneIndex==SceneManager.sceneCountInBuildSettings)
        {
            nextScneneIndex=0;
        }
        SceneManager.LoadScene(nextScneneIndex);
    }
}

/*
    using Invoke
    - Using Invoke() allows us to call a method so it executes after a delay of x seconds.
    - Syntax : Invoke("MethodName",delayInSeconds);
    - Pros : Quick and easy to use
    - Cons : String referencd; not as performant as using a Coroutine


*/