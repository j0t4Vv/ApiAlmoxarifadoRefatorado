using AlmoxarifadoDomain.Models;
using AlmoxarifadoInfrastructure.Data.Interfaces;
using AlmoxarifadoServices.DTO;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoServices
{
    public class RequisicaoService
    {
        private readonly IRequisicaoRepository _requisicaoRepository;
        private readonly MapperConfiguration configurationMapper;

        public RequisicaoService(IRequisicaoRepository pRequisicaoRepository)
        {
            _requisicaoRepository = pRequisicaoRepository;
            configurationMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Requisicao, RequisicaoGetDTO>();
                cfg.CreateMap<RequisicaoGetDTO, Requisicao>();
            });
        }

        public List<RequisicaoGetDTO> ObterTudoRequisicao()
        {
            var mapper = configurationMapper.CreateMapper();


            return  mapper.Map<List<RequisicaoGetDTO>>(_requisicaoRepository.ObterTudoRequisicao());
        }

        public Requisicao ObterRequisicaoPorID(int id)
        {
            

            return _requisicaoRepository.ObterRequisicaoPorId(id);
        }

        public RequisicaoGetDTO CriarRequisicao(RequisicaoPostDTO requisicao)
        {
           var requisicaoSalva = _requisicaoRepository.CriarRequisicao(
                new Requisicao
                {
                    IdCli = requisicao.IdCli,
                    TotalReq = requisicao.TotalReq,
                    QtdIten = requisicao.QtdIten,
                    DataReq = requisicao.DataReq,
                    Ano = requisicao.Ano,
                    Mes = requisicao.Mes,
                    IdSec = requisicao.IdSec,
                    IdSet = requisicao.IdSet,
                    Observacao = requisicao.Observacao
                }
             );

            return new RequisicaoGetDTO
            {
                IdReq = requisicaoSalva.IdReq,
                IdCli = requisicaoSalva.IdCli,
                TotalReq = requisicaoSalva.TotalReq,
                QtdIten = requisicaoSalva.QtdIten,
                DataReq = requisicaoSalva.DataReq,
                Ano = requisicaoSalva.Ano,
                Mes = requisicaoSalva.Mes,
                IdSec = requisicaoSalva.IdSec,
                IdSet = requisicaoSalva.IdSet,
                Observacao = requisicaoSalva.Observacao
            };
        }

    }
}