using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckCollisions : MonoBehaviour
{
    public GameObject btn_restart;
    public GameObject btn_continue;
    public GameObject btn_menu;
    public GameObject finishText;
    public GameObject imageFinishText;
    public TextMeshProUGUI text_finishText;
    public GameObject stopLineZ;


    public int score;
    public TextMeshProUGUI CoinText;
    public GameObject startingPoint;
    Vector3 startingPos;

    PlayerController playerControllerScript;

    public GameObject speedBoosterIcon;
    public GameObject speedNerfIcon;


    public Animator PlayerAnim;
    public GameObject Player;


    private InGameRanking ig;

    Rigidbody rb;


    private void Start()
    {
        PlayerStartUI();

        PlayerAnim = Player.GetComponentInChildren<Animator>();


        startingPos = new Vector3(startingPoint.transform.position.x, this.transform.position.y, startingPoint.transform.position.z);

        playerControllerScript = GetComponent<PlayerController>();

        speedBoosterIcon.SetActive(false);
        speedNerfIcon.SetActive(false);

        ig = FindObjectOfType<InGameRanking>();

        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            //Debug.Log("Coin collected!..");
            AddCoin();
            //Destroy(other.gameObject);
            other.gameObject.SetActive(false);
        }

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
            PlayerFinished();
            if(ig.namesTxt[6].text == "Siz")
            {
                Debug.Log("Congrats!");
                btn_continue.SetActive(true);
                text_finishText.text = "Congratulations!";
            }
            else
            {
                Debug.Log("You Lose!");
                btn_restart.SetActive(true);
                text_finishText.text = "Game Over!";
            }

            PlayerFinishedUI();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Çarptýn babba!");
            this.transform.position = startingPos;
        }
    }

    public void AddCoin()
    {
        score++;
        CoinText.text = "Score: " + score.ToString();
    }

    IEnumerator IncreaseSpeed()
    {
        playerControllerScript.runningSpeed = playerControllerScript.normalRunningSpeed; //Arka arkaya aþýrý hýzlanmasýný engellemek için

        speedNerfIcon.SetActive(false);
        speedBoosterIcon.SetActive(true);
        playerControllerScript.runningSpeed = playerControllerScript.doubleRunningSpeed;
        yield return new WaitForSeconds(2);
        playerControllerScript.runningSpeed = playerControllerScript.normalRunningSpeed;
        speedBoosterIcon.SetActive(false);
    }

    IEnumerator DecreaseSpeed()
    {
        playerControllerScript.runningSpeed = playerControllerScript.normalRunningSpeed; //Arka arkaya aþýrý yavaþlamasýný engellemek için

        speedBoosterIcon.SetActive(false);
        speedNerfIcon.SetActive(true);
        playerControllerScript.runningSpeed = playerControllerScript.halfRunningSpeed;
        yield return new WaitForSeconds(2);
        playerControllerScript.runningSpeed = playerControllerScript.normalRunningSpeed;
        speedNerfIcon.SetActive(false);
    }


    void PlayerFinished()
    {
        playerControllerScript.runningSpeed = 0f;
        rb.velocity = Vector3.zero;
        playerControllerScript.isGameContinue = false;
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, stopLineZ.transform.position.z);
        FinishCounter.IncreaseCounter();
        rb.isKinematic = true;
    }
    
    void PlayerFinishedUI()
    {
        imageFinishText.SetActive(true);
        finishText.SetActive(true);
        btn_menu.SetActive(true);
    }

    void PlayerStartUI()
    {
        finishText.SetActive(false);
        imageFinishText.SetActive(false);
        btn_restart.SetActive(false);
        btn_continue.SetActive(false);
        btn_menu.SetActive(false);
    }



}
