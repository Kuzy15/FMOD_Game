using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD;
public class AmbientSound : MonoBehaviour {


    public SoundManager _soundManager;

    FMOD.VECTOR velocity;
    FMOD.VECTOR alt_pan_pos;

    FMOD.Sound _sound;
    FMOD.Channel _channel;
    FMOD.ChannelGroup _channelGroup ;

    void Start () {

        
       
        _channel = new Channel();
        _channelGroup = new FMOD.ChannelGroup();
      
        if(gameObject.GetComponent<Rigidbody>().velocity != null)
            velocity =  SoundSystem.VectorToFmod(gameObject.GetComponent<Rigidbody>().velocity);

        _soundManager.Create("../../Sounds/cafeteria.wav", FMOD.MODE.LOOP_NORMAL, out _sound);
        _soundManager.Play(_sound, _channelGroup, false, out _channel, SoundSystem.VectorToFmod(transform.position), velocity, alt_pan_pos);

       

       
    }
	
	// Update is called once per frame
	void Update () {
		
        
	}
}
