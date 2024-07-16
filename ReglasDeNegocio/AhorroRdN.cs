using AutoMapper;
using Gastosv4.Dtos;
using Gastosv4.Entidades;
using Gastosv4.services;

namespace Gastosv4.ReglasDeNegocio
{
    public class AhorroRdN
    {
        private readonly DuckBankServicio _duckBankServicio;
        private readonly IMapper _mapper;

        public AhorroRdN(DuckBankServicio duckBankServicio, IMapper mapper)
        {
            _duckBankServicio = duckBankServicio;
            _mapper = mapper;
        }
        public async Task<List<AhorroDto>> ObtenerAsync(){
            List<Ahorro> ahorros;
            List<AhorroDto> dtos;

            ahorros = await _duckBankServicio.ObternerAsync();
            dtos = _mapper.Map<List<AhorroDto>>(ahorros);

            return dtos;
        }

        public async Task<string> AgregarAsync(AhorroDtoIn ahorro)
        {
            Ahorro ahorro1;
            int id;

            ahorro1 = _mapper.Map<Ahorro>(ahorro);
            id =  await _duckBankServicio.AgregarAsycn(ahorro1);

            return id.ToString();
        }
    }
}