using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    [SerializeField]AudioSource audOpen;
    [SerializeField]AudioSource audClose;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audOpen = GetComponent<AudioSource>();
        audClose = GetComponent<AudioSource>();
    }
    public void PlaySoundOpen()
    {
        audOpen.Play(); 
    }
    public void PlaySoundClose()
    {
        audClose.Play(); 
    }
}
