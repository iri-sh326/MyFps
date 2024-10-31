using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

namespace MyFps
{
    public class MainMenu : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;
        [SerializeField] private string loadToScene = "MainScene01";

        private AudioManager audioManager;

        public GameObject mainMenuUI;
        public GameObject optionUI;
        public GameObject creditUI;

        // Audio
        public AudioMixer audioMixer;
        public Slider bgmSlider;
        public Slider sfxSlider;
        #endregion

        private void Start()
        {
            // 게임 옵션값 불러오기
            LoadOptions();

            // 씬 페이드 효과
            fader.FromFade();

            // 참조
            audioManager = AudioManager.Instance;

            // bgm
            //audioManager.PlayBgm("MenuBgm");
        }
        public void NewGame()
        {
            audioManager.Stop(audioManager.BgmSound);
            audioManager.Play("MenuButton");

            fader.FadeTo(loadToScene);
        }

        public void LoadGame()
        {
            audioManager.Play("MenuButton");
            Debug.Log("LoadGame");
        }


        public void Options()
        {
            audioManager.Play("MenuButton");
            ShowOptions();
        }

        public void Credits()
        {
            ShowCredits();
        }

        public void QuitGame()
        {
            Debug.Log("QuitGame");
            Application.Quit();
        }

        private void ShowOptions()
        {
            mainMenuUI.SetActive(false);
            optionUI.SetActive(true);
        }

        public void HideOptions()
        {
            // 옵션값 저장하기
            SaveOptions();

            optionUI.SetActive(false);
            mainMenuUI.SetActive(true);
        }

        // AudioMix Bgm -40 ~ 0
        public void SetBgmVolume(float value)
        {
            audioMixer.SetFloat("BgmVolume", value);
        }

        public void SetSfxVolume(float value)
        {
            audioMixer.SetFloat("SfxVolume", value);
        }

        // 옵션값 저장하기
        private void SaveOptions()
        {
            PlayerPrefs.SetFloat("BgmVolume", bgmSlider.value);
            PlayerPrefs.SetFloat("SfxVolume", sfxSlider.value);
        }

        // 옵션값 로드하기
        private void LoadOptions()
        {
            // 배경음 볼륨
            float bgmVolume = PlayerPrefs.GetFloat("BgmVolume", 0);
            SetBgmVolume(bgmVolume);        // 사운드 볼륨 조절
            bgmSlider.value = bgmVolume;    // UI 셋팅

            // 효과음 볼륨
            float sfxVolume = PlayerPrefs.GetFloat("SfxVolume", 0);
            SetSfxVolume(sfxVolume);        // 사운드 볼륨 조절
            sfxSlider.value = sfxVolume;    // UI 셋팅
        }

        private void ShowCredits()
        {
            mainMenuUI.SetActive(false);
            creditUI.SetActive(true);
        }

    }
}

