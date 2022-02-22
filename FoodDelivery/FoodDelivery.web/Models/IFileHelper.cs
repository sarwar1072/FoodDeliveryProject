﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDelivery.web.Models
{
    public interface IFileHelper
    {
        void DeleteFile(string imageUrl);
        string UploadFile(IFormFile file);
    }
}
