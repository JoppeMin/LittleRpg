using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour {

    public int value;
    float valueSize;

    Vector2 randomDirection;

	void Start () {
        value = Random.Range(1, 6);
        valueSize = 1 + (0.08f * value);
        transform.localScale *= valueSize;

        randomDirection = (Vector2) transform.position + new Vector2(Random.Range(-3f, 3f), Random.Range(-1f, 1f));
    }
	
	void Update () {
        transform.position = Vector2.MoveTowards(transform.position, randomDirection, Time.deltaTime * 2);
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        switch (coll.gameObject.tag)
        {
            case "Player":
                Destroy(this.gameObject);
                coll.gameObject.GetComponent<PlayerManager>().cashValue += this.value;
                break;
        }
    }
}
