using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;

// Takes and handles input and movement for a player character
public class Player2 : MonoBehaviour
{
    public float moveSpeed = 1f;
    Rigidbody2D rb;
    Vector2 movementInput;
    SpriteRenderer spriteRenderer;
    public SwordAttack swordAttack;
    public GameObject Player;
    bool InRadius;
    
    Animator animator;

    private string WeaponType;
    private string WeaponTypeTag;

    bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
         WeaponType = "Sword";
    }

    private void Update() {
        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown("e") && InRadius == true) {
            WeaponType = WeaponTypeTag;
        }

        if (WeaponType == "Sword") {
            if (Input.GetKeyDown(KeyCode.RightArrow)) {
                swordAttack.AttackLeft();
                animator.SetTrigger("swordAttackRight");
            } if (Input.GetKeyDown(KeyCode.LeftArrow)) {
                swordAttack.AttackRight();
                animator.SetTrigger("swordAttackLeft");
            } if (Input.GetKeyDown(KeyCode.UpArrow)) {
                swordAttack.AttackUp();
                animator.SetTrigger("SwordAttackYaxisUp");
            } if (Input.GetKeyDown(KeyCode.DownArrow)) {
                swordAttack.AttackDown();
                animator.SetTrigger("SwordAttackYaxisDown");
            }
        } if (WeaponType == "Pistol") {
            if (Input.GetKeyDown(KeyCode.RightArrow)) {
                swordAttack.GunRight();
            } if (Input.GetKeyDown(KeyCode.LeftArrow)) {
                swordAttack.GunLeft();
            } if (Input.GetKeyDown(KeyCode.UpArrow)) {
                swordAttack.GunUp();
            } if (Input.GetKeyDown(KeyCode.DownArrow)) {
                swordAttack.GunDown();
            } 
            Debug.Log("Pistol bang bang");
        }
    }

    private void FixedUpdate() {
        if (canMove) {
            rb.MovePosition(rb.position + movementInput * moveSpeed * Time.deltaTime);

            animator.SetFloat("Horizontal", movementInput.x);
            animator.SetFloat("Vertical", movementInput.y);

            animator.SetFloat("speed", movementInput.sqrMagnitude);
        } else  {
            animator.SetFloat("speed", movementInput.magnitude);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Sword") {
            InRadius = true;
            WeaponTypeTag = "Sword"; 
        } if (other.gameObject.tag == "Pistol") {
            InRadius = true;
            WeaponTypeTag = "Pistol";
        }
    }


    public void LockMovement() {
        canMove = false;
    }

    public void EndSwordAttack() {
        UnlockMovement();
        swordAttack.StopAttack();
    }

     public void UnlockMovement() {
        canMove = true;
    }


}
