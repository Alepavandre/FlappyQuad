using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public PauseData pause;
    public GameObject hinttext;

    public PlayerData player;
    public TextMeshProUGUI bonusesText;

    void Update()
    {
        hinttext.SetActive(pause.isPause);
        bonusesText.text = player.bonusesCount.ToString();
    }
}
