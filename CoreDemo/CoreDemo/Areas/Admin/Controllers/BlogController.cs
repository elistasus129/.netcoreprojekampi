﻿using ClosedXML.Excel;
using CoreDemo.Areas.Admin.Models;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Areas.Admin.Controllers
{
    public class BlogController : Controller
    {
        [AllowAnonymous]
        [Area("Admin")]
        public IActionResult ExportStaticExcelBlogList()
        {
            using(var workbook=new XLWorkbook()) 
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi");
                worksheet.Cell(1, 1).Value = "Blog ID";
                worksheet.Cell(1, 2).Value = "Blog Adı";

                int BlogRowCount = 2;
                foreach (var item in GetBlogList())
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.ID;
                    worksheet.Cell(BlogRowCount, 2).Value = item.BlogName;
                    BlogRowCount++;
                }

                using (var stream = new MemoryStream()) 
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma1.xlsx");
                }


            }
       
        }
        [AllowAnonymous]
        [Area("Admin")]
        public List<BlogModel> GetBlogList()
        {
            List<BlogModel> bm = new List<BlogModel>
            {
                new BlogModel{ID=1,BlogName="C# Programlama Giriş"},
                new BlogModel{ID=2,BlogName="Tesla Firmasının Araçları"},
                new BlogModel{ID=3,BlogName="2020 olimpiyatları" }
            };

            return bm;
        }
        [AllowAnonymous]
        [Area("Admin")]
        public IActionResult BlogListExcel()
        {
            return View();
        }
        [AllowAnonymous]
        [Area("Admin")]
        public IActionResult ExportDynamicExcelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi");
                worksheet.Cell(1, 1).Value = "Blog ID";
                worksheet.Cell(1, 2).Value = "Blog Adı";

                int BlogRowCount = 2;
                foreach (var item in BlogTitleList())
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.ID;
                    worksheet.Cell(BlogRowCount, 2).Value = item.BlogName;
                    BlogRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma1.xlsx");
                }

            }


        }
        [AllowAnonymous]
        [Area("Admin")]
        public List<BlogModel2> BlogTitleList()
        {
            List<BlogModel2> bm = new List<BlogModel2>();

            using (var c=new Context())
            {
                bm = c.Blogs.Select(x => new BlogModel2
                {
                        ID=x.BlogID,
                        BlogName=x.BlogTitle
                }).ToList();
            }
            return bm;
        }
        [AllowAnonymous]
        [Area("Admin")]
        public  IActionResult BlogTitleListExcel()
        {
            return View();
        }


    }
}
