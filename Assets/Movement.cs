using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    Transform t;
    public bool selected;
    int spd, rSpd;
	// Use this for initialization
	void Start () {
        t = GetComponent<Transform>();
        spd = 10;
        rSpd = 50;
    }

    // Update is called once per frame
    void Update()
    {
        var move = new Vector3(Input.GetAxis("Vertical"), 0, 0);
        t.Translate(move * spd * Time.deltaTime);
        var rot = new Vector3(0, transform.eulerAngles.y + Input.GetAxis("Horizontal")*rSpd*Time.deltaTime, 0);
        transform.eulerAngles = rot;
        if (Input.GetKeyUp("space") && t.position.y < 5)
        {
            t.Translate(Vector3.up * 5f);
        }
    }
}
