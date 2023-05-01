namespace CleanArchMvc.Dominio.Account
{
    public interface ISeedUserRoleInitial
    {
        void SeedUsers(); //define os serviços para incluir usuários
        void SeedRoles(); //defini os perfis iniciais na base de dados
    }
}
