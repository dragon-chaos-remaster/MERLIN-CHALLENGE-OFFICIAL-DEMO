using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;
public class RockEnemy : MonoBehaviour
{
    NavMeshAgent agent;

    [SerializeField] Transform targetPos;

    [SerializeField] SphereCollider colisorEsfera;

    //[SerializeField] GameObject explosiveArea;

    [SerializeField] float velocidade;
    [SerializeField] float aceleration;
    [SerializeField] float distanciaDeNojo;
    [SerializeField] float areaDeDetecao;

    TomaDano dano;
    Snared snare;

    Collider[] enemyDetectionSpots;
    //[SerializeField] Collision chaoDetected;

    [SerializeField] LayerMask layerDoPlayer;
    Rigidbody myBody;
    [SerializeField] bool enemySpotted = false;
    [SerializeField] bool startNavMesh;

    bool canStartTracking = false;

    // Start is called before the first frame update
    void Start()
    {
        //chaoDetected = this.gameObject.GetComponent<Collision>();

        myBody = GetComponent<Rigidbody>();
        myBody.isKinematic = true;

        if (GetComponent<SphereCollider>() == null)
        {
            GetComponent<CapsuleCollider>().enabled = false;
        }
        else
        {
            colisorEsfera = GetComponent<SphereCollider>();
            colisorEsfera.enabled = false;
        }

        agent = GetComponent<NavMeshAgent>();
        agent.enabled = false;
        agent.speed = velocidade/Mathf.Clamp(transform.localScale.sqrMagnitude,1f,20f);
        agent.acceleration = aceleration;
        agent.stoppingDistance = distanciaDeNojo;

        //print(transform.localScale.sqrMagnitude);
        //print("Speed of " + agent.speed + " from " + this.gameObject.name);

        dano = GetComponent<TomaDano>();
        snare = GetComponent<Snared>();

        targetPos = GameObject.FindWithTag("player").transform;
    }

    
    // Update is called once per frame
    void Update()
    {
        //snare.Desnare(1.5f);
        if (WaveSpawner.Instance.waveRound == 2 && !WaveSpawner.Instance.activateBoss[1])
        {
            //print("roooo");
            canStartTracking = true;
            if (canStartTracking)
            {
                //print("é vc desgraçado?");
                if (GetComponent<SphereCollider>() == null)
                {
                    GetComponent<CapsuleCollider>().enabled = true;
                }
                else
                {
                    colisorEsfera.enabled = true;
                }
                
            }
            enemyDetectionSpots = Physics.OverlapSphere(transform.position, areaDeDetecao, layerDoPlayer);
            if (enemyDetectionSpots.Length != 0)
            {
                //print("ENEMY SPOTTED");
                enemySpotted = true;
            }
            if (enemySpotted)
            {
                if (!startNavMesh)
                {
                    Vector3 moveTowardsPlayer = (targetPos.position - new Vector3(transform.position.x, transform.position.y, transform.position.z * 0.1f)).normalized * agent.speed;
                    transform.Rotate(transform.forward * 10);
                    myBody.velocity = moveTowardsPlayer;
                    
                    Invoke("BeginNavMesh", 4.5f);
                }
                else
                {
                    myBody.mass = 1f;
                    snare.Desnare(1.5f);
                    agent.SetDestination(targetPos.position);
                }
                //StartCoroutine(BeginNavMesh());
                //enemySpotted = false;
                //agent.enabled = true;
                //myBody.mass = 1f;
                //agent.SetDestination(targetPos.position);
            }
        }
    }
    void BeginNavMesh()
    {      
        agent.enabled = true;
        startNavMesh = true;
        
    }
    
    //private void OnCollisionEnter(Collision chaoDetected)
    //{
    //    if (enemySpotted && chaoDetected.gameObject.CompareTag("chao"))
    //    {
    //        agent.enabled = true;
    //        myBody.mass = 1f;
    //        agent.SetDestination(targetPos.position);
    //    }
    //}
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "bolaFogo":
                enemySpotted = true;
                dano.gameObject.GetComponent<TomaDano>().TomarDanos(15);
                break;
            case "Raio":
                enemySpotted = true;
                dano.gameObject.GetComponent<TomaDano>().TomarDanos(12);
                break;
            case "RaizDoPlayer":
                enemySpotted = true;
                snare.gameObject.GetComponent<Snared>().Snare();
                dano.gameObject.GetComponent<TomaDano>().TomarDanos(7);

                break;
            case "ataqueBasico":
                enemySpotted = true;
                dano.gameObject.GetComponent<TomaDano>().TomarDanos(10);
                break;
            case "pegaFogo":
                enemySpotted = true;
                dano.gameObject.GetComponent<TomaDano>().TomarDanos(3);
                break;

        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, areaDeDetecao);
        
    }
}
