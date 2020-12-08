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

        public static GameObject AddCircleCollider2D(this GameObject gameObject)
        {
            gameObject.GetOrAddComponent<CircleCollider2D>();
            return gameObject;
        }

        public static GameObject AddTrailRenderer<T>(this GameObject gameObject, T _data)
        {

            var componentInChildren = gameObject.GetComponentInChildren<TrailRenderer>();
            if (componentInChildren)
            {
                return gameObject;
            }
            var lineRendererGameObject = new GameObject("TrailRenderer");
            var lineRenderer = lineRendererGameObject.GetOrAddComponent<TrailRenderer>();
            TrailRendererConfig(_data, lineRenderer);

            lineRendererGameObject.transform.SetParent(gameObject.transform);

            return gameObject;
        }

        private static void TrailRendererConfig<T>(T _data, TrailRenderer lineRenderer)
        {
            if (_data is PlayerData playerData)
            {
                lineRenderer.startWidth = playerData.StartWidth;
                lineRenderer.endWidth = playerData.EndWidth;
                lineRenderer.time = playerData.Time;
                lineRenderer.material = playerData.MaterialTrailRenderer;
                lineRenderer.startColor = playerData.StartColor;
                lineRenderer.endColor = playerData.EndColor;
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
