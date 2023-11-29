using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeDaMusica : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;

    public void SetarVolume(float volume)
    {   
        audioMixer.SetFloat("volume", Mathf.Log10(volume)*20);
    }
}
