using Assets.Scripts.Services;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{

    private static Bootstrap _instance = null;
    public static Bootstrap Instance { get { return _instance; } }

    private static ServiceLocator _serviceLocator;
    public static ServiceLocator ServiceLocator { get { return _serviceLocator; } }

    private Factory _factory;
    private AssetsPaths _assetsPaths;

    private void Awake()
    {
        CreateSingleton();
        CreateServices();
        GetServices();
    }

    private void Start()
    {
        ConstructLobbyUI();
    }

    private void CreateSingleton()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance == this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    private void CreateServices()
    {
        _serviceLocator = new ServiceLocator();

        _serviceLocator.RegisterService<Factory>(new Factory());
        _serviceLocator.RegisterService<AssetsPaths>(new AssetsPaths());
    }
    private void GetServices()
    {
        _factory = _serviceLocator.GetService<Factory>();
        _assetsPaths = _serviceLocator.GetService<AssetsPaths>();
    }

    private void ConstructLobbyUI()
    {
        _factory.Create(_assetsPaths.LOBBY_UI);
    }
}
