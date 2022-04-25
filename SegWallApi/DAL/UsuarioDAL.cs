using Microsoft.EntityFrameworkCore;
using SegWallApi.DAL.Context;
using SegWallApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SegWallApi.DAL
{
    public class UsuarioDAL
    {
        public IList<Usuario> Listar()
        {
            IList<Usuario> lista = new List<Usuario>();

            SegWallContext ctx = new SegWallContext();
            lista = ctx.Usuario.ToList();

            return lista;
        }

        public Usuario Consultar(int id)
        {
            SegWallContext ctx = new SegWallContext();
            Usuario usuario = ctx.Usuario.Find(id);

            return usuario;
        }

        public void Inserir(Usuario Usuario)
        {
            SegWallContext ctx = new SegWallContext();

            ctx.Usuario.Add(Usuario);

            ctx.SaveChanges();
        }

        public void Alterar(Usuario Usuario)
        {
            SegWallContext ctx = new SegWallContext();

            ctx.Entry(Usuario).State = EntityState.Modified;

            ctx.SaveChanges();
        }

        public void Excluir(int id)
        {
            SegWallContext ctx = new SegWallContext();

            Usuario Usuario = ctx.Usuario.Find(id);

            ctx.Entry(Usuario).State = EntityState.Deleted;

            ctx.SaveChanges();
        }
    }
}
