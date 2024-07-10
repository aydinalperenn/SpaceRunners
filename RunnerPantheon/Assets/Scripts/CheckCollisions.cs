using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckCollisions : MonoBehaviour
{
    public GameObject rankText;
    public GameObject endPanel;
    public GameObject inGameRanking;
    public TextMeshProUGUI text_rankText;
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

    private bool playerFounded;
    private int rank = 0;
    private int highScore;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private GameObject highScoreBroken;

    [SerializeField] private GameManager gm;


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

        highScore = PlayerPrefs.GetInt("HighScore", 0);
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
            if (gm.isStarted)
            {
                gm.isStarted = false;

                PlayerFinished();

                gm.endList.Add("You");


                

                for (int i = 0; i < gm.endList.Count; i++)
                {
                    if (gm.endList[i] == "You")
                    {
                        rank = i+1;
                        playerFounded = true;
                        break;
                    }
                }


                if (!playerFounded)
                {
                    rank = 7;
                }

                score += (80 - rank * 10);

                if (score > highScore)
                {
                    PlayerPrefs.SetInt("HighScore", score);
                    PlayerFinishedUI(true);
                }
                else
                {
                    PlayerFinishedUI(false);
                }
            }
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
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
    
    void PlayerFinishedUI(bool broken)
    {
        inGameRanking.SetActive(false);

        text_rankText.text = "Your Rank: " + rank;
        scoreText.text = "Total Score: " + score.ToString();
        highScoreText.text = "Highscore: " + highScore.ToString();

        if (broken)
        {
            highScoreBroken.SetActive(true);
        }
        else
        {
            highScoreBroken.SetActive(false);
        }


        endPanel.SetActive(true);

        
    }

    void PlayerStartUI()
    {
        endPanel.SetActive(false);

    }



}
