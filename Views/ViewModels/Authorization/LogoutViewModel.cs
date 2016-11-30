using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SecondAid.ViewModels.Authorization
{
    public class LogoutViewModel
    {
        [BindNever]
        public string RequestId { get; set; }
    }
}
