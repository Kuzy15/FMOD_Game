using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

 // This script is used for creating and playing/pausing sounds and its management
public class SoundManager : MonoBehaviour {

    FMOD.System _soundSystem;

    // Use this for initialization
    private void Start()
    {
        Init();
    }
    public void Init ()
    {
        _soundSystem = SoundSystem.GetSoundSystem();
    }
	
    public void Create(string path, FMOD.MODE mode, out FMOD.Sound sound)
    {
        _soundSystem.createSound(path, mode | FMOD.MODE._3D, out sound);
       
    }

    public void Play(FMOD.Sound sound, FMOD.ChannelGroup channelGroup, bool paused, out FMOD.Channel channel, FMOD.VECTOR pos, FMOD.VECTOR vel, FMOD.VECTOR alt_pan_pos)
    {

        _soundSystem.playSound(sound, channelGroup, paused, out channel);
        channel.set3DAttributes(ref pos, ref vel , ref alt_pan_pos);
    }

    public void Stop()
    {

    }

    void Pause(bool pause)
    {

    }

    void ChangeVolume(float volume)
    {

    }
    void ChangePanorama(float value)
    {

    }

    void SetPitch(float value)
    {

    }

    void FadeIn(float time)
    {

    }

    void FadeOut(float time)
    {

    }
}
