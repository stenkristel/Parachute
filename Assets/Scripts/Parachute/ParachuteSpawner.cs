using System.Collections;
using GameOver;
using Structs;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Parachute
{
    //Made by: Sten Kristel
    /// <summary>
    /// Spawns parachute on start and thereafter in a loop.
    /// Spawn delay will be randomly determined after every spawn using randomSpawnDelayParameters
    /// </summary>
    public class ParachuteSpawner : MonoBehaviour
    {
        [Tooltip("Will randomly spawn one of these, adding more of the same prefabs will increase it's spawn chances and reduce other prefabs spawn chances")]
        [SerializeField] private GameObject[] parachutePrefabs;                        //The prefab of the parachute
        [SerializeField] private MinAndMaxFloats randomSpawnDelayParameters;           //The minimum and maximum spawn delay in seconds 
        [SerializeField] private Transform parachuteSpawnPoint;                        //The spawn location of the parachute 

        /// <summary>
        /// Assigns events and starts the spawn loop on first frame
        /// </summary>
        private void Start()
        {
            AssignEvents();
            StartCoroutine(SpawnParachuteLoop());
        }
        
        private void OnDestroy() => UnAssignEvents();                                           //Unassigns events on destroy (prevents issues on scene changes)

        private void AssignEvents() => GameOverManager.Instance.OnGameOver += StopSpawnLoop;        //Assigns StopSpawnLoop on OnDefeat
        
        private void UnAssignEvents() => GameOverManager.Instance.OnGameOver -= StopSpawnLoop;      //Unassigns StopSpawnLoop on OnDefeat

        private void StopSpawnLoop() => StopAllCoroutines();                                    //Stops the spawn loop to prevent any spawning of new parachutes when the game has ended
        
        /// <summary>
        /// Waits for spawnDelayTime amount of seconds, then spawns a random parachute from the parachutePrefabs array,
        /// then determines the new spawnDelayTime and recalls itself.
        /// </summary>
        /// <param name="spawnDelayTime">The amount of time in seconds the Coroutine should wait until executing the rest of the code</param>
        /// <returns></returns>
        private IEnumerator SpawnParachuteLoop(float spawnDelayTime = 0)
        {
            yield return new WaitForSeconds(spawnDelayTime);
            int spawnIndex = Random.Range(0, parachutePrefabs.Length - 1);
            Instantiate(parachutePrefabs[spawnIndex], parachuteSpawnPoint.position, Quaternion.identity);
            
            var newSpawnDelayTime = Random.Range(randomSpawnDelayParameters.minValue, randomSpawnDelayParameters.maxValue);
            StartCoroutine(SpawnParachuteLoop(newSpawnDelayTime));
        }
    }
}
