using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {

    public GameObject dialogueBox;
    public Text dialogueText;
    public Text npcName;
    public Image npcSprite;
    public Vector3 npcPosition;

    public GameObject player;

    public int currentSentence;
    public string[] sentences;
    public bool isConversating = false;

    private void Start()
    {
        dialogueBox.SetActive(false);
    }

    void Update()
    {
        //next sentence
        if (Input.GetKeyDown("e") && isConversating)
        {
            StopAllCoroutines();
            currentSentence++;
            StartCoroutine(typeSentence(sentences[currentSentence]));
        }

        if(isConversating)
        {
            if (currentSentence >= sentences.Length)
            {
                DeactivateDialogueBox(0.3f);
            }
            if (Vector3.Distance(player.transform.position, npcPosition) > 5)
            {
                DeactivateDialogueBox(0.3f);
            }
        }
    }

    public void ActivateDialogueBox (string[] sentences, string name, SpriteRenderer npc, Vector3 npcPosition)
    {
        StopAllCoroutines();
        StartCoroutine(typeSentence(sentences[currentSentence]));
        dialogueBox.SetActive(true);
        npcName.text = name;
        npcSprite.sprite = npc.sprite;
        this.npcPosition = npcPosition;
        isConversating = true;
    }

    public void DeactivateDialogueBox (float time)
    {
        dialogueBox.SetActive(false);
        currentSentence = 0;
        StartCoroutine(chatDelay(time));
    }

    IEnumerator chatDelay(float time)
    {
        yield return new WaitForSeconds(time);
        isConversating = false;
        yield break;
    }

    IEnumerator typeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            switch (letter)
            {
                case '!':
                case '?':
                case '.':
                    yield return new WaitForSeconds(0.15f);
                    break;
                case ' ':
                case ',':
                    yield return new WaitForSeconds(0.03f);
                    break;
                default:
                    yield return new WaitForSeconds(0.02f);
                    break;
            }
        }
    }
}
