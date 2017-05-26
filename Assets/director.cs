using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class director : MonoBehaviour {

    public GameObject a1, a2, a3, m1, m2;
    int selec = 0;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonUp(0) && (selec == 0 || selec > 3))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction*10, Color.red, 20);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform != null)
                {
                    Debug.Log("Not null, hitting " + hit.transform.name);
                    if(hit.transform.name == "Agent1")
                    {
                        selec = 1;

                    }
                    else if(hit.transform.name == "Agent2")
                    {
                        selec = 2;
                    }
                    else if (hit.transform.name == "Agent3")
                    {
                        selec = 3;
                    }
                    else if (hit.transform.name == "MBlock1")
                    {
                        selec = 4;
                    }
                    else if (hit.transform.name == "MBlock2")
                    {
                        selec = 5;
                    }
                }
            }
        }
        else if(Input.GetMouseButtonUp(0) && selec < 4)
        {
            moveThis(selec);
        }else if (selec > 3 && Input.GetKey("left"))
        {
            moveThat(selec, 'l');
        }
        else if (selec > 3 && Input.GetKey("right"))
        {
            moveThat(selec, 'r');
        }
        else if (selec > 3 && Input.GetKey("up"))
        {
            moveThat(selec, 'u');
        }
        else if (selec > 3 && Input.GetKey("down"))
        {
            moveThat(selec, 'd');
        }
    }
    private void moveThis(int sel)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction, Color.green, 20);
        if (Physics.Raycast(ray, out hit))
        {
            if(selec == 1)
            {
                a1.GetComponent<moveTo>().moveIt(hit);
            }
            else if(selec == 2)
            {
                a2.GetComponent<moveTo>().moveIt(hit);
            }
            else if(selec == 3)
            {
                a3.GetComponent<moveTo>().moveIt(hit);
            }
        }
        selec = 0;
    }
    private void moveThat(int sel, char dir)
    {
        Transform move;
        if(sel == 4)
        {
            move = m1.GetComponent<Transform>();
        }else
        {
            move = m2.GetComponent<Transform>();
        }
        //left is z pos, up is x pos
        switch (dir)
        {
            case 'l':
                move.position = new Vector3(move.position.x, move.position.y, move.position.z+.1f);
                break;
            case 'r':
                move.position = new Vector3(move.position.x, move.position.y, move.position.z-0.1f);
                break;
            case 'u':
                move.position = new Vector3(move.position.x+0.1f, move.position.y, move.position.z);
                break;
            case 'd':
                move.position = new Vector3(move.position.x-0.1f, move.position.y, move.position.z);
                break;

        }

    }
}
