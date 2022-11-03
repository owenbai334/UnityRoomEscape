using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamera : MonoBehaviour
{
    Transform Player;
    Vector3 offects;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("JohnLemon").transform;
        offects = transform.position-Player.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = offects + Player.position;
    }
}
