using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTo : MonoBehaviour {
    Transform t;
	// Use this for initialization
	void Start () {
        t = GetComponent<Transform>();
	}
    //z is -26,26 x is -6, 26
    // Update is called once per frame
    void Update()
    {
        t.Rotate(new Vector3(0, 45, 0) * Time.deltaTime);
    }
    public void moveIt(RaycastHit hi)
    {
        Debug.Log("I like to move it move it");
        t.position = new Vector3(hi.point.x, hi.point.y + 1.5f, hi.point.z);
    }
}
