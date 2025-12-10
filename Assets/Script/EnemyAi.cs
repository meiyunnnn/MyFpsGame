using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    private Transform player;

    void Start()
    {
        // หา Player จาก Tag
        GameObject p = GameObject.FindGameObjectWithTag("Player");

        if (p != null)
        {
            player = p.transform;
        }
    }

    void Update()
    {
        // เผื่อ Player spawn ภายหลัง
        if (player == null)
        {
            GameObject p = GameObject.FindGameObjectWithTag("Player");
            if (p != null) player = p.transform;
        }

        // ไล่ตามผู้เล่น
        if (player != null)
        {
            agent.SetDestination(player.position);
        }
    }
}