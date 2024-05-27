using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlmoxarifadoInfrastructure.Data.Repositories
{
    public class ItensReqRepository : IItensReqRepository
    {
        private readonly xAlmoxarifadoContext _context;

        public ItensReqRepository(xAlmoxarifadoContext context)
        {
            _context = context;
        }

        public List<ItensReq> ObterTodosItensReq()
        {
            return _context.ItensReqs.ToList();
        }

        public ItensReq ObterItensReqPorId(int id)
        {
            return _context.ItensReqs.FirstOrDefault(item => item.NumItem == id);
        }

        public ItensReq CriarItensReq(ItensReq itemReq)
        {
            _context.ItensReqs.Add(itemReq);
            _context.SaveChanges();
            return itemReq;
        }

        public ItensReq AtualizarItensReq(ItensReq itemReq)
        {
            var itemExistente = _context.ItensReqs.FirstOrDefault(item => item.NumItem == itemReq.NumItem);
            if (itemExistente != null)
            {
                itemExistente.IdPro = itemReq.IdPro;
                itemExistente.IdReq = itemReq.IdReq;
                itemExistente.IdSec = itemReq.IdSec;
                itemExistente.QtdPro = itemReq.QtdPro;
                itemExistente.PreUnit = itemReq.PreUnit;
                itemExistente.TotalItem = itemReq.TotalItem;
                itemExistente.TotalReal = itemReq.TotalReal;
                _context.SaveChanges();
                return itemExistente;
            }
            else
            {
                throw new InvalidOperationException("Item de requisição não encontrado!");
            }
        }

        public ItensReq ExcluirItensReq(ItensReq itemReq)
        {
            var itemExcluido = _context.ItensReqs.Remove(itemReq);
            _context.SaveChanges();
            return itemExcluido.Entity;
        }
    }
}
