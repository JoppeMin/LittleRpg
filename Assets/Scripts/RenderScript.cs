using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderScript : MonoBehaviour
{

    public GameObject Player;
    public Texture2D cursorTexture;

    Vector3 mousePos;
    private static bool cameraExists;

    void Start()
    {
        Cursor.SetCursor(cursorTexture, new Vector2(16, 16), CursorMode.ForceSoftware);
    }
        void Update()
    {
        // calculates camera position
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mouseDir = (mousePos - Player.transform.position) / 5;
        Vector3 position = Player.transform.position;
        position = position + mouseDir;

        //keeps the sword here
        position.z = -1;

        transform.position = position;
    }
}
