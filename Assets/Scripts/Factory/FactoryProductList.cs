using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Factory
{
    [CreateAssetMenu(fileName = "FactoryProductList", menuName = "FactoryProductList", order = 51)]
    public class FactoryProductList : ScriptableObject
    {
        [SerializeField] private List<GameObject> _gameObjects;
        public List<GameObject> gameObjects => _gameObjects;
    }
}
