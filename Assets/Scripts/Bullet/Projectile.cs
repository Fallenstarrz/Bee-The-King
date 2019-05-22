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

    public AudioSource audioThing;

    // Use this for initialization
    void Start()
    {
        tf = GetComponent<Transform>();
        audioThing = GetComponent<AudioSource>();
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
        else if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerPawn>().isDead = true;
            collision.gameObject.GetComponent<PlayerPawn>().die();
            GameManager.instance.winner = owner;
        }
        else
        {
            // Play Miss Sound #1
            audioThing.Play();
        }
        Invoke("DestroyProjectile", 0);
    }
    void DestroyProjectile()
    {
        //Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
