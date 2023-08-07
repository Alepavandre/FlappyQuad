using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speedHor = 1f;
    public float force = 1f;
    private float border;
    public float multi = 1f;
    private float speedVer;
    private float multiCurrent;

    public PauseData pause;
    public PlayerData player;
    public Stats stats;
    // Start is called before the first frame update
    void Start()
    {
        speedVer = 0f;
        multiCurrent = -1f;
        pause.isPause = true;
        player.bonusesCount = 0;
        border = stats.border;
    }

    private void Update()
    {
        CheckBorders();
        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
        {
            pause.isPause = false;
            multiCurrent = multi * force;
        }
        else
        {
            multiCurrent = -force;
        }
    }

    void FixedUpdate()
    {
        if (pause.isPause)
        {
            return;
        }
        speedVer += multiCurrent * Time.fixedDeltaTime;
        transform.position += speedHor * Time.fixedDeltaTime * Vector3.right + speedVer * Time.fixedDeltaTime * Vector3.up;
    }

    private void CheckBorders()
    {
        if (Mathf.Abs(transform.position.y) >= border)
        {
            Debug.Log("Restart");
            Restart();
        }
    }

    public void Restart()
    {
        pause.isPause = true;
        SceneManager.LoadScene(0);
    }
}
