using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Modelo.Domain.Entities;
using Modelo.Infra.Data.Context;
using Modelo.Service.Services;

namespace Modelo.UI.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly BaseService<Usuario> _baseService;
        private readonly BaseService<Sexo> _sexoService;

        public UsuariosController(SQLServerContext sqlServerContext)
        {
            _baseService = new BaseService<Usuario>(sqlServerContext);
            _sexoService = new BaseService<Sexo>(sqlServerContext);
        }

        // GET: Usuarios
        public IActionResult Index(string searchName, bool searchAtivo = true)
        {
            var usuariosList = _baseService.Get().Where(x => x.Ativo == searchAtivo);

            if (!string.IsNullOrEmpty(searchName))
                usuariosList = usuariosList.Where(x => x.Nome.Contains(searchName)).ToList();

            return View(usuariosList);
        }

        // GET: Usuarios/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = _baseService.Get((int)id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> items = new SelectList(_sexoService.Get(), "Id", "Descricao");
            ViewBag.SexoId = items;

            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Nome,DataNascimento,Email,Senha,SexoId,Id,Ativo,Created,Updated")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                //ERRO não corrigido.
                usuario.Sexo = _sexoService.Get(1);
                usuario.Created = DateTime.Now;

                _baseService.Post(usuario);

                ViewData["Message"] = $"Usuário {usuario.Nome} criado com sucesso!";

                return RedirectToAction(nameof(Index));
            }

            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = _baseService.Get((int)id);
            if (usuario == null)
            {
                return NotFound();
            }

            IEnumerable<SelectListItem> items = new SelectList(_sexoService.Get(), "Id", "Descricao");
            ViewBag.SexoId = items;

            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Nome,DataNascimento,Email,Senha,Sexo,Id,Ativo,Created,Updated")] Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                //ERRO não corrigido.
                usuario.Sexo = _sexoService.Get(1);
                usuario.Updated = DateTime.Now;

                _baseService.Put(usuario);

                ViewData["Message"] = $"Usuário {usuario.Nome} atualizado com sucesso!";

                return RedirectToAction(nameof(Index));
            }

            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = _baseService.Get((int)id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _baseService.Delete((int)id);

            return RedirectToAction(nameof(Index));
        }
    }
}
