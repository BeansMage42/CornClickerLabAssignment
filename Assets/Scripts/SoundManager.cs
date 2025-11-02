using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{


    [SerializeField] private AudioSource m_AudioSource;
    [SerializeField] private AudioClip popSound;

    

    private void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
        GameManager.Instance.cornClicker.OnClickAction += PlayPopSound;

    }
    public void PlayPopSound(float corn)
    {
        m_AudioSource.clip = popSound;
        m_AudioSource.Play();
    }



}
