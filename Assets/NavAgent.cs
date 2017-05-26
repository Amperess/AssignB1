using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavAgent : MonoBehaviour {
    public Transform target;
    Transform self;
    NavMeshAgent agent;
    Animator a;
    float v;
    Vector3 cp, pp;
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        a = GetComponent<Animator>();
        self = GetComponent<Transform>();
        cp = self.position;
        pp = self.position;
    }
	
	// Update is called once per frame
	void Update () {
        agent.SetDestination(target.position);
        /*
        cp = self.position;
        v = (cp - pp).magnitude / Time.deltaTime;
        if (Mathf.Abs(0-v) > 0.1)
        {
            a.SetBool("isMoving", true);
        }
        else
        {
            a.SetBool("isMoving", false);
        }
        pp = self.position;
        */
    }
}
