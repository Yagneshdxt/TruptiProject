using ClientInterface.MappingConfig;
using ClientInterface.Models;
using CoreEntities;
using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ClientInterface.Controllers
{
    public class DocumentController : ApiController
    {
        private UnitOfWork _UOW;

        public DocumentController(UnitOfWork uof) {
            _UOW = uof;
        }

        public DocumentController() {
            _UOW = new UnitOfWork();
        }


        [HttpPost, ActionName("UploadDocument")]
        public IHttpActionResult UploadDocument(DocumentViewModel documentViewModel) {

            HttpRequestMessage request = this.Request;
            if (!request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            var httpRequest = System.Web.HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                DocumentLinks doc = new DocumentLinks();
                AutoMapperConfig.MapDocument_VM();
                doc = AutoMapper.Mapper.Map<DocumentLinks>(documentViewModel);
                doc.DocumentPath = "";
                /*foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    var filePath = System.Web.HttpContext.Current.Server.MapPath("~/UploadedFiles/" + DateTime.Now.Ticks.ToString() + Path.GetExtension(postedFile.FileName));
                    postedFile.SaveAs(filePath);
                    // NOTE: To store in memory use postedFile.InputStream
                    //documentLnk.
                    doc = AutoMapper.Mapper.Map<DocumentLinks>(documentViewModel);
                    doc.DocumentPath = filePath;
                    _UOW.DocumentLinkRepository.Insert(doc);
                    _UOW.Save();
                }*/
                return Ok<DocumentLinks>(doc);
                //return Request.CreateResponse(HttpStatusCode.Created);
            }

            return BadRequest("some error encountered");
        }
    }
}
