using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nero
{
    public class AnimatorManager : MonoBehaviour
    {
        public Animator animator;
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

            animator.SetFloat("Vertical", snappedVertical, 0.1f, Time.deltaTime); //set snapped vert animation; 0.1f = damp/blend time, transition between actions to smooth out motion
            animator.SetFloat("Horizontal", snappedHorizontal, 0.1f, Time.deltaTime); //set snapped hori animation
        }
    }
}