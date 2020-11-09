using System;
using Microsoft.AspNetCore.Components;

namespace PieShop.ComponentsLibrary
{
    public class ProfilePictureBase : ComponentBase
    {
        protected string CssClass { get; set; } = "circle";

        [Parameter] public RenderFragment ChildContent { get; set; }

        protected void PictureClick()
        {
            CssClass = CssClass == "circle" ? null : "circle";
        }
    }
}