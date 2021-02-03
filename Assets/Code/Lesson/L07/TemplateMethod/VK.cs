using UnityEngine;


namespace JevLogin.Lesson07.TemplateMethod
{
    public sealed class VK : Site
    {
        #region Methods

        protected override void DrawBody()
        {
            Debug.Log($"DrawBody {typeof(VK).Name}");
        }

        protected override void DrawFooter()
        {
            Debug.Log($"DrawFooter {typeof(VK).Name}");
        }

        protected override void DrawHeader()
        {
            Debug.Log($"DrawHeader {typeof(VK).Name}");
        }

        #endregion
    }
}