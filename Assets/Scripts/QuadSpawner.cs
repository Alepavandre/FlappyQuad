using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadSpawner : MonoBehaviour
{
    public PauseData pause;
    public float delayMin = 0.3f;
    public float delayMax = 0.7f;
    public float border;
    public GameObject quad;
    private bool started;

    private void Start()
    {
        started = false;
    }

    private void Update()
    {
        if (!pause.isPause && !started)
        {
            started = true;
            StartCoroutine(Spawn());
        }
    }

    private IEnumerator Spawn()
    {
        while (!pause.isPause)
        {
            Vector3 pos = new(transform.position.x, Random.Range(-border, border), transform.position.z);
            Instantiate(quad, pos, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(delayMin, delayMax));
        }
    }
}
