using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    public class PickupKey : Interactive
    {
        #region Variables
        #endregion

        protected override void DoAction()
        {
            // LEFTEYE ∆€¡Ò æ∆¿Ã≈€ »πµÊ
            PlayerStats.Instance.AcquirePuzzleItem(PuzzleKey.LEFTEYE_KEY);

            // ≈≥
            Destroy(gameObject);
        }
    }

}

