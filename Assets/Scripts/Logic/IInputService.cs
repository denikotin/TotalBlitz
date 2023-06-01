using UnityEngine;

namespace Assets.Scripts.Logic
{
    public interface IInputService
    {
        public Axis GetDirection();

        public Quaternion GetRotation();
    }
}
