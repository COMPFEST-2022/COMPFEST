using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{

    public float timer = 0;
    public Rigidbody2D bulletPrefab; //objek peluru yg dimaksud
	public GameObject shootPos; //letak munculnya peluru terhadap gameobject
    public GameObject shootPos1;
    public GameObject shootPos2;
    public GameObject shootPos3;
    public float bulletSpeed = 500;
    public float attackSpeed = 0.5f;
    public float bulletPos = 1;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        timer += Time.deltaTime;
		//memunculkan peluru pada posisi gameobject shootpos
		//memberikan dorongan peluru sebesar bulletSpeed dengan arah terbangnya bulletPos 

		if (timer >= (4.2 - 0.5)) {
            animator.SetBool("IsAttack", true);
        } if (timer >= 4.2 ) {
            Rigidbody2D bPrefab = Instantiate(bulletPrefab, shootPos.transform.position, shootPos.transform.rotation) as Rigidbody2D;
            Rigidbody2D bPrefab2 = Instantiate(bulletPrefab, shootPos1.transform.position, shootPos1.transform.rotation) as Rigidbody2D;
            Rigidbody2D bPrefab3 = Instantiate(bulletPrefab, shootPos2.transform.position, shootPos2.transform.rotation) as Rigidbody2D;
            Rigidbody2D bPrefab4 = Instantiate(bulletPrefab, shootPos3.transform.position, shootPos3.transform.rotation) as Rigidbody2D;
            bPrefab.GetComponent<Rigidbody2D>().AddForce(new Vector2 (bulletPos * bulletSpeed, 0));
            bPrefab2.GetComponent<Rigidbody2D>().AddForce(new Vector2 (bulletPos * bulletSpeed * -1, 0));
            bPrefab3.GetComponent<Rigidbody2D>().AddForce(new Vector2 (0, bulletPos * bulletSpeed));
            bPrefab4.GetComponent<Rigidbody2D>().AddForce(new Vector2 (0, bulletPos * bulletSpeed * -1));
            timer = 0;
            animator.SetBool("IsAttack", false);
        }
		//counting cooldown, nanti dicek lagi
        //coolDown = Time.time + attackSpeed;
    }
}
