using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Script : MonoBehaviour {

    public GameObject player;
    public GameObject chatBubble;
    public bool doesFlip;

    public string characterName;
    [HideInInspector]
    public SpriteRenderer sprite;

    [TextArea(3, 10)]
    public string[] sentences;
    DialogManager dialogueBox;

    void Start() {
        sprite = GetComponent<SpriteRenderer>();
        dialogueBox = FindObjectOfType<DialogManager>();
    }

    void Update() {
        FlipOnPlayerPosition();
        PressToInteract();
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

    public void PressToInteract()
    {
        if (Vector3.Distance(player.transform.position, this.transform.position) < 3)
        {
            chatBubble.GetComponent<SpriteRenderer>().enabled = true;
            
            //start conversation
            if (Input.GetKeyUp("e") && !dialogueBox.isConversating)
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
