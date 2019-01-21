using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkTrigger : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Pedestrian")
        {
            other.gameObject.GetComponent<PedestrianWalk>().ChangeDirection();
        }
    }
}
