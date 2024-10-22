using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    public class MainMenu : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;
        [SerializeField] private string loadToScene = "MainScene01";

        private AudioManager audioManager;
        #endregion

        private void Start()
        {
            // 씬 페이드 효과
            fader.FromFade();

            // 참조
            audioManager = AudioManager.Instance;

            // bgm
            audioManager.PlayBgm("MainBgm");
        }
        public void NewGame()
        {
            audioManager.Stop(audioManager.BgmSound);
            audioManager.Play("MenuButton");

            fader.FadeTo(loadToScene);
        }

        public void LoadGame()
        {
            Debug.Log("LoadGame");
        }


        public void Options()
        {
            audioManager.PlayBgm("PlayBgm");
            Debug.Log("Options");
        }

        public void Credits()
        {
            Debug.Log("Credits");
        }

        public void QuitGame()
        {
            Debug.Log("QuitGame");
            Application.Quit();
        }

    }
}

