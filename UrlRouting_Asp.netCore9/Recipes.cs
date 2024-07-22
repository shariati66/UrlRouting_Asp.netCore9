namespace UrlRouting_Asp.netCore9
{
    public class Recipes
    {
        private readonly RequestDelegate next;

        public Recipes(RequestDelegate Next)
        {
            next = Next;
        }
        public Recipes()
        {
            
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var name = context.Request.RouteValues["name"];
            string str_ingredients = string.Empty;
            switch (name.ToString().ToLower())
            {
                case "fried_egg":
                    str_ingredients = "Oil + Eggs";
                    break;
                case "omlette":
                    str_ingredients = "Oil  + Eggs + Tomato";
                    break;
                case "rice":
                    str_ingredients = "Rice + Salt";
                    break;
                default:
                    LinkGenerator? generator = context.RequestServices.GetService<LinkGenerator>();
                    string? url = generator.GetPathByRouteValues(context, "ingredients", new { name = "none" });
                    context.Response.Redirect(url);
                    break;

            }
            if (!string.IsNullOrEmpty(str_ingredients))
            {
                context.Response.StatusCode = 200;
                context.Response.ContentType = "text/html";
                await context.Response.WriteAsync(str_ingredients);
            }
            if (next != null)
                await next(context);
        }
    }
}
