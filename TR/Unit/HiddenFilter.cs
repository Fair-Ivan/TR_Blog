namespace TR.Unit
{
    using System;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc.ApiExplorer;
    using Swashbuckle.AspNetCore.Swagger;
    using Swashbuckle.AspNetCore.SwaggerGen;

    /// <summary>
    /// 隐藏接口，不生成到swagger文档展示
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]

    public partial class HiddenAttribute : Attribute
    {
    }

    public class HiddenFilter : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
        {
            foreach (ApiDescription apiDescription in context.ApiDescriptionsGroups.Items.SelectMany(e => e.Items))
            {
                if (apiDescription.ControllerAttributes().OfType<HiddenAttribute>().Count() == 0
                    && apiDescription.ActionAttributes().OfType<HiddenAttribute>().Count() == 0)
                {
                    continue;
                }

                var key = "/" + apiDescription.RelativePath.TrimEnd('/');
                if (!key.Contains("/test/") && swaggerDoc.Paths.ContainsKey(key))
                {
                    swaggerDoc.Paths.Remove(key);
                }
            }
        }
    }
}
