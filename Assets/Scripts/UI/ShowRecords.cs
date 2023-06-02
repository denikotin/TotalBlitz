using Assets.Scripts.Data.PlayerData;
using Assets.Scripts.Services;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowRecords : MonoBehaviour
{
    [SerializeField] GameObject _recordLine;

    private RecordService _recordService;
    private Factory _factory;

    private void Start()
    {
        _recordService = Bootstrap.ServiceLocator.GetService<RecordService>(); 
        _factory = Bootstrap.ServiceLocator.GetService<Factory>();
    }

    private void OnEnable()
    {
        CreateRecords();
    }

    private void CreateRecords()
    {
        List<Record> records = _recordService.GetRecords();


        for (int i=0; i < records.Count; i++)
        {
            GameObject recordLine = _factory.Create(_recordLine);
            TextMeshProUGUI lineNumber = recordLine.GetComponent<RecordLine>().Number;
            TextMeshProUGUI lineText =   recordLine.GetComponent<RecordLine>().Text;
            lineNumber.text = (i + 1).ToString();
            lineText.text = ($"{records[i]} монет");
         }
    }
}
