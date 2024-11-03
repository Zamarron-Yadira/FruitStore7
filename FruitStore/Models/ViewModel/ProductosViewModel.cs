namespace FruitStore.Models.ViewModel
{
    //Agregacion de clases:
    public class ProductosViewModel
    {
        public string Categoria { get; set; } = null!;
        public IEnumerable<ProductosModel> Productos { get; set; } = null!;
    }

    public class ProductosModel
    {
        public int Id { get; set; }
        public string NombreProd { get; set; } = null!;
        public decimal Precio { get; set; }
    }
}
