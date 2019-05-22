using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class PlayerPawn : MonoBehaviour
{
    private Transform tf;
    private Rigidbody2D rb;
    //private Animator anim;
    private AudioSource audioThing;

    public Transform thorax;
    public GameObject bulletPrefab;
    public Transform firingPoint;

    public bool isInAir;
    public bool isWalking;
    public bool isDead;
    public bool usingController;

    public float distanceToFeet;

    public float moveSpeed;
    public float jumpForce;
    public int maxJumps;
    private int currentJumps;
    public float shootRechargeTimeMax;
    private float shootRechargeTimeCurrent;

    [Header("Audio Clips")]
    public AudioClip shootingSound;
    public AudioClip jumpingSound;
    public AudioClip landingSound;
    public AudioClip deathSound;


    // Use this for initialization
    void Start()
    {
        tf = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        audioThing = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        isInAir = checkGround();
        // Set animator to isInAir
        // anim.SetBool("isInAir", isInAir);
    }
    bool isInAiry;
    public bool checkGround()
    {
        RaycastHit2D hit;
        hit = Physics2D.Raycast(tf.position, Vector2.down, distanceToFeet);
        if (hit.collider == null)
        {
            isInAiry = true;
            return true;
        }
        else
        {
            if (isInAiry == true)
            {
                isInAiry = false;
                // Play Sound for Landed #2
                audioThing.clip = landingSound;
                audioThing.Play(); 
            }
            currentJumps = 0;
            return false;
        }
    }
    public void move(float moveDirection)
    {
        if (!isDead)
        {
            isWalking = true;
            // Set animator to isWalking = true
            //anim.SetBool("isWalking", true);
            tf.Translate(tf.right * (moveDirection * (moveSpeed * Time.deltaTime)));
            if (moveDirection > 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (moveDirection < 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
        if (!isDead)
        {
            if (moveDirection == 0)
            {
                isWalking = false;
                // Set animator to isWalking = false
                // anim.SetBool("isWalking", false);
            }
        }
    }

    public void jump()
    {
        if (isDead)
        {
            return;
        }
        if (currentJumps >= maxJumps)
        {
            return;
        }

        // play sound for jump #3
        audioThing.clip = jumpingSound;
        audioThing.Play();
        rb.velocity = Vector3.up * jumpForce;
        //rb.AddForce(Vector3.up * jumpForce);
        currentJumps++;

        // Set jumpped animation
        // anim.SetBool("isInAir", true)
        // Play Sound
        // AudioSource.PlayClipAtPoint(jumpClip, tf.position, 2.0f);
    }

    public void aimTowards(Vector3 targetToLookAt)
    {
        if (usingController == false)
        {
            Vector3 dir = targetToLookAt - Camera.main.WorldToScreenPoint(thorax.position);
            float angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) + 90;
            thorax.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        else
        {
            float angle = (Mathf.Atan2(targetToLookAt.y, targetToLookAt.x) * Mathf.Rad2Deg) + 90;
            thorax.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }

    public void shoot()
    {
        // Instantiate a projectile and have it propel at it's start
        // Play Sound shoot #4
        audioThing.clip = shootingSound;
        audioThing.Play();
        Projectile myBullet = Instantiate(bulletPrefab, firingPoint.position, firingPoint.rotation).GetComponent<Projectile>();
        myBullet.owner = this.gameObject.name;
    }

    public void die()
    {
        Camera.main.GetComponent<CameraFollowMultiple>().targets.Remove(this.gameObject.transform);
        if (this.gameObject.name == "Player 1")
        {
            Debug.Log("Player 1 Died");
            GameManager.instance.winner = "Player 2";
        }
        if (this.gameObject.name == "Player 2")
        {
            Debug.Log("Player 2 Died");
            GameManager.instance.winner = "Player 1";
        }
        // Play Sound for hurt #5
        audioThing.clip = deathSound;
        audioThing.Play();
        GameManager.instance.displayWinner();
        Destroy(this.gameObject, 0.0f);
    }
}
