using SegWallApi.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SegWallApi.DAL.Context;

namespace SegWallApi.DAL
{
    public class SeguroDAL
    {
        public IList<Seguro> Listar()
        {
            IList<Seguro> lista = new List<Seguro>();

            SegWallContext ctx = new SegWallContext();
            lista = ctx.Seguro.ToList();

            return lista;
        }

        public Seguro Consultar(int id)
            {
                SegWallContext ctx = new SegWallContext();
                Seguro Seguro = ctx.Seguro.Find(id);

                return Seguro;
            }

            public void Inserir(Seguro Seguro)
            {
                SegWallContext ctx = new SegWallContext();

                ctx.Seguro.Add(Seguro);

                ctx.SaveChanges();
            }

            public void Alterar(Seguro Seguro)
            {
                SegWallContext ctx = new SegWallContext();

                ctx.Entry(Seguro).State = EntityState.Modified;

                ctx.SaveChanges();
            }

            public void Excluir(int id)
            {
                SegWallContext ctx = new SegWallContext();

                Seguro Seguro = ctx.Seguro.Find(id);

                ctx.Entry(Seguro).State = EntityState.Deleted;

                ctx.SaveChanges();
            }
        }
    }
