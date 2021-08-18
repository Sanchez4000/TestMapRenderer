using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Map
{
    [CreateAssetMenu(fileName = "NewMapData", menuName = "Game Data/Map Data")]
    public class MapData : ScriptableObject
    {
        [SerializeField] private List<Sprite> _sprites;
        [SerializeField] private TextAsset _jsonData;

        public Sprite GetSpriteOfId(string id)
        {
            foreach (Sprite item in _sprites)
            {
                if (item.name == id)
                    return item;
            }

            return null;
        }

        public List<TileData> GetMapTiles()
        {
            string data = _jsonData.text;
            return JSONReader.ReadMapDataFromJson(data);
        }
    }
}