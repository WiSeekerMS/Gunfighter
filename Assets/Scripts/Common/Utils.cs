using UnityEditor;
using UnityEngine;

namespace Common
{
    public static class Utils
    {
        public static Sprite GetSpriteFromPath(string path)
        {
            var asset = AssetDatabase.LoadAssetAtPath<Texture2D>(path);
            if (asset != null)
            {
                return Sprite.Create(asset, new Rect(0.0f, 0.0f, asset.width, asset.height),
                    new Vector2(0.5f, 0.5f), 100.0f);
            }
            
            return null;
        }
    }
}