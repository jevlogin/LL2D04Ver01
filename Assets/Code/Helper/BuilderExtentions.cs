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

        public static GameObject AddTrailRenderer(this GameObject gameObject)
        {
            var componentInChildren = gameObject.GetComponentInChildren<TrailRenderer>();
            if (componentInChildren)
            {
                return gameObject;
            }
            var lineRendererGameObject = new GameObject("TrailRenderer");
            var lineRenderer = lineRendererGameObject.GetOrAddComponent<TrailRenderer>();
            lineRenderer.startWidth = 0.1f;
            lineRenderer.endWidth = 0.01f;
            lineRenderer.time = 0.1f;
            lineRenderer.material = new Material(Shader.Find("Mobile/Particles/Additive"));
            lineRenderer.startColor = Color.red;
            lineRenderer.endColor = Color.blue;
            lineRendererGameObject.transform.SetParent(gameObject.transform);
            
            return gameObject;
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
