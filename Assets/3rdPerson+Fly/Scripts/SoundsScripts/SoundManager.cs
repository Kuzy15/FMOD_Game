using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

 // This script is used for creating and playing/pausing sounds and its management
public class SoundManager : MonoBehaviour {

    FMOD.System _soundSystem;

    private FMOD.Channel _channel;

    // Use this for initialization
    private void Awake()
    {
        Init();
    }
    public void Init ()
    {
        _soundSystem = SoundSystem.instance.GetSoundSystem();      
    }
	


    // HACER: CREAR Y REPRODUCIR EVENTOS 3D O SIN POSICIONAMIENTO (CREATE3D(), PLAY3D())
    public void Create(string path, FMOD.MODE mode, out FMOD.Sound sound)
    {
        SoundSystem.instance.ErrorCheck(_soundSystem.createSound(path, mode | FMOD.MODE._3D, out sound));
       
    }

    public void Play(FMOD.Sound sound, FMOD.ChannelGroup channelGroup, bool paused, out FMOD.Channel channel, FMOD.VECTOR pos, FMOD.VECTOR vel, FMOD.VECTOR alt_pan_pos)
    {

        _soundSystem.playSound(sound, channelGroup, paused, out channel);
        _channel = channel;
        _channel.set3DAttributes(ref pos, ref vel , ref alt_pan_pos);
    }

    public void Stop()
    {
       
       SoundSystem.instance.ErrorCheck(_channel.stop());
    }

    public void Pause(bool pause)
    {
        SoundSystem.instance.ErrorCheck(_channel.setPaused(pause));
    }

    public void ChangeVolume(float volume)
    {
        SoundSystem.instance.ErrorCheck(_channel.setVolume(volume));
    }
    public void ChangePanorama(float value)
    {
        SoundSystem.instance.ErrorCheck(_channel.setPan(value));
    }

    public void SetPitch(float value)
    {
        SoundSystem.instance.ErrorCheck(_channel.setPitch(value));
    }
}
