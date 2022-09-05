
using Microsoft.AspNetCore.Mvc;
using Models;
using Product.Data;

namespace CiudadesController;





[ApiController]
[Route("[Controller]")]

public class CiudadController : ControllerBase
{

    private readonly DataContext _context;

    public CiudadController(DataContext dataContext)
    {
        _context = dataContext;
    }

    /// <summary>
    /// Mostrar todas las ciudades
    /// </summary>
    /// <returns>Todos las ciudades</returns>
    /// <response code="200">Devuelve el listado ciudades</response>
    /// <response code="500">Si hay algún error</response>
    [HttpGet]
   public ActionResult<List<CiudadesItem>> Get()
    {
        List<CiudadesItem> ciudad = _context.CiudadItem.ToList();
        return   Ok(ciudad);
    }

    [HttpGet]
    [Route("{id:int}")]
    public ActionResult<CiudadesItem> Get(int id)
    {
    CiudadesItem CiudadItem = _context.CiudadItem.Find(id);
        return CiudadItem == null? NotFound()
            : Ok(CiudadItem);
    }


    /// <summary>
    /// añadir ciudades
    /// </summary>
    /// <returns>Todos las ciudades</returns>
    /// <response code="201">Se ha creado correctamente</response>
    /// <response code="500">Si hay algún error</response>
    [HttpPost]
    public ActionResult<CiudadesItem> Post([FromBody] CiudadesItem ciudad)
    {
 
        ciudad.id=0;
        _context.CiudadItem.Add(ciudad);
        _context.SaveChanges();

        string resourceUrl = Request.Path.ToString() + "/" + ciudad.id;
        return Created(resourceUrl, ciudad);
    }
    /// <summary>
    ///Actualizar las ciudades
    /// </summary>
    /// <returns>Todos las ciudades</returns>
    /// <response code="201">Devuelve el objeto modificado</response>
    /// <response code="404">No encontrado</response>
    /// <response code="500">Si hay algún error</response>
    [HttpPut("{id:int}")]
    public ActionResult<CiudadesItem> Update([FromBody] CiudadesItem ciudad, int id)
    {
        CiudadesItem ciudadItemToUpdate = _context.CiudadItem.Find(id);
        if (ciudadItemToUpdate == null)
        {
            return NotFound("ciudad no encontrado");
        }
        ciudadItemToUpdate.ciudad = ciudad.ciudad;
        ciudadItemToUpdate.establecimiento = ciudad.establecimiento;
        ciudadItemToUpdate.direccion = ciudad.direccion;
        ciudadItemToUpdate.fotografia = ciudad.fotografia;
        ciudadItemToUpdate.numeroStars = ciudad.numeroStars;

        _context.SaveChanges();
        string resourceUrl = Request.Path.ToString();

        return Created(resourceUrl, ciudadItemToUpdate);
    }
        /// <summary>
    /// Eliminar ciudades seleccionados
    /// </summary>
    /// <returns>Todos los ciudades</returns>
    /// <response code="200">Se ha eliminado</response>
    /// <response code="500">Si hay algún error</response>
        [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        CiudadesItem ciudadItemToDelete = _context.CiudadItem.Find(id);
        if (ciudadItemToDelete == null)
        {
            return NotFound("noticias no encontrado");
        }
        _context.CiudadItem.Remove(ciudadItemToDelete);
        _context.SaveChanges();
        return Ok();
    }

}
