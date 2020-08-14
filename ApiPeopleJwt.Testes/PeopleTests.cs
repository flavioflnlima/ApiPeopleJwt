using ApiPeopleJwt.Controllers;
using ApiPeopleJwt.Models;
using ApiPeopleJwt.Validators;
using System;
using System.Threading.Tasks;
using Xunit;
using People = ApiPeopleJwt.Models.PeopleViewModel;

namespace ApiPeopleJwt.Testes
{
    public class PeopleTests
    {
        private PeopleValidator validator;

        public PeopleTests()
        {
            validator = new PeopleValidator();
        }
        [Fact]
        public void ValidateNameSuccess()
        {

            var validatepeople = new People()
            {
                Id = 2,
                Name = "nome teste",
                Document = "05765622391"

            };

            Assert.True(validator.Validate(validatepeople).IsValid);
        }

        [Fact]
        public void ValidateNameFailed()
        {

            var validatepeople = new People()
            {
                Id = 2,
                Name = "",
                Document = "05765622391"

            };

            Assert.True(validator.Validate(validatepeople).IsValid);
        }

        [Fact]
        public void ValidateDocumentSuccess()
        {

            var validatepeople = new People()
            {
                Id = 2,
                Name = "nome teste",
                Document = "05765622391"

            };

            Assert.True(validator.Validate(validatepeople).IsValid);
        }

        [Fact]
        public void ValidateDocumentFailed()
        {

            var validatepeople = new People()
            {
                Id = 2,
                Name = "nome teste",
                Document = "5622391"

            };

            Assert.True(validator.Validate(validatepeople).IsValid);
        }
    }
}
