using System;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Ball : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    private bool bodyCheck;
    private bool headCheck;
    private int score;
    private Collider headShot;

    private void Awake()
    {
        enemy = GameObject.Find("Enemy");
        headShot = GameObject.Find("Enemy").GetComponent<Collider>();
        
    }

    private void OnCollisionEnter(Collision other)
    {
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (other.gameObject.name == "Enemy")
        {
            if (bodyCheck)
            {
                gameManager.score += score;
                bodyCheck = false;
            }
        }

        if (headShot.isTrigger)
        {
            if (headCheck)
            {
                gameManager.score += score;
                headCheck = false;
            }
        }
    }
}
