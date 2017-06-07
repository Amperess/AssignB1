using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class director : MonoBehaviour
{

    public GameObject a1, a2, a3, a4, m1, m2, ea;
    int selec = 0; //0 is unselected, 1 is unit, 2 is block1, 3 is block2
    bool[] sld;
    Vector2[][] locs;
    void Start()
    {
        sld = new bool[4];
        locs = new Vector2[6][];
        locs[0] = new[] { new Vector2(7, 22), new Vector2(-40.45f, 16) };
        locs[1] = new[] { new Vector2(-24, 7.5f), new Vector2(-40.45f, -25) };
        locs[2] = new[] { new Vector2(6.6f, 14), new Vector2(-22, 8.6f) };
        locs[3] = new[] { new Vector2(6.6f, 6.6f), new Vector2(-20, 4.3f) };
        locs[4] = new[] { new Vector2(7f, 2.1f), new Vector2(-4.4f, -25f) };
        locs[5] = new[] { new Vector2(-9f, 2.6f), new Vector2(-20f, -24f) };
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.red, 20);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform != null)
                {
                    if (hit.transform.name.Contains("Agent"))
                    {
                        if (hit.transform.name == "Agent1")
                        {
                            sld[0] = true;
                        }
                        else if (hit.transform.name == "Agent2")
                        {
                            sld[1] = true;
                        }
                        else if (hit.transform.name == "Agent3")
                        {
                            sld[2] = true;
                        }
                        else if (hit.transform.name == "EvilAgent")
                        {
                            sld[3] = true;
                        }
                        if (selec != 1)
                        {
                            selec = 1;
                        }
                    }
                    else if (hit.transform.name == "MBlock1")
                    {
                        selec = 2;
                    }
                    else if (hit.transform.name == "MBlock2")
                    {
                        selec = 3;
                    }
                    else
                    {
                        switch (selec)
                        {
                            case 0:
                                break;
                            case 1:
                                moveThis(sld);
                                break;
                            case 2:
                                selec = 0;
                                break;
                            case 3:
                                selec = 0;
                                break;
                        }
                    }
                }
            }
        }
        if (selec == 2 || selec == 3)
        {
            if (Input.GetKey("left"))
            {
                moveThat(selec, 'L');
            }
            else if (Input.GetKey("right"))
            {
                moveThat(selec, 'R');
            }
            else if (Input.GetKey("up"))
            {
                moveThat(selec, 'U');
            }
            else if (Input.GetKey("down"))
            {
                moveThat(selec, 'D');
            }
        }
    }
    private void moveThis(bool[] sld) //moves first second or third goal
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction, Color.green, 20);
        if (Physics.Raycast(ray, out hit))
        {
            if (sld[0])
            {
                a1.GetComponent<moveTo>().moveIt(hit);
                sld[0] = false;
            }
            if (sld[1])
            {
                a2.GetComponent<moveTo>().moveIt(hit);
                sld[1] = false;
            }
            if (sld[2])
            {
                a3.GetComponent<moveTo>().moveIt(hit);
                sld[2] = false;
            }
            if (sld[3])
            {
                a4.GetComponent<moveTo>().moveIt(hit);
                sld[3] = false;
            }
        }
    }
    private void moveThat(int sel, char dir) //moves block
    {
        Transform move;
        if (sel == 2)
        {
            move = m1.GetComponent<Transform>();
        }
        else
        {
            move = m2.GetComponent<Transform>();
        }
        //left is z pos, up is x pos
        switch (dir)
        {
            case 'L':
                move.position = new Vector3(move.position.x, move.position.y, move.position.z + .1f);
                break;
            case 'R':
                move.position = new Vector3(move.position.x, move.position.y, move.position.z - 0.1f);
                break;
            case 'U':
                move.position = new Vector3(move.position.x + 0.1f, move.position.y, move.position.z);
                break;
            case 'D':
                move.position = new Vector3(move.position.x - 0.1f, move.position.y, move.position.z);
                break;

        }

    }
    public void relocate(string roomTag)
    {
        int curRoom, newRoom;
        curRoom = int.Parse(roomTag.Substring(roomTag.Length - 1));
        curRoom = curRoom - 1;
        ea.tag = roomTag;
        if (a1.tag == roomTag)
        {
            do
            {
                newRoom = (int)Random.Range(0, 5);
                Debug.Log(curRoom + " " + newRoom);
            } while (newRoom == curRoom);
            findLoc(newRoom, a1);
        }
        if (a2.tag == roomTag)
        {
            do
            {
                newRoom = (int)Random.Range(0, 5);
                Debug.Log(curRoom + " " + newRoom);
            } while (newRoom == curRoom);
            findLoc(newRoom, a2);
        }
        if (a3.tag == roomTag)
        {
            do
            {
                newRoom = (int)Random.Range(0, 5);
                Debug.Log(curRoom + " " + newRoom);
            } while (newRoom == curRoom);
            findLoc(newRoom, a3);
        }

    }
    public void findLoc(int newRoom, GameObject goal)
    {
        float newX, newZ;
        RaycastHit hit;
        newX = Random.Range((locs[newRoom][0].x), (locs[newRoom][1].x));
        newZ = Random.Range((locs[newRoom][0].y), (locs[newRoom][1].y));
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(newX, 0, newZ));
        if (Physics.Raycast(ray, out hit))
        {
            goal.transform.localPosition = new Vector3(newX, hit.point.y, newZ);

        }
        goal.tag = "Room" + (newRoom + 1);
    }
}
