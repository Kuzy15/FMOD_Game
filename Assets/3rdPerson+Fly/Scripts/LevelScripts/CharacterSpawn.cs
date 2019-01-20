using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawn : MonoBehaviour {

    public GameObject enemy;
    public GameObject civil;

    private float _timeToSpawn;
    private float _timePassed;
    private float _timeShowing;
    private LevelManager _levelManager;

	// Use this for initialization
	public void Init (LevelManager lm, float timeToSpawn, float timeShowing)
    {
       
         gameObject.SetActive(true);
        _levelManager = lm;
        _timeToSpawn = timeToSpawn;
        _timePassed = _timeToSpawn;
        _timeShowing = timeShowing; // Este tiempo tiene que ir cambiando segun pasa el nivel y segun el nivel actual.
	}
	
	// Update is called once per frame
	void Update () {


        _timePassed -= Time.deltaTime;
        if(_timePassed <= 0)
        {
            _timePassed = _timeToSpawn;
            
            
            int rnd = Random.Range(0, 10);
            if (rnd <= 3)
            {
                var character = Instantiate(civil, transform.position, transform.rotation);
                character.GetComponent<Civil>().Init(_levelManager, _timeShowing);

            }
            else
            {
                var character = Instantiate(enemy, transform.position, transform.rotation);
                character.GetComponent<Enemy>().Init(_levelManager, _timeShowing); // @param: time while the character is showing.
            }
               
        }
	}
}