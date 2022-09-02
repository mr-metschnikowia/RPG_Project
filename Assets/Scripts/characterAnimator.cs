using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterAnimator : MonoBehaviour
{
    Animator animator;

    CharacterController controller;

    float moving = 0f;

    Vector3 oldPosition; 

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        oldPosition = transform.position;
    }

    void checkIfMoving() {
        if (!controller.isGrounded) {
            moving = 1;
        }
        // jump block 
        else if (transform.position != oldPosition)
        {
            moving = 0.5f;
        } else {
            moving = 0;
        }
        oldPosition = transform.position;
    }
    // set animation trigger based on player movement 

    void Update()
    {
        checkIfMoving();
        animator.SetFloat("speed", moving, .1f, Time.deltaTime);
    }
    // send animation trigger to animator 
}
