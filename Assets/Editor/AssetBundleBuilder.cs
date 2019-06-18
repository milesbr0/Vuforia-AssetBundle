using UnityEditor;

public class BundleBuilder : Editor
{
    [MenuItem("Assets/Build AssetBundles")]
    static void BuildAllAssetBundles()
    {
        BuildPipeline.BuildAssetBundles(@"Assets\StreamingAssets", //output location
            BuildAssetBundleOptions.ChunkBasedCompression,
            BuildTarget.Android //OS buildtarget
            );
    }
}
