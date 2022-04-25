using Microsoft.EntityFrameworkCore;
using SegWallApi.DAL.Context;
using SegWallApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SegWallApi.DAL
{
    public class ApoliceDAL
    {
        public IList<Apolice> Listar()
        {
            IList<Apolice> lista = new List<Apolice>();

            SegWallContext ctx = new SegWallContext();
            lista = ctx.Apolice.ToList();

            return lista;
        }

        public Apolice Consultar(int id)
        {
            SegWallContext ctx = new SegWallContext();
            Apolice apolice = ctx.Apolice.Find(id);

            return apolice;
        }

        public void Inserir(Apolice Apolice)
        {
            SegWallContext ctx = new SegWallContext();

            ctx.Apolice.Add(Apolice);

            ctx.SaveChanges();
        }

        public void Alterar(Apolice Apolice)
        {
            SegWallContext ctx = new SegWallContext();

            ctx.Entry(Apolice).State = EntityState.Modified;

            ctx.SaveChanges();
        }

        public void Excluir(int id)
        {
            SegWallContext ctx = new SegWallContext();

            Apolice Apolice = ctx.Apolice.Find(id);

            ctx.Entry(Apolice).State = EntityState.Deleted;

            ctx.SaveChanges();
        }
    }
}
