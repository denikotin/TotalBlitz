using UnityEngine;
using UnityEngine.UI;

public class OpenRecordTableButton : MonoBehaviour
{
    [SerializeField] Button _openRecordTableButton;
    [SerializeField] GameObject _buttonContaniner;
    [SerializeField] GameObject _recordTable;
    private ShowRecords _showRecords;  

    private void Start()
    {
        _openRecordTableButton.onClick.AddListener(OpenRecordTable);
        _showRecords = _recordTable.GetComponent<ShowRecords>();
    }

    private void OpenRecordTable()
    {
        _recordTable.SetActive(true);
        _showRecords.CreateRecords();
        _buttonContaniner.SetActive(false);
    }
}
