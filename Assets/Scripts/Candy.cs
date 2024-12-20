using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour
{
    public int puntajeDulce;
    private GameUIManager gameUIManager;
    public ParticleSystem explosionParticle;

    private void Start()
    {
        gameUIManager = GameObject.Find("Canvas").GetComponent<GameUIManager>();
    }

    public void AddPointsScore()
    {
        gameUIManager.AddPointsGlobalS(puntajeDulce);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other != null && other.CompareTag("Player"))
        {
            AddPointsScore();
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        }
        
    }

}
