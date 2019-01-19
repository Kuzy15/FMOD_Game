using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBehaviour :GenericBehaviour {

    public string fireButton = "Fire1";     // Default fire buttons.
    public GameObject bullet;               // Bullet prefab for instantiating other bullets.
    public Transform spawnLocation;         // Position where the bullets are spawned.
    

    private bool _shootable;                 // Boolean to determinate if the player can shoot.
    private float _bulletSpeed;              // Determine the bullet velocity.
    private float _spawnTime;                // Determine the time between the bullets spawn;
    private float _distance;


    // Use this for initialization
    void Start () {

        // fireBool = Animator.StringToHash("Fire");
        _shootable = true;
        _bulletSpeed = 70.0f;
        _spawnTime = 0.25f;
        _distance = 10;
        //behaviourManager.SubscribeBehaviour(this);
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        // Get fire input.
        if (Input.GetButtonDown(fireButton) )
        {
            if (_shootable)
            {
                _shootable = false;
                Shoot();
                StartCoroutine(Shooting());
            }
        }
    }

   /* // LocalFixedUpdate overrides the virtual function of the base class.
    public override void LocalFixedUpdate()
    {

    }*/

        IEnumerator Shooting()
    {
        yield return new WaitForSeconds(_spawnTime);
        _shootable = true;
    }


    private void Shoot()
    {

        var position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _distance);
        position = Camera.main.ScreenToWorldPoint(position);

        var newBullet = Instantiate(bullet, spawnLocation.position, spawnLocation.rotation);
        newBullet.transform.LookAt(position);
        newBullet.GetComponent<Rigidbody>().velocity = newBullet.transform.forward * _bulletSpeed;
      
       
    }
}
