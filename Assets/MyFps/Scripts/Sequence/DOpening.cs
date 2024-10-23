using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using StarterAssets;

namespace MyFps
{
    public class DOpening : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;

        public GameObject thePlayer;
        public TextMeshProUGUI textBox;
        #endregion

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            StartCoroutine(SequencePlay());
        }

        IEnumerator SequencePlay()
        {
            // �÷��̾� ��Ȱ��ȭ
            thePlayer.GetComponent<FirstPersonController>().enabled = false;

            // ����� ����
            AudioManager.Instance.PlayBgm("PlayBgm");

            // ������ �ؽ�Ʈ �ʱ�ȭ
            textBox.text = "";

            // 1�� �� ���̵��� ȿ�� ����
            yield return new WaitForSeconds(1f);
            fader.FromFade();

            // �÷��̾� Ȱ��ȭ
            yield return new WaitForSeconds(1f);
            thePlayer.GetComponent<FirstPersonController>().enabled = true;
        }
    }
}

