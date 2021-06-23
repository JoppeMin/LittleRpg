using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement SP;
    [SerializeField] private GameControls _controls;

    [SerializeField] private SpriteRenderer PlayerVisual;

    [SerializeField] private Sprite PlayerBaseFront;
    [SerializeField] private Sprite PlayerBaseBack;

    [SerializeField] private Animator animator;

    private Vector2 movement;
    public Rigidbody2D rb;
    public Vector2 velocity;
    private Vector2 mouseDir;
    private bool isAttacking = false;

    [SerializeField] Sprite[] shield = new Sprite[2];
    [SerializeField] WeaponSO weapon;

    [SerializeField] SpriteRenderer[] gearSlots = new SpriteRenderer[4];

    private void Awake()
    {
        _controls = new GameControls();
        SP = this;
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _controls.Input.Movement.performed += OnCharacterMove;
        _controls.Input.Movement.canceled += OnCharacterMove;
        _controls.Input.Movement.Enable();

        _controls.Input.Attack.started += OnPlayerAttack;
        _controls.Input.Attack.canceled += OnPlayerAttack;
        _controls.Input.Attack.Enable();


    }
    private void OnDisable()
    {
        _controls.Input.Movement.performed -= OnCharacterMove;
        _controls.Input.Movement.canceled -= OnCharacterMove;
        _controls.Input.Movement.Disable();

        _controls.Input.Attack.started -= OnPlayerAttack;
        _controls.Input.Attack.canceled -= OnPlayerAttack;
        _controls.Input.Attack.Enable();
    }

    #region Visual
    private void LateUpdate()
    {
        FaceTowardsMouse();
    }

    private void FaceTowardsMouse()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mouseDir = mousePos - (Vector2) this.transform.position;

        if (mouseDir.y < 0)
        {
            PlayerVisual.transform.localScale = Vector3.one;
            PlayerVisual.sprite = PlayerBaseFront;

            if (mouseDir.x < 0)
            {
                PlayerVisual.flipX = true;
                gearSlots[1].sortingOrder = 10;
                gearSlots[1].flipX = true;

                gearSlots[2].sortingOrder = -10;
                gearSlots[2].sprite = shield[1];
            }
            else if (mouseDir.x > 0)
            {
                PlayerVisual.flipX = false;
                gearSlots[1].sortingOrder = -10;
                gearSlots[1].flipX = false;

                gearSlots[2].sortingOrder = 10;
                gearSlots[2].sprite = shield[0];
            }
        } else if (mouseDir.y > 0)
        {
            PlayerVisual.transform.localScale = new Vector3(-1, 1, 1);
            PlayerVisual.sprite = PlayerBaseBack;

            if (mouseDir.x < 0)
            {
                PlayerVisual.flipX = true;
                gearSlots[1].sortingOrder = 10;
                gearSlots[1].flipX = false;

                gearSlots[2].sprite = shield[1]; 
                gearSlots[2].sortingOrder = -10;
            }
            else if (mouseDir.x > 0)
            {   
                PlayerVisual.flipX = false;
                gearSlots[1].sortingOrder = -10;
                gearSlots[1].flipX = true;

                gearSlots[2].sortingOrder = 10;
                gearSlots[2].sprite = shield[0];
            }
        }
        
    }

    private void AnimateWalk(bool shouldAnimate)
    {
            animator.SetBool("Moving", shouldAnimate);
    }
    #endregion

    #region Physics
    private void FixedUpdate()
    {
        rb.velocity = (movement * velocity * Time.deltaTime);
    }

    private void OnCharacterMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
        bool isMoving = movement.magnitude > 0 ? true : false;
        AnimateWalk(isMoving);
        return;
    }

    private void OnPlayerAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isAttacking = true;
            StartCoroutine(StartAttack());
        }
        else if (context.canceled)
        {
            isAttacking = false;
        }
        return;
    }

    IEnumerator StartAttack()
    {
        gearSlots[1].sprite = weapon.slashSprite;
        Instantiate(weapon.projectile, gearSlots[1].transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2 / weapon.attackSpeed);
        gearSlots[1].sprite = weapon.idleSprite;
        if (isAttacking)
        {
            StartCoroutine(StartAttack());
        }
    }
    #endregion

}
