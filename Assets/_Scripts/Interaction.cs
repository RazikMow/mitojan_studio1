using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public AudioSource radioMusic;
    public AudioSource switchSoundRadio;
    public int _Radio;
    
    public GameObject intText;
    public GameObject circleImage;
    
    public bool interactable;

    private void Start()
    {
        //radioMusic.Play();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("MainCamera"))
        {
            intText.SetActive(true);
            circleImage.SetActive(true);
            interactable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        intText.SetActive(false);
        circleImage.SetActive(false);
        interactable = false;
    }

    private void Update()
    {
        if(interactable == true)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                switchSoundRadio.Play();
                _Radio += 1;
            }
        }

        if(_Radio == 2)
        {
            _Radio = 0;
        }

        if(_Radio == 1)
        {
            radioMusic.Pause();
        } else if(_Radio == 0)
        {
            radioMusic.UnPause();
        }
    }
}
