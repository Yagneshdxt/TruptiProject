using ClientInterface.MappingConfig;
using ClientInterface.Models;
using CoreEntities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientInterface.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            DocumentLinks docLnk = new DocumentLinks();
            AutoMapperConfig.MapDocument_VM();
            DocumentViewModel model;
            model = AutoMapper.Mapper.Map<DocumentViewModel>(docLnk);
            return View(model);
        }

        // GET: Default/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Default/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Default/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Default/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Default/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Default/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Default/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult postDocument(DocumentViewModel model) {

            if (model.WebDocumentUploaded.ContentLength <= 0) {
                ModelState.AddModelError("file Required", "File not found");
            }

            using (Stream inputStream = model.WebDocumentUploaded.InputStream)
            {
                MemoryStream memoryStream = inputStream as MemoryStream;
                if (memoryStream == null)
                {
                    memoryStream = new MemoryStream();
                    inputStream.CopyTo(memoryStream);
                }
                model.documentInByte = memoryStream.ToArray();
            }
            model.documentExtension = Path.GetExtension(model.WebDocumentUploaded.FileName);


            DocumentLinks doc = new DocumentLinks();
            AutoMapperConfig.MapDocument_VM();
            doc = AutoMapper.Mapper.Map<DocumentLinks>(model);

            return View("Index",model);
        }
    }
}
