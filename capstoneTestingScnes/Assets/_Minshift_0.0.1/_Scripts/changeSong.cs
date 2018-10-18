using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeSong : MonoBehaviour {

    public AudioSource music;
    public int songTrackNumber;
    // Use this for initialization
    private void Awake()
    {
        music = GameObject.FindGameObjectWithTag("MainSoundtrack").GetComponent<AudioSource>();
        music.Stop();
        music.clip = music.GetComponent<audioPocket>().SoundsOfWar[songTrackNumber];
        music.Play();
        music.loop = true;
    }

}
