using Assets.Scripts.Logic.Camera;
using UnityEngine;

namespace Assets.Scripts.Logic
{
    public class PlayerInputService : MonoBehaviour
    {
        [SerializeField] CameraController _cameraController;
        [SerializeField] MoveController _moveController;


        public void Update()
        {
            if (Input.GetKey(KeyCode.W))
            {
                _moveController.MoveForward();
            }
            else if (Input.GetKey(KeyCode.S))
            {
                _moveController.MoveBackward();
            }
            else
            {
                _moveController.Stop();
            }
           
            if (Input.GetKey(KeyCode.A))
            {
                _moveController.MoveSideways(-1);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                _moveController.MoveSideways(1);
            }

            if (Input.GetKey(KeyCode.E))
            {
                _moveController.Turn(1);
            }
            else if (Input.GetKey(KeyCode.Q))
            {
                _moveController.Turn(-1);
            }
        }
    }
}
