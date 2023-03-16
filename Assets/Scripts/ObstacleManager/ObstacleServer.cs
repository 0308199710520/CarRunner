using System;
using System.Collections.Generic;
using UnityEngine;

namespace ObstacleManager
{
    public class ObstacleServer : MonoBehaviour
    {
        private List<Obs> CurrentRow = new List<Obs>(){
            Obs.Rock, Obs.Rock, Obs.Rock, Obs.Rock, Obs.Rock, Obs.Rock,
            Obs.Rock };

        public List<Obs> Next()
        {
            return CurrentRow;
        }
    }

    public enum Obs
    {
        Null,
        Air,
        Rock,
        Crate,
    }

}
/*public class ObstactleServer
{
    private Queue<ObstacleElement> _ElementStack = new Queue<ObstacleElement>();
    
    public ObstacleElement GetNextObstacle()
    {
        return _ElementStack.Dequeue();
    }

    public ObstacleElement ReadObstacle()
    {
        return _ElementStack.Peek();
    }
}


public struct ObstacleElement
{
    public BaseObs obs;
    public float delay;
    
    public ObstacleElement(BaseObs obstacle, float delay)
    {
        this.obs = obstacle;
        this.delay = delay;
    }
}
}*/