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
            // LEFTEYE ���� ������ ȹ��
            PlayerStats.Instance.AcquirePuzzleItem(PuzzleKey.LEFTEYE_KEY);

            // ų
            Destroy(gameObject);
        }
    }

}

