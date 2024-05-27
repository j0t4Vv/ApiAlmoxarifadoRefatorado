using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data.Repositories
{
    public class ItensNotaRepository : IItensNotaRepository
    {
        private readonly xAlmoxarifadoContext _context;

        public ItensNotaRepository(xAlmoxarifadoContext pcontext)
        {
            _context = pcontext;
        }

        public List<ItensNota> ObterTodosItensNotas()
        {
            return _context.ItensNota
                .Select(itensNota => new ItensNota
                {
                    ItemNum = itensNota.ItemNum,
                    IdPro = itensNota.IdPro,
                    IdNota = itensNota.IdNota,
                    IdSec = itensNota.IdSec,
                    QtdPro = itensNota .QtdPro,
                    PreUnit = itensNota.PreUnit,
                    TotalItem = itensNota .TotalItem,
                    EstLin = itensNota.EstLin
                })
                .ToList();
        }

        public ItensNota ObterItensNotaPorId(int id)
        {
            return _context.ItensNota
                .Select(itensNota => new ItensNota
                {
                    ItemNum = itensNota.ItemNum,
                    IdPro = itensNota.IdPro,
                    IdNota = itensNota.IdNota,
                    IdSec = itensNota.IdSec,
                    QtdPro = itensNota.QtdPro,
                    PreUnit = itensNota.PreUnit,
                    TotalItem = itensNota.TotalItem,
                    EstLin = itensNota.EstLin
                })
                .ToList().First(x => x?.ItemNum == id);
        }


        public ItensNota CriarItensNota(ItensNota itensNota)
        {
            _context.ItensNota.Add(itensNota);
            _context.SaveChanges();

            return itensNota;
        }
    }
}
