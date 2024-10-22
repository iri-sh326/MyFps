using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MySample
{
    public class MoveTest : MonoBehaviour
    {
        #region Variables
        private Rigidbody rb;

        [SerializeField] private float forwardForce = 5;    // ������ �̴� ��
        [SerializeField] private float sideForce = 5f;      // �¿�� �̴� ��

        private float dx;   // �¿� �Է°�
        #endregion

        private void Start()
        {
            // ����
            rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            dx = Input.GetAxis("Horizontal");
        }

        private void FixedUpdate()
        {
            // ������ �̵�
            rb.AddForce(0f, 0f, forwardForce, ForceMode.Acceleration);

            if(dx < 0f)
            {
                rb.AddForce(-sideForce, 0f, 0f, ForceMode.Acceleration);
            }
            if(dx > 0f)
            {
                rb.AddForce(sideForce, 0f, 0f, ForceMode.Acceleration);
            }
        }
    }
}

