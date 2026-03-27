using UnityEngine;

namespace GameOver
{
    //Made by: Sten Kristel
    /// <summary>
    /// Turns on dark effect mesh renderer on game over
    /// </summary>
    public class DarkEffectBehaviour : MonoBehaviour
    {
        [SerializeField] private new MeshRenderer renderer;             //Dark effect mesh renderer
        private void Start() => GameOverManager.Instance.OnGameOver += EnableDarkEffect;        //Adds EnableDarkEffect to GameOver event

        private void OnDestroy() => GameOverManager.Instance.OnGameOver -= EnableDarkEffect;    //removes EnableDarkEffect to GameOver event on destroy to avoid issues

        /// <summary>
        /// Turns on dark effect mesh renderer
        /// </summary>
        private void EnableDarkEffect()
        {
            renderer.enabled = true;
        }
    }
}
