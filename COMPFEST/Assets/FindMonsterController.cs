using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindMonsterController : MonoBehaviour
{
    float oldXaxis;
    private Transform playerPos;
    SpriteRenderer spriteRenderer;
    UnityEngine.AI.NavMeshAgent nav;
    float timer;
    Animator animator;

    
    // Start is called before the first frame update
    void Start()
    {
        playerPos = GetComponent<Transform>();
        oldXaxis = transform.position.x;
        spriteRenderer = GetComponent<SpriteRenderer>();
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (oldXaxis > transform.position.x) {
            //Debug.Log(oldXaxis);
            //Debug.Log("Left");
            spriteRenderer.flipX = true;
            oldXaxis = transform.position.x;
        } if (oldXaxis < transform.position.x) {
            //Debug.Log(oldXaxis);
            //Debug.Log("Right");
            spriteRenderer.flipX = false;
            oldXaxis = transform.position.x;
        }

        //Debug.Log(timer);
    }
}
