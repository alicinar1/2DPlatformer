using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectController : MonoSingleton<SoundEffectController>
{
    [SerializeField] private AudioSource jumpAudioSource;
    [SerializeField] private AudioSource fallAudioSource;
    [SerializeField] private AudioSource coinAudioSource;
    [SerializeField] private AudioSource endGameAudioSource;
    [SerializeField] private AudioSource gameOverAudioSource;
    [SerializeField] private AudioClip jumpSoundEffect;
    [SerializeField] private AudioClip fallSoundEffect;
    [SerializeField] private AudioClip coinSoundEffect;
    [SerializeField] private AudioClip endGameSoundEffect;
    [SerializeField] private AudioClip gameOverSoundEffect;


    public void JumpSoundEffect()
    {
        StartCoroutine(PlaySound(jumpSoundEffect, jumpAudioSource, 0.8f));
    }

    public void FallSoundEffect()
    {
        StartCoroutine(PlaySound(fallSoundEffect, fallAudioSource, 1f));
    }

    public void CoinSoundEffect()
    {
        StartCoroutine(PlaySound(coinSoundEffect, coinAudioSource, 0.2f));
    }

    public void EndGameSoundEffect() 
    {
        StartCoroutine(PlaySound(endGameSoundEffect, endGameAudioSource, 1.5f));
    }
    
    public void GameOverSounEffect()
    {
        StartCoroutine(PlaySound(gameOverSoundEffect, gameOverAudioSource, 2f));
    }

    IEnumerator PlaySound(AudioClip audioClip, AudioSource audioS, float effectDuration)
    {
        audioS.clip = audioClip;
        audioS.Play();

        yield return new WaitForSeconds(effectDuration);

        audioS.Stop();
    }
}
