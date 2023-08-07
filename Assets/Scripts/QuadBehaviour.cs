using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadBehaviour : MonoBehaviour
{
    private float distance;
    private float speed;
    private float startHeight;
    private float up;
    private float timeToDestroy;
    public Stats stats;

    void Start()
    {
        distance = Random.Range(stats.quadMinDistance, stats.quadMaxDistance);
        speed = Random.Range(stats.quadMinSpeed, stats.quadMaxSpeed);
        startHeight = transform.position.y;
        up = 1f;
        timeToDestroy = stats.quadLivingTime;
    }

    private void Update()
    {
        if (transform.position.y > startHeight + distance || transform.position.y > stats.border)
        {
            up = -1f;
        }
        if (transform.position.y < startHeight - distance || transform.position.y < -stats.border)
        {
            up = 1f;
        }
        timeToDestroy -= Time.deltaTime;
        if (timeToDestroy <= 0f)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        transform.position += speed * Time.fixedDeltaTime * up * Vector3.up;
    }
}
