using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Rendering;
using Unity.Mathematics;
public class ObstacleSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] private Mesh 
    void Start()
    {
        MakeEntity();
    }

    private void MakeEntity()
    {
        EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

        EntityArchetype archetype = entityManager.CreateArchetype(typeof(Translation),
            typeof(Rotation),
            typeof(RenderMesh),
            typeof(RenderBounds),
            typeof(LocalToWorld)
        );
        
        entityManager.CreateEntity(archetype);
    }
}
