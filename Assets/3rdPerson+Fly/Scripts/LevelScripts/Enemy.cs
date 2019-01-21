using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private float timeShowing;
    private LevelManager _levelManager;
    private FMOD.Studio.EventInstance _screamInstance;
    private FMOD.Studio.EventInstance _spawnInstance;
    private FMOD.ATTRIBUTES_3D _attributes3D;

    // Use this for initialization
    public void Init (LevelManager lm, float t)
    {
        _levelManager = lm;
        timeShowing = t;

        // Event description for creating the scream event instance
        FMOD.Studio.EventDescription screamDescription;
        SoundSystem.instance.ErrorCheck(SoundSystem.instance.GetStudioSoundSystem().getEvent("event:/Scream", out screamDescription));
        SoundSystem.instance.ErrorCheck(screamDescription.createInstance(out _screamInstance));

        // Event description for creating the spawn event instance
        FMOD.Studio.EventDescription spawnDescription;
        SoundSystem.instance.ErrorCheck(SoundSystem.instance.GetStudioSoundSystem().getEvent("event:/HelloEnemy", out spawnDescription));
        SoundSystem.instance.ErrorCheck(spawnDescription.createInstance(out _spawnInstance));

        // Set the 3d attributes of this sound depending on this script's owner
        _attributes3D = FMODUnity.RuntimeUtils.To3DAttributes(this.gameObject, this.gameObject.GetComponent<Rigidbody>());
        _screamInstance.set3DAttributes(_attributes3D);
        _spawnInstance.set3DAttributes(_attributes3D);

        // Set the minimum and maximum distances for scream event instance
        SoundSystem.instance.ErrorCheck(_screamInstance.setProperty(FMOD.Studio.EVENT_PROPERTY.MINIMUM_DISTANCE, 3.0f));
        SoundSystem.instance.ErrorCheck(_screamInstance.setProperty(FMOD.Studio.EVENT_PROPERTY.MAXIMUM_DISTANCE, 30.0f));

        // Set the minimum and maximum distances for scream event instance
        SoundSystem.instance.ErrorCheck(_spawnInstance.setProperty(FMOD.Studio.EVENT_PROPERTY.MINIMUM_DISTANCE, 3.0f));
        SoundSystem.instance.ErrorCheck(_spawnInstance.setProperty(FMOD.Studio.EVENT_PROPERTY.MAXIMUM_DISTANCE, 30.0f));

        _spawnInstance.setVolume(0.5f);
        _spawnInstance.start();

    }

    // Update is called once per frame
    void Update () {

        Destroy(gameObject, timeShowing);
    }

    private void FixedUpdate()
    {
        _attributes3D = FMODUnity.RuntimeUtils.To3DAttributes(this.gameObject, this.gameObject.GetComponent<Rigidbody>());
        _screamInstance.set3DAttributes(_attributes3D);
        _spawnInstance.set3DAttributes(_attributes3D);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Has been hitten by a bullet
        if(collision.gameObject.GetComponent<Bullet>() != null)
        {
            // Start the replay of the event
            _screamInstance.start();

            Debug.Log("Enemy hitten");           
            _levelManager.EnemyKilled();
            Destroy(gameObject); 
        }
    }

    private void OnDestroy()
    {
        _screamInstance.release();
        _spawnInstance.release();
    }
}
