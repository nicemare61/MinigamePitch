using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private GameObject playObj;
    [SerializeField] private Player player;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float distance;
    [SerializeField] public Collider headCol;
    private GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playObj = GameObject.Find("Player");
        player = GameObject.Find("Player").GetComponent<Player>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager.enemyIngame += 1;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, playObj.transform.position);
        if (distance > 0.1f)
        {
           agent.destination = playObj.transform.position;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Player")
        {
            gameManager.playAlive = false;
        }
    }
    
    private void OnDestroy()
    {
        gameManager.enemyIngame -= 1;
    }

    IEnumerator<WaitForSeconds> Destroy()
    {
        yield return new WaitForSeconds(1f);
    }
}
