using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nero
{
    public class AnimatorHandler : AnimatorManager
    {
        PlayerManager playerManager;
        PlayerLocomotion playerLocomotion;

        int vertical;
        int horizontal;

        public bool canRotate;

        public void Initialize()
        {
            playerManager = GetComponent<PlayerManager>();
            animator = GetComponent<Animator>();

            vertical = Animator.StringToHash("Vertical");
            horizontal = Animator.StringToHash("Horizontal");
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