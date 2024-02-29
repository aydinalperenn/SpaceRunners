using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class InGameRanking : MonoBehaviour
{
    public TextMeshProUGUI[] namesTxt;

    public string a, b, c, d, e, f, g;


    private void Update()
    {
        namesTxt[0].text = a;
        namesTxt[1].text = b;
        namesTxt[2].text = c;
        namesTxt[3].text = d;
        namesTxt[4].text = e;
        namesTxt[5].text = f;
        namesTxt[6].text = g;






        ////    Düzgün çalýþmýyor.
        //if(FinishCounter.counter == 0)
        //{
        //    namesTxt[0].text = a;
        //    namesTxt[1].text = b;
        //    namesTxt[2].text = c;
        //    namesTxt[3].text = d;
        //    namesTxt[4].text = e;
        //    namesTxt[5].text = f;
        //    namesTxt[6].text = g;
        //}
        //else if (FinishCounter.counter == 1)
        //{
        //    namesTxt[0].text = a;
        //    namesTxt[1].text = b;
        //    namesTxt[2].text = c;
        //    namesTxt[3].text = d;
        //    namesTxt[4].text = e;
        //    namesTxt[5].text = f;
        //}
        //else if (FinishCounter.counter == 2)
        //{
        //    namesTxt[0].text = a;
        //    namesTxt[1].text = b;
        //    namesTxt[2].text = c;
        //    namesTxt[3].text = d;
        //    namesTxt[4].text = e;
        //}
        //else if (FinishCounter.counter == 3)
        //{
        //    namesTxt[0].text = a;
        //    namesTxt[1].text = b;
        //    namesTxt[2].text = c;
        //    namesTxt[3].text = d;
        //}
        //else if (FinishCounter.counter == 4)
        //{
        //    namesTxt[0].text = a;
        //    namesTxt[1].text = b;
        //    namesTxt[2].text = c;
        //}
        //else if (FinishCounter.counter == 5)
        //{
        //    namesTxt[0].text = a;
        //    namesTxt[1].text = b;
        //}
        //else if (FinishCounter.counter == 6)
        //{
        //    namesTxt[0].text = a;
        //}

    }

}
