using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   [SerializeField] GameObject deathVFX;
   [SerializeField] GameObject hitVFX;

   [SerializeField] Transform parent;
   [SerializeField] int scorePerHit=15;
   [SerializeField] int hitPoints = 2;

   ScoreBoard scoreBoard;

   void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();

        AddRigidbody();
    }

    private void AddRigidbody()
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();

        if(hitPoints < 1)
            KillEnemy();
    }

   void KillEnemy()
    {
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        Destroy(gameObject);
    }

   void ProcessHit()
    {
        hitPoints--;
        GameObject vfx=Instantiate(hitVFX,transform.position,Quaternion.identity);
        scoreBoard.IncreaseScore(scorePerHit);
    }
}
