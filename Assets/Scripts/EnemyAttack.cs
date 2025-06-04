using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject effectBoom;
    public GameManager gameManager;
    public AudioSource souoom;
    public AudioClip soundAttack;
    private float speed = 4;
    private float destroyBoom = -6f;
    private int score = 2;
    void Start()
    {
        gameManager = GameManager.FindAnyObjectByType<GameManager>();   
        souoom = GetComponent<AudioSource>();
        souoom.PlayOneShot(soundAttack, 1.2f);
        
    }

    void Update()
    {
        MoveBolt();
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Spark"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            Vector2 positionEffect = new Vector2(transform.position.x, transform.position.y);
            Instantiate(effectBoom, positionEffect, effectBoom.transform.rotation);

            if (other.gameObject.CompareTag("Spark"))
            {
                gameManager.UpdateScore(score);
            }
        }
    }
    private void MoveBolt()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        if (transform.position.y < destroyBoom)
        {
            Destroy(gameObject);
        }
    }

}
