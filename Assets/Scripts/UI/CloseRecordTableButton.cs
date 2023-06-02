using UnityEngine;
using UnityEngine.UI;

public class CloseRecordTableButton : MonoBehaviour
{
    [SerializeField] Button _closeRecordTableButton;
    [SerializeField] GameObject _buttonContaniner;
    [SerializeField] GameObject _recordTable;

    private void Start() => _closeRecordTableButton.onClick.AddListener(CloseRecordTable);

    private void CloseRecordTable()
    {
        _buttonContaniner.SetActive(true);
        _recordTable.SetActive(false);
    }
}
