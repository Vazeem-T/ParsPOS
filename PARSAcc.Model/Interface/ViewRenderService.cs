using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.DependencyInjection;

namespace PARSAcc.Model.Interface
{
	public class ViewRenderService : IViewRenderService
	{
		public string RenderPartialViewToString(ControllerContext controller, string viewName, object model)
		{
			var viewEngine = controller.HttpContext.RequestServices.GetService<ICompositeViewEngine>();
			var tempDataProvider = controller.HttpContext.RequestServices.GetService<ITempDataProvider>();

			var viewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
			{
				Model = model
			};

			using (var sw = new StringWriter())
			{
				var viewResult = viewEngine.FindView(controller, viewName, false);

				var viewContext = new ViewContext(
					controller,
					viewResult.View,
					viewData,
					new TempDataDictionary(controller.HttpContext, tempDataProvider),
					sw,
					new HtmlHelperOptions()
				);

				var task = viewResult.View.RenderAsync(viewContext);
				task.Wait();

				return sw.ToString();
			}
		}
	}
}
