using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : SingletonPersistant<SoundManager>
{


    [SerializeField] private AudioSource m_AudioSource;
    [SerializeField] private AudioClip popSound;

    

    private void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }
    public void PlayPopSound()
    {
        m_AudioSource.clip = popSound;
        m_AudioSource.Play();
    }



}
