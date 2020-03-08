using Entity.Modelos;
using GeneralConfig.General;
using Interfaces.GeneralConfig.database;
using Interfaces.Usuario;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MySql.Controllers
{
    [RoutePrefix("api/values")]
    public class ValuesController : BaseController<CUsuario>
    {
        private readonly IBaseService<CUsuario> baseService;
        public ValuesController(IBaseService<CUsuario> baseService) : base(baseService)
        {
            this.baseService = baseService;
        }

        [Route("AgregarImage"), HttpPost]
        public new bool Agregar(CUsuario entity)
        {
            entity.Imagen = Imagenes().Content.ToString();
            return baseService.Create(entity);
        }
    }
}
