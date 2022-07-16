using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nero
{
    public class AnimatorManager : MonoBehaviour
    {
        Animator animator;
        float snappedVertical;
        float snappedHorizontal;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public void HandleAnimatorValues(float verticalMovement, float horizontalMovement)
        {
            animator.SetFloat("Vertical", verticalMovement, 0.1f, Time.deltaTime);
            animator.SetFloat("Horizontal", horizontalMovement, 0.1f, Time.deltaTime);

            #region Snapped Vertical
            if (verticalMovement > 0) //if greater than 0
            {
                snappedVertical = 1; //default to 1
            }
            else if (verticalMovement < 0) //if greater than 0
            {
                snappedVertical = -1; //default to -1
            }
            else
            {
                snappedVertical = 0; //default to 0
            }
            #endregion

            #region snapped horizontal
            if (horizontalMovement > 0) //if greater than 0
            {
                snappedHorizontal = 1; //default to 1
            }
            else if (horizontalMovement < 0) //if less than 0
            {
                snappedHorizontal = -1; //default to -1
            }
            else
            {
                snappedHorizontal = 0; //default to 0
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