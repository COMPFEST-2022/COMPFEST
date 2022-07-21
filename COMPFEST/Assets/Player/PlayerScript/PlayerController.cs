using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Takes and handles input and movement for a player character
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;
    public SwordAttack swordAttack;
    public GameObject Player;

    Vector2 movementInput;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    Animator animator;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    private string WeaponType;

    bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        WeaponType = "Sword";
    }

    private void FixedUpdate() {
        if(canMove) {
            // If movement input is not 0, try to move
            if(movementInput != Vector2.zero){
                
                bool success = TryMove(movementInput);

                if(!success) {
                    success = TryMove(new Vector2(movementInput.x, 0));
                    //animator.SetFloat("Horizontal", movementInput.x);
                }

                if(!success) {
                    success = TryMove(new Vector2(0, movementInput.y));   
                    //animator.SetFloat("Vertical", movementInput.y);
                }
            
                animator.SetFloat("Horizontal", movementInput.x);
                animator.SetFloat("Vertical", movementInput.y);

                animator.SetFloat("speed", movementInput.sqrMagnitude);
                
                //Debug.Log(movementInput);
                //Debug.Log(movementInput.magnitude);
                //animator.SetBool("isMoving", success);
            } else {
                animator.SetFloat("speed", movementInput.magnitude);
                //Debug.Log(movementInput.magnitude);
                //animator.SetBool("isMoving", false);
            }

            // Set direction of sprite to movement direction
            if(movementInput.x < 0) {
                spriteRenderer.flipX = true;
            } else if (movementInput.x > 0) {
                spriteRenderer.flipX = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Pistol") {
            WeaponType = "Pistol";
            Debug.Log("Change");
        } if (other.gameObject.tag == "Sword") {
            WeaponType = "Sword";
            Debug.Log("Change");
        }
    }

    private bool TryMove(Vector2 direction) {
        if(direction != Vector2.zero) {
            // Check for potential collisions
            int count = rb.Cast(
                direction, // X and Y values between -1 and 1 that represent the direction from the body to look for collisions
                movementFilter, // The settings that determine where a collision can occur on such as layers to collide with
                castCollisions, // List of collisions to store the found collisions into after the Cast is finished
                moveSpeed * Time.fixedDeltaTime + collisionOffset); // The amount to cast equal to the movement plus an offset

            if(count == 0){
                rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
                return true;
            } else {
                return false;
            }
        } else {
            // Can't move if there's no direction to move in
            return false;
        }
        
    }

    void OnMove(InputValue movementValue) {
        movementInput = movementValue.Get<Vector2>();
    }

    IEnumerator OnFire() {
        if (WeaponType == "Sword") {
            if (movementInput.x == 1) {
            swordAttack.AttackLeft();
            LockMovement();
            animator.SetTrigger("swordAttack");
             yield return new WaitForSeconds(0.5f);
            EndSwordAttack();
            } if (movementInput.x == -1) {
                swordAttack.AttackRight();
                LockMovement();
                animator.SetTrigger("swordAttack");
                yield return new WaitForSeconds(0.5f);
                EndSwordAttack();
            } if (movementInput.y == 1) {
                swordAttack.AttackUp();
                LockMovement();
                animator.SetTrigger("SwordAttackYaxisUp");
                yield return new WaitForSeconds(0.5f);
                EndSwordAttack();
            } if (movementInput.y == -1) {
                swordAttack.AttackDown();
                LockMovement();
                animator.SetTrigger("SwordAttackYaxisDown");
                yield return new WaitForSeconds(0.5f);
                EndSwordAttack();
            } if (movementInput.x == 0 && movementInput.y == 0) {
                animator.SetTrigger("SwordAttackYaxisDown");
            }
        } if (WeaponType == "Pistol") {
            Debug.Log("Pistol bang bang");
        }
    }

    /*
    public void SwordAttack() {
        LockMovement();

        if(spriteRenderer.flipX == true){
            swordAttack.AttackLeft();
        } else {
            swordAttack.AttackRight();
        }
    }
    */

    public void EndSwordAttack() {
        UnlockMovement();
        swordAttack.StopAttack();
    }

    public void LockMovement() {
        canMove = false;
    }

    public void UnlockMovement() {
        canMove = true;
    }
}
