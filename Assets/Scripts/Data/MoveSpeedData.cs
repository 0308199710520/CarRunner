using Unity.Entities;


namespace Data
{
    [GenerateAuthoringComponent]
    public struct MoveSpeedData : IComponentData
    {
        public float Speed;
    }
}
