using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterAnimator : MonoBehaviour
{
    Animator animator;

    float moving = 0f;

    Vector3 oldPosition; 

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        oldPosition = transform.position;
    }

    void checkIfMoving() {
        if (transform.position != oldPosition)
        {
            moving = 1;
        }
        else {
            moving = 0;
        }
        oldPosition = transform.position;
    }

    void Update()
    {
        checkIfMoving();
        animator.SetFloat("speed", moving, .1f, Time.deltaTime);
    }
}
