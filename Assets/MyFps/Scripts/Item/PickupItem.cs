using System.Collections;
using System.Collections.Generic;
using System.Security;
using UnityEngine;

namespace MyFps
{
    public class PickupItem : MonoBehaviour
    {
        #region Variables
        [SerializeField] private float verticalBobrequency = 1f;    // 이동 속도
        [SerializeField] private float bobingAmount = 1f;           // 이동 범위
        [SerializeField] private float rotateSpeed = 360f;          // 회전 속도

        private Vector3 startPosition;
        #endregion

        private void Start()
        {
            // 처음 위치
            startPosition = transform.position;
        }

        private void Update()
        {
            // 위 아래 흔들림
            float bobingAnimationPhase = Mathf.Sin(Time.time * verticalBobrequency) * bobingAmount;
            transform.position = startPosition + Vector3.up * bobingAnimationPhase;

            // 회전
            transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime, Space.World);
        }

        // 충돌 체크
        private void OnTriggerEnter(Collider other)
        {
            // 플레이어 체크
            if (other.tag == "Player")
            {
                // 아이템 획득
                if(OnPickup() == true)
                {
                    // 킬
                    Destroy(gameObject);
                }
            }

        }

        // 아이템 획득 성공, 실패 반환
        protected virtual bool OnPickup()
        {
            // 아이템 획득
            //Debug.Log("아이템 획득");

            // 탄환 7개 지급
            // hp, mp 아이템 etc...

            return true;
        }
    }

}
