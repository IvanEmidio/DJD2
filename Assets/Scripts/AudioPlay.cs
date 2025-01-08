using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    [SerializeField]AudioSource audOpen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audOpen = GetComponent<AudioSource>();
    }
    public void PlaySoundOpen()
    {
        audOpen.Play(); 
    }
}
