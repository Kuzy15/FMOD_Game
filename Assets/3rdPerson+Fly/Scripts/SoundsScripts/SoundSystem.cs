using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD;


public class SoundSystem : MonoBehaviour{

    public static SoundSystem instance = null;

    // FMOD LOW LEVEL API system object
    private FMOD.System lowlevelSystem;
    // FMOD STUDIO system object
    private FMOD.Studio.System studioSystem;

    private FMOD.RESULT _result;
    // FMOD.Studio.CPU_USAGE _cpuUsage; // No hace falta ponerlo, se hace en el script RuntimeManager
    
    public GameObject sceneListener; // EL JUGADOR¿? LA CAMARA NO TIENE VELOCIDAD, LA TIENE EL JUGADOR
    private FMOD.ATTRIBUTES_3D _listenerAttributes3D;
   
 

   void Awake()
    {
        Init();             
    }
   
   
    // Use this for initialization
    void Init() {

        if(instance == null)
        {
            instance = this;
            // Specify that the game object with this behaviour doesn't gets destroyed when reloading the scene
            DontDestroyOnLoad(gameObject);
        }


        // Get the studio and low level systems from RuntimeManager, where them have been created
        studioSystem = FMODUnity.RuntimeManager.StudioSystem;
        lowlevelSystem = FMODUnity.RuntimeManager.LowlevelSystem;

        //studioSystem.getCPUUsage(out _cpuUsage);


        uint version;
        _result = lowlevelSystem.getVersion(out version);
        ErrorCheck(_result);

        UnityEngine.Debug.Log("FMOD version: " + version);


        //System.IntPtr extradriverdata = new System.IntPtr(0);
        // Initialize studio and low level system
        //_result = studioSystem.initialize(128, FMOD.Studio.INITFLAGS.NORMAL, FMOD.INITFLAGS.NORMAL, extradriverdata);
        //ErrorCheck(_result);
        //_result = lowlevelSystem.init(128, FMOD.INITFLAGS.NORMAL, extradriverdata);
        //ErrorCheck(_result);



        _listenerAttributes3D = RuntimeUtils.To3DAttributes(sceneListener, sceneListener.GetComponent<Rigidbody>());       
        _result = lowlevelSystem.set3DListenerAttributes(0,ref _listenerAttributes3D.position,  ref _listenerAttributes3D.velocity, ref _listenerAttributes3D.forward, ref _listenerAttributes3D.up);
        ErrorCheck(_result);

       
    }
  
    private void LateUpdate()
    {
        _listenerAttributes3D = RuntimeUtils.To3DAttributes(sceneListener, sceneListener.GetComponent<Rigidbody>());
        _result = lowlevelSystem.set3DListenerAttributes(0, ref _listenerAttributes3D.position, ref _listenerAttributes3D.velocity, ref _listenerAttributes3D.forward, ref _listenerAttributes3D.up);
        ErrorCheck(_result);

        lowlevelSystem.update();
        studioSystem.update();
    }

    void OnApplicationQuit()
    {
       //lowlevelSystem.close();
        //lowlevelSystem.release();
    }

    // Get the low level system
    public FMOD.System GetSoundSystem()
    {
        return lowlevelSystem;
    }

    // Get the studio system
    public FMOD.Studio.System GetStudioSoundSystem()
    {
        return studioSystem;
    }

    // Errors checking
    public int ErrorCheck(FMOD.RESULT result)
    {
        if (result != FMOD.RESULT.OK)
        {
            UnityEngine.Debug.LogError("FMOD ERROR " + FMOD.Error.String(result));
            
            return 1;
        }
        // Debug.Log("FMOD good");
        return 0;
    }

    // Converts an Unity vector3 into a FMOD VECTOR
    public  FMOD.VECTOR VectorToFmod(Vector3 vPosition) {

        FMOD.VECTOR fVec;
        fVec.x = vPosition.x;
        fVec.y = vPosition.y;
        fVec.z = vPosition.z;
        return fVec;
    }



}
