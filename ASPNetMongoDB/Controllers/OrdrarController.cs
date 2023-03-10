namespace ASPNetMongoDB.Controllers;

using ASPNetMongoDB.Database;
using ASPNetMongoDB.Models;
using Microsoft.AspNetCore.Mvc;

public class OrdrarController : Controller
{
    #region Private Fields

    //Deklarerar en privat fält av typen MongoDBContext
    private readonly MongoDBContext _mongoDBContext;

    #endregion Private Fields

    #region Public Constructors

    //Konstruktorn instansierar en ny MongoDBContext och sätter det som vårt privata fält
    public OrdrarController() => _mongoDBContext = new MongoDBContext();

    #endregion Public Constructors

    #region Public Methods

    //HttpGet metod för att 
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    //HttpPost metod för att skapa en ny katt, tar emot ett Cat-objekt från vyn
    [HttpPost]
    public IActionResult Create(Order order
        )
    {
        //Använder vår MongoDBContext för att skapa en ny katt i databasen
        _orderDBContext.CreateProduct(order);
        //Redirect till index-sidan efter att katten skapats
        return RedirectToAction("Index");
    }

    //HttpPost metod för att radera en befintlig katt, tar emot en id som parameter
    [HttpGet]
    public IActionResult Delete(string id)
    {
        //Använder vår MongoDBContext för att radera en katt i databasen
        _mongoDBContext.DeleteProduct(id);
        //Redirect till index-sidan efter att katten raderats
        return RedirectToAction("Index");
    }

    //HttpGet metod för att hämta detaljer för en katt, tar emot en id som parameter
    [HttpGet]
    public IActionResult Details(string id)
    {
        //Använder vår MongoDBContext för att hämta en katt med det angivna id:t
        var cat = _mongoDBContext.GetProduct(id);
        return View(cat);
    }

    //HttpGet metod för att redigera en befintlig katt, tar emot en id som parameter
    [HttpGet]
    public IActionResult Edit(string id)
    {
        //Använder vår MongoDBContext för att hämta en katt med det angivna id:t
        var product = _mongoDBContext.GetProduct(id);
        return View(product);
    }

    //HttpPost metod för att uppdatera en befintlig katt, tar emot ett Cat-objekt från vyn
    [HttpPost]
    public IActionResult Edit(Product product)
    {
        //Använder vår MongoDBContext för att uppdatera en katt i databasen
        _mongoDBContext.UpdateProduct(product.Id, product);
        //Redirect till index-sidan efter att katten uppdaterats
        return RedirectToAction("Index");
    }

    // HttpGet-metod som hämtar alla katter från databasen och returnerar dem till vyn.
    [HttpGet]
    public IActionResult Index()
    {
        //Använder vår MongoDBContext för att hämta alla katter
        var product = _mongoDBContext.GetAllProducts();
        return View(product);
    }

    #endregion Public Methods
}