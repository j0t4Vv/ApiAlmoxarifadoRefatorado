using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data.Repositories
{
    public class ItensReqRepository : IItensReqRepository
    {
        private readonly xAlmoxarifadoContext _context;

        public ItensReqRepository(xAlmoxarifadoContext pContext)
        {
            _context = pContext;
        }

        public List<ItensReq> ObterTodosItensReq()
        {
            return _context.ItensReqs
                    .Select(itensReq => new ItensReq
                    {
                        NumItem = itensReq.NumItem,
                        IdPro = itensReq.IdPro,
                        IdReq = itensReq.IdReq,
                        IdSec = itensReq.IdSec,
                        QtdPro = itensReq.QtdPro,
                        PreUnit = itensReq.PreUnit,
                        TotalItem = itensReq.TotalItem,
                        TotalReal = itensReq.TotalReal

                    })
                    .ToList();
        }

        public ItensReq ObterItensReqPorId(int id)
        {
            return _context.ItensReqs
                   .Select(itensReq => new ItensReq
                   {
                       NumItem = itensReq.NumItem,
                       IdPro = itensReq.IdPro,
                       IdReq = itensReq.IdReq,
                       IdSec = itensReq.IdSec,
                       QtdPro = itensReq.QtdPro,
                       PreUnit = itensReq.PreUnit,
                       TotalItem = itensReq.TotalItem,
                       TotalReal = itensReq.TotalReal
                   })
                   .ToList().First(x => x?.NumItem == id);
        }

        public ItensReq CriarItensReq(ItensReq itensReq)
        {
            _context.ItensReqs.Add(itensReq);
            _context.SaveChanges();

            return itensReq;
        }
    }
}
