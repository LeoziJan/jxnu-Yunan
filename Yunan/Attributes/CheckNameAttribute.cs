using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Model;
using bll;

namespace Yunan.Model
{
    public class CheckNameAttribute:ValidationAttribute
    {
        
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string valuestring = value.ToString();
            UsersManage usm = new UsersManage();
            var user = usm.LoadService();
            foreach(var item in user)
            {
                if (valuestring == item.UserName)
                {
                    return new ValidationResult("你来晚了这个昵称被占用了");
                }
            }
            return ValidationResult.Success;
        }
    }
}