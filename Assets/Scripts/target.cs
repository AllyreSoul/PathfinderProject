using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class target : MonoBehaviour
{
    public Transform targ;
    // Start is called before the first frame update
	void Start()	{
		var agent = GetComponent<NavMeshAgent>();
		agent.updateRotation = false;
		agent.updateUpAxis = false;
        agent.SetDestination(targ.position);
	}
}
