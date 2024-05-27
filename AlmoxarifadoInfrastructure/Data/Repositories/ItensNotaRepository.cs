using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

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
                    QtdPro = itensNota.QtdPro,
                    PreUnit = itensNota.PreUnit,
                    TotalItem = itensNota.TotalItem,
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
                .ToList().FirstOrDefault(x => x?.ItemNum == id);
        }


        public ItensNota CriarItensNota(ItensNota itensNota)
        {
            _context.ItensNota.Add(itensNota);
            _context.SaveChanges();

            return itensNota;
        }

        public ItensNota AtualizarItemNota(ItensNota itensNota)
        {
            var itemNotaExistente = _context.ItensNota.FirstOrDefault(i => i.ItemNum == itensNota.ItemNum);
            if (itemNotaExistente != null)
            {
                itemNotaExistente.IdPro = itensNota.IdPro;
                itemNotaExistente.IdNota = itensNota.IdNota;
                itemNotaExistente.IdSec = itensNota.IdSec;
                itemNotaExistente.QtdPro = itensNota.QtdPro;
                itemNotaExistente.PreUnit = itensNota.PreUnit;
                itemNotaExistente.TotalItem = itensNota.TotalItem;
                itemNotaExistente.EstLin = itensNota.EstLin;

                _context.SaveChanges();
                return itemNotaExistente;
            }
            else
            {
                throw new InvalidOperationException("Item de nota não encontrado!");
            }
        }

        public ItensNota ExcluirItemNota(ItensNota itensNota)
        {
            var itemNotaExcluido = _context.ItensNota.Remove(itensNota);
            _context.SaveChanges();
            return itemNotaExcluido.Entity;
        }
    }
}
