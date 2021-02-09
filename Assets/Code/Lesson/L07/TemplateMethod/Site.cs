namespace JevLogin.Lesson07.TemplateMethod
{
    public abstract class Site
    {
        #region Methods
        
        /// <summary>
        /// Pattern Template Method
        /// </summary>
        public void Draw()
        {
            DrawHeader();
            DrawBody();
            DrawFooter();
        }

        protected abstract void DrawHeader();
        protected abstract void DrawBody();
        protected abstract void DrawFooter(); 

        #endregion
    }
}