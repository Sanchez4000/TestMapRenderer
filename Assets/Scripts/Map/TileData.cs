using System;

namespace Assets.Scripts.Map
{
    [Serializable] public struct TileData
    {
        public string Id;
        public string Type;
        public float X;
        public float Y;
        public float Width;
        public float Height;
    }
}