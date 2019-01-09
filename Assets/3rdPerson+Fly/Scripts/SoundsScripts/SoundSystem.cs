using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class SoundSystem : MonoBehaviour{

    // FMOD LOW LEVEL API system object
    public static FMOD.System lowlevelSystem;
    // FMOD STUDIO system object
    public static FMOD.Studio.System studioSystem;

    private FMOD.RESULT _result;
    // FMOD.Studio.CPU_USAGE _cpuUsage; // No hace falta ponerlo, se hace en el script RuntimeManager

    public GameObject sceneListener; // EL JUGADOR¿? LA CAMARA NO TIENE VELOCIDAD, LA TIENE EL JUEGADOR
    FMOD.VECTOR fordward;
    FMOD.VECTOR up;
    FMOD.VECTOR listenerPos;
    FMOD.VECTOR listenerVel;

 

    void Awake()
    {
        Init();             
    }

   
    // Use this for initialization
    void Init() {

        // Get the studio and low level systems from RuntimeManager, where them have been created
        studioSystem = FMODUnity.RuntimeManager.StudioSystem;
        lowlevelSystem = FMODUnity.RuntimeManager.LowlevelSystem;

        //studioSystem.getCPUUsage(out _cpuUsage);


        uint version;
        _result = lowlevelSystem.getVersion(out version);
        ErrorCheck(_result);

        Debug.Log("FMOD version: " + version);

        System.IntPtr extradriverdata = new System.IntPtr(0);


        // Initialize studio and low level system
       // _result = studioSystem.initialize(128, FMOD.Studio.INITFLAGS.NORMAL, FMOD.INITFLAGS.NORMAL, extradriverdata);
        //ErrorCheck(_result);
        //_result = lowlevelSystem.init(128, FMOD.INITFLAGS.NORMAL, extradriverdata);
        //ErrorCheck(_result);


        listenerPos = VectorToFmod(sceneListener.transform.position);
        listenerVel = VectorToFmod(sceneListener.GetComponent<Rigidbody>().velocity);
       
        lowlevelSystem.set3DListenerAttributes(0,ref listenerPos,  ref listenerVel, ref fordward, ref up);
    }

    // Get the low level system
    static public FMOD.System GetSoundSystem()
    {
        return lowlevelSystem;
    }

    // Errors checking
    static public int ErrorCheck(FMOD.RESULT result)
    {
        if (result != FMOD.RESULT.OK)
        {
            Debug.LogError("FMOD ERROR " + result);
            return 1;
        }
        // Debug.Log("FMOD good");
        return 0;
    }

    // Converts an Unity vector3 into a FMOD VECTOR
    public static FMOD.VECTOR VectorToFmod(Vector3 vPosition) {

        FMOD.VECTOR fVec;
        fVec.x = vPosition.x;
        fVec.y = vPosition.y;
        fVec.z = vPosition.z;
        return fVec;
    }



}
