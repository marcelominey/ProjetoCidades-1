using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProjetoCidades.Models;
using ProjetoCidades.Repositorio;

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
            var lista = objCidadeRep.Listar();
            return View(lista);
        }
        public IActionResult TodosOsDados(){
            var lista = objCidadeRep.Listar();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Cadastrar(){
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar([Bind]Cidade cidade){
            objCidadeRep.Cadastrar(cidade);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Editar(int id){
            var lista = objCidadeRep.Listar().Where(x => x.Id == id).FirstOrDefault();
            return View(lista);

        }

        [HttpPost]
        public IActionResult Editar([Bind]Cidade cidade){
            objCidadeRep.Editar(cidade);
            return RedirectToAction("Index");
        }

        
        public IActionResult Excluir(int id){
            var lista = objCidadeRep.Excluir(id);
            return RedirectToAction("Index");
        }
    }
}