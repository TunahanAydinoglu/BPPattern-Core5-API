﻿using BPP.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPP.WebAPI.Filters
{
    public class NotFoundFilter:ActionFilterAttribute
    {
        private readonly IProductService _productService;

        public NotFoundFilter(IProductService productService)
        {
            _productService = productService;
        }

        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            int id =(int) context.ActionArguments.Values.FirstOrDefault();

            var product = await _productService.GetByIdAync(id);
            if (product != null)
            {
                await next();
            }
            else
            {
                ErrorDto errorDto = new ErrorDto();

                errorDto.Status = 404;
                errorDto.Errors.Add($"Id'si {id} olan ürün veritabanında bulunamadı");

                context.Result = new NotFoundObjectResult(errorDto);
            }
        }
    }
}
