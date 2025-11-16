using Microsoft.AspNetCore.Mvc;

namespace mango.Web.SweetAlert
{
    public static class SweetAlert
    {
        
            public static void SetSweetAlert(this Controller controller, string title, string message, string icon)
            {
                controller.TempData["SweetAlertTitle"] = title;
                controller.TempData["SweetAlertMessage"] = message;
                controller.TempData["SweetAlertIcon"] = icon; // success, error, warning, info, question
            }
        
    }
}
