
namespace Assets.Scripts.Services
{
    public class AssetsPaths: IService
    {
        const string _LOBBY_UI = "UI/UILobby";
        public string LOBBY_UI { get { return _LOBBY_UI; } }

        const string _GAME_UI = "UI/UIGame";
        public string GAME_UI { get { return _GAME_UI; } }
    }
}
