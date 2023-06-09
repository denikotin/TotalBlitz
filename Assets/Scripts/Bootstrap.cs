using Assets.Scripts.Services;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{

    [SerializeField] GameObject _lobbySceneManagerPrefab;

    public static Bootstrap Instance { get { return _instance; } }
    private static Bootstrap _instance = null;

    public static ServiceLocator ServiceLocator { get { return _serviceLocator; } }
    private static ServiceLocator _serviceLocator;

    private Factory _factory;

    private void Awake()
    {
        CreateSingleton();
        RegisterServices();
        GetServices();
    }

    private void Start() => RunGame();
    private void CreateSingleton()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (_instance == this)
        {
            Destroy(gameObject);
        }
    }
    private void RegisterServices()
    {
        _serviceLocator = new ServiceLocator();
        _serviceLocator.RegisterService<Factory>(new Factory());
        _serviceLocator.RegisterService<AssetsPaths>(new AssetsPaths());
        _serviceLocator.RegisterService<SceneLoader>(new SceneLoader());
        _serviceLocator.RegisterService<ScoreService>(new ScoreService());
        _serviceLocator.RegisterService<RecordService>(new RecordService());
        _serviceLocator.RegisterService<SaveLoadService>(new SaveLoadService());
    }
    private void GetServices() => _factory = _serviceLocator.GetService<Factory>();
    private void RunGame() => _factory.Create(_lobbySceneManagerPrefab);
}
