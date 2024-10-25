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
        // ���� UI
        public GameObject puzzleUI;
        public Image itemImage;
        public TextMeshProUGUI puzzleText;

        public GameObject PuzzleItemGP;

        [SerializeField] private PuzzleKey puzzleKey;                // ȹ���� ����Ű
        public Sprite itemSprite;                                    // ȹ���� ������ ������
        [SerializeField] private string puzzleStr = "Puzzle Text";   // ������ ȹ�� �ȳ� �ؽ�Ʈ
        #endregion
        protected override void DoAction()
        {
            StartCoroutine(GainPuzzleItem());
        }

        IEnumerator GainPuzzleItem()
        {
            PlayerStats.Instance.AcquirePuzzleItem(puzzleKey);

            // ����
            if (puzzleUI != null)
            {
                // ������ Ʈ���� ��Ȱ��ȭ
                this.GetComponent<BoxCollider>().enabled = false;
                PuzzleItemGP.SetActive(false);

                puzzleUI.SetActive(true);
                itemImage.sprite = itemSprite;
                puzzleText.text = puzzleStr;

                yield return new WaitForSeconds(2f);
                puzzleUI.SetActive(false);
            }

            // ų
            Destroy(gameObject);

            yield return null;
        }
    }
}

