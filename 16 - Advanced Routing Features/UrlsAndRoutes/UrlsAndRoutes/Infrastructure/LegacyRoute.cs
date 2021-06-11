using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace UrlsAndRoutes.Infrastructure {

    // https://stackoverflow.com/questions/59720319/migrate-irouter-usage-to-asp-net-core-3-1
    public class LegacyRoute : IRouter {
        private string[] urls;
        private IRouter mvcRoute;

        public LegacyRoute(IRouter routeHandler, params string[] targetUrls) {
            this.urls = targetUrls;
            mvcRoute = routeHandler;
        }

        public async Task RouteAsync(RouteContext context) {

            string requestedUrl = context.HttpContext.Request.Path
                .Value.TrimEnd('/');

            if (urls.Contains(requestedUrl, StringComparer.OrdinalIgnoreCase)) {
                context.RouteData.Values["controller"] = "Legacy";
                context.RouteData.Values["action"] = "GetLegacyUrl";
                context.RouteData.Values["legacyUrl"] = requestedUrl;
                await mvcRoute.RouteAsync(context);
            }
        }

        public VirtualPathData GetVirtualPath(VirtualPathContext context) {
            if (context.Values.ContainsKey("legacyUrl")) {
                string url = context.Values["legacyUrl"] as string;
                if (urls.Contains(url)) {
                    return new VirtualPathData(this, url);
                }
            }
            return null;
        }
    }
}
