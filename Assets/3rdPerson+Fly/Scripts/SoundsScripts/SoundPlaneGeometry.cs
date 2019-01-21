using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlaneGeometry : MonoBehaviour {


    private FMOD.Geometry _geometry;
    private int _polygonIndex;

    [Range(0f, 1f)]
    public float directOcclusion;
    [Range(0f, 1f)]
    public float reverbOcclusion;

    // Start is called before the first frame update
    void Start()
    {
        
        SoundSystem.instance.ErrorCheck(SoundSystem.instance.GetSoundSystem().createGeometry(1, 4, out _geometry));

        // Cogemos la rotación y la posición
        FMOD.VECTOR position = FMODUnity.RuntimeUtils.ToFMODVector(gameObject.transform.position);
        FMOD.VECTOR forward = FMODUnity.RuntimeUtils.ToFMODVector(gameObject.transform.forward);
        FMOD.VECTOR up = FMODUnity.RuntimeUtils.ToFMODVector(gameObject.transform.up);

        //Ponemos la pared en la posición y mirando hacia donde mira el gameobject
        _geometry.setPosition(ref position);
        _geometry.setRotation(ref forward, ref up);

        Vector3 size = gameObject.transform.localScale;

        FMOD.VECTOR[] vertices = new FMOD.VECTOR[4];
        vertices[0].x = ((-size.x / 2));
        vertices[0].y = (size.y );
        vertices[0].z = 0;
        vertices[1].x = ((size.x / 2));
        vertices[1].y = (size.y );
        vertices[1].z = 0;
        vertices[2].x = ((size.x / 2));
        vertices[2].y = (-size.y );
        vertices[2].z = 0;
        vertices[3].x = ((-size.x / 2));
        vertices[3].y = (-size.y );
        vertices[3].z = 0;

        SoundSystem.instance.ErrorCheck(_geometry.addPolygon(directOcclusion, reverbOcclusion, true, 4, vertices, out _polygonIndex));

    }

    // Update is called once per frame
    void Update()
    {
       // Cogemos la rotación y la posición
        FMOD.VECTOR position = FMODUnity.RuntimeUtils.ToFMODVector(gameObject.transform.position);
        FMOD.VECTOR forward = FMODUnity.RuntimeUtils.ToFMODVector(gameObject.transform.forward);
        FMOD.VECTOR up = FMODUnity.RuntimeUtils.ToFMODVector(gameObject.transform.up);

        //Ponemos la pared en la posición y mirando hacia donde mira el gameobject
        _geometry.setPosition(ref position);
        _geometry.setRotation(ref forward, ref up);
    }



   
   
}
