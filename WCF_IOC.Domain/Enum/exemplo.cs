namespace Cabesp.ServicosBenner.Domain.ValueObject
{
    public enum Ambiente : int
    {
        None = 0,

        Invalid = 1,

        // "1 - Benner Saúde 
        _1BennerSaúde = 2,

        // "2 - Benner Corporativo 
        _2BennerCorporativo = 4,

        // "3 - Web 
        _3Web = 8,

        // "4 - WorkFlow 
        _4WorkFlow = 16,

        // "5 - ePrimeCare 
        _5EPrimeCare = 32,

        // "6 - Orizon 
        _6Orizon = 64,
    }
}
