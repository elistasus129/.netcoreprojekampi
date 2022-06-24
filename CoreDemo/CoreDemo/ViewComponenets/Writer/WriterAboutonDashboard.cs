﻿using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.ViewComponenets.Writer
{
  
    public class WriterAboutonDashboard:ViewComponent
    {
        WriterManager writermanager = new WriterManager(new EfWriterRepository());

        private readonly UserManager<AppUser> _userManager;

        Context c = new Context();

       

        public IViewComponentResult Invoke()
        {
           // var user = await _userManager.FindByIdAsync(User.Identity.Name);
            var username = User.Identity.Name;
            ViewBag.veri = username;
            var usermail = c.Users.Where(x=>x.UserName==username).Select(y => y.Email).FirstOrDefault();
            var writerID = c.Writers.Where(x => x.WriterMail == usermail).Select(y => y.WriterID).FirstOrDefault();
            var values = writermanager.GetWriterById(writerID);
            return View(values);
        }
    }
}
