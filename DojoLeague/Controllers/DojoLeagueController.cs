using Microsoft.EntityFrameworkCore;
using DojoLeague.Models;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace DojoLeague
{
    public class DojoLeagueController: Controller
    {
        private DojoLeagueContext _context;

        public DojoLeagueController(DojoLeagueContext context)
        {
            _context = context;
        }

        [HttpGet, Route("Dojos")]
        public IActionResult Dojos()
        {
            // List<Ninja> allNinjas = _context.ninjas.ToList();
            ViewBag.AllDojos = _context.dojos.ToList();

            return View("DojoForm");
        }

        [HttpPost, Route("Dojos")]
        public IActionResult Dojos(DojoViewModel model)
        {
            if(ModelState.IsValid)
            {
                Dojo NewDojo = new Dojo
                {
                    DojoName = model.DojoName,
                    Location = model.Location,
                    Info = model.Info
                };
                _context.dojos.Add(NewDojo);
                _context.SaveChanges();
                return RedirectToAction("Dojos");
            }
            ViewBag.AllDojos = _context.dojos.ToList();
            return View("DojoForm");
        }

        [HttpGet, Route("Ninjas")]
        public IActionResult Ninjas()
        {
            // List<Ninja> allNinjas = _context.ninjas.ToList();
            List<Ninja> allNinjas = _context.ninjas.Include(n => n.Dojo).ToList();
            List<Dojo> allDojos = _context.dojos.ToList();

            NinjaDojoBundle NinjaViewInfo = new NinjaDojoBundle
            {
                NinjaModel = new Ninja(),
                DojoList = allDojos,
                NinjaList = allNinjas
            };

            return View("NinjaForm", NinjaViewInfo);
        }

        [HttpPost, Route("Ninjas")]
        public IActionResult Ninjas(NinjaDojoBundle model)
        {
            
            if(ModelState.IsValid)
            {
                if (model.NinjaModel.MemberOfId == 0)
                {
                    model.NinjaModel.MemberOfId = null;
                }
                _context.ninjas.Add(model.NinjaModel);
                _context.SaveChanges();
                return RedirectToAction("Ninjas");
            }
            // other models (DojoList, NinjaList) come in as null when model bundle is passed in
            model.DojoList = _context.dojos.ToList();
            model.NinjaList = _context.ninjas.Include(n => n.Dojo).ToList();
            
            return View("NinjaForm", model);
        }

        [HttpGet, Route("Ninjas/{ninjaId}")]
        public IActionResult ShowNinja(int ninjaId)
        {
            Ninja ninja = _context.ninjas.Where(n => n.NinjaId == ninjaId).Include(selectedNinja => selectedNinja.Dojo).SingleOrDefault();
            return View("NinjaDetails", ninja);
        }

        [HttpGet, Route("Dojos/{dojoId}")]
        public IActionResult ShowDojo(int dojoId)
        {
            List<Dojo> dojoAndRogues = _context.dojos.Where(d => d.DojoId == dojoId || d.DojoId == 5)
                                                        .Include(selectedDojos => selectedDojos.NinjaCohort)
                                                        .ToList();
            
            return View("DojoDetails", dojoAndRogues);
        }

        [HttpGet, Route("Ninja/Banish/{ninjaId}/{dojoId}")]
        public IActionResult Banish(int ninjaId, int dojoId)
        {
            // Dojo dojoToRemove = _context.dojos.Where(d => d.DojoId == dojoId).Include(selectedDojo => selectedDojo.NinjaCohort).ThenInclude(n => n.NinjaId == ninjaId);
            // Dojo dojoToRemove = _context.dojos.Where(d => d.DojoId == dojoId).SingleOrDefault();
            // Ninja ninja = _context.ninjas.Where(n => n.NinjaId == ninjaId).Include(selectedNinja => selectedNinja.Dojo).SingleOrDefault().Remove(rouge => rouge.Dojo);

            

            // ninja.Dojo.DojoId = 5;
            // _context.SaveChanges();

            return RedirectToAction("ShowDojo", new {dojoId = dojoId});
        }
    }
}