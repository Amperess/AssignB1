using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roamDevil : MonoBehaviour {
    Transform t;
    float x;
    int rev = 1;
	// -13.5 -22.5
	void Start () {
        t = GetComponent<Transform>();
        
	}
	
	// Update is called once per frame
	void Update () {
        x = t.position.x;
        if (x <= -22.5)
            rev = 1;
        if (x >= -13.5)
            rev = -1;
        t.position = new Vector3((x + (0.1f * rev)), t.position.y, t.position.z);
	}
}
