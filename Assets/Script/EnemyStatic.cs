using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatic : MonoBehaviour
{

    public Transform player;
    public GameEnding gameEnding;
    bool isInRange = false;
    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject == player.gameObject)
        {
            isInRange = true;
        }
    }
    void OnTriggerExit(Collider other) 
    {
        if(other.gameObject == player.gameObject)
        {
            isInRange = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isInRange)
        {
            Vector3 dir = player.position - transform.position +Vector3.up;
            Ray ray = new Ray(transform.position,dir);
            RaycastHit raycastHit;

            if(Physics.Raycast(ray,out raycastHit))
            {
                if(raycastHit.collider.transform == player)
                {
                    gameEnding.Caught();
                }
            }
        }
    }
}
