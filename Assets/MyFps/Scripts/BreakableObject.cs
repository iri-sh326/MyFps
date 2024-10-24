using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    public class BreakableObject : MonoBehaviour, IDamageable
    {
        #region Variables
        public GameObject fakeObject;       // 온전한 오브젝트
        public GameObject breakObject;      // 깨지는 오브젝트
        public GameObject effectObject;     // 깨지는 오브젝트용
        public GameObject hiddenItem;       // 히든 아이템

        private bool isBreak = false;

        [SerializeField] private bool unBreakable = false;   // true : 깨지지 않는다
        #endregion

        // 총을 맞으면
        public void TakeDamage(float damage)
        {
            // 1 shot 1 kill
            if(!isBreak)
            {
                StartCoroutine(BreakObject());
            }
        }

        // 페이크 -> 브레이크 오브젝트
        IEnumerator BreakObject()
        {
            isBreak = true;
            this.GetComponent<BoxCollider>().enabled = false;

            fakeObject.SetActive(false);
            yield return new WaitForSeconds(0.1f);

            // 깨지는 사운드 재생
            AudioManager.Instance.Play("PotterySmash");
            breakObject.SetActive(true);

            if (effectObject != null)
            {
                effectObject.SetActive(true);

                yield return new WaitForSeconds(0.05f);
                effectObject.SetActive(false);
            }

            // 숨겨진 아이템이 있으면 활성화
            if(hiddenItem != null)
            {
                hiddenItem.SetActive(true);
            }
        }
    }
}

