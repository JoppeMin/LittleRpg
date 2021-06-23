using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterVisual : MonoBehaviour
{
    Animator animator;
    Vector2 mousePos;
    Vector2 direction;
    public WeaponBehaviour weaponBehaviour;
    public GameObject faceDirection;
    public GameObject faceSprite;

    public GameObject Particles;
    public GameObject ParticlesOutline;


    void lookDirection()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        direction = new Vector2(mousePos.x - weaponBehaviour.gameObject.transform.position.x, mousePos.y - weaponBehaviour.gameObject.transform.position.y);
        faceDirection.transform.up = direction;
        faceSprite.transform.up = Vector3.zero;
    }
}

