using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpToTarget : MonoBehaviour
{
    public Transform targetObject;
    public float jumpHeight = 5f;
    public float jumpDuration = 1f;
    public float horizontalMoveDistance = 1f;

    private bool isJumping = false;

    private void Start()
    {
        JumpToTargetWithDelay();
    }

    private void Update()
    {
        if (isJumping)
        {
            // Kiểm tra khoảng cách với targetObject
            float distance = Vector3.Distance(transform.position, targetObject.position);
            if (distance > 0.1f)
            {
                // Kiểm tra thời gian di chuyển so với thời gian nhảy
                float remainingTime = jumpDuration;
                if (remainingTime > 0.1f)
                {
                    if (Input.GetKeyDown(KeyCode.LeftArrow))
                    {
                        MoveToLeft();
                    }

                    if (Input.GetKeyDown(KeyCode.RightArrow))
                    {
                        MoveToRight();
                    }
                }
            }
        }
    }

    private void JumpToTargetWithDelay()
    {
        isJumping = true;

        float distance = Vector3.Distance(transform.position, targetObject.position);
        float jumpTime = distance / jumpHeight;

        transform.DOJump(targetObject.position, jumpHeight, 1, jumpTime)
            .OnComplete(() => isJumping = false);
    }

    private void MoveToLeft()
    {
        transform.DOMoveX(transform.position.x - horizontalMoveDistance, jumpDuration);
    }

    private void MoveToRight()
    {
        transform.DOMoveX(transform.position.x + horizontalMoveDistance, jumpDuration);
    }
}
