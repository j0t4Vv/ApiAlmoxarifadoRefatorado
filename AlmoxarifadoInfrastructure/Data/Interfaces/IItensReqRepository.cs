using AlmoxarifadoDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data.Interfaces
{
    public interface IItensReqRepository
    {
        List<ItensReq> ObterTodosItensReq();
        ItensReq ObterItensReqPorId(int id);
        ItensReq CriarItensReq(ItensReq itensReq);
        ItensReq AtualizarItensReq(ItensReq itensReq);
        ItensReq ExcluirItensReq(ItensReq itensReq);
    }
}
