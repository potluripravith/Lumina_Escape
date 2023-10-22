using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    int isJumpingHash;
    int isRunningHash;
    public Rigidbody rb;
    public float force = 100f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isJumpingHash = Animator.StringToHash("isJumping");
        isRunningHash = Animator.StringToHash("isRunning");
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(0, 0, force*Time.deltaTime);

        bool isJumping = animator.GetBool(isJumpingHash);
        bool isRunning = animator.GetBool(isRunningHash);
        bool spacePressed = Input.GetKey(KeyCode.Space);

        if (!isJumping && spacePressed)
        {
            animator.SetBool(isJumpingHash, true);
            animator.SetBool(isRunningHash, false);

        }

        if (isJumping && !spacePressed)
        {
            animator.SetBool(isJumpingHash, false);
            animator.SetBool(isRunningHash, true);
            rb.AddForce(0, 0, force * Time.deltaTime);
        }
    }
}
