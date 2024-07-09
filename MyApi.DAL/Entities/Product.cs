namespace MyApi.DAL.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
/*
CREATE TABLE Products (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    Price DECIMAL(18, 2) NOT NULL,
    RowVersion BINARY(8) NOT NULL DEFAULT 0,
    CONSTRAINT CHK_Price CHECK (Price >= 0)
);
*/