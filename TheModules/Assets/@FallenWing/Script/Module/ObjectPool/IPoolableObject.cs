using UnityEngine;
namespace FallenWing.Module.ObjectPooler
{
    public interface IPoolableObject
    {
        public string KeyPool { get; }
        public GameObject GameObjectPool { get; }
        public Transform TransformObj { get; }
        public void ResetValue();
        public void ReturningToPool();
    }
}