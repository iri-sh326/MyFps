using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    public class EJumpTrigger : MonoBehaviour
    {
        #region Variables
        public GameObject thePlayer;

        public GameObject activityObject;   // 연출용 오브젝트
        #endregion

        private void OnTriggerEnter(Collider other)
        {
            StartCoroutine(PlaySequence());
        }

        IEnumerator PlaySequence()
        {
            // 플레이어 비활성화
            thePlayer.GetComponent<FirstPersonController>().enabled = false;
            activityObject.SetActive(true);

            yield return new WaitForSeconds(2f);

            // 플레이어 활성화
            thePlayer.GetComponent<FirstPersonController>().enabled = true;

            // 연출용 오브젝트
            Destroy(activityObject);

            // 트리거 충돌체 비활성화 - 킬
            Destroy(gameObject);

        }
    }
}

