using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyEnter : MonoBehaviour {
    public GameObject camera;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        other.tag = tag;
        if (other.name == "EvilAgent")
        {
            camera.GetComponent<director>().relocate(tag);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        other.tag = tag;
    }
}
