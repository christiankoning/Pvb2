using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour {

    public AudioClip Punch;
    public AudioClip Collectible;
    public AudioClip FireBallHit;
    public AudioClip MenuMusic;

    public AudioSource AudioCollecting;
    public AudioSource AudioShot;
    public AudioSource AudioSwordSwing;
    public AudioSource MainMenuSong;

    void Start()
    {
        AudioShot = AddAudio(FireBallHit, false, 0.2f);
        AudioCollecting = AddAudio(Collectible, false, 0.2f);
        MainMenuSong = AddAudio(MenuMusic, true, 0.5f);
        CheckScene();
    }

    public AudioSource AddAudio(AudioClip clip, bool Loop, float Volume)
    {
        AudioSource NewAudio = gameObject.AddComponent<AudioSource>();
        NewAudio.clip = clip;
        NewAudio.loop = Loop;
        NewAudio.volume = Volume;
        return NewAudio;
    }

    void CheckScene()
    {
        if (SceneManager.GetSceneByBuildIndex(0).isLoaded)
        {
            MainMenuSong.Play();
        }
    }
}
