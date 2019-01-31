using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehaviour : MonoBehaviour
{

    public GameObject player;
    public GameObject slash;
    public Transform sword;
    public PlayerMovement playerMovement;
    public bool Attacking = false;
    public bool Blocking = false;
    public bool Bashing = false;
    public bool Bashinit = false;
    Vector2 mousePos;
    Vector2 direction;
    Vector2 size;

    float cooldownTime = 3;
    float nextbashTime;

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePos - playerMovement.position;
        faceMouse();
        shieldBlock();
        shieldBash();
        weaponAttackAnimation(); 
    }

    void faceMouse()
    {
        transform.up = direction;
    }

    void weaponAttackAnimation()
    {
        if (Input.GetButton("Fire1") && !Input.GetButton("Fire2"))
        {
            Attacking = true;
        }
        if (!Input.GetButton("Fire1") && !Input.GetButton("Fire2"))
        {
            Attacking = false;
        }
        animator.SetBool("Attacking", Attacking);
    }
    void weaponAttack()
    {
        //put eventtrigger in animation
        if (Attacking) {
        Instantiate(slash, sword.transform.position, sword.transform.rotation);
        }
    }

    void shieldBlock()
    {
        if (Input.GetButton("Fire2"))
        {
            Attacking = false;
            Blocking = true;
            transform.up = -transform.up;

            if (Time.time > nextbashTime && Input.GetButtonDown("Fire1"))
            {
                Bashinit = true;
            } else
            {
                Bashinit = false;
            }
        }
        else
        {
            Blocking = false;
        }
        animator.SetBool("Blocking", Blocking);
    }

    void shieldBash()
    {
        if (Bashinit)
        {
            playerMovement.force = direction.normalized;
            nextbashTime = Time.time + cooldownTime;
        }

        if (playerMovement.force.x < -0.01 || playerMovement.force.x > 0.01 || playerMovement.force.y < -0.01 || playerMovement.force.y > 0.01)
        {
            Bashing = true;
        }
        else
        {
            Bashing = false;
            playerMovement.force = new Vector2(0, 0);
        }
        animator.SetBool("Bashing", Bashing);
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (Bashing)
        {
            switch (coll.tag)
            {
                case "Enemy":
                    coll.GetComponent<enemyBehaviour>().force = playerMovement.force;
                    playerMovement.force = -playerMovement.force;
                    coll.GetComponent<enemyBehaviour>().Health--;
                    coll.GetComponent<Animator>().SetTrigger("Hit");
                    break;
                case "Destroyable":
                    playerMovement.force = -playerMovement.force;
                    coll.GetComponent<DestroyableObject>().spriteNumber++;
                    coll.GetComponent<ParticleSystem>().Emit(5);
                    break;
            }
        }
    }
}
