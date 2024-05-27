using AlmoxarifadoDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data.Interfaces
{
    public interface IRequisicaoRepository
    {
        List<Requisicao> ObterTudoRequisicao();
        Requisicao ObterRequisicaoPorId(int id);
        Requisicao CriarRequisicao(Requisicao requisicao);
        Requisicao AtualizarRequisicao(Requisicao requisicao);
        Requisicao ExcluirRequisicao(Requisicao requisicao);
    }
}
