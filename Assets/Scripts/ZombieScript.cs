using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScript : MonoBehaviour
{
    // Variables

    public Animator enemyAnim;
    private Rigidbody rb;
    public GameObject player;
    public GameManager gameManager;

    private float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        enemyAnim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // Follow player
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        transform.forward = lookDirection;
        rb.AddForce(lookDirection * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Zombie Attack
        if(collision.gameObject.CompareTag("Player"))
        {
            speed = 0;
            enemyAnim.SetTrigger("attack");
            gameManager.UpdateHealth(-1);
            speed = 1;
        }
    }
}
