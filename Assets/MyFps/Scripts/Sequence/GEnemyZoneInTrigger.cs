using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    public class GEnemyZoneInTrigger : MonoBehaviour
    {
        #region Variables
        public Transform gunMan;
        public GameObject enemyZoneOut; // Out Ʈ����
        #endregion
        private void OnTriggerEnter(Collider other)
        {
            // �Ǹ� �߰� ����
            if(other.tag == "Player")
            {
                if(gunMan != null)
                {
                    gunMan.GetComponent<Enemy>().SetState(EnemyState.E_Chase);
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            // �Ǹ� �߰� ����
            if (other.tag == "Player")
            {
                this.gameObject.SetActive(false);
                enemyZoneOut.SetActive(true);
            }
        }
    }
}
