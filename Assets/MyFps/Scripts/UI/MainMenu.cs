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
            // ���� �ɼǰ� �ҷ�����
            LoadOptions();

            // �� ���̵� ȿ��
            fader.FromFade();

            // ����
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
            // �ɼǰ� �����ϱ�
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

        // �ɼǰ� �����ϱ�
        private void SaveOptions()
        {
            PlayerPrefs.SetFloat("BgmVolume", bgmSlider.value);
            PlayerPrefs.SetFloat("SfxVolume", sfxSlider.value);
        }

        // �ɼǰ� �ε��ϱ�
        private void LoadOptions()
        {
            // ����� ����
            float bgmVolume = PlayerPrefs.GetFloat("BgmVolume", 0);
            SetBgmVolume(bgmVolume);        // ���� ���� ����
            bgmSlider.value = bgmVolume;    // UI ����

            // ȿ���� ����
            float sfxVolume = PlayerPrefs.GetFloat("SfxVolume", 0);
            SetSfxVolume(sfxVolume);        // ���� ���� ����
            sfxSlider.value = sfxVolume;    // UI ����
        }

        private void ShowCredits()
        {
            mainMenuUI.SetActive(false);
            creditUI.SetActive(true);
        }

    }
}

