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
    public class GrupoService
    {
        private readonly IGrupoRepository _grupoRepository;
        private readonly MapperConfiguration configurationMapper;

        public GrupoService(IGrupoRepository pGrupoRepository)
        {
            _grupoRepository = pGrupoRepository;
            configurationMapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Grupo, GrupoGetDTO>();
                cfg.CreateMap<GrupoGetDTO, Grupo>();
            });
        }

        public List<GrupoGetDTO> ObterTodosGrupos()
        {
            var mapper = configurationMapper.CreateMapper();


            return  mapper.Map<List<GrupoGetDTO>>(_grupoRepository.ObterTodosGrupos());
        }

        public Grupo ObterGrupoPorID(int id)
        {
            

            return _grupoRepository.ObterGrupoPorId(id);
        }

        public GrupoGetDTO CriarGrupo(GrupoPostDTO grupo)
        {
           var grupoSalvo = _grupoRepository.CriarGrupo(
                new Grupo { NomeGru = grupo.NomeGru, SugestaoGru=grupo.SugestaoGru}
             );

            return new GrupoGetDTO { IdGru = grupoSalvo.IdGru,
                                     NomeGru = grupoSalvo.NomeGru, 
                                     SugestaoGru = grupoSalvo.SugestaoGru };
        }

    }
}
