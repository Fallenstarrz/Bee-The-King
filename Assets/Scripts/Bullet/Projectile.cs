using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Transform tf;
    public float bulletSpeed;
    public float lifeTime;
    public string owner;

    public GameObject destroyEffect;

    // Use this for initialization
    void Start()
    {
        tf = GetComponent<Transform>();
        Invoke("DestroyProjectile", lifeTime);
    }
    // Update is called once per frame
    void Update()
    {
        tf.Translate(-Vector3.up * bulletSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == owner)
        {
            return;
        }
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerPawn>().isDead = true;
            collision.gameObject.GetComponent<PlayerPawn>().die();
            GameManager.instance.winner = owner;
        }
        Invoke("DestroyProjectile", 0);
    }
    void DestroyProjectile()
    {
        //Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
