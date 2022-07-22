using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator animator;
    public Rigidbody2D rb2d;
    UnityEngine.AI.NavMeshAgent nav;

    public float Health = 3;
    private float strength = 16;

    private void Start() {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    public void DamageHealth(Vector3 PlayerPos) {
        if (Health > 0) {
            Health -= 1;
            Debug.Log(Health);
            Vector2 direction = (transform.position - PlayerPos).normalized;
            rb2d.AddForce(direction * strength, ForceMode2D.Impulse);
            StartCoroutine("Reset");
        } else {
            Vector2 direction = (transform.position - PlayerPos).normalized;
            rb2d.AddForce(direction * strength, ForceMode2D.Impulse);
            StartCoroutine("RemoveEnemy");
        }
    }

    private IEnumerator EnemyLock() {
        nav.enabled = false;
        yield return new WaitForSeconds(0.1f);
        nav.enabled = true;
        
    }

    private IEnumerator Reset() {
        yield return new WaitForSeconds(0.15f);
        rb2d.velocity = Vector3.zero;
        StartCoroutine("EnemyLock");
    }

    private IEnumerator RemoveEnemy() {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }


    public void Defeated(){
        animator.SetTrigger("Defeated");
    }
}
