using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    float speed;
    Vector2 speedMinMax = new Vector2(15, 20);
    float bottomScreen;
    float angularVel;

    // Start is called before the first frame update
    void Start()
    {

        speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y,
            DifficultyManager.getDifficultyPercent());
        angularVel = Random.Range(-20, 20) * speed;

        bottomScreen = Camera.main.orthographicSize;

        float scaleF = Random.Range(4, 10);
        transform.localScale = new Vector3(scaleF, scaleF, 1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * angularVel * Time.deltaTime, Space.Self);
        transform.Translate(Vector2.down * speed * Time.deltaTime, Space.World);

        if (transform.position.y < -bottomScreen - transform.localScale.y)
        {
            Destroy(gameObject);
        }

    }
}
