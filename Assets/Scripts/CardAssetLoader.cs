using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class CardAssetLoader : MonoBehaviour
{
    [Header("AssetBundle")]
    [SerializeField] string bundleName;
    [SerializeField] string bundleVariant;

    Sprite assetPics, assetName;
    string[] assetText;

    void Awake()
    {
        StartCoroutine(LoadAsset());
    }

    IEnumerator LoadAsset()
    {
        string targetPath = $"Card/{(string.IsNullOrEmpty(bundleVariant) ? bundleName : $"{bundleName}.{bundleVariant}")}";
        string url = Path.Combine(Application.streamingAssetsPath, targetPath);

        UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(url);
        yield return request.SendWebRequest();
        AssetBundle remoteAssetBundle = DownloadHandlerAssetBundle.GetContent(request);
        TextAsset assetReader = remoteAssetBundle.LoadAsset<TextAsset>("AboutUs.txt");

        if (remoteAssetBundle == null)
        {
            Debug.LogError("Failed to download AssetBundle!");
            yield break;
        }

        string[] reader = assetReader.text.Split('\n');
        assetPics = remoteAssetBundle.LoadAsset<Sprite>("ProfilePic");
        assetName = remoteAssetBundle.LoadAsset<Sprite>("ProfileName");
        assetText = new string[reader.Length];

        for (int i = 0; i < reader.Length; i++)
        {
            string[] split = reader[i].Split('=');
            assetText[i] = split[split.Length - 1];
        }

        remoteAssetBundle.Unload(false);
    }

    public Sprite GetFacePic()
    {
        return assetPics;
    }

    public Sprite GetNamePic()
    {
        return assetName;
    }

    public string GetPhoneNumber()
    {
        return assetText[0];
    }

    public string GetWebsite()
    {
        return assetText[1];
    }

    public string GetEmail()
    {
        return assetText[2];
    }

    //[Header("AssetBundles")]
    //[SerializeField] string bundleName;
    //[SerializeField] string bundleVariant;

    //Sprite assetPics, assetName;
    //string[] assetText;

    //// Awake is called when loaded
    //void Awake()
    //{
    //    string targetPath = $"Card/{(string.IsNullOrEmpty(bundleVariant) ? bundleName : $"{bundleName}.{bundleVariant}")}";
    //    AssetBundle localAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, targetPath));
    //    TextAsset assetReader = localAssetBundle.LoadAsset<TextAsset>("AboutUs.txt");

    //    if (localAssetBundle == null)
    //    {
    //        Debug.LogError("Fail to load AssetBundle!");
    //        return;
    //    }

    //    string[] reader = assetReader.text.Split('\n');
    //    assetPics = localAssetBundle.LoadAsset<Sprite>("ProfilePic");
    //    assetName = localAssetBundle.LoadAsset<Sprite>("ProfileName");
    //    assetText = new string[reader.Length];

    //    for (int i = 0; i < reader.Length; i++)
    //    {
    //        string[] split = reader[i].Split('=');
    //        assetText[i] = split[split.Length - 1];
    //    }

    //    localAssetBundle.Unload(false);
    //}

    //public Sprite GetFacePic()
    //{
    //    return assetPics;
    //}

    //public Sprite GetNamePic()
    //{
    //    return assetName;
    //}

    //public string GetPhoneNumber()
    //{
    //    return assetText[0];
    //}

    //public string GetWebsite()
    //{
    //    return assetText[1];
    //}

    //public string GetEmail()
    //{
    //    return assetText[2];
    //}
}
