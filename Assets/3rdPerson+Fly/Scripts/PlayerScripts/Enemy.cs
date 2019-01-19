using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private float timeShowing;
    private LevelManager _levelManager;

    // Use this for initialization
    public void Init (LevelManager lm, float t)
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
        if(collision.gameObject.GetComponent<Bullet>() != null)
        {
            Debug.Log("Enemy hitten");
            _levelManager.EnemyKilled();
           Destroy(gameObject); 
        }
    }
}
