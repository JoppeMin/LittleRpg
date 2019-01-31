using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashBehaviour : MonoBehaviour
{
    Vector2 dir;
    int spritenumber = 0;
    public Sprite SlashSprite1;
    public Sprite SlashSprite2;
    public Sprite SlashSprite3;

    private void Start()
    {
        dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    }
    void Update()
    {
        Movement();
        RandomSprite();
    }

    void Movement()
    {
        transform.position += (Vector3) dir.normalized * 20 * Time.deltaTime;
    }

    void Delete()
    {
       Destroy(this.gameObject);
    }

    void RandomSprite()
    {
        spritenumber++;

        switch (spritenumber)
        {
            case 1:
                this.GetComponent<SpriteRenderer>().sprite = SlashSprite1;
                break;
            case 2:
                this.GetComponent<SpriteRenderer>().sprite = SlashSprite2;
                break;
            case 3:
                this.GetComponent<SpriteRenderer>().sprite = SlashSprite3;
                break;
            case 4:
                this.GetComponent<SpriteRenderer>().sprite = SlashSprite2;
                break;
            default:
                this.GetComponent<SpriteRenderer>().sprite = SlashSprite1;
                break;
        }
        if (spritenumber > 5)
        {
            spritenumber = 0;
        }
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        switch (coll.tag)
        {
            case "Enemy":
                Delete();
                coll.GetComponent<enemyBehaviour>().Health--;
                coll.GetComponent<Animator>().SetTrigger("Hit");
                break;
            case "Destroyable":
                Delete();
                coll.GetComponent<DestroyableObject>().spriteNumber++;
                coll.GetComponent<ParticleSystem>().Emit(5);
                break;
        }
    }
}
