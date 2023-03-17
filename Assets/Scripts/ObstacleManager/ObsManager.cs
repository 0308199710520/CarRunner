using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ObstacleManager
{
    public class ObsManager : MonoBehaviour
    {
        [SerializeField] private float boundsDistance = -10f;
        [SerializeField] [Range(0.01f, 100f)] private float speed = 1f;
        [SerializeField] [Range(0.01f, 1f)] private float delayDelta = 0.5f; // To be removed once speed is implemented

        [SerializeField] private GameObject rock;
        private readonly List<GameObject> _markedForDeath = new();
        private readonly int[] _positionOffset = { -6, -4, -2, 0, 2, 4, 6 };

        private readonly List<GameObject> _spawnedObs = new();
        private float _lastSpawnDelta;

        private void Update()
        {
            Spawn();
            UpdatePositions();
            BoundsCheck();
        }

        private void LateUpdate()
        {
            CleanupSpawnedObject();
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
                SpawnObs(_positionOffset[Random.Range(0, _positionOffset.Length)],
                    Obs.Rock); // only rock prefab is being used for now
                _lastSpawnDelta = 0;
            }
            else
            {
                _lastSpawnDelta += Time.deltaTime;
            }
        }

        private void BoundsCheck()
        {
            foreach (var obs in _spawnedObs)
                if (obs.transform.position.z < boundsDistance)
                    MarkedForDeath(obs);
        }

        public void MarkedForDeath(GameObject obs)
        {
            if (_markedForDeath.Contains(obs))
                return; // Guard check to makes sure game objects can only be marked for death once
            _markedForDeath.Add(obs);
        }

        private void CleanupSpawnedObject()
        {
            foreach (var obj in _markedForDeath)
            {
                _spawnedObs.Remove(obj);
                Destroy(obj);
            }

            _markedForDeath.Clear();
        }

        private void UpdatePositions()
        {
            foreach (var obs in _spawnedObs) obs.transform.position += Vector3.back * (speed * Time.deltaTime);
        }

        private void SpawnObs(int offset, Obs obs)
        {
            GameObject newObject = null;
            //Instantiate Object
            switch (obs)
            {
                // Use factories in future to avoid this jank GetComponent System create unique procedural objects in the future.
                case Obs.Null:
                    return;
                case Obs.Air:
                    return;
                case Obs.Rock:
                {
                    newObject = Instantiate(rock, new Vector3(0 + offset, 0, 0), Quaternion.identity);
                    newObject.GetComponent<Rock>().SetObsManager(this);
                    break;
                }
                case Obs.Crate:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(obs), obs, null);
            }

            if (_spawnedObs != null) _spawnedObs.Add(newObject);
        }
    }
}