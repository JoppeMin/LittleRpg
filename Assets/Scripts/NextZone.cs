using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextZone : MonoBehaviour {

    public GameObject player;
    public GameObject entranceBubble;
    public GameObject currentZoneText;

    // Use this for initialization
    void Start () {
        currentZoneText = GameObject.Find("Zone name");
        entranceBubble.GetComponent<SpriteRenderer>().enabled = false;

        currentZoneText.GetComponent<Text>().text = SceneManager.GetActiveScene().name;
        currentZoneText.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
        PressToInteract();
    }

    public void PressToInteract()
    {
        if (Vector3.Distance(player.transform.position, this.transform.position) < 3)
        {
            entranceBubble.GetComponent<SpriteRenderer>().enabled = true;

            if (Input.GetKeyUp("e"))
            {
                PlayerPrefs.SetString("previousZone", SceneManager.GetActiveScene().name);
                SceneManager.LoadScene(gameObject.name, LoadSceneMode.Single);
            }
        }
        else
        {
            entranceBubble.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
