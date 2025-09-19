using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;


    [SerializeField] private AudioSource m_AudioSource;
    [SerializeField] private AudioClip popSound;

    private void Awake()
    {
        if (instance != null) 
        {
            if(instance != this)
            {
                Destroy(this);
            }
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

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
