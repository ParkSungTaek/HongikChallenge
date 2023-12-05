using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ResourceManager
{
    /// <summary> 로드한 적 있는 object cache </summary>
    Dictionary<string, Object> _cache = new Dictionary<string, Object>();
    /// <summary>
    /// Resources.Load로 불러오기
    /// </summary>
    /// <typeparam name="T"> 타입 </typeparam>
    /// <param name="path"> 경로 </param>
    /// <param name="caching"> 캐싱 여부 </param>
    /// <returns></returns>
    public T Load<T>(string path, bool caching = true) where T : Object
    {

        Object obj;
        //캐시에 존재 -> 캐시에서 반환
        if (_cache.TryGetValue(path, out obj))
            return obj as T;

        //캐시에 없음 -> 로드하여 캐시에 저장 후 반환
        obj = Resources.Load<T>(path);
#if UNITY_EDITOR
        if (obj == null)
            Debug.LogError($"NULL {path}확인 바람 ");
#endif

        if (caching)
        {
            _cache.Add(path, obj);
        }

        return obj as T;

    }

    /// <summary> GameObject 생성 </summary>
    public GameObject Instantiate(string path, Transform parent = null) => Instantiate<GameObject>(path, parent);
    /// <summary> T type object 생성 </summary>
    public T Instantiate<T>(string path, Transform parent = null) where T : UnityEngine.Object
    {
        T prefab = Load<T>($"Prefabs/{path}");
        if (prefab == null)
        {
            Debug.LogError($"Failed to load prefab : {path}");
            return null;
        }

        T instance = UnityEngine.Object.Instantiate<T>(prefab, parent);

        instance.name = prefab.name;

        return instance;
    }

    /// <summary>
    /// Cache 초기화 (맵 이동, 메모리 초과 상황)
    /// </summary>
    public void Clear()
    {
        _cache.Clear();
    }
}