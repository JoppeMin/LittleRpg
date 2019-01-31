using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charactervisual : MonoBehaviour
{

    Animator animator;
    Vector2 mousePos;
    Vector2 direction;
    public WeaponBehaviour weaponBehaviour;
    public GameObject faceDirection;
    public GameObject faceSprite;

    public GameObject Particles;
    public GameObject ParticlesOutline;

    public Sprite AttackFace;
    public Sprite NeutralFace;
    public Sprite BlockFace;



    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        characterMovement();
        lookDirection();
        faceExpressions();
    }

    void lookDirection()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        faceDirection.transform.up = direction;
        faceSprite.transform.up = new Vector3(0, 0, 0);
    }

    void characterMovement()
    {
        bool moving = false;
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            moving = true;
        }

        if (moving || weaponBehaviour.Bashing)
        {
            Particles.GetComponent<ParticleSystem>().Emit(2);
            ParticlesOutline.GetComponent<ParticleSystem>().Emit(2);
        }

        animator.SetBool("Moving", moving);
    }
    void faceExpressions()
    {
        if (Input.GetButton("Fire2"))
        {
            faceSprite.GetComponent<SpriteRenderer>().sprite = BlockFace;
        }
        else if (Input.GetButton("Fire1"))
        {
            faceSprite.GetComponent<SpriteRenderer>().sprite = AttackFace;
        }
        else
        {
            faceSprite.GetComponent<SpriteRenderer>().sprite = NeutralFace;
        }
    }
}

