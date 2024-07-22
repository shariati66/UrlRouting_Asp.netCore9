namespace UrlRouting_Asp.netCore9
{
    public class IngredientMiddleware
    {
        private readonly RequestDelegate next;

        public IngredientMiddleware(RequestDelegate Next)
        {
            next = Next;
        }
        public IngredientMiddleware()
        {
            
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var name = context.Request.RouteValues["name"];
            string str_ingredients = string.Empty;
            switch (name.ToString().ToLower())
            {
                case "fried_egg":
                    str_ingredients = "Oil and eggs";
                    break;
                case "omelette":
                    str_ingredients = "Oil, Eggs and Tomato";
                    break;
                case "rice":
                    str_ingredients = "Rice and solt";
                    break;
                default:
                    str_ingredients = "I don't Know";
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
