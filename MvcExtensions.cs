using Microsoft.AspNetCore.Mvc.Rendering;

namespace Tipi.Tools.UIExtensions.Mvc
{
    /// <summary>
    /// Static class <c>MvcExtensions</c> that let's you access all the classes to intergace with your Mvc Razor Views,
    /// <see href="https://docs.codingtipi.com/docs/toolkit/mvc-extensions">See More</see>
    /// </summary>
    /// <remarks>
    /// Access a variaty of methods to render logic in Mvc Razor Views.
    /// </remarks>
    public static class MvcExtensions
    {
        /// <summary>
        /// Adds a css class inside the Current Controller and Action, 
        /// <see href="https://docs.codingtipi.com/docs/toolkit/mvc-extensions/methods#active-class">See More</see>.
        /// </summary>
        /// <remarks>
        /// Evaluates based on provided parameters the current Controller and Action and renders a given Css class.
        /// </remarks>
        /// <param name="htmlHelper">Helper to interact with Html.</param>
        /// <param name="controllers">Controllers you want to check separated by ','</param>
        /// <param name="actions">Actions you want to check separated by ','</param>
        /// <param name="cssClass">Css class you want to render when the condition for the Controllers and Actios is met, the default is active</param>
        public static string ActiveClass(this IHtmlHelper htmlHelper, string? controllers = null, string? actions = null, string cssClass = "active")
        {
            var currentController = htmlHelper?.ViewContext.RouteData.Values["controller"] as string;
            var currentAction = htmlHelper?.ViewContext.RouteData.Values["action"] as string;

            var acceptedControllers = (controllers ?? currentController ?? "").Split(',');
            var acceptedActions = (actions ?? currentAction ?? "").Split(',');

            return acceptedControllers.Contains(currentController) && acceptedActions.Contains(currentAction)
                ? cssClass
                : "";
        }
    }
}
