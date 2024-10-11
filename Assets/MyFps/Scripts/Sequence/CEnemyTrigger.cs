using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    public class CEnemyTrigger : MonoBehaviour
    {
        #region Variables
        public GameObject theDoor;
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

            yield return null;
        }
    }
}

