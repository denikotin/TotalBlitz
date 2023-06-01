using System;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Services
{
    public class SceneLoader:IService
    {
        public void Load(string sceneName, Action onLoaded = null)
        {
            SceneManager.LoadScene(sceneName); 
            onLoaded?.Invoke(); 
        }
    }
}
