using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class ZombieAI : MonoBehaviour
{
    public Transform[] m_waypoints;
    private int m_currentWaypoint;
    private NavMeshAgent m_agent;
    private EZombieState m_ZombieState;
    private PlayerController m_player;
    private Renderer m_rend;

    public EZombieState Zombiestate
    {
        get
        {
            return m_ZombieState;
        }
        set
        {
            if (m_ZombieState == value)
            {
                return;
            }
            DeactivateOldState();
            m_ZombieState = value;
            ActivateNewState();
        }
    }

    public enum EZombieState
    {
        PATROLE,
        HUNT,
        COLLIDE
    }
    // Use this for initialization
    void Start()
    {
        m_agent = GetComponent<NavMeshAgent>();
        Zombiestate = EZombieState.PATROLE;
        m_player = FindObjectOfType<PlayerController>();
        m_rend = GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {
        switch (m_ZombieState)
        {
            case EZombieState.HUNT:
                HuntPlayer();
                break;
            case EZombieState.PATROLE:
                Patrole();
                break;
            case EZombieState.COLLIDE:
                break;
        }

    }

    void HuntPlayer()
    {
        if (m_player == null ||
            (m_player != null &&
                    (m_player.transform.position - transform.position).sqrMagnitude > 100))
        {
            Zombiestate = EZombieState.PATROLE;
            return;


        }
        m_agent.SetDestination(m_player.transform.position);
    }

    void Patrole()
    {
        if (m_player != null && (m_player.transform.position - transform.position).sqrMagnitude < 100)
        {
            Zombiestate = EZombieState.HUNT;
            return;
        }

        if ((m_waypoints[m_currentWaypoint].position - transform.position).sqrMagnitude < 0.025)
        {
            m_currentWaypoint = (m_currentWaypoint + 1) % m_waypoints.Length;

            m_agent.SetDestination(m_waypoints[m_currentWaypoint].position);
        }

    }
    void DeactivateOldState()
    {
        switch (m_ZombieState)
        {
            case EZombieState.HUNT:
                break;
            case EZombieState.PATROLE:
                break;
            case EZombieState.COLLIDE:
                break;
        }
    }

    void ActivateNewState()
    {
        switch (m_ZombieState)
        {
            case EZombieState.PATROLE:
                m_rend.material.color = Color.yellow;
                m_currentWaypoint = 0;
                for (int i = 1; i < m_waypoints.Length; i++)
                {

                    if ((m_waypoints[m_currentWaypoint].position - transform.position).sqrMagnitude >
                         (m_waypoints[i].position - transform.position).sqrMagnitude)
                    {
                        m_currentWaypoint = i;
                    }
                }
                m_agent.SetDestination(m_waypoints[m_currentWaypoint].transform.position);
                break;
            case EZombieState.HUNT:
                m_rend.material.color = Color.red;

                m_agent.SetDestination(m_player.transform.position);
                break;
            case EZombieState.COLLIDE:
                m_rend.material.color = Color.gray;
                Destroy(m_player.gameObject);
                break;

        }

    }

}