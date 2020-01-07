using appVentas.BusinessEntities;
using appVentas.BusinessLogic;
using appVentas.WebUI.ViewsModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace appVentas.WebUI.Controllers
{
    public class ProductoController : Controller
    {
        private ProductoBL productoBL;
        private LineaBL lineaBL;
        private GrupoBL grupoBL;

        public ProductoController()
        {
            productoBL = new ProductoBL();
            lineaBL = new LineaBL();
            grupoBL = new GrupoBL();
        }


        // GET: Producto
        public ActionResult Listado()
        {
            ProductoViewModel productoViewModel = new ProductoViewModel();
            List<GrupoViewModel> lstgrupoViewModel = new List<GrupoViewModel>();
            List<LineaViewModel> lstlineaViewModel = new List<LineaViewModel>();
            List<ProductoViewModel> lstproductoViewModel = new List<ProductoViewModel>();
            lstgrupoViewModel = grupoBL.GetAllGrupos().Select(x => new GrupoViewModel()
            {
                CodGrup = x.CodGrup,
                NomGrup = x.NomGrup
            }).ToList();

            lstlineaViewModel = lineaBL.GetAllLineas().Select(x => new LineaViewModel()
            {
                CodLin = x.CodLin,
                NomLin = x.NomLin
            }).ToList();

            lstproductoViewModel = productoBL.GetAllProductos().Select(x => new ProductoViewModel
            {
                CodProd = x.CodProd,
                NomProd = x.NomProd,
                CodGrup = x.CodGrup,
                CodLin = x.CodLin,
                Marca = x.Marca,
                CosPromC = x.CosPromC,
                PrecioVta = x.PrecioVta

            }).ToList();
            productoViewModel.lstproductoViewModel = lstproductoViewModel;
            productoViewModel.lstgrupoViewModel = lstgrupoViewModel;
            productoViewModel.lstlineaViewModel = lstlineaViewModel;
            return View(productoViewModel);
        }

        // GET: Producto
        public ActionResult Nuevo()
        {
            ProductoViewModel productoViewModel = new ProductoViewModel();
            List<GrupoViewModel> lstgrupoViewModel = new List<GrupoViewModel>();
            List<LineaViewModel> lstlineaViewModel = new List<LineaViewModel>();
            lstgrupoViewModel = grupoBL.GetAllGrupos().Select(x => new GrupoViewModel()
            {
                CodGrup = x.CodGrup,
                NomGrup = x.NomGrup
            }).ToList();

            lstlineaViewModel = lineaBL.GetAllLineas().Select(x => new LineaViewModel()
            {
                CodLin = x.CodLin,
                NomLin = x.NomLin
            }).ToList();

            productoViewModel.lstgrupoViewModel = lstgrupoViewModel;
            productoViewModel.lstlineaViewModel = lstlineaViewModel;
            return View(productoViewModel);
        }

        public ActionResult Guardar(ProductoViewModel viewModel)
        {
            ProductoBO productoBE = new ProductoBO()
            {
                CodProd = viewModel.CodProd,
                NomProd = viewModel.NomProd,
                CodGrup = viewModel.CodGrup,
                CodLin = viewModel.CodLin,
                Marca = viewModel.Marca,
                CosPromC = viewModel.CosPromC,
                PrecioVta = viewModel.PrecioVta
            };
            ViewBag.message = productoBL.InsertProducto(productoBE) ? "OK" : "";
            return RedirectToAction("Listado");
        }

        public ActionResult Editar(string idProducto)
        {
            ProductoViewModel productoViewModel = new ProductoViewModel();
            List<GrupoViewModel> lstgrupoViewModel = new List<GrupoViewModel>();
            List<LineaViewModel> lstlineaViewModel = new List<LineaViewModel>();
       
            lstgrupoViewModel = grupoBL.GetAllGrupos().Select(x => new GrupoViewModel()
            {
                CodGrup = x.CodGrup,
                NomGrup = x.NomGrup
            }).ToList();

            lstlineaViewModel = lineaBL.GetAllLineas().Select(x => new LineaViewModel()
            {
                CodLin = x.CodLin,
                NomLin = x.NomLin
            }).ToList();

            ProductoBO productoBO = productoBL.GetProductoById(new ProductoBO()
            {
                CodProd = idProducto
            });
            productoViewModel.CodProd = productoBO.CodProd;
            productoViewModel.NomProd = productoBO.NomProd;
            productoViewModel.CodGrup = productoBO.CodGrup;
            productoViewModel.CodLin = productoBO.CodLin;
            productoViewModel.Marca = productoBO.Marca;
            productoViewModel.CosPromC = productoBO.CosPromC;
            productoViewModel.PrecioVta = productoBO.PrecioVta; 
            productoViewModel.lstgrupoViewModel = lstgrupoViewModel;
            productoViewModel.lstlineaViewModel = lstlineaViewModel;
            return View(productoViewModel);
        }

        public ActionResult Actualizar(ProductoViewModel viewModel)
        {
            ProductoBO productoBE = new ProductoBO()
            {
                CodProd = viewModel.CodProd,
                NomProd = viewModel.NomProd,
                CodGrup = viewModel.CodGrup,
                CodLin = viewModel.CodLin,
                Marca = viewModel.Marca,
                CosPromC = viewModel.CosPromC,
                PrecioVta = viewModel.PrecioVta
            };
            ViewBag.message = productoBL.UpdateProducto(productoBE) ? "OK" : "";
            return RedirectToAction("Listado");
        }

        public ActionResult EliminarProducto(string idProducto)
        {
            ProductoBO productoBE = new ProductoBO
            {
                CodProd = idProducto
            };
            productoBL.DeleteProducto(productoBE);
            return RedirectToAction("Listado");
        }
    }
}