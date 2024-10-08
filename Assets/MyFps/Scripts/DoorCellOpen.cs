using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace MyFps
{
    public class DoorCellOpen : MonoBehaviour
    {
        #region Variables
        // action UI
        public GameObject actionUI;
        public TextMeshProUGUI actionText;
        [SerializeField] private string action = "Open the door";
        public GameObject extraCross;

        private float theDistance;

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

        private void Update()
        {
            theDistance = PlayerCasting.distanceFromTarget;
        }

        // 마우스를 가져가면 액션 UI를 보여준다
        private void OnMouseOver()
        {
            // 거리가 2이하 일때
            if(theDistance < 2f)
            {
                ShowActionUI();

                if (Input.GetButtonDown("Action"))
                {
                    HideActionUI();

                    // 문이 열리는 액션
                    animator.SetBool("isOpen", true);
                    collider.enabled = false;
                    audioSource.Play();

                }
            }
            else
            {
                HideActionUI();
            }
        }

        // 마우스가 벗어나면 액션 UI를 감춘다
        private void OnMouseExit()
        {
            actionUI.SetActive(false);
            //actionText.text = "";
        }

        void ShowActionUI()
        {
            actionUI.SetActive(true);
            actionText.text = action;
            extraCross.SetActive(true);
        }

        void HideActionUI()
        {
            actionUI.SetActive(false);
            actionText.text = "";
            extraCross.SetActive(false);
        }
    }
}

