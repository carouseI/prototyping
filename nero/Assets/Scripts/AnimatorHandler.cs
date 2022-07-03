using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nero
{
    public class AnimatorHandler : AnimatorManager
    {
        PlayerManager playerManager;
        PlayerLocomotion playerLocomotion;

        public bool canRotate;

        public void Initialize()
        {
            playerManager = GetComponent<PlayerManager>();
            anim = GetComponent<Animator>();
        }

        public void UpdateAnimatorValues(float verticalMovement, float horizontalMovement, bool isWalking)
        {
            float v = 0;
            float h = 0;

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