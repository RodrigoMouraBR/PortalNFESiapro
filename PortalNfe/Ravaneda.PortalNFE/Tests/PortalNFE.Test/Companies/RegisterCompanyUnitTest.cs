using Moq;
using PortalNFE.Core.Interfaces;
using PortalNFE.Register.Companies.Domain.Interfaces.Repositories;
using PortalNFE.Register.Companies.Domain.Models;
using PortalNFE.Register.Companies.Domain.Services;

namespace PortalNFE.Test.Companies
{
    public class RegisterCompanyUnitTest
    {

        #region CompanyRoot

        [Fact]
        public void DeveTerSucesso_DevidoEmpresaMatrizSerValida()
        {
            #region ARRANGE
            var companyRepository = new Mock<ICompanyRepository>();
            var notifier = new Mock<INotifier>();
            var companyRoot = new Company("Empresa A",
                                      "Empresa A",
                                      "08379414000185",
                                      string.Empty,
                                      "123456",
                                      "11945087936",
                                      "teste@teste.com.br");

            var companyService = new CompanyService(companyRepository.Object, notifier.Object);

            #endregion

            #region ACT
            _ = companyService.CompanyAdd(companyRoot);
            #endregion

            #region ASSERT
            Assert.True(companyRoot.CompanyIsValid());
            companyRepository.Verify(r => r.CompanyAdd(companyRoot), Times.Once);
            companyRepository.Verify(r => r.UnitOfWork.Commit(), Times.Never);
            #endregion

        }

        [Fact]
        public void DeveTerFalha_DevidoEmpresaMatrizSerInvalida_DocumentoCnpjNaoInformado()
        {
            #region ARRANGE
            var companyRepository = new Mock<ICompanyRepository>();
            var notifier = new Mock<INotifier>();

            var companyAffiliate = new Company("Empresa A",
                                     "Empresa A",
                                     string.Empty,//"74.153.620/0001-00",
                                     string.Empty, // "74.153.620/0001-00", //cnpj invalido
                                     "123456",
                                     "11945087936",
                                     "teste@teste.com.br");

            var companyService = new CompanyService(companyRepository.Object, notifier.Object);

            #endregion

            #region ACT
            _ = companyService.CompanyAdd(companyAffiliate);
            #endregion

            #region ASSERT
            Assert.False(companyAffiliate.CompanyIsValid());
            companyRepository.Verify(r => r.CompanyAdd(companyAffiliate), Times.Never);
            #endregion
        }

        [Fact]
        public void DeveTerFalha_DevidoEmpresaMatrizSerInvalida_DocumentoCnpjInvalido()
        {
            #region ARRANGE
            var companyRepository = new Mock<ICompanyRepository>();
            var notifier = new Mock<INotifier>();

            var companyAffiliate = new Company("Empresa A",
                                     "Empresa A",
                                     "74.153.620/0001-00",
                                     string.Empty, // "74.153.620/0001-00", //cnpj invalido
                                     "123456",
                                     "11945087936",
                                     "teste@teste.com.br");

            var companyService = new CompanyService(companyRepository.Object, notifier.Object);

            #endregion

            #region ACT
            _ = companyService.CompanyAdd(companyAffiliate);
            #endregion

            #region ASSERT
            Assert.False(companyAffiliate.CompanyIsValid());
            companyRepository.Verify(r => r.CompanyAdd(companyAffiliate), Times.Never);
            #endregion
        }

        [Fact]
        public void DeveTerFalha_DevidoEmpresaMatrizSerInvalida_EmailInvalido()
        {
            #region ARRANGE
            var companyRepository = new Mock<ICompanyRepository>();
            var notifier = new Mock<INotifier>();

            var companyAffiliate = new Company("Empresa A",
                                     "Empresa A",
                                     "79.880.825/0001-06",
                                     string.Empty,
                                     "123456",
                                     "11945087936",
                                     "tteste.com.br");

            var companyService = new CompanyService(companyRepository.Object, notifier.Object);

            #endregion

            #region ACT
            _ = companyService.CompanyAdd(companyAffiliate);
            #endregion

            #region ASSERT
            Assert.False(companyAffiliate.CompanyIsValid());
            companyRepository.Verify(r => r.CompanyAdd(companyAffiliate), Times.Never);
            #endregion
        }
        
        #endregion

        #region CompanyAffiliate

        [Fact]
        public void DeveTerSucesso_DevidoEmpresaFilialSerValida()
        {
            #region ARRANGE
            var companyRepository = new Mock<ICompanyRepository>();
            var notifier = new Mock<INotifier>();

            var companyAffiliate = new Company("Empresa A",
                                     "Empresa A",
                                     "08379414000185",
                                     "74.153.620/0001-05",
                                     "123456",
                                     "11945087936",
                                     "teste@teste.com.br");

            var companyService = new CompanyService(companyRepository.Object, notifier.Object);

            #endregion

            #region ACT
            _ = companyService.CompanyAdd(companyAffiliate);
            #endregion

            #region ASSERT
            Assert.True(companyAffiliate.CompanyIsValid());
            companyRepository.Verify(r => r.CompanyAdd(companyAffiliate), Times.Once);
            #endregion
        }

        [Fact]
        public void DeveTerFalha_DevidoEmpresaFilialSerInValida_DocumentoCnpjInvalido()
        {
            #region ARRANGE
            var companyRepository = new Mock<ICompanyRepository>();
            var notifier = new Mock<INotifier>();

            var companyAffiliate = new Company("Empresa A",
                                     "Empresa A",
                                     "08379414000185",
                                     "74.153.620/0001-00", //cnpj invalido
                                     "123456",
                                     "11945087936",
                                     "teste@teste.com.br");

            var companyService = new CompanyService(companyRepository.Object, notifier.Object);

            #endregion

            #region ACT
            _ = companyService.CompanyAdd(companyAffiliate);
            #endregion

            #region ASSERT
            Assert.False(companyAffiliate.CompanyIsValid());
            companyRepository.Verify(r => r.CompanyAdd(companyAffiliate), Times.Never);
            #endregion
        }

        [Fact]
        public void DeveTerFalha_DevidoEmpresaFilialSerInvalida_EmailInvalido()
        {
            #region ARRANGE
            var companyRepository = new Mock<ICompanyRepository>();
            var notifier = new Mock<INotifier>();

            var companyAffiliate = new Company("Empresa A",
                                     "Empresa A",
                                     "08379414000185",
                                     "74.153.620/0001-05",
                                     "123456",
                                     "11945087936",
                                     "teste.com.br");

            var companyService = new CompanyService(companyRepository.Object, notifier.Object);

            #endregion

            #region ACT
            _ = companyService.CompanyAdd(companyAffiliate);
            #endregion

            #region ASSERT
            Assert.False(companyAffiliate.CompanyIsValid());
            companyRepository.Verify(r => r.CompanyAdd(companyAffiliate), Times.Never);
            #endregion
        }

        #endregion
    }
}
