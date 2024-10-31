using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    public class CreditUI : MonoBehaviour
    {
        #region Variables
        public GameObject mainMenuUI;
        #endregion

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                HideCredits();
            }
        }

        private void HideCredits()
        {
            mainMenuUI.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}

