using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAninmations : MonoBehaviour
{
    public float speed = 1f;
    private float strength = 3.315f;
    private float RandomOffset;

    // Start is called before the first frame update
    void Start()
    {
        RandomOffset = Random.Range(-strength, strength);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Sin(Time.time * speed * RandomOffset) * strength;
        transform.position = pos;

    }
}