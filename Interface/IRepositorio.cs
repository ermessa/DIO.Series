using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIO.Series.Interface
{
    public interface IRepositorio <T>
    {
        List<T> Lista();
        T RetornaPorId(int Id);
        void Insere(T Entidade);
        void Exclui(int Id);
        void Atualiza(int Id, T Entidade);
        int ProximoId();
    }
}
