using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponBehaviour : MonoBehaviour
{

    public GameObject player;
    PlayerMovement playerMovement;
    public GameObject slash;
    public Transform sword;
    public bool Attacking = false;
    public bool Blocking = false;
    public bool Bashing = false;
    public bool Bashinit = false;
    Vector2 mousePos;
    Vector2 direction;
    Vector2 size;

    float bashForce = 5000;
    float cooldownTime = 3; //length of the cooldown
    float bashLength = 0.6f;
    float bashTime;
    float nextbashTime;

    public Animator animator;

    void Start()
    {
        animator = GetComponentInParent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        direction = (mousePos - (Vector2)this.gameObject.transform.position).normalized;

        faceMouse();
        weaponAttackAnimation();

        shieldBlock();
    }

    void faceMouse()
    {
        this.gameObject.transform.up = direction;
    }

    void weaponAttackAnimation()
    {
        if (Input.GetButton("Fire1") && !Input.GetButton("Fire2"))
        {
            Attacking = true;
        }
        else
        {
            Attacking = false;
        }
        animator.SetBool("Attacking", Attacking);
    }

    void shieldBlock()
    {
        if (Input.GetButton("Fire2") || Bashing)
        {
            Attacking = false;
            Blocking = true;
            this.gameObject.transform.up = -direction;
        } else
        {
            Blocking = false;
        }
        animator.SetBool("Blocking", Blocking);
    }


    void weaponAttack()
    {
        //put eventtrigger in animation
        if (Attacking)
        {
            Instantiate(slash, this.gameObject.transform.position, this.transform.rotation);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // FIX THE SHIELD DOING DMG
        if (Bashing)
        {
            switch (other.tag)
            {
                case "Enemy":
                    PlayerMovement.SP.rb.velocity = -PlayerMovement.SP.rb.velocity;
                    other.GetComponent<enemyBehaviour>().Health--;
                    other.GetComponent<Animator>().SetTrigger("Hit");
                    break;
                case "Destroyable":
                    PlayerMovement.SP.rb.velocity = -PlayerMovement.SP.rb.velocity;
                    other.GetComponent<DestroyableObject>().SpriteUpdate();
                    other.GetComponent<ParticleSystem>().Emit(5);
                    break;
                case "Wall":
                    PlayerMovement.SP.rb.velocity = -PlayerMovement.SP.rb.velocity / 2;
                    break;
            }
        }
    }
}
