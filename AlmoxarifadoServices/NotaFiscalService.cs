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
    public class NotaFiscalService
    {
        private readonly INotaFiscalRepository _notaFiscalRepository;
        private readonly MapperConfiguration configurationMapper;

        public NotaFiscalService(INotaFiscalRepository pNotaFiscalRepository)
        {
            _notaFiscalRepository = pNotaFiscalRepository;
            configurationMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<NotaFiscal, NotaFiscalGetDTO>();
                cfg.CreateMap<NotaFiscalGetDTO, NotaFiscal>();
            });
        }

        public List<NotaFiscalGetDTO> ObterTodosNotaFiscal()
        {
            var mapper = configurationMapper.CreateMapper();


            return  mapper.Map<List<NotaFiscalGetDTO>>(_notaFiscalRepository.ObterTodosNotaFiscal());
        }

        public NotaFiscal ObterNotaFiscalPorID(int id)
        {
            

            return _notaFiscalRepository.ObterNotaFiscalPorId(id);
        }

        public NotaFiscalGetDTO CriarNotaFiscal(NotaFiscalPostDTO notaFiscal)
        {
           var notaFiscalSalva = _notaFiscalRepository.CriarNotaFiscal(
                new NotaFiscal {
                    IdFor = notaFiscal.IdFor,
                    IdSec = notaFiscal.IdSec,
                    NumNota = notaFiscal.NumNota,
                    ValorNota = notaFiscal.ValorNota,
                    QtdItem = notaFiscal.QtdItem,
                    Icms = notaFiscal.Icms,
                    Iss = notaFiscal.Iss,
                    Ano = notaFiscal.Ano,
                    Mes = notaFiscal.Mes,
                    DataNota = notaFiscal.DataNota,
                    IdTipoNota = notaFiscal.IdTipoNota,
                    ObservacaoNota = notaFiscal.ObservacaoNota,
                    EmpenhoNum = notaFiscal.EmpenhoNum
                }
             );

            return new NotaFiscalGetDTO {
                IdNota = notaFiscalSalva.IdNota,
                IdFor = notaFiscalSalva.IdFor,
                IdSec = notaFiscalSalva.IdSec,
                NumNota = notaFiscalSalva.NumNota,
                ValorNota = notaFiscalSalva.ValorNota,
                QtdItem = notaFiscalSalva.QtdItem,
                Icms = notaFiscalSalva.Icms,
                Iss = notaFiscalSalva.Iss,
                Ano = notaFiscalSalva.Ano,
                Mes = notaFiscalSalva.Mes,
                DataNota = notaFiscalSalva.DataNota,
                IdTipoNota = notaFiscalSalva.IdTipoNota,
                ObservacaoNota = notaFiscalSalva.ObservacaoNota,
                EmpenhoNum = notaFiscalSalva.EmpenhoNum
            };
        }

    }
}
