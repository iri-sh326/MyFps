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
            // 퍼즐 조각을 모두 모았으면
            if (PlayerStats.Instance.HasPuzzleItem(PuzzleKey.LEFTEYE_KEY)
                && PlayerStats.Instance.HasPuzzleItem(PuzzleKey.RIGHTEYE_KEY))
            {
                // 출구 열기
                StartCoroutine(OpenExitWall());
            }
            else
            {
                // 메세지 출력
                StartCoroutine(LockedExitWall());
            }
        }

        IEnumerator OpenExitWall()
        {
            // 완성본 그림 보이기
            emptyPicture.SetActive(false);
            fullPicture.SetActive(true);

            exitWallAnimator.SetBool("IsOpen", true);
            yield return null;

            // exit 트리거 활성화
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

