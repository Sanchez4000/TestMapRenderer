using UnityEngine;
using Assets.Scripts.Map;

namespace Assets.Scripts.CameraControl
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] private float _zoomSensetivity = 1;
        [SerializeField] private float _minZoom = 2;
        [SerializeField] private float _maxZoom = 7;

        private CameraBorder _border;
        private float _cameraVerticalHalfSize = 0;
        private float _cameraHorizontalHalfSize = 0;

        private void Awake()
        {
            _cameraVerticalHalfSize = Camera.main.orthographicSize;
            _cameraHorizontalHalfSize = (float)Screen.width / (float)Screen.height * _cameraVerticalHalfSize;
        }
        private void Start()
        {
            InGameMap map = GameObject.FindObjectOfType<InGameMap>();
            _border.Set(0, map.Width, 0, -map.Height);

            if (_maxZoom * 2 > map.Height)
                _maxZoom = map.Height / 2;
        }

        private void PositionAdjustment()
        {
            Vector3 adjustmentPosition = transform.position;

            float x0 = adjustmentPosition.x - _cameraHorizontalHalfSize;
            float y0 = adjustmentPosition.y + _cameraVerticalHalfSize;

            float x1 = x0 + _cameraHorizontalHalfSize * 2;
            float y1 = y0 - _cameraVerticalHalfSize * 2;

            if (x0 < _border.Left)
            {
                adjustmentPosition.x = _border.Left + _cameraHorizontalHalfSize;
            }

            if (x1 > _border.Right)
            {
                adjustmentPosition.x = _border.Right - _cameraHorizontalHalfSize;
            }

            if (y0 > _border.Top)
            {
                adjustmentPosition.y = _border.Top - _cameraVerticalHalfSize;
            }

            if (y1 < _border.Bottom)
            {
                adjustmentPosition.y = _border.Bottom + _cameraVerticalHalfSize;
            }

            transform.position = adjustmentPosition;
        }

        public void Move(Vector2 movement)
        {
            Vector3 newPosition = new Vector3(transform.position.x + movement.x,
                                              transform.position.y + movement.y,
                                              transform.position.z);

            transform.position = newPosition;
            PositionAdjustment();
        }
        public void Zoom(float baseZoom)
        {
            float additional = baseZoom * _zoomSensetivity;
            float resultZoom = Camera.main.orthographicSize + additional;

            if (resultZoom < _minZoom)
                resultZoom = _minZoom;

            if (resultZoom > _maxZoom)
                resultZoom = _maxZoom;

            if (resultZoom != Camera.main.orthographicSize)
            {
                Camera.main.orthographicSize = resultZoom;
                _cameraVerticalHalfSize = Camera.main.orthographicSize;
                _cameraHorizontalHalfSize = (float)Screen.width / (float)Screen.height * _cameraVerticalHalfSize;
                PositionAdjustment();
            }
        }
    }
}