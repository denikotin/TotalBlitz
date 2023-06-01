using Assets.Scripts.Logic.Camera;
using UnityEngine;

namespace Assets.Scripts.Logic
{
    public class PlayerInputService : IInputService
    {
        private Axis _axis = new Axis();
        private CameraController _cameraController;

        public PlayerInputService(CameraController cameraController)
        {
            _cameraController = cameraController;
        }


        public Axis GetDirection()
        {
            float xAxis = Input.GetAxisRaw("Horizontal");
            float zAxis = Input.GetAxisRaw("Vertical");
            _axis.xAxis = xAxis;
            _axis.zAxis = zAxis;
            return _axis;
        }

        public Quaternion GetRotation() => _cameraController.PlanarRotation;
    }
}
