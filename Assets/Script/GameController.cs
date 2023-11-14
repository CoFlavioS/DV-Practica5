using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : Singleton<GameController>
{
    public int points = 0;
    public float remainingTime = 60;

    [SerializeField] private TextMeshProUGUI txtMesh;

    void Update()
    {
        remainingTime -= Time.deltaTime;
        txtMesh.text = "Points: " + points + "\nTime: " + (int)remainingTime;
        if(remainingTime < 0f)
        {
            Application.Quit();
        }
    }
}
