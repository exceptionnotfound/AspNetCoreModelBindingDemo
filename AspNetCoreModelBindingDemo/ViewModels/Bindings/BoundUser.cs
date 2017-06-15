using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreModelBindingDemo.ViewModels.Bindings
{
    public class BoundUser
    {
        [BindRequired]
        public int ID { get; set; }

        [BindRequired]
        public string FirstName { get; set; }

        [BindNever]
        public string LastName { get; set; }

        [BindRequired]
        public DateTime DateOfBirth { get; set; }

        [BindRequired]
        [FromRoute]
        public string Controller { get; set; }
    }
}
