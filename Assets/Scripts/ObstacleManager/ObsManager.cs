using System;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;

namespace ObstacleManager
{
    public class ObsManager : MonoBehaviour
    {
        private float _lastSpawnDelta = 0f;
        [SerializeField, Range(0.1f, 5f)]private float delayDelta = 0.5f; // To be removed once speed is implimented
        
        private readonly int[] _positionOffset = { -6, -4, -2, 0, 2, 4, 6 };

        private ObstacleServer _obsServer;
        
        [SerializeField] private GameObject Rock;

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
                SpawnObs(RandomNumberGenerator.GetInt32(0, 8), Obs.Rock);
            }
            else _lastSpawnDelta += Time.deltaTime;
        }

        private void SpawnObs(int offset, Obs obs)
        {
            switch (obs)
            {
                case Obs.Null:
                    return;
                
                case Obs.Rock:
                    GameObject RockCopy = Instantiate(Rock, new Vector3( 0 + offset, 0, 0), Quaternion.identity);
                    break;
            }
        }
    }
}