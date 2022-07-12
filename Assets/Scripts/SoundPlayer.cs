using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource _clickActionSource;
    [SerializeField] private AudioSource _musicSource;

    [Header("Music")]
    [SerializeField] private AudioClip _mainMenuMusic;
    [SerializeField] private AudioClip _gameMusic;

    [Header("Sounds")]
    [SerializeField] private AudioClip _buttonClickSound; 
    [SerializeField] private AudioClip _defeatSound;
    [SerializeField] private AudioClip _monsterKilledSound;
    [SerializeField] private AudioClip _punchSound;

    private void Start()
    {
        Monster.OnMosnterPunched += PlayButtonPunchSound;
        Monster.OnMonsterDead += PlayMonsterKilledtSound;
    }

    #region Sounds
    public void PlayButtonClickSound()
    {
        _clickActionSource.PlayOneShot(_buttonClickSound);
    }

    public void PlayButtonPunchSound()
    {
        _clickActionSource.PlayOneShot(_punchSound);
    }

    public void PlayDefeatSound()
    {
        _clickActionSource.PlayOneShot(_defeatSound);
    }

    public void PlayMonsterKilledtSound()
    {
        _clickActionSource.PlayOneShot(_monsterKilledSound);
    }
    #endregion

    #region Musics
    public void PlayGameMusic()
    {
        _musicSource.clip = _gameMusic;
        _musicSource.Play();
    }

    public void PlayMainMenuMusic()
    {
        _musicSource.clip = _mainMenuMusic;
        _musicSource.Play();
    }
    #endregion
}
