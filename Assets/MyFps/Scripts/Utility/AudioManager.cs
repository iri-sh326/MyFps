using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace MyFps
{
    // ������� �����ϴ� Ŭ����
    public class AudioManager : PersistentSingleton<AudioManager>
    {
        #region Variables
        public Sound[] sounds;

        private string bgmSound = "";       // ���� ��� ���� BGM �̸�
        public string BgmSound
        {
            get { return bgmSound; }
            set { bgmSound = value; }
        }
        #endregion

        protected override void Awake()
        {
            // Singleton ������
            base.Awake();

            // AudioManager �ʱ�ȭ
            foreach(var sound in sounds)
            {
                sound.source = this.gameObject.AddComponent<AudioSource>();

                sound.source.clip = sound.clip;
                sound.source.volume = sound.volume;
                sound.source.pitch = sound.pitch;
                sound.source.loop = sound.loop;

                sound.source.Play();
            }
        }

        public void Play(string name)
        {
            Sound sound = null;

            // �Ű����� �̸��� ���� Ŭ�� ã��
            foreach(var s in sounds)
            {
                if(s.name == name)
                {
                    sound = s;

                    //
                    if(s.name == bgmSound)
                    {
                        bgmSound = "";
                    }
                    break;
                }
            }

            // �Ű����� �̸��� ���� Ŭ���� ������
            if(sound == null)
            {
                Debug.Log($"Cannot Find {name}");
                return;
            }

            sound.source.Play();
        }

        public void Stop(string name)
        {
            Sound sound = null;

            // �Ű����� �̸��� ���� Ŭ�� ã��
            foreach (var s in sounds)
            {
                if (s.name == name)
                {
                    sound = s;
                    break;
                }
            }

            // �Ű����� �̸��� ���� Ŭ���� ������
            if (sound == null)
            {
                Debug.Log($"Cannot Find {name}");
                return;
            }

            sound.source.Stop();
        }

        // ����� ���
        public void PlayBgm(string name)
        {
            // ����� �̸� üũ
            if(bgmSound == name)
            {
                return;
            }

            // ����� ����
            Stop(bgmSound);

            Sound sound = null;

            foreach(var s in sounds)
            {
                sound = s;
                break;
            }
        }
    }
}

