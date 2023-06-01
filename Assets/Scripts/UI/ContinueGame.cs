using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class ContinueGame:MonoBehaviour
    {
        [SerializeField] GameObject _mainMenu;
        [SerializeField] Button _continueButton;

        public void Awake() => _continueButton.onClick.AddListener(Pause);
        public void Pause()
        {
            Time.timeScale = 1f;
            _mainMenu.SetActive(false);
        }
    }
}
