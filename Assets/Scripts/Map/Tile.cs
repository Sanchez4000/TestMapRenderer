using UnityEngine;

namespace Assets.Scripts.Map
{
    public class Tile : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;

        public float Width { get; set; }
        public float Height { get; set; }

        public void SetSprite(Sprite newSprite)
        {
            _spriteRenderer.sprite = newSprite;
        }
    }
}