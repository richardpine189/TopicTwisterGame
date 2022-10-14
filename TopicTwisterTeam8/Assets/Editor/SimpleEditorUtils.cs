using UnityEditor;
using UnityEditor.SceneManagement;

namespace Team8.TopicTwister
{
    [InitializeOnLoad]
    public class SimpleEditorUtils
    {
        [MenuItem("Edit/Play-Unplay, But From Prelaunch Scene %0")]
        public static void PlayFromPrelaunchScene()
        {
            if (EditorApplication.isPlaying == true)
            {
                EditorApplication.isPlaying = false;
                return;
            }
            EditorApplication.isPlaying = true;

            EditorSceneManager.OpenScene("Assets/Scenes/MainScene.unity");
        }

    }
}
