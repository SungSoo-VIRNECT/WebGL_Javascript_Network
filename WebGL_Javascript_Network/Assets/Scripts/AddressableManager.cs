using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AddressableManager : MonoBehaviour
{
    [SerializeField]
    private AssetReference m_assetRef;
    [SerializeField]
    private AssetReference m_scene;
    private GameObject m_loadedObject;
    public Button switchScene;

    private void Start()
    {
        LoadObject();
        switchScene.onClick.AddListener(SwitchScene);
    }

    private void LoadObject()
    {
        AsyncOperationHandle<GameObject> handle = m_assetRef.LoadAssetAsync<GameObject>();
        handle.Completed += OnObjectLoaded;
    }

    private void OnObjectLoaded(AsyncOperationHandle<GameObject> handle)
    {
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            m_loadedObject = handle.Result;
            Instantiate(m_loadedObject);
            Transform objectTransform = m_loadedObject.transform;

            // Use DOTween to move the object
            objectTransform.DOMove(new Vector3(2, 0, 0), 1f);
        }
    }

    public void SwitchScene()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        // Load the scene asynchronously
        AsyncOperationHandle<SceneInstance> handle = Addressables.LoadSceneAsync(m_scene, UnityEngine.SceneManagement.LoadSceneMode.Single);
        // When the scene has finished loading, unload the previous scene
        handle.Completed += (operation) =>
        {
            //Addressables.UnloadSceneAsync(UnityEngine.SceneManagement.SceneManager.GetActiveScene().handle);
        };
    }
}

