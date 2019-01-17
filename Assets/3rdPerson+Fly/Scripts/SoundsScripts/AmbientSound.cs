using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD;
public class AmbientSound : MonoBehaviour {


    public SoundManager _soundManager;

    //private FMOD.VECTOR _position;
    //private FMOD.VECTOR _velocity ;
    private FMOD.VECTOR _alt_pan_pos;

    private Rigidbody _rigidBody;
    private FMOD.ATTRIBUTES_3D _attributes3D;

    private FMOD.Sound _sound;
    private FMOD.Channel _channel;
    private FMOD.ChannelGroup _channelGroup ;

    void Start () {

       
        
       
        _channel = new Channel();
        _channelGroup = new FMOD.ChannelGroup();

        //_velocity = new FMOD.VECTOR();
        _alt_pan_pos = new FMOD.VECTOR();
        //_position = SoundSystem.instance.VectorToFmod(transform.position);

        _rigidBody = gameObject.GetComponent<Rigidbody>();

        // Convert game object 3d attributes to FMOD.ATTRIBUTES_3D struct
        _attributes3D =  RuntimeUtils.To3DAttributes(gameObject, _rigidBody);

        /*if (gameObject.GetComponent<Rigidbody>() != null)
            _velocity =  SoundSystem.instance.VectorToFmod(gameObject.GetComponent<Rigidbody>().velocity);*/

       

        _soundManager.Create("Assets/3rdPerson+Fly/Sounds/cafeteria.wav", FMOD.MODE.LOOP_NORMAL, out _sound);
        
        _soundManager.Play(_sound, _channelGroup, false, out _channel, _attributes3D.position, _attributes3D.velocity, _alt_pan_pos);

        
        // minDistance: distancia a partir de la cual el sonido comienza a atenuarse
        // maxDistance: distancia a partir de la cual el sonido no se atenúa más (el volumen no es necesariamente 0.0)   
       // _channel.set3DMinMaxDistance(1.0f, 500.0f);


    }
	
	// Using fixed update because it's physics what is being updated
	void FixedUpdate () {

        /*_position = SoundSystem.instance.VectorToFmod(transform.position);
        _velocity = SoundSystem.instance.VectorToFmod(gameObject.GetComponent<Rigidbody>().velocity);*/

        // Update emitter location
        _attributes3D = RuntimeUtils.To3DAttributes(gameObject, _rigidBody);
        _channel.set3DAttributes(ref _attributes3D.position, ref _attributes3D.velocity, ref _alt_pan_pos);
    }
}
