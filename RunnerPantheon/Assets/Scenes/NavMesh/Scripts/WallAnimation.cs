using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallAnimation : MonoBehaviour
{
    public float speed = 1f;
    public float strength = 2.5f;

    private float randomOffset;


    // Start is called before the first frame update
    void Start()
    {
        randomOffset = Random.Range(-2.5f, 2.5f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Sin(Time.time * speed * randomOffset) * strength;
        transform.position = pos;
    }

}
