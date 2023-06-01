using UnityEngine;
using UnityEngine.UI;

public class OpenRecordTableButton : MonoBehaviour
{
    [SerializeField] Button _openRecordTableButton;
    [SerializeField] GameObject _buttonContaniner;
    [SerializeField] GameObject _recordTable;

    private void Start() => _openRecordTableButton.onClick.AddListener(OpenRecordTable);

    private void OpenRecordTable()
    {
        _recordTable.SetActive(true);
        _buttonContaniner.SetActive(false);
    }
}
