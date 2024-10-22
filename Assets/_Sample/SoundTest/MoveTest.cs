using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MySample
{
    public class MoveTest : MonoBehaviour
    {
        #region Variables
        private Rigidbody rb;

        [SerializeField] private float forwardForce = 5;    // 앞으로 미는 힘
        [SerializeField] private float sideForce = 5f;      // 좌우로 미는 힘

        private float dx;   // 좌우 입력값
        #endregion

        private void Start()
        {
            // 참조
            rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            dx = Input.GetAxis("Horizontal");
        }

        private void FixedUpdate()
        {
            // 앞으로 이동
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

