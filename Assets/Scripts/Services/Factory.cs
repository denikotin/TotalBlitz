using UnityEngine;

namespace Assets.Scripts.Services
{
    public class Factory: IService
    {
        public GameObject Create(string path)
        {
                GameObject prefab = Resources.Load<GameObject>(path);
                GameObject gameObject = Object.Instantiate(prefab);
                return gameObject;
        }
    }
}
