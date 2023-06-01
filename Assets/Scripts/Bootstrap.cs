using Assets.Scripts.Logic;
using Assets.Scripts.Services;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{

    [SerializeField] GameObject _lobbySceneManagerPrefab;
    [SerializeField] GameObject _gameSceneManagerPrefab;

    private static Bootstrap _instance = null;
    public static Bootstrap Instance { get { return _instance; } }

    private static ServiceLocator _serviceLocator;
    public static ServiceLocator ServiceLocator { get { return _serviceLocator; } }

    private Factory _factory;
    private SceneLoader _sceneLoader;

    private void Awake()
    {
        CreateSingleton();
        RegisterServices();
        GetServices();
    }

    private void Start()
    {
        RunGame();
    }

    private void RunGame()
    {
        GameObject lobbySceneManagerGO = _factory.Create(_lobbySceneManagerPrefab);
        lobbySceneManagerGO.GetComponent<LobbySceneManager>().Construct(_serviceLocator, _gameSceneManagerPrefab);
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
    private void RegisterServices()
    {
        _serviceLocator = new ServiceLocator();

        _serviceLocator.RegisterService<Factory>(new Factory());
        _serviceLocator.RegisterService<AssetsPaths>(new AssetsPaths());
        _serviceLocator.RegisterService<SceneLoader>(new SceneLoader());
    }
    private void GetServices()
    {
        _factory = _serviceLocator.GetService<Factory>();
        _sceneLoader = _serviceLocator.GetService<SceneLoader>();
    }
}
