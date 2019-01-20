using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundsManager : MonoBehaviour {

    private FMOD.Studio.EventInstance _jumpInstance;
    private FMOD.Studio.EventInstance _WalkInstance;
    private State _state;
    private int _velocityIndex;
    private FMOD.ATTRIBUTES_3D _attributes3D;
    

    // Use this for initialization
    void Start () {

        _state = State.IDLE;


        FMOD.Studio.EventDescription walkDescription;
        SoundSystem.instance.ErrorCheck(SoundSystem.instance.GetStudioSoundSystem().getEvent("event:/Pasos", out walkDescription));
        SoundSystem.instance.ErrorCheck(walkDescription.createInstance(out _WalkInstance));

        FMOD.Studio.PARAMETER_DESCRIPTION velocityDescription;
        SoundSystem.instance.ErrorCheck(walkDescription.getParameter("Velocidad", out velocityDescription));
        _velocityIndex = velocityDescription.index;

       /* FMOD.Studio.EventDescription jumpDescription;
        SoundSystem.instance.ErrorCheck(SoundSystem.instance.GetStudioSoundSystem().getEvent("event:/Jump", out jumpDescription));
        SoundSystem.instance.ErrorCheck(jumpDescription.createInstance(out _jumpInstance));*/
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        _attributes3D = FMODUnity.RuntimeUtils.To3DAttributes(this.gameObject, this.gameObject.GetComponent<Rigidbody>());
        _WalkInstance.set3DAttributes(_attributes3D);
    }

    public void ChangeState(State s)
    {
        if (s != _state)
        {
            _state = s;
            switch (_state)
            {
                case State.IDLE:
                    //_jumpInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                    _WalkInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                    break;
                case State.JUMP:
                    _WalkInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                   // _jumpInstance.start();
                    break;
                case State.WALK:
                    _WalkInstance.start();
                    _WalkInstance.setParameterValueByIndex(_velocityIndex, 0.5f);
                    break;
                case State.RUN:
                    _WalkInstance.start();
                    _WalkInstance.setParameterValueByIndex(_velocityIndex, 1.0f);
                    break;
               
                default:
                    break;
            }
        }

    }

  
}
