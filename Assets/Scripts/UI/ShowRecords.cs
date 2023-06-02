using Assets.Scripts.Data.PlayerData;
using Assets.Scripts.Services;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowRecords : MonoBehaviour
{
    [SerializeField] GameObject _recordLine;
    [SerializeField] GameObject _recordsContainer;

    private RecordService _recordService;
    private Factory _factory;

    private void Awake()
    {
        _recordService = Bootstrap.ServiceLocator.GetService<RecordService>(); 
        _factory = Bootstrap.ServiceLocator.GetService<Factory>();
    }

    public void CreateRecords()
    {
        List<Record> records = _recordService.GetRecord().Records;


        for (int i=0; i < records.Count; i++)
        {
            GameObject recordLine = _factory.Create(_recordLine);
            recordLine.transform.SetParent(_recordsContainer.transform);
            TextMeshProUGUI lineNumber = recordLine.GetComponent<RecordLine>().Number;
            TextMeshProUGUI lineText =   recordLine.GetComponent<RecordLine>().Text;
            lineNumber.text = (i + 1).ToString();
            lineText.text = ($"{records[i].Value} монет");
         }
    }
}
