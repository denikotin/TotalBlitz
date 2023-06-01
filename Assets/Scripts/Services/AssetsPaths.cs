
namespace Assets.Scripts.Services
{
    public class AssetsPaths: IService
    {
        public string LOBBY_UI { get { return "UI/UILobby"; } private set { } }
        public string GAME_UI { get { return "UI/UIGame"; } private set { } }
        public string MAZE_SPAWNER { get { return "Spawners/MazeSpawner"; } private set { } }
        public string PLAYER { get { return "Characters/Player/Player"; } private set { } }
        public string ENEMY { get { return "Characters/Enemies/Enemy"; } private set { } }
    }
}
