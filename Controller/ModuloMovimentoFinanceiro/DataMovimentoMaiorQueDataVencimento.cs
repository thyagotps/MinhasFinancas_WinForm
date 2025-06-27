using System.ComponentModel.DataAnnotations;

namespace Controller.ModuloMovimentoFinanceiro
{
    public class DataMovimentoMaiorQueDataVencimento : ValidationAttribute
    {
        private readonly string _outraData;

        public DataMovimentoMaiorQueDataVencimento(string outraData)
        {
            _outraData = outraData;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var propriedadeComparada = validationContext.ObjectType.GetProperty(_outraData);
            if (propriedadeComparada == null)
            {
                return new ValidationResult($"Propriedade {_outraData} não encontrada.");
            }

            var dataVencimento = (DateTime?)value;
            var dataMovimento = (DateTime?)propriedadeComparada.GetValue(validationContext.ObjectInstance);

            if (dataVencimento.Value == new DateTime(1900, 1, 1)) return ValidationResult.Success;

            if (dataVencimento.HasValue
                && dataMovimento.HasValue
                && dataMovimento.Value >= dataVencimento.Value)
            {
                IEnumerable<string> members = new List<string> { "DataVencimento" };
                return new ValidationResult($"Menor que movimento!", members);
            }

            return ValidationResult.Success;
        }


    }
}
