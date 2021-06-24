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

    [SerializeField] SpriteRenderer[] gearSlotsArray = new SpriteRenderer[4];
    enum GearSlots
    {
        Armor,
        MainHand,
        OffHand,
        Helmet
    }
    [SerializeField] Dictionary<GearSlots, SpriteRenderer> gearSlots = new Dictionary<GearSlots, SpriteRenderer>();

    //sorting order
    int behindPlayer = -10;
    int frontPlayer = 10;

    private void Awake()
    {
        _controls = new GameControls();
        SP = this;
        rb = gameObject.GetComponent<Rigidbody2D>();

        for (int i = 0; i < gearSlotsArray.Length; i++)
        {
            gearSlots.Add((GearSlots) i, gearSlotsArray[i]);
        }
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
        
        //front view directions
        if (mouseDir.y < 0)
        {
            this.transform.localScale = Vector3.one;
            PlayerVisual.sprite = PlayerBaseFront;

            if (mouseDir.x < 0)
            {

                PlayerVisual.flipX = true;

                MainhandInFront(true, true);
                OffhandInFront(false);
            }
            else if (mouseDir.x > 0)
            {
                PlayerVisual.flipX = false;

                MainhandInFront(false, false);
                OffhandInFront(true);
            }
        }
        //back view directions
        else if (mouseDir.y > 0)
        {
            this.transform.localScale = new Vector3(-1, 1, 1);
            PlayerVisual.sprite = PlayerBaseBack;

            if (mouseDir.x < 0)
            {
                PlayerVisual.flipX = false;

                MainhandInFront(true, false);
                OffhandInFront(false);
            }
            else if (mouseDir.x > 0)
            {
                PlayerVisual.flipX = true;

                MainhandInFront(false, true);
                OffhandInFront(true);
            }
        }
        
    }

    private void AnimateWalk(bool shouldAnimate)
    {
            animator.SetBool("Moving", shouldAnimate);
    }

    #region SpriteSorting
    private void OffhandInFront(bool isInFront)
    {
        if (isInFront)
        {
            gearSlots[GearSlots.OffHand].sortingOrder = frontPlayer;
            gearSlots[GearSlots.OffHand].sprite = shield[0];
        } else
        {
            gearSlots[GearSlots.OffHand].sprite = shield[1];
            gearSlots[GearSlots.OffHand].sortingOrder = behindPlayer;
        }
    }

    private void MainhandInFront(bool isInFront, bool shouldFlip)
    {
        gearSlots[GearSlots.MainHand].flipX = shouldFlip;
        gearSlots[GearSlots.MainHand].sortingOrder = isInFront ? frontPlayer : behindPlayer;
    }
    #endregion



    #endregion

    #region Input and Physics
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
        gearSlots[GearSlots.MainHand].sprite = weapon.slashSprite;
        Instantiate(weapon.projectile, this.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2 / weapon.attackSpeed);
        gearSlots[GearSlots.MainHand].sprite = weapon.idleSprite;
        if (isAttacking)
        {
            StartCoroutine(StartAttack());
        }
    }
    #endregion

}
