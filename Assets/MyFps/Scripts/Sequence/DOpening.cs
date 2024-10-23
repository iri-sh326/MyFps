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
            // 플레이어 비활성화
            thePlayer.GetComponent<FirstPersonController>().enabled = false;

            // 배경음 시작
            AudioManager.Instance.PlayBgm("PlayBgm");

            // 시퀀스 텍스트 초기화
            textBox.text = "";

            // 1초 후 페이드인 효과 시작
            yield return new WaitForSeconds(1f);
            fader.FromFade();

            // 플레이어 활성화
            yield return new WaitForSeconds(1f);
            thePlayer.GetComponent<FirstPersonController>().enabled = true;
        }
    }
}

