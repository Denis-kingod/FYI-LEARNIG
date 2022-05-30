using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tcc_dbfyi.Domains;

namespace tcc_dbfyi.Interfaces
{
    public interface ICategoriumRepository
    {
        List<Categorium> Listar();

        void Cadastrar(Categorium novaCategoria);

        void Atualizar(int id, Categorium CategoriaAtualizada);

        void Deletar(int id);

        Categorium BuscarPorId(int id);
            
        Categorium BuscarPorTitulo(string titulo);
    }
}
