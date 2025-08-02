using UnityEditor;
using UnityEngine;
using System.IO;

public class LudoWordoStructureGenerator : EditorWindow
{
    [MenuItem("Tools/Generate LudoWordo Structure")]
    public static void GenerateStructure()
    {
        string basePath = Application.dataPath + "/_Project";

        CreateFolders(new string[]
        {
            "_Project",
            "_Project/Scripts/Core/Managers",
            "_Project/Scripts/Core/Systems",
            "_Project/Scripts/Core/Utilities",
            "_Project/Scripts/UI/Screens",
            "_Project/Scripts/UI/Components",
            "_Project/Scripts/UI/Animations",
            "_Project/Scripts/Game/Board",
            "_Project/Scripts/Game/Tokens",
            "_Project/Scripts/Game/Words",
            "_Project/Scripts/Game/Dice",
            "_Project/Scripts/Data/Models",
            "_Project/Scripts/Data/ScriptableObjects",
            "_Project/Scripts/Data/Configurations",
            "_Project/Scripts/Networking",
            "_Project/Prefabs/UI",
            "_Project/Prefabs/Game",
            "_Project/Prefabs/Effects",
            "_Project/Sprites/UI/Backgrounds",
            "_Project/Sprites/UI/Buttons",
            "_Project/Sprites/UI/Icons",
            "_Project/Sprites/UI/Logo",
            "_Project/Sprites/Game",
            "_Project/Sprites/Textures",
            "_Project/Audio/Music",
            "_Project/Audio/SFX",
            "_Project/Audio/UI",
            "_Project/Fonts",
            "_Project/Materials",
            "_Project/Shaders",
            "_Project/Resources",
        });

        CreateFolders(new string[]
        {
            "Settings",
            "StreamingAssets",
            "TextMeshPro"
        });

        // Generate template script files
        CreateTemplateScript("Core/Managers", "UIManager");
        CreateTemplateScript("Core/Managers", "GameManager");
        CreateTemplateScript("Core/Managers", "NetworkManager");
        CreateTemplateScript("Core/Managers", "AudioManager");
        CreateTemplateScript("Core/Managers", "EconomyManager");
        CreateTemplateScript("Core/Managers", "SessionManager");
        CreateTemplateScript("Core/Managers", "ReconnectionManager");

        CreateTemplateScript("Core/Systems", "PerformanceSystem");
        CreateTemplateScript("Core/Systems", "PlatformSystem");
        CreateTemplateScript("Core/Systems", "GraphicsSystem");

        CreateTemplateScript("Core/Utilities", "Singleton");
        CreateTemplateScript("Core/Utilities", "EventBus");
        CreateTemplateScript("Core/Utilities", "Extensions");

        CreateTemplateScript("UI/Screens", "SplashScreen");
        CreateTemplateScript("UI/Screens", "LoadingScreen");
        CreateTemplateScript("UI/Screens", "MainMenuScreen");
        CreateTemplateScript("UI/Screens", "GameModeScreen");
        CreateTemplateScript("UI/Screens", "EntryFeeScreen");
        CreateTemplateScript("UI/Screens", "MatchmakingScreen");
        CreateTemplateScript("UI/Screens", "GameplayScreen");
        CreateTemplateScript("UI/Screens", "ResultScreen");

        CreateTemplateScript("UI/Components", "CustomButton");
        CreateTemplateScript("UI/Components", "LoadingBar");
        CreateTemplateScript("UI/Components", "CoinDisplay");
        CreateTemplateScript("UI/Components", "SafeAreaHandler");

        CreateTemplateScript("UI/Animations", "UIAnimator");
        CreateTemplateScript("UI/Animations", "PanelTransition");
        CreateTemplateScript("UI/Animations", "ButtonAnimator");

        CreateTemplateScript("Data/Models", "GameData");
        CreateTemplateScript("Data/Models", "PlayerData");
        CreateTemplateScript("Data/Models", "MatchData");
        CreateTemplateScript("Data/Models", "UserData");

        CreateTemplateScript("Data/ScriptableObjects", "GameSettings");
        CreateTemplateScript("Data/ScriptableObjects", "UITheme");
        CreateTemplateScript("Data/ScriptableObjects", "PerformanceSettings");

        CreateTemplateScript("Data/Configurations", "GraphicsConfig");
        CreateTemplateScript("Data/Configurations", "NetworkConfig");
        CreateTemplateScript("Data/Configurations", "PlatformConfig");

        CreateTemplateScript("Networking", "NakamaClient");
        CreateTemplateScript("Networking", "WebSocketHandler");
        CreateTemplateScript("Networking", "APIManager");

        AssetDatabase.Refresh();
        Debug.Log("LudoWordo structure generated successfully!");
    }

    private static void CreateFolders(string[] paths)
    {
        foreach (var path in paths)
        {
            string fullPath = Path.Combine(Application.dataPath, path);
            if (!Directory.Exists(fullPath))
                Directory.CreateDirectory(fullPath);
        }
    }

    private static void CreateTemplateScript(string subfolder, string className)
    {
        string scriptPath = Path.Combine(Application.dataPath, "_Project/Scripts", subfolder, className + ".cs");
        if (File.Exists(scriptPath)) return;

        string content =
$@"using UnityEngine;

namespace LudoWordo.{subfolder.Replace("/", ".")}
{{
    public class {className} : MonoBehaviour
    {{
        void Start()
        {{
            // TODO: Implement {className}
        }}
    }}
}}";
        File.WriteAllText(scriptPath, content);
    }
}