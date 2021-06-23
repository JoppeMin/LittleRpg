using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextZone : MonoBehaviour {

    GameObject player;
    SpriteRenderer[] spriteRenderer; // 0 is mainsprite, 1 is "questbubble"
    Text currentZoneText;

    float distanceToInteract = 3;

    private void OnValidate()
    {
        //player = FindObjectOfType<PlayerManager>().gameObject;

        spriteRenderer = gameObject.GetComponentsInChildren<SpriteRenderer>();

        currentZoneText = GameObject.Find("Zone name").GetComponent<Text>();
        spriteRenderer[1].enabled = false;

        currentZoneText.GetComponent<Text>().text = SceneManager.GetActiveScene().name;
    }

    private void Start()
    {
        player = FindObjectOfType<PlayerManager>().gameObject;
    }

    void Update () {
        PressToInteract();
    }

    public void PressToInteract()
    {
        if (Vector3.Distance(player.transform.position, this.transform.position) < distanceToInteract)
        {
            spriteRenderer[1].enabled = true;

            if (Input.GetKeyUp("e"))
            {
                PlayerPrefs.SetString("previousZone", SceneManager.GetActiveScene().name);
                SceneManager.LoadScene(gameObject.name, LoadSceneMode.Single);
            }
        }
        else
        {
            spriteRenderer[1].enabled = false;
        }
    }
}
