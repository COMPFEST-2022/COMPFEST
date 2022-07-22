using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    public Collider2D swordCollider;
    public Collider2D shootCollider;
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
        shootCollider.enabled = false;
        Debug.Log("PLAYER POS" + playerPos.transform.position);
        
    }

    private void Update() {
        timer = Time.deltaTime;
    }

    public void AttackRight() {
        swordCollider.enabled = true;
        transform.localPosition = rightAttackOffset;
        StartCoroutine("StopAttack");
    }

    public void AttackLeft() {
        swordCollider.enabled = true;
        transform.localPosition = new Vector3(rightAttackOffset.x * -1, rightAttackOffset.y);
        StartCoroutine("StopAttack");
    }

     public void AttackUp() {
        swordCollider.enabled = true;
        transform.localPosition = new Vector3(rightAttackOffset.x * 0, rightAttackOffset.y + 1.15f);
        StartCoroutine("StopAttack");
    }
    
     public void AttackDown() {
        swordCollider.enabled = true;
        transform.localPosition = new Vector3(rightAttackOffset.x * 0, rightAttackOffset.y - 1.15f);
        StartCoroutine("StopAttack");
    }

    public void GunRight() {
        shootCollider.enabled = true;
        Rigidbody2D bPrefab2 = Instantiate(bulletPrefab, shootCollider.transform.position, Quaternion.Euler(new Vector3(0, 0, 180))) as Rigidbody2D;
        bPrefab2.GetComponent<Rigidbody2D>().AddForce(new Vector2 (bulletPos * bulletSpeed, 0));
        transform.localPosition = rightAttackOffset; 
        Debug.Log(transform.localPosition);
        StartCoroutine("StopShoot");
    }

    public void GunLeft() {
        shootCollider.enabled = true;
        Rigidbody2D bPrefab2 = Instantiate(bulletPrefab, shootCollider.transform.position, swordCollider.transform.rotation) as Rigidbody2D;
        bPrefab2.GetComponent<Rigidbody2D>().AddForce(new Vector2 (bulletPos * bulletSpeed * -1, 0));
        transform.localPosition = new Vector3(rightAttackOffset.x * -1, rightAttackOffset.y);
        Debug.Log(transform.localPosition);
        StartCoroutine("StopShoot");
    }

     public void GunDown() {
        shootCollider.enabled = true;
        Rigidbody2D bPrefab2 = Instantiate(bulletPrefab, shootCollider.transform.position, Quaternion.Euler(new Vector3(0, 0, 90))) as Rigidbody2D;
        bPrefab2.GetComponent<Rigidbody2D>().AddForce(new Vector2 (0, bulletPos * bulletSpeed * -1));
        transform.localPosition = new Vector3(rightAttackOffset.x * 0, rightAttackOffset.y + 1.15f); 
        Debug.Log(transform.localPosition);
        StartCoroutine("StopShoot");
    }
    
     public void GunUp() {
        shootCollider.enabled = true;
        Rigidbody2D bPrefab2 = Instantiate(bulletPrefab, shootCollider.transform.position, Quaternion.Euler(new Vector3(0, 0, 270))) as Rigidbody2D;
        bPrefab2.GetComponent<Rigidbody2D>().AddForce(new Vector2 (0, bulletPos * bulletSpeed));
        transform.localPosition = new Vector3(rightAttackOffset.x * 0, rightAttackOffset.y - 1.15f);
        Debug.Log(transform.localPosition);
        StartCoroutine("StopShoot");
    }
    
    public IEnumerator StopAttack() {
        yield return new WaitForSeconds(1);
        swordCollider.enabled = false;
    }

    public IEnumerator StopShoot() {
        yield return new WaitForSeconds(0.4f);
        shootCollider.enabled = false;
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Enemy") {
            // Deal damage to the enemy

            Debug.Log("Hit");
            Enemy enemy = other.GetComponent<Enemy>();
                enemy.DamageHealth( playerPos.transform.position);
        }
    }
}
