using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public Collider2D swordCollider;
    public Transform playerPos;
    public float damage = 3;
    Vector2 rightAttackOffset;
    float timer;
    float timer2 = 0;

    private void Start() {
        //playerPos = GetComponent<Transform>();
        rightAttackOffset = playerPos.position - transform.position;
        swordCollider.enabled = false;
        Debug.Log(rightAttackOffset);
        
    }

    private void Update() {
        timer = Time.deltaTime;

        //Debug.Log("Timer " + timer + "Timer 2" + timer2);

        if (timer >= timer2) {
            swordCollider.enabled = false;
        }
    }

    public void AttackRight() {
        swordCollider.enabled = true;
        transform.localPosition = rightAttackOffset;
        timer2 = (timer + 2) * 0.01f;   
    }

    public void AttackLeft() {
        swordCollider.enabled = true;
        transform.localPosition = new Vector3(rightAttackOffset.x * -1, rightAttackOffset.y);
        timer2 = (timer + 2) * 0.01f; 
    }

     public void AttackUp() {
        swordCollider.enabled = true;
        transform.localPosition = new Vector3(rightAttackOffset.x * 0, rightAttackOffset.y + 1.15f);
        timer2 = (timer + 2) * 0.01f; 
    }
    
     public void AttackDown() {
        swordCollider.enabled = true;
        transform.localPosition = new Vector3(rightAttackOffset.x * 0, rightAttackOffset.y - 1.15f);
        timer2 = (timer + 2) * 0.01f; 
    }
    
    
    
    

    public void StopAttack() {
        swordCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Enemy") {
            // Deal damage to the enemy

            Debug.Log("Hit");
            Enemy enemy = other.GetComponent<Enemy>();
            enemy.RemoveEnemy();

            if(enemy != null) {
                enemy.Health -= damage;
            }
        }
    }
}
