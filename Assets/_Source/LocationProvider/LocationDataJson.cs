using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Source.LocationProvider
{
    [Serializable]
    public class LocationPoolData
    {
        public string PoolName;
        public TextAsset JsonFile;
    }

    [CreateAssetMenu(fileName = "LocationSettings", menuName = "Settings/Location Settings")]
    public class LocationSettings : ScriptableObject
    {
        public List<LocationPoolData> Pools;
    }
}