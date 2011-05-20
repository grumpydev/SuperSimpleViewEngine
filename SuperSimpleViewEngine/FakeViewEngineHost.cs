namespace SuperSimpleViewEngine
{
    using System;

    public class FakeViewEngineHost : IViewEngineHost
    {
        public Func<string, string> GetTemplateCallback { get; set; }

        /// <summary>
        /// Html "safe" encode a string
        /// </summary>
        /// <param name="input">Input string</param>
        /// <returns>Encoded string</returns>
        public string HtmlEncode(string input)
        {
            return input.Replace("&", "&amp;").
                Replace("<", "&lt;").
                Replace(">", "&gt;").
                Replace("\"", "&quot;");
        }

        /// <summary>
        /// Get the contenst of a template
        /// </summary>
        /// <param name="templateName">Name/location of the template</param>
        /// <returns>Contents of the template, or null if not found</returns>
        public string GetTemplate(string templateName)
        {
            return this.GetTemplateCallback != null ? this.GetTemplateCallback.Invoke(templateName) : string.Empty;
        }

        /// <summary>
        /// Gets a uri string for a named route
        /// </summary>
        /// <param name="name">Named route name</param>
        /// <param name="parameters">Parameters to use to expand the uri string</param>
        /// <returns>Expanded uri string, or null if not found</returns>
        public string GetUriString(string name, params string[] parameters)
        {
            throw new NotImplementedException();
        }
    }
}