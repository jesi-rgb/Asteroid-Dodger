using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinePulsing : MonoBehaviour
{
    public float maxSize = 2.0f;
    public float minSize = 0.2f;
    public float speed = 1.0f;

    void Update()
    {
        float range = maxSize - minSize;

        float scale = (Mathf.Sin(Time.time * speed) + 1.0f) / 2.0f * range + minSize;

        transform.localScale = new Vector3(scale, scale);
    }
}
