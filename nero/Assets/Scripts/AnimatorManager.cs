using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nero
{
    public class AnimatorManager : MonoBehaviour
    {
        Animator animator;

        int horizontal;
        int vertical;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            horizontal = Animator.StringToHash("Horizontal");
            vertical = Animator.StringToHash("Vertical");
        }

        public void UpdateAnimatorValues(float horizontalMovement, float verticalMovement)
        {
            float snappedHorizontal;
            float snappedVertical;

            #region snapped horizontal
            if (horizontalMovement > 0 && horizontalMovement < 0.55f) //if greater than 0 + less the 0.55
            {
                snappedHorizontal = 0.5f; //default to 0.5
            }
            else if (horizontalMovement > 0.55f) //if greater than 0.55
            {
                snappedHorizontal = 1; //default to 1
            }
            else if (horizontalMovement < 0 && horizontalMovement > -0.55f) //if less than 0 + greater than -0.55
            {
                snappedHorizontal = -0.5f; //default to -0.5
            }
            else if (horizontalMovement < -0.55f) //if less than -0.55
            {
                snappedHorizontal = -1; //default to -1
            }
            else
            {
                snappedHorizontal = 0; //default to 0
            }
            #endregion

            #region Snapped Vertical
            if (verticalMovement > 0 && verticalMovement < 0.55f) //if greater than 0 + less the 0.55
            {
                snappedVertical = 0.5f; //default to 0.5
            }
            else if (verticalMovement > 0.55f) //if greater than 0.55
            {
                snappedVertical = 1; //default to 1
            }
            else if (verticalMovement < 0 && verticalMovement > -0.55f) //if less than 0 + greater than -0.55
            {
                snappedVertical = -0.5f; //default to -0.5
            }
            else if (verticalMovement < -0.55f) //if less than -0.55
            {
                snappedVertical = -1; //default to -1
            }
            else
            {
                snappedVertical = 0; //default to 0
            }
            #endregion

            animator.SetFloat(horizontal, snappedHorizontal, 0.1f, Time.deltaTime); //set snapped horizontal animation; 0.1f = damp/blend time, transition between actions to smooth out motion
            animator.SetFloat(vertical, snappedVertical, 0.1f, Time.deltaTime); //set snapped vertical animation
        }

        public void PlayTargetAnimation(string targetAnimator, bool isInteracting)
        {
            animator.applyRootMotion = isInteracting; //set root to interacting
            animator.SetBool("isInteracting", isInteracting); //set bool
            animator.CrossFade(targetAnimator, 0.2f); //set cross fade
        }
    }
}