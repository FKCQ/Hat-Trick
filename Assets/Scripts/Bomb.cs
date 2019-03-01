using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {
    public GameObject explosion;
    public float destroyTime;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameObject explosionInstance = Instantiate(explosion, transform.position, transform.rotation);
            Destroy(explosionInstance, destroyTime);
            Destroy(gameObject);
        }
    }
}
