using UnityEngine;
using TMPro;
using Assets.Scripts.Map;

namespace Assets.Scripts.UI
{
    public class TextWriter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textField;

        private void OnEnable()
        {
            Vector3 topLeftPoint = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height - 1));
            InGameMap map = GameObject.FindObjectOfType<InGameMap>();
            foreach (Tile item in map.Tiles)
            {
                float xPos = item.transform.position.x;
                float yPos = item.transform.position.y;

                float width = item.Width;
                float height = item.Height;

                if (topLeftPoint.x > xPos && topLeftPoint.y < yPos &&
                    topLeftPoint.x < xPos + width && topLeftPoint.y > yPos - height) 
                {
                    _textField.text = item.name;
                    break;
                }
            }
        }
    }
}