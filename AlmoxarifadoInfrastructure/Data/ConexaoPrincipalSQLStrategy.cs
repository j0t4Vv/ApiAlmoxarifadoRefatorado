using AlmoxarifadoInfrastructure.Data.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data
{
    public class ConexaoPrincipalSQLStrategy : IDatabaseStrategy
    {
        private readonly IConfiguration _configuration;

        public ConexaoPrincipalSQLStrategy(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnectionString()
        {
            return _configuration.GetConnectionString("ConexaoPrincipalSQL");
        }
    }

    public class ConexaoReplicaSQLStrategy : IDatabaseStrategy
    {
        private readonly IConfiguration _configuration;

        public ConexaoReplicaSQLStrategy(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnectionString()
        {
            return _configuration.GetConnectionString("ConexaoReplicaSQL");
        }
    }

}
