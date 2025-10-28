using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scenes
{
    //Made by Sten Kristel
    /// <summary>
    /// Loads the scene specified by sceneToLoad
    /// </summary>
    public class SceneChange : MonoBehaviour
    {
        /// <summary>
        /// Load the scene sceneToLoad
        /// </summary>
        /// <param name="sceneToLoad">The scene to load</param>
        public void ChangeScene(int sceneToLoad)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
