using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] float loadDelay=1f;
    [SerializeField] ParticleSystem crashVFX;

    void OnTriggerEnter(Collider other)
    {
        StartCrashSequnce();
    }

    void StartCrashSequnce()
    {
        crashVFX.Play();
        GetComponent<MeshRenderer>().enabled=false;
        GetComponent<PlayerControls>().enabled=false;
        GetComponent<BoxCollider>().enabled=false;
        Invoke("ReloadLevel",loadDelay);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}


/*
    SceneManager.GetActiveScene()

    - Return : Scene the active Scene.
    - Description
     : Gets the currently active Scene.


*/