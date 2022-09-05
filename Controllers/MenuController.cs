
using Microsoft.AspNetCore.Mvc;
using Product.Data;
using Models;


namespace MenuController;


[ApiController]
[Route("[Controller]")]

public class MenuController : ControllerBase
{

    private readonly DataContext _context;

    public MenuController(DataContext dataContext)
    {
        _context = dataContext;
    }

    /// <summary>
    /// Mostrar todos los menus
    /// </summary>
    /// <returns>Todos los menus</returns>
    /// <response code="200">Devuelve el listado de menus</response>
    /// <response code="500">Si hay algún error</response>
    [HttpGet]
    public ActionResult<List<MenuItem>> Get()
    {
        List<MenuItem> menu = _context.MenuItems.ToList();
        return   Ok(menu);
    }
    [HttpGet]
    [Route("{id:int}")]
    public ActionResult<MenuItem> Get(int id)
    {
    MenuItem MenuItem = _context.MenuItems.Find(id);
        return MenuItem == null? NotFound()
            : Ok(MenuItem);
    }

    /// <summary>
    /// añadir menus
    /// </summary>
    /// <returns>Todos los menus</returns>
    /// <response code="201">Se ha creado correctamente</response>
    /// <response code="500">Si hay algún error</response>
    [HttpPost]
    public ActionResult<MenuItem> Post([FromBody] MenuItem menu)
    {

        menu.id=0;
        _context.MenuItems.Add(menu);
        _context.SaveChanges();

        string resourceUrl = Request.Path.ToString() + "/" + menu.id;
        return Created(resourceUrl, menu);
    }
    /// <summary>
    ///Actualizar los menus
    /// </summary>
    /// <returns>Todos los menus</returns>
    /// <response code="201">Devuelve el listado de menus</response>
    /// <response code="500">Si hay algún error</response>
    [HttpPut("{id:int}")]
    public ActionResult<MenuItem> Update([FromBody] MenuItem menu, int id)
    {
        MenuItem menuItemToUpdate = _context.MenuItems.Find(id);
        if (menuItemToUpdate == null)
        {
            return NotFound("menu no encontrado");
        }
        menuItemToUpdate.establecimiento=menu.establecimiento;
        menuItemToUpdate.name=menu.name;
        menuItemToUpdate.precio=menu.precio;
        menuItemToUpdate.numeroStars=menu.numeroStars;

        _context.SaveChanges();
        string resourceUrl = Request.Path.ToString() + "/" + menuItemToUpdate.id;

        return Created(resourceUrl, menuItemToUpdate);
    }

    /// <summary>
    /// Eliminar menus seleccionados
    /// </summary>
    /// <returns>Todos los menus</returns>
    /// <response code="200">Se ha eliminado</response>
    /// <response code="500">Si hay algún error</response>
        [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        MenuItem menuItemToDelete = _context.MenuItems.Find(id);
        if (menuItemToDelete == null)
        {
            return NotFound("menu no encontrado");
        }
        _context.MenuItems.Remove(menuItemToDelete);
        _context.SaveChanges();
        return Ok(menuItemToDelete);
    }

}
