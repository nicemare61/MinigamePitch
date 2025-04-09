using System;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Ball : MonoBehaviour
{
    private bool bodyCheck;
    private bool headCheck;
    private int score;
    [SerializeField] private GameObject enemy;

    private void OnCollisionEnter(Collision other)
    {
        GameObject headShot = GetComponentInChildren<GameObject>();
        Collision headCollision = headShot.GetComponent<Collision>();
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (other.gameObject.name == "Enemy")
        {
            if (bodyCheck)
            {
                gameManager.score += score;
                bodyCheck = false;
            }
        }

        if (other == headCollision) 
        {
            if (headCheck)
            {
                gameManager.score += score;
                headCheck = false;
            }
        }
    }
}
