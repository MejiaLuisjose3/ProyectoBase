using Interfaces.GeneralConfig.database;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace GeneralConfig.General
{
    public class BaseController<T> : ApiController where T: class
    {
        private IBaseService<T> baseService;

        public BaseController(IBaseService<T> baseService)
        {
            this.baseService = baseService;
        }

        [Route("Agregar"), HttpPost]
        public bool Agregar(T entity)
        {
            return baseService.Create(entity);
        }

        [Route("Buscar"),HttpPost]
        public List<T> Buscar()
        {
            return baseService.BuscarTodos();
        }

        [Route("Eliminar/{codigo}"), HttpDelete]
        public bool Eliminar(int codigo)
        {
            try
            {
                baseService.Eliminar(codigo);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Route("EliminarModelo"), HttpDelete]
        public bool EliminarModelo(T entity)
        {
            try
            {
                baseService.EliminarModelo(entity);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Route("Actualizar"), HttpPut]
        public bool Actualizar(T entity)
        {
            try
            {
                baseService.Actualizar(entity);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Route("CargarImagen"), HttpPost]
        public HttpResponseMessage Imagenes()
        {

            Dictionary<string, object> dict = new Dictionary<string, object>();

            try
            {

                var httpRequest = HttpContext.Current.Request;
                var filePath = "";
                foreach (string file in httpRequest.Files)
                {
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);

                    var postedFile = httpRequest.Files[file];
                    if (postedFile != null && postedFile.ContentLength > 0)
                    {

                        int MaxContentLength = 1024 * 1024 * 1; //Size = 1 MB

                        IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".gif", ".png" };
                        var ext = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.'));
                        var extension = ext.ToLower();
                        if (!AllowedFileExtensions.Contains(extension))
                        {

                            var message = string.Format("Please Upload image of type .jpg, .gif, .png.");

                            dict.Add("error", message);
                            return Request.CreateResponse(HttpStatusCode.BadRequest, dict);
                        }
                        else if (postedFile.ContentLength > MaxContentLength)
                        {

                            var message = string.Format("Please Upload a file upto 1 mb.");

                            dict.Add("error", message);
                            return Request.CreateResponse(HttpStatusCode.BadRequest, dict);
                        }
                        else
                        {

                            //YourModelProperty.imageurl = userInfo.email_id + extension;
                            //  where you want to attach your imageurl

                            //if needed write the code to update the table

                             filePath = HttpContext.Current.Server.MapPath("~/Imagenes/" + "Verificar"+ extension);
                            //Userimage myfolder name where i want to save my image
                            postedFile.SaveAs(filePath);

                        }
                    }

                    var message1 = string.Format("Image Updated Successfully.");
                    return Request.CreateErrorResponse(HttpStatusCode.Created, filePath); ;
                }
                var res = string.Format("Please Upload a image.");
                dict.Add("error", res);
                return Request.CreateResponse(HttpStatusCode.NotFound, dict);
            }
            catch (Exception ex)
            {
                var res = string.Format("some Message");
                dict.Add("error", res);
                return Request.CreateResponse(HttpStatusCode.NotFound, dict);
            }
        }
    }
}
