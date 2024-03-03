using System.Collections;
using BepInEx;

namespace EditorOnStartup;

[BepInPlugin("com.enchart.editoronstartup", "EditorOnStartup", "1.0.0.0")]
public class Plugin : BaseUnityPlugin
{
    private void Awake()
    {
        Logger.LogInfo("Plugin EditorOnStartup is loaded!");
        StartCoroutine(LoadEditorScene());
    }

    private static IEnumerator LoadEditorScene()
    {
        while (DataManager.inst == null || InputDataManager.inst == null)
            yield return null;
        DataManager.inst.UpdateSettingBool("HasPlayedIntro", true);
        DataManager.inst.UpdateSettingBool("CanEdit", true);
        InputDataManager.inst.players.Clear();
        InputDataManager.inst.players.Add(new InputDataManager.CustomPlayer(true, 0));
        UnityEngine.SceneManagement.SceneManager.LoadScene("editor");
    }
}