using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RenderScript : MonoBehaviour
{

    public GameObject Player;
    public Texture2D cursorTexture;

    Vector3 mousePos;
    private static bool cameraExists;

    private void Awake()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            Instantiate(Resources.Load("Prefabs/Player"));
        }
    }

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        // calculates camera position
        mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Vector3 mouseDir = (mousePos - Player.transform.position) / 5;
        Vector3 position = Player.transform.position;
        position = position + mouseDir;

        //keeps the sword here
        position.z = -1;

        transform.position = position;
    }
}
