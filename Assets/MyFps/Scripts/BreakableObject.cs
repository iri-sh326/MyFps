using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    public class BreakableObject : MonoBehaviour, IDamageable
    {
        #region Variables
        public GameObject fakeObject;       // ������ ������Ʈ
        public GameObject breakObject;      // ������ ������Ʈ
        public GameObject effectObject;     // ������ ������Ʈ��
        public GameObject hiddenItem;       // ���� ������

        private bool isBreak = false;

        [SerializeField] private bool unBreakable = false;   // true : ������ �ʴ´�
        #endregion

        // ���� ������
        public void TakeDamage(float damage)
        {
            // 1 shot 1 kill
            if(!isBreak)
            {
                StartCoroutine(BreakObject());
            }
        }

        // ����ũ -> �극��ũ ������Ʈ
        IEnumerator BreakObject()
        {
            isBreak = true;
            this.GetComponent<BoxCollider>().enabled = false;

            fakeObject.SetActive(false);
            yield return new WaitForSeconds(0.1f);

            // ������ ���� ���
            AudioManager.Instance.Play("PotterySmash");
            breakObject.SetActive(true);

            if (effectObject != null)
            {
                effectObject.SetActive(true);

                yield return new WaitForSeconds(0.05f);
                effectObject.SetActive(false);
            }

            // ������ �������� ������ Ȱ��ȭ
            if(hiddenItem != null)
            {
                hiddenItem.SetActive(true);
            }
        }
    }
}

