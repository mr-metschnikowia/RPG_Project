using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public Transform player;

    public Vector3 offset;

    void matchPlayer() {

        transform.position = player.position + offset;

    }
    // match players position and rotation

    // Update is called once per frame
    void Update()
    {
        //matchPlayer(); 
    }
}
