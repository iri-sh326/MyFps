using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    public class FExitTriegger : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;
        [SerializeField] private string loadToScene = "MainMenu";
        #endregion
        private void OnTriggerEnter(Collider other)
        {
            PlaySequence();
        }

        void PlaySequence()
        {
            // �� Ŭ���� ó��
            // ����� ����
            AudioManager.Instance.StopBgm();

            // �� Ŭ���� ����, ������ ó��
            //...

            // ���� �޴��� �̵�
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            fader.FadeTo(loadToScene);
        }
    }
}

