using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Map
{
    public class InGameMap : MonoBehaviour
    {
        [SerializeField] private Tile _tilePrefab;
        [SerializeField] private MapData _mapData;

        private List<Tile> _tiles = new List<Tile>();
        private float _width = 0;
        private float _height = 0;

        public float Width => _width;
        public float Height => _height;
        public List<Tile> Tiles => _tiles;

        private void Awake()
        {
            List<TileData> _allTileData = _mapData.GetMapTiles();

            foreach (TileData data in _allTileData)
            {
                Tile instance = Instantiate(_tilePrefab);
                instance.transform.parent = transform;
                instance.name = data.Id;
                instance.transform.position = new Vector3(data.X, data.Y);
                instance.Width = data.Width;
                instance.Height = data.Height;
                instance.SetSprite(_mapData.GetSpriteOfId(data.Id));

                _tiles.Add(instance);
            }

            CalculateWidth();
            CalculateHeight();
        }

        private void CalculateWidth()
        {
            float yStatic = 0;

            foreach (Tile item in _tiles)
            {
                if (item.transform.position.y == yStatic)
                {
                    _width += item.Width;
                }
            }
        }
        private void CalculateHeight()
        {
            float xStatic = 0;

            foreach (Tile item in _tiles)
            {
                if (item.transform.position.x == xStatic)
                {
                    _height += item.Height;
                }
            }
        }
    }
}