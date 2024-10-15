using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    public class CEnemyTrigger : MonoBehaviour
    {
        #region Variables
        public GameObject theDoor;  // ��
        public AudioSource doorBang;    // �� ����

        public AudioSource jumpScare;   // �� ���� ����
        public GameObject theRobot;     // ��
        #endregion
        private void OnTriggerEnter(Collider other)
        {
            StartCoroutine(PlaySequence());
        }

        // Ʈ���� �۵��� �÷���
        IEnumerator PlaySequence()
        {
            // �� ����
            theDoor.GetComponent<Animator>().SetBool("isOpen", true);
            theDoor.GetComponent<BoxCollider>().enabled = false;

            // �� ����
            doorBang.Play();

            // Enemy Ȱ��ȭ
            theRobot.SetActive(true);

            yield return new WaitForSeconds(1f);

            // Enemy ���� ����
            jumpScare.Play();

            // Ʈ���� ų
            Destroy(this.gameObject);
        }
    }
}

