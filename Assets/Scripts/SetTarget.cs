using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SetTarget : MonoBehaviour
{
    public Transform targ;
    public NavMeshAgent agent;
    public CircleCollider2D circle;
    public LayerMask layerMask;
    public ContactFilter2D contactFilter;
    public Animator anim;
    private bool playerVisible = false;
    // Start is called before the first frame update
    void Start()
    {
        targ = GameObject.Find("Player").transform;
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    private void Update() {
        if(agent.remainingDistance == 0 && !playerVisible){
            gameObject.GetComponent<NavMeshAgent>().isStopped = true;
            circle.radius = 2;
            anim.SetBool("isIdle", true);
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        CheckColliders();
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        CheckColliders();
    }
    private Vector2 GetPlayerAngle()
    {
        Transform player = GameObject.Find("Player").transform;
        Vector2 selfToPlayer = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y);
        Vector2 rotation = selfToPlayer/selfToPlayer.magnitude;
        return rotation;
    }
    private void CheckColliders()
    {
        RaycastHit2D[] hit = new RaycastHit2D[1];
        int hitCheck = Physics2D.Raycast(transform.position, new Vector3(GetPlayerAngle().x, GetPlayerAngle().y, 0), contactFilter, hit);
        Debug.DrawRay(transform.position, new Vector3(GetPlayerAngle().x, GetPlayerAngle().y, 0), Color.yellow, 2f);
        Debug.Log("Raycast Fired");
        Debug.Log("Raycast Hit:" + hit[0].collider.gameObject);
        if(hitCheck > 0){
            Debug.Log("Raycast Hit:" + hit[0].collider.gameObject);
            if (hit[0].collider.gameObject.tag == "Player")
            {
                gameObject.GetComponent<NavMeshAgent>().isStopped = false;
                playerVisible = true;
                agent.SetDestination(targ.gameObject.transform.position);
                circle.radius = 10;
                anim.SetBool("isIdle", false);
            }
            else
            {
                playerVisible = false;  
            }
        }
    }
    
}
