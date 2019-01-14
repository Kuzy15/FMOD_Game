using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD;
public class AmbientSound : MonoBehaviour {


    public SoundManager _soundManager;

    private FMOD.VECTOR _position;
    private FMOD.VECTOR _velocity ;
    private FMOD.VECTOR _alt_pan_pos;

    private FMOD.Sound _sound;
    private FMOD.Channel _channel;
    private FMOD.ChannelGroup _channelGroup ;

    void Start () {

       
        
       
        _channel = new Channel();
        _channelGroup = new FMOD.ChannelGroup();
        _velocity = new FMOD.VECTOR();
        _alt_pan_pos = new FMOD.VECTOR();
        _position = SoundSystem.instance.VectorToFmod(transform.position);

        if (gameObject.GetComponent<Rigidbody>() != null)
            _velocity =  SoundSystem.instance.VectorToFmod(gameObject.GetComponent<Rigidbody>().velocity);

       

        _soundManager.Create("Assets/3rdPerson+Fly/Sounds/cafeteria.wav", FMOD.MODE.LOOP_NORMAL, out _sound);
        
        _soundManager.Play(_sound, _channelGroup, false, out _channel, _position, _velocity, _alt_pan_pos);

       

       
    }

	
	// Update is called once per frame
	void FixedUpdate () {

        _position = SoundSystem.instance.VectorToFmod(transform.position);
        _velocity = SoundSystem.instance.VectorToFmod(gameObject.GetComponent<Rigidbody>().velocity);

        _channel.set3DAttributes(ref _position, ref _velocity, ref _alt_pan_pos);
    }
}
