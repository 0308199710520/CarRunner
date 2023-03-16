using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using Debug = System.Diagnostics.Debug;
using Random = System.Random;

namespace ObstacleManager
{
    public class ObsManager : MonoBehaviour
    {
        private float _lastSpawnDelta = 0f;
        private ObstacleServer _obsServer;
        
        [SerializeField, Range(0.01f, 1f)]private float delayDelta = 0.5f; // To be removed once speed is implimented
        
        [SerializeField] private int[] _positionOffset = { -6, -4, -2, 0, 2, 4, 6 };

        
        [SerializeField] private GameObject Rock;


        private List<GameObject> spawnedObs = new List<GameObject>();
        
        
        private void Awake()
        {
            _obsServer = GetComponent<ObstacleServer>();
        }

        private void Update()
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
                SpawnObs(_positionOffset[RandomNumberGenerator.GetInt32(0, 8)], Obs.Rock);
            }
            else _lastSpawnDelta += Time.deltaTime;
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
                    newObject = Instantiate(Rock, new Vector3( 0 + offset, 0, 0), Quaternion.identity);
                    break;
            }

            spawnedObs.Add(newObject);
        }
        
    }
}