﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tcc_dbfyi.Domains;

namespace tcc_dbfyi.Interfaces
{
    public interface ITipoUsuarioRepository
    {
        List<TipoUsuario> Listar();

        void Cadastrar(TipoUsuario novoTipoUsuario);

        void Deletar(int id);

        void Atualizar(int id, TipoUsuario tipoUsuarioAtualizado);

        TipoUsuario BuscarPorId(int id);
    }
}
