using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public Rigidbody2D body;
    float halfScreen;

    // Start is called before the first frame update
    void Start()
    {
        body.velocity = transform.up * speed;
        halfScreen = Camera.main.orthographicSize;
    }

    private void Update()
    {
        if (transform.position.y > halfScreen + transform.localScale.y)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Asteroid")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
