using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float resetDelay = .5f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;
    bool canCrashSound = true;
    
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag =="Ground" && canCrashSound)
        {
            FindObjectOfType<PlayerController>().DisableControls();
            crashEffect.Play();
            canCrashSound = false;
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", resetDelay);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }

}
