using UnityEngine;


namespace JevLogin
{
    public static partial class BuilderExtentions
    {
        #region Methods

        public static GameObject AddSprite(this GameObject gameObject, Sprite sprite)
        {
            var component = gameObject.GetOrAddComponent<SpriteRenderer>();
            component.sprite = sprite;
            return gameObject;
        }

        public static GameObject AddRigidbody2D(this GameObject gameObject)
        {
            gameObject.GetOrAddComponent<Rigidbody2D>();
            return gameObject;
        }

        public static GameObject AddCircleCollider2D(this GameObject gameObject)
        {
            gameObject.GetOrAddComponent<CircleCollider2D>();
            return gameObject;
        }



        public static GameObject AddTrailRenderer<T>(this GameObject gameObject, T data)
        {
            var componentInChildren = gameObject.GetComponentInChildren<TrailRenderer>();
            if (componentInChildren)
            {
                return gameObject;
            }
            var lineRendererGameObject = new GameObject("TrailRenderer");
            if (data is PlayerData playerData)
            {
                lineRendererGameObject.transform.position = playerData.PlayerSettingsData.OffsetVectorTrailrenderer;
            }
            var lineRenderer = lineRendererGameObject.GetOrAddComponent<TrailRenderer>();
            TrailRendererConfig(data, lineRenderer);

            lineRendererGameObject.transform.SetParent(gameObject.transform);

            return gameObject;
        }

        public static GameObject AddChildrenTransform(this GameObject gameObject, string name)
        {
            var transformObject = new GameObject(name).transform;
            transformObject.SetParent(gameObject.transform);

            return gameObject;
        }

        private static void TrailRendererConfig<T>(T _data, TrailRenderer lineRenderer)
        {
            if (_data is PlayerData playerData)
            {
                lineRenderer.startWidth = playerData.PlayerSettingsData.StartWidth;
                lineRenderer.endWidth = playerData.PlayerSettingsData.EndWidth;
                lineRenderer.time = playerData.PlayerSettingsData.Time;
                lineRenderer.material = playerData.PlayerSettingsData.MaterialTrailRenderer;
                lineRenderer.startColor = playerData.PlayerSettingsData.StartColor;
                lineRenderer.endColor = playerData.PlayerSettingsData.EndColor;
            }
        }



        private static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            var result = gameObject.GetComponent<T>();
            if (!result)
            {
                result = gameObject.AddComponent<T>();
            }
            return result;
        }

        #endregion
    }
}
