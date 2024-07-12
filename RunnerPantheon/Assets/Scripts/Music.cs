using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    private static Music instance;

    private void Awake()
    {
        // Eger singleton örnegi henüz yoksa, bu nesneyi singleton olarak ayarla ve yok edilmesin
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Singleton örnegi zaten varsa, bu nesneyi yok et
            Destroy(gameObject);
        }
    }

    public static Music Instance
    {
        get
        {
            return instance;
        }
    }
}