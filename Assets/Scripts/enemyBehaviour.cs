using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehaviour : MonoBehaviour {

    public GameObject player;
    public GameObject coin;

    public int Health = 10;
    public int Damage = 3;
    public Vector2 dir;
    public Vector2 velocity;
    public Vector2 force;
    Vector2 position;

    int coinDropAmount;

    public GameObject faceDirection;
    public GameObject faceSprite;

    void Start()
    {
        position = transform.position;
        coinDropAmount = Random.Range(3, 6);
    }

    void Update () {
        dir = player.transform.position - transform.position;
        lookDirection();
        Flipart();
        Dash();
        AliveCheck();
    }
    void Dash()
    {
        velocity = dir.normalized;
        position += velocity * 5 * Time.deltaTime;
        position += force * 90 * Time.deltaTime;

        force *= 0.9f;
        transform.position = position;
    }
    void lookDirection()
    {
        faceDirection.transform.up = dir;
        faceSprite.transform.up = new Vector3(0, 0, 0);
    }
    void Flipart()
    {
        if (player.transform.position.x > transform.position.x)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
        } else
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
        }
    }
    void AliveCheck()
    {
        if (Health <= 0)
        {
            Destroy(this.gameObject);
            for (int i = 0; i < coinDropAmount; i++)
            {
                Instantiate(coin, this.transform.position, Quaternion.identity);
            }
        }
    }
}
