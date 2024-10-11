using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace MyFps
{
    public class DoorCellOpen : Interactive
    {
        #region Variables
        private Animator animator;
        private Collider collider;
        public AudioSource audioSource;
        // 
        #endregion

        private void Start()
        {
            animator = GetComponent<Animator>();
            collider = GetComponent<Collider>();
        }

        protected override void DoAction()
        {
            animator.SetBool("isOpen", true);
            collider.enabled = false;
            audioSource.Play();
        }
    }
}

