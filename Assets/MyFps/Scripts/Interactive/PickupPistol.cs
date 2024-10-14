using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MyFps
{
    public class PickupPistol : Interactive
    {
        #region Variables
        // action
        public GameObject realPistol;
        public GameObject arrow;

        public GameObject enemyTrigger;
        #endregion

   

        protected override void DoAction()
        {
            realPistol.SetActive(true);
            arrow.SetActive(false);

            enemyTrigger.SetActive(true);

            Destroy(gameObject);
        }
    }
}

