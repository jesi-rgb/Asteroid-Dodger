using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float speed = 20;
    float outOfScreenX;
    float halfPlayerWidth;
    public event System.Action OnPlayerDeath;


    // Start is called before the first frame update
    void Start()
    {
        halfPlayerWidth = GetComponent<SpriteRenderer>().size.x / 2f;
        outOfScreenX = Camera.main.aspect * Camera.main.orthographicSize + halfPlayerWidth;

    }

    // Update is called once per frame
    void Update()
    {
        Run();
        WrapEdges();

    }

    void Run()
    {
        float inputX = Input.GetAxisRaw("Horizontal");

        //float speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, DifficultyManager.getDifficultyPercent());

        Vector2 velocity = new Vector2(inputX, 0).normalized * speed;

        transform.Translate(velocity * Time.deltaTime);

    }

    void WrapEdges()
    {
        if (transform.position.x <= -outOfScreenX + halfPlayerWidth * 2)
        {
            //print("out left");
            transform.position = new Vector3(-outOfScreenX + halfPlayerWidth * 2, transform.position.y, transform.position.z);
        }

        if (transform.position.x >= outOfScreenX - halfPlayerWidth * 2)
        {
            //print("out right");
            transform.position = new Vector3(outOfScreenX - halfPlayerWidth * 2, transform.position.y, transform.position.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("You are garbage");

        OnPlayerDeath?.Invoke();

        Destroy(gameObject);
    }
}
