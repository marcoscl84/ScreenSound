using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco;

internal abstract class DAL<T>
{
    public abstract IEnumerable<T> Listar();
    public abstract void Adicionar(T objeto);
    public abstract void Atualizar(Artista artista);
    public abstract void Deletar(T objeto);
}
