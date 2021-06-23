using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SlashBehaviour : MonoBehaviour
{
    Vector2 dir;
    int spritenumber = 0;

    private void Start()
    {
        dir = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()) - transform.position;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, dir);
    }
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        transform.position += (Vector3) dir.normalized * 20 * Time.deltaTime;
    }

    void Delete()
    {
       Destroy(this.gameObject);
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
                coll.GetComponent<ParticleSystem>().Emit(5);
                coll.GetComponent<DestroyableObject>().SpriteUpdate();
                break;
        }
    }
}
