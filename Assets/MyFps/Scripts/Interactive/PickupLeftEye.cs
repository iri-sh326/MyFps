using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MyFps
{
    public class PickupLeftEye : Interactive
    {
        #region Variables
        // 퍼즐 UI
        public GameObject puzzleUI;
        public Image itemImage;
        public TextMeshProUGUI puzzleText;

        public GameObject PuzzleItemGP;

        public Sprite itemSprite;                                    // 획득한 아이템 아이콘
        [SerializeField] private string puzzleStr = "Puzzle Text";   // 아이템 획득 안내 텍스트
        #endregion

        protected override void DoAction()
        {
            StartCoroutine(GainPuzzleItem());
        }

        IEnumerator GainPuzzleItem()
        {

            // LEFTEYE_KEY 획득 여부 저장
            PlayerStats.Instance.AcquirePuzzleItem(PuzzleKey.LEFTEYE_KEY);

            // 연출
            if(puzzleUI != null)
            {
                // 아이템 트리거 비활성화
                this.GetComponent<BoxCollider>().enabled = false;
                PuzzleItemGP.SetActive(false);

                puzzleUI.SetActive(true);
                itemImage.sprite = itemSprite;
                puzzleText.text = puzzleStr;

                yield return new WaitForSeconds(2f);
                puzzleUI.SetActive(false);
            }

            // 킬
            Destroy(gameObject);
        }
    }
}

