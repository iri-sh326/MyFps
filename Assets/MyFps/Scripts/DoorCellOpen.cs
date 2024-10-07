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

        // ���콺�� �������� �׼� UI�� �����ش�
        private void OnMouseOver()
        {
            // �Ÿ��� 2���� �϶�
            if(theDistance < 2f)
            {
                actionUI.SetActive(true);
                actionText.text = action;

                if (Input.GetButtonDown("Action"))
                {
                    HideActionUI();

                    // ���� ������ �׼�
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

        // ���콺�� ����� �׼� UI�� �����
        private void OnMouseExit()
        {
            actionUI.SetActive(false);
            //actionText.text = "";
        }

        void HideActionUI()
        {
            actionUI.SetActive(false);
            actionText.text = "";
        }
    }
}

