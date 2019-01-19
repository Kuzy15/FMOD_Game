using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Civil : MonoBehaviour {

    private float timeShowing;
    private LevelManager _levelManager;

    // Use this for initialization
    public void Init(LevelManager lm, float t)
    {
        _levelManager = lm;
        timeShowing = t;
    }

    // Update is called once per frame
    void Update () {

        Destroy(gameObject, timeShowing);
    }

    private void OnCollisionEnter(Collision collision)
    { 
        // Llamar al game over del level manager

        if (collision.gameObject.GetComponent<Bullet>() != null)
        {          
            Destroy(gameObject);
            _levelManager.LevelOver();
        }
    }
}
