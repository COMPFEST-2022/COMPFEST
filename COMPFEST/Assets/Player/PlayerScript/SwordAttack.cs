using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public Collider2D swordCollider;
    public Rigidbody2D bulletPrefab; //objek peluru yg dimaksud
    public Transform playerPos;
    public float damage = 3;
    Vector2 rightAttackOffset;
    float timer;
    float timer2 = 0;
    public float bulletPos = 1;
    public float bulletSpeed = 500;

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

    public void GunRight() {
        swordCollider.enabled = true;
        Rigidbody2D bPrefab2 = Instantiate(bulletPrefab, swordCollider.transform.position, Quaternion.Euler(new Vector3(0, 0, 180))) as Rigidbody2D;
        //bPrefab2.GetComponent<Rigidbody2D>().AddForce(new Vector2 (bulletPos * bulletSpeed, 0));
        transform.localPosition = rightAttackOffset;
        timer2 = (timer + 2) * 0.01f;   
        Debug.Log(transform.localPosition);
    }

    public void GunLeft() {
        swordCollider.enabled = true;
        Rigidbody2D bPrefab2 = Instantiate(bulletPrefab, swordCollider.transform.position, swordCollider.transform.rotation) as Rigidbody2D;
        //bPrefab2.GetComponent<Rigidbody2D>().AddForce(new Vector2 (bulletPos * bulletSpeed * -1, 0));
        transform.localPosition = new Vector3(rightAttackOffset.x * -1, rightAttackOffset.y);
        timer2 = (timer + 2) * 0.01f; 
        Debug.Log(transform.localPosition);
    }

     public void GunDown() {
        swordCollider.enabled = true;
        Rigidbody2D bPrefab2 = Instantiate(bulletPrefab, swordCollider.transform.position, Quaternion.Euler(new Vector3(0, 0, 90))) as Rigidbody2D;
        //bPrefab2.GetComponent<Rigidbody2D>().AddForce(new Vector2 (0, bulletPos * bulletSpeed * -1));
        transform.localPosition = new Vector3(rightAttackOffset.x * 0, rightAttackOffset.y + 1.15f);
        timer2 = (timer + 2) * 0.01f; 
        Debug.Log(transform.localPosition);
    }
    
     public void GunUp() {
        swordCollider.enabled = true;
        Rigidbody2D bPrefab2 = Instantiate(bulletPrefab, swordCollider.transform.position, Quaternion.Euler(new Vector3(0, 0, 270))) as Rigidbody2D;
        //bPrefab2.GetComponent<Rigidbody2D>().AddForce(new Vector2 (0, bulletPos * bulletSpeed));
        transform.localPosition = new Vector3(rightAttackOffset.x * 0, rightAttackOffset.y - 1.15f);
        timer2 = (timer + 2) * 0.01f; 
        Debug.Log(transform.localPosition);
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
