using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MyFps
{
    public class PickupPuzzleItem : Interactive
    {
        #region Variables
        // ∆€¡Ò UI
        public GameObject puzzleUI;
        public Image itemImage;
        public TextMeshProUGUI puzzleText;

        public GameObject PuzzleItemGP;

        [SerializeField] private PuzzleKey puzzleKey;                // »πµÊ«— ∆€¡Ò≈∞
        public Sprite itemSprite;                                    // »πµÊ«— æ∆¿Ã≈€ æ∆¿Ãƒ‹
        [SerializeField] private string puzzleStr = "Puzzle Text";   // æ∆¿Ã≈€ »πµÊ æ»≥ª ≈ÿΩ∫∆Æ
        #endregion
        protected override void DoAction()
        {
            StartCoroutine(GainPuzzleItem());
        }

        IEnumerator GainPuzzleItem()
        {
            PlayerStats.Instance.AcquirePuzzleItem(puzzleKey);

            // ø¨√‚
            if (puzzleUI != null)
            {
                // æ∆¿Ã≈€ ∆Æ∏Æ∞≈ ∫Ò»∞º∫»≠
                this.GetComponent<BoxCollider>().enabled = false;
                PuzzleItemGP.SetActive(false);

                puzzleUI.SetActive(true);
                itemImage.sprite = itemSprite;
                puzzleText.text = puzzleStr;

                yield return new WaitForSeconds(2f);
                puzzleUI.SetActive(false);
            }

            // ≈≥
            Destroy(gameObject);

            yield return null;
        }
    }
}

