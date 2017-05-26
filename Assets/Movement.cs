using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    Transform t;
    public bool selected;
    int spd;
	// Use this for initialization
	void Start () {
        t = GetComponent<Transform>();
        spd = 15;
    }

    // Update is called once per frame
	void Update () {
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        if (selected)
        {
            if (Input.GetKey("left"))
            {
                t.Rotate(-Vector3.up * Time.deltaTime * 70);
            }
            else if (Input.GetKey("right"))
            {
                t.Rotate(Vector3.up * Time.deltaTime * 70);
            }
            else if ((Input.GetKey(KeyCode.RightShift) && Input.GetKey("up")) || (Input.GetKey("up") && Input.GetKey(KeyCode.RightShift)))
            {
                spd = 20;
                t.Translate(Vector3.right * Time.deltaTime * spd);
            }
            else if ((Input.GetKey(KeyCode.RightShift) && Input.GetKey("down")) || (Input.GetKey("down") && Input.GetKey(KeyCode.RightShift)))
            {
                spd = 20;
                t.Translate(Vector3.left * Time.deltaTime * spd);
            }
            else if (Input.GetKey("up"))
            {
                spd = 15;
                t.Translate(Vector3.right * Time.deltaTime * spd);
            }
            else if (Input.GetKey("down"))
            {
                spd = 15;
                t.Translate(Vector3.left * Time.deltaTime * 15);
            }
            else if (Input.GetKeyUp("space") && t.position.y < 5)
            {
                t.Translate(Vector3.up * 5f);
            }
        }
    }
}
