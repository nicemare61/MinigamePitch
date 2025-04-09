using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private GameObject playObj;
    [SerializeField] private Player player;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float distance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playObj = GameObject.Find("Player");
        player = GameObject.Find("Player").GetComponent<Player>();
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
}
