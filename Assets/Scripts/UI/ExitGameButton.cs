using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class ExitGameButton:MonoBehaviour
    {
        [SerializeField] Button _exitGameButton;

        private void Start()
        {
            _exitGameButton.onClick.AddListener(ExitGame);
        }

        private void ExitGame()
        {
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#endif

            Application.Quit();
        }
    }
}
