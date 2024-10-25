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

        public GameObject activityObject;   // ����� ������Ʈ
        #endregion

        private void OnTriggerEnter(Collider other)
        {
            StartCoroutine(PlaySequence());
        }

        IEnumerator PlaySequence()
        {
            // �÷��̾� ��Ȱ��ȭ
            thePlayer.GetComponent<FirstPersonController>().enabled = false;
            activityObject.SetActive(true);

            yield return new WaitForSeconds(2f);

            // �÷��̾� Ȱ��ȭ
            thePlayer.GetComponent<FirstPersonController>().enabled = true;

            // ����� ������Ʈ
            Destroy(activityObject);

            // Ʈ���� �浹ü ��Ȱ��ȭ - ų
            Destroy(gameObject);

        }
    }
}

