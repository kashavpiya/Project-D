using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSoundController : MonoBehaviour
{

    public AudioSource source;
    public AudioClip audioClip;

    public void playClip()
    {
        source.clip = audioClip;
        source.Play();
    }
}
