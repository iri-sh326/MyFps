using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    public class PickupAmmo : PickupItem
    {
        #region Variables
        [SerializeField] private int giveAmount = 7;
        #endregion

        protected override bool OnPickup()
        {
            // źȯ 7�� ����
            PlayerStats.Instance.AddAmmo(7);

            return true;
        }
    }
}

