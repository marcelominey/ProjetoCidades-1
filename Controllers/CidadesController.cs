using Microsoft.AspNetCore.Mvc;
using ProjetoCidades.Models;
using ProjetoCidades_master.Repositorio;

namespace ProjetoCidades.Controllers
{
    public class CidadesController: Controller
    {
        Cidade cidade = new Cidade();
        CidadeRep objCidadeRep = new CidadeRep();
        public IActionResult Index(){
            var lista = objCidadeRep.Listar();
            //não vou usar uma viewbag como usamos no projeto anterior

            return View(lista);
        }
        public IActionResult CidadesEstados(){
            //vai lá dentro da View procurar esse arquivo CidaedesEstados
            var lista = cidade.ListarCidades();
            return View(lista);
        }
        public IActionResult TodosOsDados(){
            var lista = cidade.ListarCidades();
            return View(lista);
        }

        public IActionResult Cadastrar(){
            return View();
        }
    }
}