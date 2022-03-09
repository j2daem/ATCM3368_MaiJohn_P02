using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    [SerializeField] Animator animator = null;
    int isWalkingHash;
    int isRunningHash;

    private void Start()
    {
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
    }

    private void Update()
    {
        bool isWalking = animator.GetBool("isWalking");
        bool isRunning = animator.GetBool("isRunning");

        if (!isWalking && Input.GetKey(KeyCode.W))
        {
            animator.SetBool(isWalkingHash, true);
        }

        if (isWalking && Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool(isWalkingHash, false);
        }

        if (!isRunning && (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift)))
        {
            animator.SetBool(isRunningHash, true);
        }

        if (isRunning && (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.LeftShift)))
        {
            animator.SetBool(isRunningHash, false);
        }
    }
}
