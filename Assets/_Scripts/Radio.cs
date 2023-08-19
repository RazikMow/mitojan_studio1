using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class Radio : MonoBehaviour
{
   public AudioSource radio;
   public AudioSource switchSound;

   public int radioInt;

   private void Start()
   {
      radioInt = 0;
      //radio.Play();
   }

   private void Update()
   {
      if(Input.GetKeyDown(KeyCode.E))
      {
         switchSound.Play();
         radioInt += 1;
      } else if(radioInt == 2)
      {
         radioInt = 0;
      }

      if(radioInt == 0)
      {
         radio.UnPause();
      } else if(radioInt == 1)
      {
         radio.Pause();
      }
   }

}
