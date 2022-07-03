using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nero
{
    public class AnimatorHandler : AnimatorManager
    {
        PlayerManager playerManager;
        PlayerLocomotion playerLocomotion;

        int vert;
        int hori;

        public bool canRotate;

        public void Initialize()
        {
            playerManager = GetComponent<PlayerManager>();
            anim = GetComponent<Animator>();

            vert = Animator.StringToHash("Vertical");
            hori = Animator.StringToHash("Horizontal");
        }

        public void UpdateAnimatorValues(float verticalMovement, float horizontalMovement, bool isWalking)
        {
            #region vertical clamp
            float v = 0;

            if (verticalMovement > 0 && verticalMovement < 0.55f) // if greater than 0 + less than 0.55
            {
                v = 0.5f;
            }
            else if (verticalMovement > 0.55f) //if greater than 0.55
            {
                v = 1;
            }
            else if (verticalMovement < 0 && verticalMovement > -0.55f) //if less than 0 + greater tan -0.55
            {
                v = -0.5f;
            }
            else if (verticalMovement < -0.55f) //if less than -0.55
            {
                v = -1;
            }
            else
            {
                v = 0;
            }
            #endregion
            #region horizontal clamp
            float h = 0;

            if (horizontalMovement > 0 && horizontalMovement < 0.55f) // if greater than 0 + less than 0.55
            {
                h = 0.5f;
            }
            else if (horizontalMovement > 0.55f) //if greater than 0.55
            {
                h = 1;
            }
            else if (horizontalMovement < 0 && horizontalMovement > -0.55f) //if less than 0 + greater tan -0.55
            {
                h = -0.5f;
            }
            else if (horizontalMovement < -0.55f) //if less than -0.55
            {
                h = -1;
            }
            else
            {
                h = 0;
            }
            #endregion

            if (isWalking)
            {
                v = 2;
                h = horizontalMovement;
            }
        }

        public void CanRotate()
        {
            canRotate = true;
        }

        public void StopRotation()
        {
            canRotate = false;
        }
    }
}