using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other) 
    {
        switch(other.gameObject.tag)
        {
            case "Friendly" :
                Debug.Log("This thing is friendly");
                break;

            case "Finish" :
                LoadNextLevel();
                break;

            case "Fuel" :
                Debug.Log("You picked up fuel");
                break;
            default :
                ReloadLevel();
                break;
        }
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
