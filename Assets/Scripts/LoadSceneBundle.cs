using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadSceneBundle : MonoBehaviour
{
    [Tooltip("Path to the asset bundle.")]
    static AssetBundle assetBundle;

    public void InitScene(string filename)
    {
        StartCoroutine("LoadScene", filename);
    }

    IEnumerator LoadScene(string filename)
    {
        //download assetbundle
        WWW downloadedAssetBundle = WWW.LoadFromCacheOrDownload(new System.Uri(Path.Combine(Application.streamingAssetsPath, filename)).AbsoluteUri, 1);
        yield return downloadedAssetBundle;
        if (!string.IsNullOrEmpty(downloadedAssetBundle.error)) {
            Debug.Log("" + downloadedAssetBundle.error);
            yield break;
        } 

        assetBundle = downloadedAssetBundle.assetBundle;

        if (assetBundle.isStreamedSceneAssetBundle)
        {
            string[] scenePaths = assetBundle.GetAllScenePaths();
            string sceneName = Path.GetFileNameWithoutExtension(scenePaths[0]);
            yield return SceneManager.LoadSceneAsync(sceneName);

        }
       
    }
    private void OnDestroy()
    {
        assetBundle.Unload(false);
    }
}