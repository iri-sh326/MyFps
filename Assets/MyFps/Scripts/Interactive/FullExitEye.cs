using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MyFps
{
    public class FullExitEye : Interactive
    {
        #region Variables
        public GameObject emptyPicture;
        public GameObject fullPicture;

        public Animator exitWallAnimator;
        public GameObject exitTrigger;

        public TextMeshProUGUI textBox;
        [SerializeField] private string puzzleStr = "You need more puzzle pieces";
        #endregion

        protected override void DoAction()
        {
            // ���� ������ ��� �������
            if (PlayerStats.Instance.HasPuzzleItem(PuzzleKey.LEFTEYE_KEY)
                && PlayerStats.Instance.HasPuzzleItem(PuzzleKey.RIGHTEYE_KEY))
            {
                // �ⱸ ����
                StartCoroutine(OpenExitWall());
            }
            else
            {
                // �޼��� ���
                StartCoroutine(LockedExitWall());
            }
        }

        IEnumerator OpenExitWall()
        {
            // �ϼ��� �׸� ���̱�
            emptyPicture.SetActive(false);
            fullPicture.SetActive(true);

            exitWallAnimator.SetBool("IsOpen", true);
            yield return null;

            // exit Ʈ���� Ȱ��ȭ
            exitTrigger.SetActive(true);
        }

        IEnumerator LockedExitWall()
        {
            textBox.gameObject.SetActive(true);
            textBox.text = puzzleStr;

            yield return new WaitForSeconds(2f);
        }
    }
}

