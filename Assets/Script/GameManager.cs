using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public float health = 100;
    [SerializeField] private TextMeshProUGUI txtMesh;
    public override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        txtMesh.text = "Health: " + health;
        if (health <= 0f)
        {
            Application.Quit();
        }
    }

    public void ChangeHealth(int healthVariation)
    {
        health -= healthVariation;
    }
}
