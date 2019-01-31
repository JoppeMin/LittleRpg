using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //public WeaponBehaviour weaponBehaviour;
    public Vector2 position;
    public Vector2 velocity;
    public Vector2 force;
    public GameObject previousZone;

    void Start()
    {
        if (PlayerPrefs.GetString("previousZone") == null)
        {
            PlayerPrefs.SetString("previousZone", this.gameObject.name);
        }
        previousZone = GameObject.Find(PlayerPrefs.GetString("previousZone"));
        position = previousZone.transform.position;
        position.y -= 1;
    }
    void Update()
    {
        characterMovement();
    }

    void characterMovement()
    {
        position.y += Input.GetAxis("Vertical") * velocity.y * Time.deltaTime;
        position.x += Input.GetAxis("Horizontal") * velocity.x * Time.deltaTime;
        position += force * 90 * Time.deltaTime;
        force *= 0.9f;

        transform.position = position;
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        switch (coll.tag)
        {
            case "Enemy":
                Debug.Log("OW OW OW");
                force = (transform.position - coll.transform.position) / 5;
                GetComponent<PlayerManager>().hitPoints -= coll.GetComponent<enemyBehaviour>().Damage;
                GetComponentInChildren<Animator>().SetTrigger("Hit");
                break;
            case "Coin":
                Destroy(coll.gameObject);
                GetComponent<PlayerManager>().cashValue += coll.GetComponent<CoinPickup>().value;
                break;
        }
    }
}
