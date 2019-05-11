using UnityEngine;

public class SingletonManager<T> : MonoBehaviour where T : Component {

    static T instance;

    public static T Instance {
        get {
            if (instance == null) {
                instance = FindObjectOfType<T>();
                if (instance == null) {
                    GameObject obj = new GameObject();
                    obj.name = typeof(T).Name;
                    instance = obj.AddComponent<T>();
                }
            }
            return instance;
        }
    }

    public virtual void Awake() {
        if (instance == null) {
            instance = this as T;
        }
        else {
            Destroy(gameObject);
        }
    }
}

