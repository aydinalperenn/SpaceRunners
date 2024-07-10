using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Opponent : MonoBehaviour
{
    public NavMeshAgent opponentAgent;
    public GameObject target;
    public GameObject stopLineZ;

    Vector3 stopLineZPos;
    Vector3 startingPos;

    public GameObject speedBoosterIcon;
    public GameObject speedNerfIcon;

    Rigidbody rb;

    bool isFinished = false;


    [SerializeField] private GameManager gameManager;


    void Start()
    {
        rb = GetComponent<Rigidbody>();

        opponentAgent = GetComponent<NavMeshAgent>();
        startingPos = this.transform.position;

        opponentAgent.speed = Random.Range(3f, 6f);
        opponentAgent.acceleration = Random.Range(5f, 10f);

        speedBoosterIcon.SetActive(false);
        speedNerfIcon.SetActive(false);

        
    }


    void Update()
    {
        if (!gameManager.isStarted)
        {
            return;
        }

        opponentAgent.SetDestination(target.transform.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Çarptýn babba!");
            startingPos = new Vector3(Random.Range(-3.277f, 3.277f), startingPos.y, startingPos.z);
            this.transform.position = startingPos;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpeedBoost"))
        {
            StartCoroutine(IncreaseSpeed());
        }

        if (other.CompareTag("SpeedNerf"))
        {
            StartCoroutine(DecreaseSpeed());
        }

        if (other.CompareTag("FinishPoint"))
        {
            if (!isFinished)
            {
                isFinished = true;
                OpponentFinished();
            }
        }
    }



    IEnumerator IncreaseSpeed()
    {
        speedBoosterIcon.SetActive(true);
        opponentAgent.speed *= 2f;
        opponentAgent.acceleration *= 1.5f;
        yield return new WaitForSeconds(2f);
        opponentAgent.speed /= 2f;
        opponentAgent.acceleration /= 1.5f;
        speedBoosterIcon.SetActive(false);
    }

    IEnumerator DecreaseSpeed()
    {
        speedNerfIcon.SetActive(true);
        opponentAgent.speed /= 2f;
        opponentAgent.acceleration /= 1.5f;      
        yield return new WaitForSeconds(2f);
        opponentAgent.speed *= 2f;
        opponentAgent.acceleration *= 1.5f;
        speedNerfIcon.SetActive(false);
    }

    void OpponentFinished()
    {
        gameManager.endList.Add(this.gameObject.name);

        opponentAgent.speed = 0f;
        opponentAgent.acceleration = 0f;
        rb.velocity = Vector3.zero;
        stopLineZPos = new Vector3(transform.position.x, transform.position.y, stopLineZ.transform.position.z);
        transform.position = stopLineZPos;
        FinishCounter.IncreaseCounter();
        rb.isKinematic = true;
    }
}
