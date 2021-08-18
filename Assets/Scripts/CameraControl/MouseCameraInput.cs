using UnityEngine;

namespace Assets.Scripts.CameraControl
{
    public class MouseCameraInput : MonoBehaviour
    {
        public static MouseCameraInput Instance { get; private set; }

        [SerializeField] private Camera _mainCamera;
        [SerializeField] private CameraMovement _cameraMovement;

        private Vector2 _lastFrameCursorPosition = Vector2.zero;

        private void Update()
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                Vector2 cursorPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
                Vector2 deltaPosition = cursorPosition - _lastFrameCursorPosition;
                deltaPosition *= -1;
                _cameraMovement.Move(deltaPosition);
            }

            _cameraMovement.Zoom(-Input.GetAxis(Axis.MouseScrollWheel));

            _lastFrameCursorPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}