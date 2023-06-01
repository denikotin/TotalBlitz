
namespace Assets.Scripts.Services
{
    public class AssetsPaths: IService
    {
        const string _LOBBY_UI = "UI/UILobby";
        public string LOBBY_UI { get { return _LOBBY_UI; } }

        const string _MAIN_MENU_UI = "UI/UIMainMenu";
        public string MAIN_MENU_UI { get { return MAIN_MENU_UI; } }
    }
}
