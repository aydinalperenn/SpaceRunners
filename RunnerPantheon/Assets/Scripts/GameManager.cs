using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private InGameRanking ig;

    private GameObject[] runners;
    List<RankingSystem> sortArray = new List<RankingSystem>();

    public bool isStarted;

    int timer = 3;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject timerPanel;

    [HideInInspector] public List<string> endList = new List<string>();


    private void Awake()
    {
        instance = this;
        runners = GameObject.FindGameObjectsWithTag("Runner");
        ig = FindObjectOfType<InGameRanking>();
    }


    void Start()
    {
        FinishCounter.ResetCounter();

        for(int i = 0; i<runners.Length; i++)
        {
            sortArray.Add(runners[i].GetComponent<RankingSystem>());
        }

        StartCoroutine(CountDown());
    }


    private IEnumerator CountDown()
    {
        timerText.text = timer.ToString();
        timer--;
        yield return new WaitForSeconds(1);
        if (timer > 0)
        {
            StartCoroutine(CountDown());
        }
        else
        {
            StartCoroutine(StartGame());
        }
    }

    private IEnumerator StartGame()
    {
        timerText.text = "Ready!";
        yield return new WaitForSeconds(1);
        timerPanel.SetActive(false);
        isStarted = true;
    }

    void Update()
    {
        if(isStarted)
        {
            CalculateRanking();
        }
    }


    void CalculateRanking()
    {
        sortArray = sortArray.OrderBy(x => x.distance).ToList();
        sortArray[0].rank = 1;
        sortArray[1].rank = 2;
        sortArray[2].rank = 3;
        sortArray[3].rank = 4;
        sortArray[4].rank = 5;
        sortArray[5].rank = 6;
        sortArray[6].rank = 7;


        ig.a = sortArray[6].name;
        ig.b = sortArray[5].name;
        ig.c = sortArray[4].name;
        ig.d = sortArray[3].name;
        ig.e = sortArray[2].name;
        ig.f = sortArray[1].name;
        ig.g = sortArray[0].name;
    }
}
