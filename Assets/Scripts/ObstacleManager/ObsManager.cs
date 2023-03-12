using UnityEngine;

namespace ObstacleManager
{
    public class ObsManager : MonoBehaviour
    {
        private readonly int[] _positionOffset = { -6, -4, -2, 0, 2, 4, 6 };
        
        [SerializeField] private GameObject Rock;
        
        private float pos = 0;

        private void Start()
        {
            for (int x = 0; x < _positionOffset.Length; x++)
            {
                SpawnObs(_positionOffset[x]);
            }
        }
        
        private void SpawnObs(int offset)
        {
            GameObject RockCopy = Instantiate(Rock, new Vector3( 0 + offset, 0, 0), Quaternion.identity);
        }
    }
}