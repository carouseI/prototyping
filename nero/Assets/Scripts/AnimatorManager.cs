using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Nero
{
    public class AnimatorManager : MonoBehaviour
    {
        public Animator animator;
        public Animator anim;

        int vertical;
        int horizontal;

        private void Awake()
        {
            animator = GetComponent<Animator>();

            vertical = Animator.StringToHash("Vertical");
            horizontal = Animator.StringToHash("Horizontal");
        }
    }
}