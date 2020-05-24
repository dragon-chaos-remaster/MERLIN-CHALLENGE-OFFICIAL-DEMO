using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Snared : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    float velocidadeOriginal;

    float snare = 0.1f;

    //EnemyFollow enemyStop;

    float tempoAtivo = 0f;
    float tempoAtual = 1f;


    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        velocidadeOriginal = navMeshAgent.speed;

    }

    // Update is called once per frame
    /*void Update()
    {


    }*/

    public void Snare()
    {
        navMeshAgent.velocity = Vector3.zero;
        navMeshAgent.speed = snare;
        FindObjectOfType<AudioManager>().Play("snare");
        //enemyStop.enabled = false;
        navMeshAgent.isStopped = true;
    }
    public void Desnare(float duracaoSnare)
    {
        if (navMeshAgent.speed <= 0.1f)
        {
            tempoAtivo += tempoAtual * Time.deltaTime;
        }
        if (tempoAtivo >= duracaoSnare)
        {
            navMeshAgent.velocity = Vector3.one;
            navMeshAgent.speed = velocidadeOriginal;
            FindObjectOfType<AudioManager>().Play("revertSnare");
            navMeshAgent.isStopped = false;
            tempoAtivo = 0f;

        }
    }
}
