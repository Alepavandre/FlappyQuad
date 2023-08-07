using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBehaviour : MonoBehaviour
{
    public PlayerData player;
    public Stats stats;
    private float timeToDestroy;
    private bool isFollow;
    private Transform playerTransform;

    private void Start()
    {
        timeToDestroy = stats.quadLivingTime * 2f;
        isFollow = false;
    }

    private void Update()
    {
        if (timeToDestroy <= 0f)
        {
            Destroy(gameObject);
        }
        else
        {
            timeToDestroy -= Time.deltaTime;
        }
        if (isFollow)
        {
            FollowPlayer();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.bonusesCount++;
            Destroy(gameObject);
        }
        if (collision.CompareTag("PlayerField"))
        {
            isFollow = true;
            playerTransform = collision.transform;
        }
    }

    private void FollowPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, stats.bonusSpeed * Time.deltaTime);
    }
}
