using System;
using UnityEngine;

namespace Assets.Scripts.CameraControl
{
    [Serializable] public struct CameraBorder
    {
        [SerializeField] private float _left;
        [SerializeField] private float _right;
        [SerializeField] private float _bottom;
        [SerializeField] private float _top;

        public float Left => _left;
        public float Right => _right;
        public float Bottom => _bottom;
        public float Top => _top;

        public void Set(float left, float right, float top, float bottom)
        {
            _left = left;
            _right = right;
            _top = top;
            _bottom = bottom;
        }
    }
}