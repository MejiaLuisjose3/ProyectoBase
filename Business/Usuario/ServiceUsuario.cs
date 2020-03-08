using System.Collections.Generic;

namespace Business.Usuario
{
    public class ServiceUsuario : IServiceUsuario
    {
        private readonly IDataUsuario data;
        public ServiceUsuario(IDataUsuario data)
        {
            this.data = data;
        }

        public bool Create(CUsuario usuario)
        {
            return data.Create(usuario);
        }

        public List<CUsuario> get()
        {
            return data.get();
        }
    }
}
