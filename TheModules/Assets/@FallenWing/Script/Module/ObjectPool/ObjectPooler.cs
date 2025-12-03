using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FallenWing.Core;

namespace FallenWing.Module.ObjectPooler
{
    public class ObjectPooler : BaseSingleton<ObjectPooler>
    {
        public Dictionary<string, Stack<IPoolableObject>> pools = new Dictionary<string, Stack<IPoolableObject>>();
        public Transform parentPool, guiParentPool;
        public bool isScalable;
        public int initPopulateCount;


        public T GetPoolableObject<T>(string _poolName, T _ref) where T : MonoBehaviour
        {
            if (pools.ContainsKey(_poolName))
            {
                if (pools[_poolName].Count > 0)
                {
                    //Debug.Log($"Get Obj On Pool {_poolName}");
                    pools[_poolName].Peek().ResetValue();
                    return (T)pools[_poolName].Pop();
                }
                else
                {
                    if (isScalable)
                    {
                        //Debug.Log($"Create New Obj On Pool {_poolName}");
                        T _newObject = Instantiate(_ref, parentPool);
                        return _newObject;
                    }
                }

            }
            else
            {
                Debug.Log($"Create Pool {_poolName}");
                Stack<IPoolableObject> _stacks = new Stack<IPoolableObject>();
                for (int i = 0; i < initPopulateCount; i++)
                {
                    T _newObject = Instantiate(_ref, parentPool);
                    _newObject.gameObject.SetActive(false);
                    _stacks.Push(_newObject.GetComponent<IPoolableObject>());
                }
                pools.Add(_poolName, _stacks);
                pools[_poolName].Peek().ResetValue();
                return (T)pools[_poolName].Pop();
            }
            return null;
        }

        /// <summary>
        /// Just to make sure and add clarity its on Canvas parent when pooled
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_poolName"></param>
        /// <param name="_ref"></param>
        /// <returns></returns>
        public T GetPoolableGUIObject<T>(string _poolName, T _ref) where T : MonoBehaviour
        {
            if (pools.ContainsKey(_poolName))
            {
                if (pools[_poolName].Count > 0)
                {
                    //Debug.Log($"Get Obj On Pool {_poolName}");
                    pools[_poolName].Peek().ResetValue();
                    return (T)pools[_poolName].Pop();
                }
                else
                {
                    if (isScalable)
                    {
                        //Debug.Log($"Create New Obj On Pool {_poolName}");
                        T _newObject = Instantiate(_ref, guiParentPool);
                        return _newObject;
                    }
                }

            }
            else
            {
                Debug.Log($"Create Pool {_poolName}");
                Stack<IPoolableObject> _stacks = new Stack<IPoolableObject>();
                for (int i = 0; i < initPopulateCount; i++)
                {
                    T _newObject = Instantiate(_ref, guiParentPool);
                    _newObject.gameObject.SetActive(false);
                    _stacks.Push(_newObject.GetComponent<IPoolableObject>());
                }
                pools.Add(_poolName, _stacks);
                pools[_poolName].Peek().ResetValue();
                return (T)pools[_poolName].Pop();
            }
            return null;
        }
        public void ReturnObj(string _poolName, IPoolableObject _ref)
        {
            _ref.ReturningToPool();
            _ref.TransformObj.SetParent(parentPool);
            if (pools.ContainsKey(_poolName))
            {
                pools[_poolName].Push(_ref);
            }
            else
            {
                Stack<IPoolableObject> _stacks = new Stack<IPoolableObject>();
                _stacks.Push(_ref);
                pools.Add(_poolName, _stacks);
            }
        }

        public void ReturnGUIObj(string _poolName, IPoolableObject _ref)
        {
            _ref.ReturningToPool();
            _ref.TransformObj.SetParent(guiParentPool);
            if (pools.ContainsKey(_poolName))
            {
                pools[_poolName].Push(_ref);
            }
            else
            {
                Stack<IPoolableObject> _stacks = new Stack<IPoolableObject>();
                _stacks.Push(_ref);
                pools.Add(_poolName, _stacks);
            }
        }
    }
}