using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace ObstacleManager
{
    public class ObsManager : MonoBehaviour
    {
        private float _lastSpawnDelta = 0f;
        private ObstacleServer _obsServer;
        [SerializeField, Range(0.01f, 1f)] private float _speed = 1f;
        [SerializeField, Range(0.01f, 1f)] private float delayDelta = 0.5f; // To be removed once speed is implimented
        
        [SerializeField] private int[] _positionOffset = { -6, -4, -2, 0, 2, 4, 6 };

        
        [SerializeField] private GameObject Rock;


        private List<GameObject> spawnedObs = new List<GameObject>();
        
        
        private void Awake()
        {
            _obsServer = GetComponent<ObstacleServer>();
        }

        private void Update()
        {
            Spawn();
            UpdatePositions();
        }

        private void Spawn()
        {
            if (_lastSpawnDelta >= delayDelta)
            {
                /*
                 * This system is going to be completely reworked, data will be read in groups of 7 from
                 * the obs server
                 *
                 * Randomly placing them is completely arbitrary at the moment.
                 * 
                 */
                SpawnObs(_positionOffset[Random.Range(0, 8)], Obs.Rock); // only rock prefab is being used for now
            }
            else _lastSpawnDelta += Time.deltaTime;
        }

        private void UpdatePositions()
        {
            foreach (var obs in spawnedObs)
            {
                obs.transform.position += Vector3.back * _speed * Time.deltaTime;
            }
        }
        
        private void SpawnObs(int offset, Obs obs)
        {
            GameObject newObject = null;
            //Instantiate Object
            switch (obs)
            {
                // Potentially use factories to create unique procedural objects in the future.
                case Obs.Null:
                    return;
                case Obs.Air:
                    return;
                case Obs.Rock:
                    newObject = Instantiate(Rock, new Vector3(0 + offset, 0, 0), Quaternion.identity);
                    break;
            }

            spawnedObs?.Add(newObject);
        }
    }
}