using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float resetDelay = 1f;
    [SerializeField] ParticleSystem finishedEffect;
    
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            finishedEffect.Play();
            GetComponent<AudioSource>().Play();
            Invoke("ReloadScene", resetDelay);
        }

    }

    void ReloadScene()
    {
            SceneManager.LoadScene(0);
    }
}
