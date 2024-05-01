using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Crogen.ObjectPooling
{
    public class PoolManager : MonoBehaviour
    {
        internal static Dictionary<string, Queue<GameObject>> poolDic = new Dictionary<string, Queue<GameObject>>();
        public PoolBase poolBase;
        public List<PoolPair> poolingPairs;

#if UNITY_EDITOR
        private void Reset()
        {
            transform.position = Vector3.zero;
        }  
#endif

        public void Awake()
        {
            PopCore.Init(poolBase, this);
            PushCore.Init(this);
            
            MakeObj();
        }
        
        private void MakeObj()
        {
            PoolPair[] poolingPairs = poolBase.pairs.ToArray();
            for (int i = 0; i < poolingPairs.Length; i++)
            {
                poolDic.Add(poolingPairs[i].poolType.ToString(), new Queue<GameObject>());
            }

	    	for (int i = 0; i < poolingPairs.Length; i++)
	    	{
                for (int j = 0; j < poolingPairs[i].poolCount; j++)
                {
                    GameObject poolObject = CreateObject(poolBase.pairs[i], Vector3.zero, Quaternion.identity);
                    poolObject.Push(poolingPairs[i].poolType);
	    		}
            }
        }

        public static GameObject CreateObject(PoolPair poolPair, Vector3 vec, Quaternion rot)
        {
            GameObject poolObject = Instantiate(poolPair.prefab);
            poolObject.transform.localPosition = vec;
            poolObject.transform.localRotation = rot;
            poolObject.name = poolObject.name.Replace("(Clone)","");

            return poolObject;
        }
    }
}
