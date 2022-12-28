using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource gameAudio;
    public AudioSource bgmAudio;

    //����BGM
    public void PlayBgm(AudioClip bgmclip)
    {
        bgmAudio.clip = bgmclip;
        bgmAudio.loop = true;
        bgmAudio.Play();
    }
    //���ŶԻ�
    public void PlaySound(AudioClip sound)
    {
        gameAudio.clip = sound;
        gameAudio.Play();
    }

    public void StopSound()
    {
        if (gameAudio.isPlaying == true)
        {
            gameAudio.Stop();
        }
        
    }
    
}
