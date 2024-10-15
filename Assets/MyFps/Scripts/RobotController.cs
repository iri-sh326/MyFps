using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    // �κ� ����
    public enum RobotState
    {
        R_Idle,
        R_Walk,
        R_Attack,
        R_Death
    }
    public class RobotController : MonoBehaviour
    {
        #region Variables
        private Animator animator;

        // �κ� ���� ����
        private RobotState currentState;
        // �κ� ���� ����
        private RobotState beforeState;

        // ü��
        [SerializeField] private float startHealth = 20;
        #endregion

        private void Start()
        {
            // ����
            animator = GetComponent<Animator>();
            SetState(RobotState.R_Idle);
        }

        // �κ��� ���� ����
        private void SetState(RobotState newState)
        {
            // ���� ���� üũ
            if (currentState == newState)
                return;
            
            // ���� ���� ����
            beforeState = currentState;
            // ���� ����
            currentState = newState;

            // ���� ���濡 ���� ���� ����
            animator.SetInteger("RobotState", (int)newState);
        }
    }
}

