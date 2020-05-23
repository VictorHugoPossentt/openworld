using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavSystem : MonoBehaviour
{
    public NavMeshAgent navAgent;
    public Transform objective;
    private bool isAlive = true;
    public GameObject primarySystemObj;
    public PrimarySystem primaryScript;
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        objective = GameObject.FindGameObjectWithTag("Player").transform;
        isAlive = true;        
        primarySystemObj = GameObject.FindGameObjectWithTag("System");
        primaryScript = primarySystemObj.GetComponent<PrimarySystem>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!navAgent.isOnNavMesh)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            primaryScript.scoreNumber++;
            StartCoroutine(Deathtimer());                       
        }
        else if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Game Over");
            primaryScript.GameOver();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Estruturas"))
        {
            if (isAlive == true)
            {
                navAgent.SetDestination(objective.position);
            }            
        }
    }

    IEnumerator Deathtimer()
    {
        isAlive = false;
        navAgent.ResetPath();
        this.GetComponent<ParticleSystem>().Play();
        yield return new WaitForSeconds(0.2f);
        Destroy(this.gameObject);
    }
}
