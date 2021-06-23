using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NPC_Script : MonoBehaviour {

    [SerializeField] private GameControls _controls;

    GameObject player;
    public GameObject chatBubble;
    public bool doesFlip;

    public string characterName;
    [HideInInspector]
    public SpriteRenderer sprite;

    [TextArea(3, 10)]
    public string[] sentences;
    DialogManager dialogueBox;

    private void OnValidate()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        sprite = GetComponent<SpriteRenderer>();
        dialogueBox = FindObjectOfType<DialogManager>();
    }

    private void Awake()
    {
        _controls = new GameControls();
    }

    private void OnEnable()
    {
        _controls.Input.Interact.performed += PressToInteract;
        _controls.Input.Interact.Enable();
    }
    private void OnDisable()
    {
        _controls.Input.Interact.performed -= PressToInteract;
        _controls.Input.Interact.Disable();
    }

    void Update() {
        FlipOnPlayerPosition();
    }

    public void FlipOnPlayerPosition()
    {
        if (doesFlip)
        {
            if (player.transform.position.x < this.transform.position.x)
            {
                sprite.flipX = true;
            }
            else
            {
                sprite.flipX = false;
            }
        }  
    }

    public void PressToInteract(InputAction.CallbackContext context)
    {
        if (Vector3.Distance(player.transform.position, this.transform.position) < 3)
        {
            chatBubble.GetComponent<SpriteRenderer>().enabled = true;
            
            //start conversation
            if (!dialogueBox.isConversating)
            {
                dialogueBox.currentSentence = 0;
                dialogueBox.sentences = sentences;
                dialogueBox.ActivateDialogueBox(sentences, characterName, sprite, this.transform.position);
            }
        } else {
            chatBubble.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
