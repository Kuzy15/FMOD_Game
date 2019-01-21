using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianWalk : MonoBehaviour {

    private float _x;
    private float _dir;
	// Use this for initialization
	void Start () {
        _dir = 1.0f;
        _x = gameObject.transform.position.x;
    }
	
	// Update is called once per frame
	void Update () {

        _x += _dir;
        //this.gameObject.transform.position.Set(_x, gameObject.transform.position.y, gameObject.transform.position.z);
        gameObject.transform.Translate(_dir * Time.deltaTime, 0, 0, Space.World);
	}

    public void ChangeDirection()
    {
        _dir *= -1;
        Vector3 rotation = new Vector3(0, 180, 0);
        gameObject.transform.Rotate(rotation, Space.Self);
    }
}
