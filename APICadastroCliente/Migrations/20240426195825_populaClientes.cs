using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICadastroCliente.Migrations
{
    public partial class populaClientes : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Clientes(Nome,Cpf,Rg,DataNascimento,Ocupacao,Email,DataCadastro,EnderecoId) " +
                "Values('Iago Lucas', '06254536520', '179222242', '2000-06-10', 'Desenvolvedor', 'iago@hotmail.com'," + DateTime.Now.ToString("yyyy-MM-dd") + ",1)");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("Delete from Clientes");
        }
    }
}
