using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data.Repositories
{
    public class RequisicaoRepository : IRequisicaoRepository
    {
        private readonly xAlmoxarifadoContext _context;

        public RequisicaoRepository(xAlmoxarifadoContext pContext)
        {
            _context = pContext;
        }

        public List<Requisicao> ObterTudoRequisicao()
        {
            return _context.Requisicoes
                    .Select(requisicao => new Requisicao
                    {
                        IdReq = requisicao.IdReq,
                        IdCli = requisicao.IdCli,
                        TotalReq = requisicao.TotalReq,
                        QtdIten = requisicao.QtdIten,
                        DataReq = requisicao.DataReq,
                        Ano = requisicao.Ano,
                        Mes = requisicao.Mes,
                        IdSec = requisicao.IdSec,
                        IdSet = requisicao.IdSet,
                        Observacao = requisicao.Observacao
                    })
                    .ToList();
        }

        public Requisicao ObterRequisicaoPorId(int id)
        {
            return _context.Requisicoes
                   .Select(requisicao => new Requisicao
                   {
                       IdReq = requisicao.IdReq,
                       IdCli = requisicao.IdCli,
                       TotalReq = requisicao.TotalReq,
                       QtdIten = requisicao.QtdIten,
                       DataReq = requisicao.DataReq,
                       Ano = requisicao.Ano,
                       Mes = requisicao.Mes,
                       IdSec = requisicao.IdSec,
                       IdSet = requisicao.IdSet,
                       Observacao = requisicao.Observacao
                   })
                   .ToList().First(x => x?.IdReq == id);
        }

        public Requisicao CriarRequisicao(Requisicao requisicao)
        {
            _context.Requisicoes.Add(requisicao);
            _context.SaveChanges();

            return requisicao;
        }
    }
}
