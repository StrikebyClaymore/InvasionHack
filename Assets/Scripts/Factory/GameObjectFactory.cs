using UnityEngine;

namespace Assets.Scripts.Factory
{
    public abstract class GameObjectFactory : ScriptableObject
    {
        private Transform _transform;
        public Transform transform
        {
            get => _transform;
            set => _transform = value;
        }
        [SerializeField] protected FactoryProductList productList;

        protected T Get<T>(int i) where T : MonoBehaviour => productList.gameObjects[i].GetComponent<T>();

        protected T CreateGameObjectInstance<T>(T prefab) where T : MonoBehaviour
        {
            var instance = Instantiate(prefab, _transform);
            //SceneManager.MoveGameObjectToScene(instance.gameObject, scene);
            return instance;

        }
    }
}
